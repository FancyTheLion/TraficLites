using TrafficLights.Models.Enums;

namespace TrafficLights.Services.Abstract;

/// <summary>
/// Delegate (data type), which can accept void(bool, bool, bool) method
/// </summary>
public delegate void SetLightsStatesDelegate(bool isRedOn, bool isYellowOn, bool isGreenOn);

/// <summary>
/// Service to control lights
/// </summary>
public interface ILightsControllerService
{
    /// <summary>
    /// Attach lights control (accept lights control delegate)
    /// </summary>
    void AttachLightsControl(SetLightsStatesDelegate controlDelegate);
    
    /// <summary>
    /// Set light (of given color) state
    /// </summary>
    void SetLightState(LightColorEnum color, LightStateEnum state);
}