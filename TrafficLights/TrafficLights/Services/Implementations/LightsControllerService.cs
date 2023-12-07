using System;
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

    public void AttachLightsControl(SetLightsStatesDelegate controlDelegate)
    {
        _lightsControlDelegate = controlDelegate;
    }

    public void SetLightState(LightColorEnum color, LightStateEnum state)
    {
        switch (color)
        {
            case LightColorEnum.Red:
                _trafficLightsModel.RedLightState = state;
                break;
            
            case LightColorEnum.Yellow:
                _trafficLightsModel.YellowLightState = state;
                break;
            
            case LightColorEnum.Green:
                _trafficLightsModel.GreenLightState = state;
                break;
            
            default:
                throw new ArgumentException("Invalid color!", nameof(color));
        }

        _lightsControlDelegate
        (
            _trafficLightsModel.RedLightState == LightStateEnum.On,
            _trafficLightsModel.YellowLightState == LightStateEnum.On,
            _trafficLightsModel.GreenLightState == LightStateEnum.On
        );
    }
}