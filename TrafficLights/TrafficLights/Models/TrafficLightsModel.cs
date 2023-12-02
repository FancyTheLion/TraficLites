using TrafficLights.Models.Enums;

namespace TrafficLights.Models;

/// <summary>
/// Traffic lights model
/// </summary>
public class TrafficLightsModel
{
    /// <summary>
    /// Red light state
    /// </summary>
    public LightStateEnum RedLightState { get; set; } = LightStateEnum.Off;
    
    /// <summary>
    /// Yellow light state
    /// </summary>
    public LightStateEnum YellowLightState { get; set; } = LightStateEnum.Off;
    
    /// <summary>
    /// Green light state
    /// </summary>
    public LightStateEnum GreenLightState { get; set; } = LightStateEnum.Off;
}