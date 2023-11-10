﻿using ReactiveUI;
using System.Reactive;

namespace TrafficLights.ViewModels;

public class MainViewModel : ViewModelBase
{
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

    #region Commands

    public ReactiveCommand<Unit, Unit> TurnRedOnCommand { get; set; }
    public ReactiveCommand<Unit, Unit> TurnRedOffCommand { get; set; }
    public ReactiveCommand<Unit, Unit> TurnYellowOnCommand { get; set; }
    public ReactiveCommand<Unit, Unit> TurnYellowOffCommand { get; set; }
    public ReactiveCommand<Unit, Unit> TurnGreenOnCommand { get; set; }
    public ReactiveCommand<Unit, Unit> TurnGreenOffCommand { get; set; }

    #endregion

    public MainViewModel()
    {
        #region Commands binding

        TurnRedOnCommand = ReactiveCommand.Create(TurnRedOn);
        TurnRedOffCommand = ReactiveCommand.Create(TurnRedOff);
        TurnYellowOnCommand = ReactiveCommand.Create(TurnYellowOn);
        TurnYellowOffCommand = ReactiveCommand.Create(TurnYellowOff);
        TurnGreenOnCommand = ReactiveCommand.Create(TurnGreenOn);
        TurnGreenOffCommand = ReactiveCommand.Create(TurnGreenOff);

        #endregion
    }

    /// <summary>
    /// Turn red light on
    /// </summary>
    private void TurnRedOn()
    {
        IsRedOn = true;
    }

    /// <summary>
    /// Turn red light off
    /// </summary>
    private void TurnRedOff()
    {
        IsRedOn = false;
    }

    /// <summary>
    /// Turn yellow light on
    /// </summary>
    private void TurnYellowOn()
    {
        IsYellowOn = true;
    }

    /// <summary>
    /// Turn yellow light off
    /// </summary>
    private void TurnYellowOff()
    {
        IsYellowOn = false;
    }

    /// <summary>
    /// Turn green light on
    /// </summary>
    private void TurnGreenOn()
    {
        IsGreenOn = true;
    }

    /// <summary>
    /// Turn green light off
    /// </summary>
    private void TurnGreenOff()
    {
        IsGreenOn = false;
    }

}