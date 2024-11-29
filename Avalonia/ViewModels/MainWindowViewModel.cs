using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace Waifu2x.ViewModels;

public partial class MainWindowViewModel(FileGroupViewModel fileGroupViewModel, SettingsGroupViewModel settingsGroupViewModel) : ViewModelBase
{
    public ObservableCollection<string> Log { get; } = [];

    public FileGroupViewModel FileGroupViewModel { get; } = fileGroupViewModel;

    public SettingsGroupViewModel SettingsGroupViewModel { get; } = settingsGroupViewModel;

    public MainWindowViewModel() : this(new FileGroupViewModel(), new SettingsGroupViewModel()) { }

    [RelayCommand]
    private void RunWaifu()
    {
        Debug.WriteLine(this.SettingsGroupViewModel.Scale);
        Debug.WriteLine(this.SettingsGroupViewModel.DenoiseLevel);
        Debug.WriteLine(this.SettingsGroupViewModel.Format);
    }
}
