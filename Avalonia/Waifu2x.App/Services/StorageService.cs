using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using Avalonia.VisualTree;
using HanumanInstitute.MvvmDialogs.Avalonia;
using HanumanInstitute.MvvmDialogs.FileSystem;
using Waifu2x.Core.Services;

namespace Waifu2x.Services;

/// <summary>
/// Avalonia storage service
/// </summary>
internal class StorageService : IStorageService
{
    /// <summary>
    /// Gets the current top level application
    /// </summary>
    /// <returns>Top level app</returns>
    private static TopLevel? GetTopLevel() => Application.Current?.ApplicationLifetime switch
    {
        IClassicDesktopStyleApplicationLifetime desktop => desktop.MainWindow,
        ISingleViewApplicationLifetime viewApp          => viewApp.MainView?.GetVisualRoot() as TopLevel,
        _                                               => null
    };

    /// <summary>
    /// Gets the current storage provider
    /// </summary>
    private static IStorageProvider? StorageProvider => field ??= GetTopLevel()?.StorageProvider;

    /// <inheritdoc cref="IStorageService.GetFileDialogData"/>
    public async Task<(string? Name, IDialogStorageFolder? StartFolder)> GetFileDialogData(string path)
    {
        if (StorageProvider is null) return (null, null);

        string? name = null;
        IStorageFolder? startFolder = null;

        FileInfo file = new(path);
        if (file.Exists)
        {
            name        = file.Name;
            startFolder = await StorageProvider.TryGetFolderFromPathAsync(file.DirectoryName!);
            string? directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory))
            {
                startFolder = await StorageProvider.TryGetFolderFromPathAsync(directory);
            }
        }
        else
        {
            DirectoryInfo directory = new(path);
            if (directory.Exists)
            {
                startFolder = await StorageProvider.TryGetFolderFromPathAsync(path);
            }
        }

        return name is not null && startFolder is not null ? (name, startFolder.ToDialog()) : (null, null);
    }

    /// <inheritdoc cref="IStorageService.GetFolderDialogData"/>
    public async Task<IDialogStorageFolder?> GetFolderDialogData(string path)
    {
        if (StorageProvider is null) return null;

        IStorageFolder? startFolder = null;
        DirectoryInfo directory = new(path);
        if (directory.Exists)
        {
            startFolder = await StorageProvider.TryGetFolderFromPathAsync(directory.Parent?.FullName ?? directory.FullName);
        }
        else
        {
            FileInfo file = new(path);
            if (file.Exists)
            {
                startFolder = await StorageProvider.TryGetFolderFromPathAsync(file.Directory!.Parent?.FullName ?? file.Directory.FullName);
            }
        }

        return startFolder?.ToDialog();
    }
}
