
using System.Collections.ObjectModel;

namespace Waifu2x.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ReadOnlyCollection<string> ScaleFactors { get; } = new(["1", "2", "4", "8", "16", "32"]);

    public ReadOnlyCollection<string> DenoiseLevels { get; } = new(["0", "1", "2", "3"]);

    public ReadOnlyCollection<string> OutputFormats { get; } = new(["PNG", "JPG", "WEBP"]);

    public ObservableCollection<string> Log { get; } = [];
}
