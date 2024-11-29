using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;

namespace Waifu2x.Services;

public class FileDialogService : IFileDialogService
{
    private static readonly ReadOnlyCollection<FilePickerFileType> AllowedFiles;

    static FileDialogService()
    {
        FilePickerFileType fileFilter = new("Images")
        {
            Patterns                    = ["*.jpg", "*.png", "*.webp"],
            AppleUniformTypeIdentifiers = ["public.jpeg", "public.png", "org.webmproject.webp"],
            MimeTypes                   = ["image/jpeg", "image/png", "image/webp"]
        };

        AllowedFiles = new ReadOnlyCollection<FilePickerFileType>([fileFilter]);
    }

    /// <inheritdoc />
    public async Task<string> ShowOpenFileDialog(string title, string path)
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime application || application.MainWindow is null)
        {
            return string.Empty;
        }

        string? name = null;
        IStorageFolder? startFolder = null;
        IStorageProvider storageProvider = application.MainWindow.StorageProvider;

        FileInfo file = new(path);
        if (file.Exists)
        {
            name        = file.Name;
            startFolder = await storageProvider.TryGetFolderFromPathAsync(file.DirectoryName!);
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory))
            {
                startFolder = await storageProvider.TryGetFolderFromPathAsync(directory);
            }
        }
        else
        {
            DirectoryInfo directory = new(path);
            if (directory.Exists)
            {
                startFolder = await storageProvider.TryGetFolderFromPathAsync(path);
            }
        }

        FilePickerOpenOptions options = new()
        {
            Title                  = title,
            AllowMultiple          = false,
            FileTypeFilter         = AllowedFiles,
            SuggestedFileName      = name,
            SuggestedStartLocation = startFolder
        };

        IReadOnlyList<IStorageFile> files = await storageProvider.OpenFilePickerAsync(options);
        return files.Count is 1 ? Sanitize(files[0].Path.AbsolutePath) : string.Empty;
    }

    /// <inheritdoc />
    public async Task<string> ShowOpenFolderDialog(string title, string path)
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime application || application.MainWindow is null)
        {
            return string.Empty;
        }

        string? name = null;
        IStorageFolder? startFolder = null;
        IStorageProvider storageProvider = application.MainWindow.StorageProvider;

        DirectoryInfo directory = new(path);
        if (!directory.Exists)
        {
            FileInfo file = new(path);
            if (file.Exists)
            {
                directory = file.Directory!;
            }
        }

        if (directory.Exists)
        {
            name        = directory.Name;
            startFolder = await storageProvider.TryGetFolderFromPathAsync(directory.Parent?.FullName ?? directory.FullName);
        }

        FolderPickerOpenOptions options = new()
        {
            Title                  = title,
            AllowMultiple          = false,
            SuggestedFileName      = name,
            SuggestedStartLocation = startFolder
        };

        IReadOnlyList<IStorageFolder> folders = await storageProvider.OpenFolderPickerAsync(options);
        return folders.Count is 1 ? Sanitize(folders[0].Path.AbsolutePath) : string.Empty;
    }

    private static string Sanitize(string path) => Path.GetFullPath(path).TrimEnd(Path.DirectorySeparatorChar);
}
