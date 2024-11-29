using System;
using Avalonia;
using ImageMagick;

namespace Waifu2x;

/// <summary>
/// Entry point
/// </summary>
internal static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    private static void Main(string[] args)
    {
        MagickNET.Initialize();
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
                                                              .UsePlatformDetect()
                                                              .WithInterFont()
                                                              .LogToTrace();
}
