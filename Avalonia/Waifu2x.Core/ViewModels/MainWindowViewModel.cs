using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using Waifu2x.Core.Services;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel(IStorageService storageService, IDialogService dialogService) : ViewModelBase
{
    public ObservableCollection<string> Log { get; } = [];

    public MainWindowViewModel() : this(null!, null!) { }

    [RelayCommand(CanExecute = nameof(CanRunWaifu))]
    private void RunWaifu()
    {
        Debug.WriteLine(this.Scale);
        Debug.WriteLine(this.DenoiseLevel);
        Debug.WriteLine(this.Format);
    }

    private bool CanRunWaifu() => !string.IsNullOrWhiteSpace(this.InputPath)
                               && !string.IsNullOrWhiteSpace(this.OutputSuffix);
}
