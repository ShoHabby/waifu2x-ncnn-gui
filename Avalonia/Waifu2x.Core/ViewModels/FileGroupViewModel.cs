using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.FileSystem;
using HanumanInstitute.MvvmDialogs.FrameworkDialogs;
using Waifu2x.Core.Services;

namespace Waifu2x.Core.ViewModels;

public partial class FileGroupViewModel(IDialogService dialogService, IStorageService storageService) : ViewModelBase
{
    private static readonly ReadOnlyCollection<FileFilter> AllowedFiles;

    static FileGroupViewModel()
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

    internal INotifyPropertyChanged? MainWindow { get; set; }

    [ObservableProperty]
    private bool isFolder = true;

    [ObservableProperty]
    private string? inputPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    [ObservableProperty]
    private string outputSuffix = "_waifu";

    public FileGroupViewModel() : this(null!, null!) { }

    [RelayCommand]
    private async Task Browse()
    {
        IDialogStorageItem? item;
        if (this.IsFolder)
        {
            IDialogStorageFolder? startFolder = await storageService.GetFolderDialogData(this.InputPath!);

            OpenFolderDialogSettings settings = new()
            {
                Title                  = "Select Folder",
                SuggestedStartLocation = startFolder
            };
            item = await dialogService.ShowOpenFolderDialogAsync(this.MainWindow, settings);
        }
        else
        {
            (string? name, IDialogStorageFolder? startFolder) = await storageService.GetFileDialogData(this.InputPath!);

            OpenFileDialogSettings settings = new()
            {
                Title                  = "Select Image",
                DereferenceLinks       = true,
                Filters                = AllowedFiles,
                SuggestedFileName      = name ?? string.Empty,
                SuggestedStartLocation = startFolder
            };
            item = await dialogService.ShowOpenFileDialogAsync(this.MainWindow, settings);
        }

        if (item is not null && !string.IsNullOrWhiteSpace(item.Path.AbsolutePath))
        {
            this.InputPath = item.Path.AbsolutePath.Replace('/', Path.DirectorySeparatorChar).TrimEnd(Path.DirectorySeparatorChar);
        }
    }
}
