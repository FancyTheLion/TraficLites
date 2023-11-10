using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
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
        /// Here we store yellow linght state
        /// </summary>
        public static readonly AttachedProperty<bool> IsYellowLightOnProperty
           = AvaloniaProperty.RegisterAttached<TrafficLightsControl, Interactive, bool>(nameof(IsYellowLightOn));

        /// <summary>
        /// Here we store green linght state
        /// </summary>
        public static readonly AttachedProperty<bool> IsGreenLightOnProperty
           = AvaloniaProperty.RegisterAttached<TrafficLightsControl, Interactive, bool>(nameof(IsGreenLightOn));

        /// <summary>
        /// Is red light on proxy
        /// </summary>
        public bool IsRedLightOn
        {
            get { return GetValue(IsRedLightOnProperty); }
            set { SetValue(IsRedLightOnProperty, value); }
        }

        /// <summary>
        /// Is yellow light on proxy
        /// </summary>
        public bool IsYellowLightOn
        {
            get { return GetValue(IsYellowLightOnProperty); }
            set { SetValue(IsYellowLightOnProperty, value); }
        }

        /// <summary>
        /// Is green light on proxy
        /// </summary>
        public bool IsGreenLightOn
        {
            get { return GetValue(IsGreenLightOnProperty); }
            set { SetValue(IsGreenLightOnProperty, value); }
        }

        #endregion

        /// <summary>
        /// Control width
        /// </summary>
        private double _width;

        /// <summary>
        /// Control height
        /// </summary>
        private double _height;

        public TrafficLightsControl()
        {
            InitializeComponent();

            // Register a control property change handler
            PropertyChanged += OnPropertyChangedListener;

            // Setting up properties handlers
            IsRedLightOnProperty.Changed.Subscribe(x => HandleRedLightStateChanged(x.Sender, x.NewValue.GetValueOrDefault<bool>()));
            IsYellowLightOnProperty.Changed.Subscribe(x => HandleYellowLightStateChanged(x.Sender, x.NewValue.GetValueOrDefault<bool>()));
            IsGreenLightOnProperty.Changed.Subscribe(x => HandleGreenLightStateChanged(x.Sender, x.NewValue.GetValueOrDefault<bool>()));
        }

        #region Lights state handlers

        /// <summary>
        /// This method will be called when red light state is changed
        /// </summary>
        private void HandleRedLightStateChanged(AvaloniaObject sender, bool isRedLightOn)
        {
            InvalidateVisual(); // Redraw control
        }

        /// <summary>
        /// This method will be called when yellow light state is changed
        /// </summary>
        private void HandleYellowLightStateChanged(AvaloniaObject sender, bool isYellowLightOn)
        {
            InvalidateVisual(); // Redraw control
        }

        /// <summary>
        /// This method will be called when green light state is changed
        /// </summary>
        private void HandleGreenLightStateChanged(AvaloniaObject sender, bool isGreenLightOn)
        {
            InvalidateVisual(); // Redraw control
        }

        #endregion

        /// <summary>
        /// This method is being called when any property of the control changes.
        /// </summary>
        private void OnPropertyChangedListener(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.Name.Equals("Bounds")) // If a change occurs to a property named Bounds
            {
                OnResize((Rect)e.NewValue); // Call method OnResize(), passing there the new sizes of the control
            }
        }

        /// <summary>
        /// The method is called when the size of the control changes
        /// </summary>
        private void OnResize(Rect bounds)
        {
            _width = bounds.Width;
            _height = bounds.Height;
        }

        /// <summary>
        /// Method for drawing
        /// </summary>
        public override void Render(DrawingContext context)
        {
            base.Render(context);

        }
    }
}
