namespace TrafficLights.Models.Enums;

/// <summary>
/// State machine states
/// </summary>
public enum StatesEnum
{
    /// <summary>
    /// Red light on
    /// </summary>
    RedOn,
    
    /// <summary>
    /// Red and yellow lights on
    /// </summary>
    RedYellowOn,
    
    /// <summary>
    /// Green lights on
    /// </summary>
    GreenOn,
    
    /// <summary>
    /// Green light blink
    /// </summary>
    GreenBlink,
    
    /// <summary>
    /// Yellow light on
    /// </summary>
    YellowOn
}