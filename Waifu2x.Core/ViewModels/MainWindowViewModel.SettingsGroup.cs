using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Waifu2x.Core.Services;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel
{
    /// <summary>
    /// Upscale factors
    /// </summary>
    public static ReadOnlyCollection<int> ScaleFactors { get; } = new([1, 2, 4, 8, 16, 32]);

    /// <summary>
    /// Denoise levels labels
    /// </summary>
    public static ReadOnlyCollection<string> DenoiseLevels { get; } = new(["None", "Low", "Medium", "High"]);

    /// <summary>
    /// Upscale output formats
    /// </summary>
    public static ReadOnlyCollection<UpscaleFormat> OutputFormats { get; } = new([UpscaleFormat.PNG, UpscaleFormat.JPG, UpscaleFormat.WEBP]);

    [ObservableProperty]
    private int scale = 2;
    [ObservableProperty]
    private int denoiseLevel;
    [ObservableProperty]
    private UpscaleFormat format = UpscaleFormat.PNG;
    [ObservableProperty]
    private int decodeThreads = 2;
    [ObservableProperty]
    private int upscaleThreads = 2;
    [ObservableProperty]
    private int encodeThreads = 2;
    [ObservableProperty]
    private bool grayscale;
    [ObservableProperty]
    private bool ttaMode;
}
