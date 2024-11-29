using HanumanInstitute.MvvmDialogs.FileSystem;

namespace Waifu2x.Core.Services;

/// <summary>
/// Device storage service
/// </summary>
public interface IStorageService
{
    /// <summary>
    /// Gets required data to open a file pick dialog
    /// </summary>
    /// <param name="path">Current template path</param>
    /// <returns>A tuple containing the suggested current file name and starting folder</returns>
    Task<(string? Name, IDialogStorageFolder? StartFolder)> GetFileDialogData(string path);

    /// <summary>
    /// Gets the required data to open a folder pick dialog
    /// </summary>
    /// <param name="path">Current template path</param>
    /// <returns>The suggested starting folder</returns>
    Task<IDialogStorageFolder?> GetFolderDialogData(string path);
}
