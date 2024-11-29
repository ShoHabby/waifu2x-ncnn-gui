namespace Waifu2x.ViewsModels.Services;

public interface IFileDialogService
{
    Task<string> ShowOpenFileDialog(string title, string path);

    Task<string> ShowOpenFolderDialog(string title, string path);
}
