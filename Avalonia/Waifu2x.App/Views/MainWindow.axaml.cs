using Avalonia;
using Avalonia.Controls;

namespace Waifu2x.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Items.PropertyChanged += ItemsOnPropertyChanged;
    }

    private void ItemsOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.Name == ItemsControl.ItemCountProperty.Name)
        {
            this.Scroll.ScrollToEnd();
        }
    }
}
