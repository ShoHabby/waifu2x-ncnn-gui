using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Waifu2x.Services;

namespace Waifu2x.ViewModels;

public partial class FileGroupViewModel(IFileDialogService fileDialogService) : ViewModelBase
{
    [ObservableProperty]
    private bool isFolder = true;

    [ObservableProperty]
    private string? inputPath = @"C:\";

    [ObservableProperty]
    private string outputSuffix = "_waifu";

    public FileGroupViewModel() : this(new FileDialogService()) { }

    [RelayCommand]
    private async Task Browse()
    {
        string? path = await (this.IsFolder
                                  ? fileDialogService.ShowOpenFolderDialog("Select Folder", this.InputPath!)
                                  : fileDialogService.ShowOpenFileDialog("Select Image", this.InputPath!));

        if (!string.IsNullOrEmpty(path))
        {
            this.InputPath = path;
        }
    }
}
