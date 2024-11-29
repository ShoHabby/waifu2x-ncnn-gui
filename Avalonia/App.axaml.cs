using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Waifu2x.Services;
using Waifu2x.ViewModels;
using Waifu2x.Views;

namespace Waifu2x;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();

            ServiceCollection services = new();
            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddTransient<FileGroupViewModel>();
            services.AddTransient<SettingsGroupViewModel>();
            services.AddTransient<MainWindowViewModel>();

            ServiceProvider provider = services.BuildServiceProvider();
            desktop.MainWindow = new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        DataAnnotationsValidationPlugin[] toRemove = BindingPlugins.DataValidators
                                                                   .OfType<DataAnnotationsValidationPlugin>()
                                                                   .ToArray();
        // Remove each entry found
        Array.ForEach(toRemove, plugin => BindingPlugins.DataValidators.Remove(plugin));
    }
}
