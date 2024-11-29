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

    /// <inheritdoc cref="IUpscalerService.RunUpscaler"/>
    public async Task RunUpscaler(UpscaleOptions options)
    {
        Log("Beginning Waifu upscale process...");

        // Create process
        Process waifuProcess = new()
        {
            EnableRaisingEvents = true,
            StartInfo = new ProcessStartInfo
            {
                FileName               = Path.GetFullPath(@"dist\waifu2x-ncnn-vulkan.exe"),
                Arguments              = GetArguments(options),
                UseShellExecute        = false,
            }
        };

        waifuProcess.Start();
        await waifuProcess.WaitForExitAsync();
        waifuProcess.Close();
        waifuProcess.Dispose();

        Log("Waifu process completed");

        if (options.ConvertGrayscale)
        {
            await RunGrayscaleConversion(options);
        }
    }

    /// <summary>
    /// Starts the grayscale conversion operation
    /// </summary>
    /// <param name="options">The upscaling options</param>
    private async Task RunGrayscaleConversion(UpscaleOptions options)
    {
        Log("Converting images to grayscale...");

        // Check if we are targeting a folder or file
        bool isFolder = (File.GetAttributes(options.OutputPath) & FileAttributes.Directory) is not 0;
        if (isFolder)
        {
            DirectoryInfo outputDir = new(options.OutputPath);
            FileInfo[] files = outputDir.GetFiles($"*.{options.Format}");
            StrongReferenceMessenger.Default.Send(new ReportProgressMessage(files.Length));
            await Parallel.ForEachAsync(files, (f, _) => ConvertToGrayAsync(f, options.Format));
        }
        else
        {
            await ConvertToGrayAsync(new FileInfo(options.OutputPath), options.Format);
        }

        Log("Grayscale conversion completed");
    }

    /// <summary>
    /// Converts an image to Grayscale
    /// </summary>
    /// <param name="file">File to convert</param>
    /// <param name="format">Output file format</param>
    /// <returns>The conversion task</returns>
    /// <exception cref="UnreachableException">If <paramref name="format"/> is unknown</exception>
    private static ValueTask ConvertToGrayAsync(FileInfo file, UpscaleFormat format)
    {
        // Load image and set format
        using MagickImage image = new(file);
        image.Grayscale(PixelIntensityMethod.Average);
        image.SetBitDepth(8u);
        image.Format = format switch
        {
            UpscaleFormat.PNG  => MagickFormat.Png8,
            UpscaleFormat.JPG  => MagickFormat.Jpg,
            UpscaleFormat.WEBP => MagickFormat.WebP,
            _                  => throw new UnreachableException("Invalid format")
        };
        image.Settings.Compression = CompressionMethod.NoCompression;

        // Convert to grayscale table
        image.Quantize(GrayscaleSettings);
        image.Write(file);

        Log(file.FullName + " converted to grayscale");
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
