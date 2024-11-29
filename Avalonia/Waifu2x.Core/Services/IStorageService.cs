using HanumanInstitute.MvvmDialogs.FileSystem;

namespace Waifu2x.Core.Services;

public interface IStorageService
{
    Task<(string? Name, IDialogStorageFolder? StartFolder)> GetFileDialogData(string path);

    Task<IDialogStorageFolder?> GetFolderDialogData(string path);
}
