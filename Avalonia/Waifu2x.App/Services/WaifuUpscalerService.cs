using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
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
        using Process waifuProcess = new();
        waifuProcess.EnableRaisingEvents = true;
        waifuProcess.StartInfo = new ProcessStartInfo
        {
            FileName        = Path.GetFullPath(@"dist\waifu2x-ncnn-vulkan.exe"),
            Arguments       = options.GetArguments(),
            UseShellExecute = false,
        };

        waifuProcess.Start();
        await waifuProcess.WaitForExitAsync();
        waifuProcess.Close();

        if (options.ConvertGrayscale)
        {
            await RunGrayscaleConversion(options);
        }
    }

    private async Task RunGrayscaleConversion(UpscaleOptions options)
    {
        bool isFolder = (File.GetAttributes(options.OutputPath) & FileAttributes.Directory) is not 0;
        if (!isFolder)
        {
            await ConvertToGrayAsync(new FileInfo(options.OutputPath), options.Format);
            return;
        }

        DirectoryInfo outputDir = new(options.OutputPath);
        FileInfo[] files = outputDir.GetFiles($"*.{options.Format}");
        await Parallel.ForEachAsync(files, (f, _) => ConvertToGrayAsync(f, options.Format));
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
        return ValueTask.CompletedTask;
    }
}
