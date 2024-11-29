using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel(FileGroupViewModel fileGroupViewModel, SettingsGroupViewModel settingsGroupViewModel) : ViewModelBase
{
    public ObservableCollection<string> Log { get; } = [];

    public FileGroupViewModel FileGroupViewModel { get; } = fileGroupViewModel;

    public SettingsGroupViewModel SettingsGroupViewModel { get; } = settingsGroupViewModel;

    public MainWindowViewModel() : this(new FileGroupViewModel(), new SettingsGroupViewModel()) { }

    [RelayCommand]
    private void RunWaifu()
    {
        Debug.WriteLine((object?)this.SettingsGroupViewModel.Scale);
        Debug.WriteLine((object?)this.SettingsGroupViewModel.DenoiseLevel);
        Debug.WriteLine((string?)this.SettingsGroupViewModel.Format);
    }
}
