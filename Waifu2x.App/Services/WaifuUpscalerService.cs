using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using ImageMagick;
using Waifu2x.Core.Messages;
using Waifu2x.Core.Services;

namespace Waifu2x.Services;

/// <summary>
/// Waifu2x upscaler service
/// </summary>
public class WaifuUpscalerService : IUpscalerService
{
    /// <summary>
    /// Grayscale conversion settings
    /// </summary>
    private static readonly QuantizeSettings GrayscaleSettings = new()
    {
        Colors       = 256u,
        ColorSpace   = ColorSpace.Gray,
        DitherMethod = DitherMethod.No
    };
    /// <summary>
    /// Program argument StringBuilder
    /// </summary>
    private static readonly StringBuilder ArgumentBuilder = new();


    /// <summary>
    /// Folder name in which third party tools are distributed
    /// </summary>
    private const string DISTRIBUTION_FOLDER = "dist";
    /// <summary>
    /// Waifu upscaler executable file name
    /// </summary>
    private const string EXECUTABLE_NAME = "waifu2x-ncnn-vulkan";
    /// <summary>
    /// Path to the external upscaler tool
    /// </summary>
    private static readonly string ExternalToolPath = Path.Join(DISTRIBUTION_FOLDER, EXECUTABLE_NAME) + (OperatingSystem.IsWindows() ? ".exe" : string.Empty);

    /// <inheritdoc cref="IUpscalerService.RunUpscaler"/>
    public async Task RunUpscaler(UpscaleOptions options)
    {
        Log("Beginning Waifu upscale process...");

        // Create process
        Process waifuProcess = new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName        = Path.GetFullPath(ExternalToolPath),
                Arguments       = GetArguments(options),
                UseShellExecute = false,
            }
        };

        waifuProcess.Start();
        await waifuProcess.WaitForExitAsync();
        waifuProcess.Close();
        waifuProcess.Dispose();

        Log("Waifu process completed");

        await RunFileProcessing(options);
    }

    /// <summary>
    /// Starts the grayscale conversion operation
    /// </summary>
    /// <param name="options">The upscaling options</param>
    private static async Task RunFileProcessing(UpscaleOptions options)
    {
        Log("Processing upscaled files...");

        // Check if we are targeting a folder or file
        bool isFolder = (File.GetAttributes(options.OutputPath) & FileAttributes.Directory) is not 0;
        if (isFolder)
        {
            DirectoryInfo outputDir = new(options.OutputPath);
            FileInfo[] files = outputDir.GetFiles($"*.{options.Format}");
            StrongReferenceMessenger.Default.Send(new ReportProgressMessage(files.Length));
            await Parallel.ForEachAsync(files, (f, _) => ProcessFileAsync(f, options));
        }
        else
        {
            await ProcessFileAsync(new FileInfo(options.OutputPath), options);
        }

        Log("All files processed");
    }

    /// <summary>
    /// Converts an image to Grayscale
    /// </summary>
    /// <param name="file">File to convert</param>
    /// <param name="options">File options</param>
    /// <returns>The conversion task</returns>
    /// <exception cref="UnreachableException">If the options format is unknown</exception>
    private static ValueTask ProcessFileAsync(FileInfo file, in UpscaleOptions options)
    {
        // Load image and set format
        using MagickImage image = new(file);
        image.Format = options.Format switch
        {
            UpscaleFormat.PNG when options.ConvertGrayscale               => MagickFormat.Png8,
            UpscaleFormat.PNG when options.RemoveAlpha || !image.HasAlpha => MagickFormat.Png24,
            UpscaleFormat.PNG                                             => MagickFormat.Png32,
            UpscaleFormat.JPG                                             => MagickFormat.Jpg,
            UpscaleFormat.WEBP                                            => MagickFormat.WebP,
            _                                                             => throw new UnreachableException("Invalid format")
        };

        // Set PPI
        image.Density = new Density(options.PPI, DensityUnit.PixelsPerInch);

        // Remove alpha as needed
        if (options.RemoveAlpha && image.HasAlpha)
        {
            // Force set background to black
            image.BackgroundColor = MagickColors.Black;
            image.Alpha(AlphaOption.Remove);
        }

        // Convert to grayscale if needed
        if (options.ConvertGrayscale)
        {
            // Set grayscale settings
            image.Grayscale(PixelIntensityMethod.Average);
            image.SetBitDepth(8u);
            image.Settings.Compression = CompressionMethod.NoCompression;

            // Quantize to grayscale
            image.Quantize(GrayscaleSettings);
        }

        // Save image
        image.Write(file);

        // Terminate and report
        Log(file.FullName + " processed");
        StrongReferenceMessenger.Default.Send(new ReportProgressMessage());
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Sends a log message
    /// </summary>
    /// <param name="message">Message to log</param>
    private static void Log(string message) => StrongReferenceMessenger.Default.Send(new LogMessage(message));

    /// <summary>
    /// Obtains the arguments list for the given options
    /// </summary>
    /// <param name="options">Upscaling options</param>
    /// <returns>The generated argument string</returns>
    private static string GetArguments(in UpscaleOptions options)
    {
        ArgumentBuilder.Append($"-i \"{options.InputPath}\" ");
        ArgumentBuilder.Append($"-o \"{options.OutputPath}\" ");
        ArgumentBuilder.Append($"-s {options.ScaleFactor} ");
        ArgumentBuilder.Append($"-n {options.DenoiseLevel} ");
        ArgumentBuilder.Append($"-f {options.Format.ToString().ToLowerInvariant()} ");
        ArgumentBuilder.Append($"-j {options.ThreadOptions.DecodeThreads}:{options.ThreadOptions.UpscaleThreads}:{options.ThreadOptions.EncodeThreads} ");
        ArgumentBuilder.Append("-v");

        // Optional
        if (options.TTAMode)
        {
            ArgumentBuilder.Append(" -x");
        }

        string argument = ArgumentBuilder.ToString();
        ArgumentBuilder.Clear();
        return argument;
    }
}
