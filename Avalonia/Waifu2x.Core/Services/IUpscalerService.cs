using System.Text;

namespace Waifu2x.Core.Services;

public interface IUpscalerService
{
    Task RunUpscaler(UpscaleOptions options);
}
