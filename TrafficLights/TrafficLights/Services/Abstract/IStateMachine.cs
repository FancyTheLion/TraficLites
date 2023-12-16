namespace TrafficLights.Services.Abstract;

/// <summary>
/// Ligths control state machine
/// </summary>
public interface IStateMachine
{
    /// <summary>
    /// Start state machine
    /// </summary>
    void StartMachine();
}