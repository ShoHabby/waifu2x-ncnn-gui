using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FileSystem;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;

namespace Waifu2x.Core.ViewModels;

public partial class MainWindowViewModel
{
    private static readonly ReadOnlyCollection<FileFilter> AllowedFiles;

    static MainWindowViewModel()
    {
        FileFilter filter = new()
        {
            Name                        = "Images",
            Extensions                  = ["jpg", "png", "webp"],
            AppleUniformTypeIdentifiers = ["public.jpeg", "public.png", "org.webmproject.webp"],
            MimeTypes                   = ["image/jpeg", "image/png", "image/webp"]
        };
        AllowedFiles = new ReadOnlyCollection<FileFilter>([filter]);
    }

    [ObservableProperty]
    private bool isFolder = true;

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(RunRequestedCommand))]
    private string? inputPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    [ObservableProperty, NotifyCanExecuteChangedFor(nameof(RunRequestedCommand))]
    private string outputSuffix = "_waifu";

    private string OutputPath => this.IsFolder ? this.InputPath + this.OutputSuffix
                                               : $"{Path.GetFileNameWithoutExtension(this.InputPath)}{this.OutputSuffix}.{this.Format}";

    [RelayCommand]
    private async Task Browse()
    {
        IDialogStorageItem? item;
        if (this.IsFolder)
        {
            IDialogStorageFolder? startFolder = await this.storageService1.GetFolderDialogData(this.InputPath!);

            OpenFolderDialogSettings settings = new()
            {
                Title                  = "Select Folder",
                SuggestedStartLocation = startFolder
            };
            item = await this.dialogService1.ShowOpenFolderDialogAsync(this, settings);
        }
        else
        {
            (string? name, IDialogStorageFolder? startFolder) = await this.storageService1.GetFileDialogData(this.InputPath!);

            OpenFileDialogSettings settings = new()
            {
                Title                  = "Select Image",
                DereferenceLinks       = true,
                Filters                = AllowedFiles,
                SuggestedFileName      = name ?? string.Empty,
                SuggestedStartLocation = startFolder
            };
            item = await this.dialogService1.ShowOpenFileDialogAsync(this, settings);
        }

        if (item is not null && !string.IsNullOrWhiteSpace(item.Path.AbsolutePath))
        {
            this.InputPath = item.Path.AbsolutePath.Replace('/', Path.DirectorySeparatorChar).TrimEnd(Path.DirectorySeparatorChar);
        }
    }
}
