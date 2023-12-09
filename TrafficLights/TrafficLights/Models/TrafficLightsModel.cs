using TrafficLights.Models.Enums;

namespace TrafficLights.Models;

/// <summary>
/// Traffic lights model
/// </summary>
public class TrafficLightsModel
{
    /// <summary>
    /// Is red light currently on?
    /// </summary>
    public bool IsRedLightOn { get; set; } = false;

    /// <summary>
    /// Red light state
    /// </summary>
    public LightStateEnum RedLightState { get; set; } = LightStateEnum.Off;
    
    /// <summary>
    /// Is yellow light currently on?
    /// </summary>
    public bool IsYellowLightOn { get; set; } = false;
    
    /// <summary>
    /// Yellow light state
    /// </summary>
    public LightStateEnum YellowLightState { get; set; } = LightStateEnum.Off;
    
    /// <summary>
    /// Is green light currently on?
    /// </summary>
    public bool IsGreenLightOn { get; set; } = false;
    
    /// <summary>
    /// Green light state
    /// </summary>
    public LightStateEnum GreenLightState { get; set; } = LightStateEnum.Off;
}