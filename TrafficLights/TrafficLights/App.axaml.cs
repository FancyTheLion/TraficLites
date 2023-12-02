using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TrafficLights.Models;
using TrafficLights.ViewModels;
using TrafficLights.Views;

namespace TrafficLights;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                // Here we create the traffic lights (new TrafficLightsModel())
                // then we create the view model (new MainViewModel())
                // and passing created traffic lights to it
                DataContext = new MainViewModel(new TrafficLightsModel())
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel(new TrafficLightsModel())
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
