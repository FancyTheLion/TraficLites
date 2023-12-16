using ReactiveUI;
using TrafficLights.Services.Abstract;

namespace TrafficLights.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ILightsControllerService _lightsControllerService;
    private readonly IStateMachine _stateMachine;
    
    #region Is red on

    private bool _isRedOn;

    public bool IsRedOn
    {
        get => _isRedOn;

        set => this.RaiseAndSetIfChanged(ref _isRedOn, value);
    }

    #endregion

    #region Is yellow on

    private bool _isYellowOn;

    public bool IsYellowOn
    {
        get => _isYellowOn;

        set => this.RaiseAndSetIfChanged(ref _isYellowOn, value);
    }

    #endregion

    #region Is green on

    private bool _isGreenOn;

    public bool IsGreenOn
    {
        get => _isGreenOn;

        set => this.RaiseAndSetIfChanged(ref _isGreenOn, value);
    }

    #endregion
    
    public MainViewModel
    (
        ILightsControllerService lightsControllerService,
        IStateMachine stateMachine
    )
    {
        _lightsControllerService = lightsControllerService;
        _stateMachine = stateMachine;
        
        _lightsControllerService.AttachLightsControl(SetLightsStates);
        _stateMachine.StartMachine();
    }

    /// <summary>
    /// Set all lights states alltogether
    /// </summary>
    private void SetLightsStates(bool isRedOn, bool isYellowOn, bool isGreenOn)
    {
        IsRedOn = isRedOn;
        IsYellowOn = isYellowOn;
        IsGreenOn = isGreenOn;
    }

}
