using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Avalonia.Markup.Xaml;
using DataGridDemo.ViewModels;
using DataGridDemo.Views;

namespace DataGridDemo;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
        // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
        DisableAvaloniaDataAnnotationValidation();

        var collection = new ServiceCollection();

        // Window is only needed for Desktop
        collection.AddSingleton<MainWindow>();

        // add viewmodels
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<DemoDataGridViewModel>();
        collection.AddSingleton<DemoTreeDataGridViewModel>();

        // add views
        collection.AddTransient<MainView>();
        collection.AddSingleton<DemoDataGridView>();
        collection.AddSingleton<DemoTreeDataGridView>();

        var serviceProvider = collection.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = serviceProvider.GetRequiredService<MainWindow>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = serviceProvider.GetRequiredService<MainView>();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove = BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}