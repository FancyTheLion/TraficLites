using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace TrafficLights.Controls
{
    public partial class TrafficLightsControl : UserControl
    {
        #region Bound properties

        /// <summary>
        /// Here we store red linght state
        /// </summary>
        public static readonly AttachedProperty<bool> IsRedLightOnProperty
           = AvaloniaProperty.RegisterAttached<TrafficLightsControl, Interactive, bool>(nameof(IsRedLightOn));

        /// <summary>
        /// Is red light on proxy
        /// </summary>
        public bool IsRedLightOn
        {
            get { return GetValue(IsRedLightOnProperty); }
            set { SetValue(IsRedLightOnProperty, value); }
        }

        #endregion

        public TrafficLightsControl()
        {
            InitializeComponent();

            // Setting up properties handlers
            IsRedLightOnProperty.Changed.Subscribe(x => HandleRedLightStateChanged(x.Sender, x.NewValue.GetValueOrDefault<bool>()));
        }

        #region Lights state handlers

        /// <summary>
        /// This method will be called when red light state is changed
        /// </summary>
        private void HandleRedLightStateChanged(AvaloniaObject sender, bool isRedLightOn)
        {
            InvalidateVisual(); // Redraw control
        }

        #endregion
    }
}
