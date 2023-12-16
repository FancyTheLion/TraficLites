using System.Timers;
using TrafficLights.Models.Enums;
using TrafficLights.Services.Abstract;

namespace TrafficLights.Services.Implementations;

public class StateMachine : IStateMachine
{
    private readonly ILightsControllerService _lightsController;

    /// <summary>
    /// State machine current state
    /// </summary>
    private StatesEnum _currentState;
    
    /// <summary>
    /// Timer for states change
    /// </summary>
    private Timer _statesTimer = new Timer(1000); // Never will be called
    
    public StateMachine
    (
        ILightsControllerService lightsController
    )
    {
        _lightsController = lightsController;
    }

    public void StartMachine()
    {
        GoToRedOnState();
    }

    private void GoToRedOnState()
    {
        _currentState = StatesEnum.RedOn;
        
        _lightsController.SetLightState(LightColorEnum.Red, LightStateEnum.On);
        _lightsController.SetLightState(LightColorEnum.Yellow, LightStateEnum.Off);
        _lightsController.SetLightState(LightColorEnum.Green, LightStateEnum.Off);
        
        _statesTimer.Stop();
        _statesTimer.Dispose();
        
        _statesTimer = new Timer(5000);
        _statesTimer.Elapsed += (sender, args) => { GoToRedYellowOnState(); };
        _statesTimer.Enabled = true;
    }
    
    private void GoToRedYellowOnState()
    {
        _currentState = StatesEnum.RedYellowOn;
        
        _lightsController.SetLightState(LightColorEnum.Red, LightStateEnum.On);
        _lightsController.SetLightState(LightColorEnum.Yellow, LightStateEnum.On);
        _lightsController.SetLightState(LightColorEnum.Green, LightStateEnum.Off);
        
        _statesTimer.Stop();
        _statesTimer.Dispose();
        
        _statesTimer = new Timer(2000);
        _statesTimer.Elapsed += (sender, args) => { GoToGreenOnState(); };
        _statesTimer.Enabled = true;
    }
    
    private void GoToGreenOnState()
    {
        _currentState = StatesEnum.GreenOn;
        
        _lightsController.SetLightState(LightColorEnum.Red, LightStateEnum.Off);
        _lightsController.SetLightState(LightColorEnum.Yellow, LightStateEnum.Off);
        _lightsController.SetLightState(LightColorEnum.Green, LightStateEnum.On);
        
        _statesTimer.Stop();
        _statesTimer.Dispose();
        
        _statesTimer = new Timer(5000);
        _statesTimer.Elapsed += (sender, args) => { GoToGreenBlinkState(); };
        _statesTimer.Enabled = true;
    }
    
    private void GoToGreenBlinkState()
    {
        _currentState = StatesEnum.GreenBlink;
        
        _lightsController.SetLightState(LightColorEnum.Red, LightStateEnum.Off);
        _lightsController.SetLightState(LightColorEnum.Yellow, LightStateEnum.Off);
        _lightsController.SetLightState(LightColorEnum.Green, LightStateEnum.Blinking);
        
        _statesTimer.Stop();
        _statesTimer.Dispose();
        
        _statesTimer = new Timer(2000);
        _statesTimer.Elapsed += (sender, args) => { GoToYellowOnState(); };
        _statesTimer.Enabled = true;
    }
    
    private void GoToYellowOnState()
    {
        _currentState = StatesEnum.YellowOn;
        
        _lightsController.SetLightState(LightColorEnum.Red, LightStateEnum.Off);
        _lightsController.SetLightState(LightColorEnum.Yellow, LightStateEnum.On);
        _lightsController.SetLightState(LightColorEnum.Green, LightStateEnum.Off);
        
        _statesTimer.Stop();
        _statesTimer.Dispose();
        
        _statesTimer = new Timer(3000);
        _statesTimer.Elapsed += (sender, args) => { GoToRedOnState(); };
        _statesTimer.Enabled = true;
    }
}