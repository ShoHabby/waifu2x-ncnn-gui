using HanumanInstitute.MvvmDialogs.Avalonia;
using Waifu2x.Core.ViewModels;
using Waifu2x.Views;

namespace Waifu2x;

public class ViewLocator : StrongViewLocator
{
    public ViewLocator()
    {
        Register<MainWindowViewModel, MainWindow>();
        Register<FileGroupViewModel, FileGroup>();
        Register<SettingsGroupViewModel, SettingsGroup>();
    }
}
