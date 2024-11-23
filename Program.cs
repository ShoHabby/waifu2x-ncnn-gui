using ImageMagick;

namespace Waifu2x;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        MagickNET.Initialize();
        Application.Run(new WaifuForm());
    }
}