using Avalonia;
using Avalonia.Controls;

namespace Waifu2x.Views;

/// <summary>
/// Main window view
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Items.PropertyChanged += ItemsOnPropertyChanged;
    }

    /// <inheritdoc />
    protected override void OnClosing(WindowClosingEventArgs e)
    {
        if (this.Items is not null)
        {
            this.Items.PropertyChanged -= ItemsOnPropertyChanged;
        }

        base.OnClosing(e);
    }

    private void ItemsOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
    {
        // Scroll to bottom on item added
        if (e.Property.Name == ItemsControl.ItemCountProperty.Name)
        {
            this.Scroll.ScrollToEnd();
        }
    }
}
