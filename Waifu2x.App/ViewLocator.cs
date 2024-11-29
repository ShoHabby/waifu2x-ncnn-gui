using HanumanInstitute.MvvmDialogs.Avalonia;
using Waifu2x.Core.ViewModels;
using Waifu2x.Views;

namespace Waifu2x;

/// <summary>
/// ViewModel locator
/// </summary>
public class ViewLocator : StrongViewLocator
{
    public ViewLocator() => Register<MainWindowViewModel, MainWindow>();
}
