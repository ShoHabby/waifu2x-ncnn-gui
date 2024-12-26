namespace Waifu2x.Core.Services;

/// <summary>
/// Upscale output file format
/// </summary>
public enum UpscaleFormat
{
    PNG,
    JPG,
    WEBP
}

/// <summary>
/// Upscaler GPU thread options
/// </summary>
/// <param name="DecodeThreads">Amount of image decoder GPU threads</param>
/// <param name="UpscaleThreads">Amount of image upscaler GPU threads</param>
/// <param name="EncodeThreads">Amount of image encoder GPU threads</param>
public readonly record struct ThreadOptions(int DecodeThreads, int UpscaleThreads, int EncodeThreads);

/// <summary>
/// Upscaler options
/// </summary>
/// <param name="InputPath">Input file or folder</param>
/// <param name="OutputPath">Output file or folder</param>
/// <param name="ScaleFactor">Upscaling factor</param>
/// <param name="DenoiseLevel">Denoising level</param>
/// <param name="Format">Output file format</param>
/// <param name="ThreadOptions">GPU Threads option</param>
/// <param name="PPI">File PPI</param>
/// <param name="ConvertGrayscale">If the files should be converted to grayscale</param>
/// <param name="TTAMode">If TTA mode should be activated</param>
/// <param name="RemoveAlpha">If the file's alpha channel should be stripped</param>
public readonly record struct UpscaleOptions(string InputPath, string OutputPath, int ScaleFactor, int DenoiseLevel, UpscaleFormat Format, ThreadOptions ThreadOptions, int PPI, bool ConvertGrayscale, bool TTAMode, bool RemoveAlpha);
