using System;
using System.Timers;
using TrafficLights.Models;
using TrafficLights.Models.Enums;
using TrafficLights.Services.Abstract;

namespace TrafficLights.Services.Implementations;

public class LightsControllerService : ILightsControllerService
{
    /// <summary>
    /// Here we store traffic lights state
    /// </summary>
    private TrafficLightsModel _trafficLightsModel = new TrafficLightsModel();

    /// <summary>
    /// Method to control lights will be stored here
    /// </summary>
    private SetLightsStatesDelegate _lightsControlDelegate;
    
    /// <summary>
    /// Timer for light blinking
    /// </summary>
    private Timer _blinkTimer;

    /// <summary>
    /// Constructor
    /// </summary>
    public LightsControllerService()
    {
        _blinkTimer = new Timer(500);
        _blinkTimer.AutoReset = true;
        _blinkTimer.Enabled = true;
        _blinkTimer.Elapsed += OnBlinkTimer;
    }

    public void AttachLightsControl(SetLightsStatesDelegate controlDelegate)
    {
        _lightsControlDelegate = controlDelegate;
    }

    public void SetLightState(LightColorEnum color, LightStateEnum state)
    {
        bool isLightOn = IsLigtOnInGivenState(state);
        
        switch (color)
        {
            case LightColorEnum.Red:
                _trafficLightsModel.RedLightState = state;
                _trafficLightsModel.IsRedLightOn = isLightOn;
                break;
            
            case LightColorEnum.Yellow:
                _trafficLightsModel.YellowLightState = state;
                _trafficLightsModel.IsYellowLightOn = isLightOn;
                break;
            
            case LightColorEnum.Green:
                _trafficLightsModel.GreenLightState = state;
                _trafficLightsModel.IsGreenLightOn = isLightOn;
                break;
            
            default:
                throw new ArgumentException("Invalid color!", nameof(color));
        }

        _lightsControlDelegate
        (
            _trafficLightsModel.IsRedLightOn,
            _trafficLightsModel.IsYellowLightOn,
            _trafficLightsModel.IsGreenLightOn
        );
    }

    /// <summary>
    /// Does light must be on in given state?
    /// </summary>
    private bool IsLigtOnInGivenState(LightStateEnum state)
    {
        switch (state)
        {
            case LightStateEnum.On:
                return true;
            
            case LightStateEnum.Off:
                return false;
            
            case LightStateEnum.Blinking:
                return false;
            
            default:
                throw new ArgumentException("Invalid state!", nameof(state));
        }
    }
    
    /// <summary>
    /// This method got called every 500ms
    /// </summary>
    private void OnBlinkTimer(object? sender, ElapsedEventArgs e)
    {
        if (_trafficLightsModel.RedLightState == LightStateEnum.Blinking)
        {
            _trafficLightsModel.IsRedLightOn = !_trafficLightsModel.IsRedLightOn;
        }
        
        if (_trafficLightsModel.YellowLightState == LightStateEnum.Blinking)
        {
            _trafficLightsModel.IsYellowLightOn = !_trafficLightsModel.IsYellowLightOn;
        }
        
        if (_trafficLightsModel.GreenLightState == LightStateEnum.Blinking)
        {
            _trafficLightsModel.IsGreenLightOn = !_trafficLightsModel.IsGreenLightOn;
        }
        
        _lightsControlDelegate
        (
            _trafficLightsModel.IsRedLightOn,
            _trafficLightsModel.IsYellowLightOn,
            _trafficLightsModel.IsGreenLightOn
        );
    }
}