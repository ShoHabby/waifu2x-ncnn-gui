using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel
{
    public static ReadOnlyCollection<int> ScaleFactors { get; } = new([1, 2, 4, 8, 16, 32]);

    public static ReadOnlyCollection<string> DenoiseLevels { get; } = new(["None", "Low", "Medium", "High"]);

    public static ReadOnlyCollection<string> OutputFormats { get; } = new(["PNG", "JPG", "WEBP"]);

    [ObservableProperty]
    private int scale = 2;
    [ObservableProperty]
    private int denoiseLevel;
    [ObservableProperty]
    private string format = "PNG";
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
