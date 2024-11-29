namespace Waifu2x.Core.Services;

/// <summary>
/// Image upscaler service
/// </summary>
public interface IUpscalerService
{
    /// <summary>
    /// Start the upscaling process with the provided options
    /// </summary>
    /// <param name="options">Upscaling options</param>
    /// <returns>The upscaling process Task</returns>
    Task RunUpscaler(UpscaleOptions options);
}
