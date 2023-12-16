using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using TrafficLights.Models;
using TrafficLights.Services.Abstract;
using TrafficLights.Services.Implementations;
using TrafficLights.ViewModels;
using TrafficLights.Views;

namespace TrafficLights;

public partial class App : Application
{
    /// <summary>
    /// Dependency injector
    /// </summary>
    public static ServiceProvider Di { get; set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Setting up dependency injector
        Di = ConfigureServices()
            .BuildServiceProvider();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel
                (
                    Di.GetService<ILightsControllerService>(),
                    Di.GetService<IStateMachine>()
                )
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel
                (
                    Di.GetService<ILightsControllerService>(),
                    Di.GetService<IStateMachine>()
                )
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    /// <summary>
    /// Configure dependency injector
    /// </summary>
    public static IServiceCollection ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();
        
        #region Singletons

        // This command means "use LightsControllerService where application needs the ILightsControllerService
        // interface"
        services.AddSingleton<ILightsControllerService, LightsControllerService>();
        services.AddSingleton<IStateMachine, StateMachine>();

        #endregion

        return services;
    }
}
