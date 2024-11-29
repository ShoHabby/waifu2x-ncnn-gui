using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using ImageMagick;
using Waifu2x.Core.Messages;
using Waifu2x.Core.Services;

namespace Waifu2x.Services;

public class WaifuUpscalerService : IUpscalerService
{
    private static readonly QuantizeSettings GrayscaleSettings = new()
    {
        Colors     = 256,
        ColorSpace = ColorSpace.Gray,
        DitherMethod = DitherMethod.No
    };

    public async Task RunUpscaler(UpscaleOptions options)
    {
        Log("Beginning Waifu upscale process...");

        using Process waifuProcess = new();
        waifuProcess.EnableRaisingEvents = true;
        waifuProcess.StartInfo = new ProcessStartInfo
        {
            FileName        = Path.GetFullPath(@"dist\waifu2x-ncnn-vulkan.exe"),
            Arguments       = options.GetArguments(),
            UseShellExecute = false
        };

        waifuProcess.Start();
        await waifuProcess.WaitForExitAsync();
        waifuProcess.Close();

        Log("Waifu process completed");

        if (options.ConvertGrayscale)
        {
            await RunGrayscaleConversion(options);
        }
    }

    private async Task RunGrayscaleConversion(UpscaleOptions options)
    {
        Log("Converting images to grayscale...");

        bool isFolder = (File.GetAttributes(options.OutputPath) & FileAttributes.Directory) is not 0;
        if (isFolder)
        {
            DirectoryInfo outputDir = new(options.OutputPath);
            FileInfo[] files = outputDir.GetFiles($"*.{options.Format}");
            await Parallel.ForEachAsync(files, (f, _) => ConvertToGrayAsync(f, options.Format));
        }
        else
        {
            await ConvertToGrayAsync(new FileInfo(options.OutputPath), options.Format);
        }

        Log("Grayscale conversion completed");
    }

    private ValueTask ConvertToGrayAsync(FileInfo file, string format)
    {
        using MagickImage image = new(file);
        image.Grayscale(PixelIntensityMethod.Average);
        image.SetBitDepth(8u);
        image.Format = format.ToLowerInvariant() switch
        {
            "jpg"  => MagickFormat.Jpg,
            "png"  => MagickFormat.Png8,
            "webp" => MagickFormat.WebP,
            _      => throw new UnreachableException("Invalid format")
        };
        image.Settings.Compression = CompressionMethod.NoCompression;
        image.Quantize(GrayscaleSettings);
        image.Write(file);

        Log(file.FullName + " converted to grayscale");
        return ValueTask.CompletedTask;
    }

    private static void Log(string message) => StrongReferenceMessenger.Default.Send(new LogMessage(message));
}
