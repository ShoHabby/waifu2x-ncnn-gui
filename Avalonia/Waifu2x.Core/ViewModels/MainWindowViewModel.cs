using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Waifu2x.Core.Services;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel(IStorageService storageService, IDialogService dialogService) : ViewModelBase
{
    public ObservableCollection<string> Log { get; } = [];

    public MainWindowViewModel() : this(null!, null!) { }

    [ObservableProperty]
    private bool isEnabled = true;

    /// <summary>
    /// Validates the input/output paths
    /// </summary>
    /// <typeparam name="T">Type of IO (folder/file)</typeparam>
    /// <param name="input">Input path</param>
    /// <param name="output">Output path</param>
    /// <returns><see langword="true"/> if the paths are valid, otherwise <see langword="false"/></returns>
    private async Task<bool> ValidateIO<T>(T input, T output) where T : FileSystemInfo
    {
        string type = input switch
        {
            FileInfo      => "file",
            DirectoryInfo => "folder",
            _             => "object"
        };

        if (!input.Exists)
        {
            await dialogService.ShowMessageBoxAsync(this, $"The selected input {type} does not exist.", "Error", icon: MessageBoxImage.Error);
            return false;
        }

        if (output.Exists)
        {
            bool? result = await dialogService.ShowMessageBoxAsync(this, $"The output {type} already exists, overwrite file(s)?", "Warning",
                                                                   button: MessageBoxButton.OkCancel, MessageBoxImage.Error);
            return result is not null;
        }

        if (output is DirectoryInfo outputDir)
        {
            outputDir.Create();
        }

        return true;
    }

    private void AddLog(string? message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            this.Log.Add(message);
        }
    }

    private bool CanRequestRun() => !string.IsNullOrWhiteSpace(this.InputPath)
                               && !string.IsNullOrWhiteSpace(this.OutputSuffix);

    [RelayCommand(CanExecute = nameof(CanRequestRun))]
    private async Task RunRequested()
    {
        FileAttributes attributes = File.GetAttributes(this.InputPath!);
        bool isDir = (attributes & FileAttributes.Directory) is not 0;
        if (this.IsFolder != isDir)
        {
            await dialogService.ShowMessageBoxAsync(this, $"The selected input is not a {(this.IsFolder ? "Folder" : "File")}.", "Error", icon: MessageBoxImage.Error);
            return;
        }

        try
        {
            bool valid = this.IsFolder ? await ValidateIO(new DirectoryInfo(this.InputPath!), new DirectoryInfo(this.OutputPath))
                                       : await ValidateIO(new FileInfo(this.InputPath!), new FileInfo(this.OutputPath));
            if (valid)
            {
                await RunWaifu();
            }
        }
        catch (ArgumentException exception)
        {
            await dialogService.ShowMessageBoxAsync(this, $"The selected path has invalid characters.\nError: {exception.Message}", "Error", icon: MessageBoxImage.Error);
        }
    }

    private async Task RunWaifu()
    {
        this.IsEnabled = false;
        await Task.Delay(1000);
        this.IsEnabled = true;
    }
}
