using System.Text;

namespace Waifu2x.Core.Services;

public readonly record struct ThreadOptions(int DecodeThreads, int UpscaleThreads, int EncodeThreads)
{
    public string GetArgument() => $"-j {this.DecodeThreads}:{this.UpscaleThreads}:{this.EncodeThreads}";
}

public readonly record struct UpscaleOptions(string InputPath, string OutputPath, int ScaleFactor, int DenoiseLevel, string Format, ThreadOptions ThreadOptions, bool ConvertGrayscale, bool TTAMode)
{
    private static readonly StringBuilder ArgumentBuilder = new();

    public string GetArguments()
    {
        ArgumentBuilder.Append("-v ");
        ArgumentBuilder.Append($"-i \"{this.InputPath}\" ");
        ArgumentBuilder.Append($"-o \"{this.OutputPath}\" ");
        ArgumentBuilder.Append($"-s {this.ScaleFactor} ");
        ArgumentBuilder.Append($"-n {this.DenoiseLevel} ");
        ArgumentBuilder.Append($"-f {this.Format.ToLowerInvariant()} ");
        ArgumentBuilder.Append(this.ThreadOptions.GetArgument());

        if (this.TTAMode)
        {
            ArgumentBuilder.Append(" -x");
        }

        string argument = ArgumentBuilder.ToString();
        ArgumentBuilder.Clear();
        return argument;
    }
}
