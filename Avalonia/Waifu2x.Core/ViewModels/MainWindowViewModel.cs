using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<string> Log { get; } = [];

    public FileGroupViewModel FileGroupViewModel { get; }

    public SettingsGroupViewModel SettingsGroupViewModel { get; }

    public MainWindowViewModel() : this(new FileGroupViewModel(), new SettingsGroupViewModel()) { }

    /// <inheritdoc/>
    public MainWindowViewModel(FileGroupViewModel fileGroupViewModel, SettingsGroupViewModel settingsGroupViewModel)
    {
        this.FileGroupViewModel     = fileGroupViewModel;
        this.SettingsGroupViewModel = settingsGroupViewModel;

        this.FileGroupViewModel.MainWindow      =  this;
        this.FileGroupViewModel.PropertyChanged += FileGroupViewModelOnPropertyChanged;
    }

    private void FileGroupViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(this.FileGroupViewModel.InputPath) or nameof(this.FileGroupViewModel.OutputSuffix))
        {
            this.RunWaifuCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand(CanExecute = nameof(CanRunWaifu))]
    private void RunWaifu()
    {
        Debug.WriteLine(this.SettingsGroupViewModel.Scale);
        Debug.WriteLine(this.SettingsGroupViewModel.DenoiseLevel);
        Debug.WriteLine(this.SettingsGroupViewModel.Format);
    }

    private bool CanRunWaifu() => !string.IsNullOrWhiteSpace(this.FileGroupViewModel.InputPath)
                               && !string.IsNullOrWhiteSpace(this.FileGroupViewModel.OutputSuffix);
}
