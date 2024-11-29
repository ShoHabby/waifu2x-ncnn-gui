using System;
using Avalonia;
using Avalonia.Controls;
using Waifu2x.Core.Services;

namespace Waifu2x.Views;

/// <summary>
/// Main window view
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    /// <inheritdoc />
    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);

        this.IsFolder.IsChecked = Settings.Default.IsFolder;
        this.IsFile.IsChecked   = !Settings.Default.IsFolder;
        if (!string.IsNullOrWhiteSpace(Settings.Default.InputPath))
        {
            this.Input.Text = Settings.Default.InputPath;
        }
        this.OutputSuffix.Text          =  Settings.Default.OutputSuffix;
        this.Scale.SelectedValue        =  Settings.Default.Scale;
        this.DenoiseLevel.SelectedIndex =  Settings.Default.DenoiseLevel;
        this.Format.SelectedValue       =  Settings.Default.Format;
        this.DecodeThreads.Value        =  Settings.Default.DecodeThreads;
        this.UpscaleThreads.Value       =  Settings.Default.UpscaleThreads;
        this.EncodeThreads.Value        =  Settings.Default.EncodeThreads;
        this.Grayscale.IsChecked        =  Settings.Default.Grayscale;
        this.TtaMode.IsChecked          =  Settings.Default.TtaMode;
        this.Width                      =  Settings.Default.Width;
        this.Height                     =  Settings.Default.Height;
        this.Items.PropertyChanged      += ItemsOnPropertyChanged;
    }

    /// <inheritdoc />
    protected override void OnClosing(WindowClosingEventArgs e)
    {
        if (this.Items is not null)
        {
            this.Items.PropertyChanged -= ItemsOnPropertyChanged;
        }

        Settings.Default.IsFolder       = this.IsFolder.IsChecked ?? true;
        Settings.Default.InputPath      = this.Input.Text;
        Settings.Default.OutputSuffix   = this.OutputSuffix.Text;
        Settings.Default.Scale          = (int?)this.Scale.SelectedValue ?? 2;
        Settings.Default.DenoiseLevel   = this.DenoiseLevel.SelectedIndex;
        Settings.Default.Format         = (UpscaleFormat?)this.Format.SelectedValue ?? UpscaleFormat.PNG;
        Settings.Default.DecodeThreads  = (int?)this.DecodeThreads.Value ?? 2;
        Settings.Default.UpscaleThreads = (int?)this.UpscaleThreads.Value ?? 2;
        Settings.Default.EncodeThreads  = (int?)this.EncodeThreads.Value ?? 2;
        Settings.Default.Grayscale      = this.Grayscale.IsChecked ?? false;
        Settings.Default.TtaMode        = this.TtaMode.IsChecked ?? false;
        Settings.Default.Width          = (int)Math.Round(this.Width);
        Settings.Default.Height         = (int)Math.Round(this.Height);
        Settings.Default.Save();

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
