using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace TrafficLights.Controls
{
    public partial class TrafficLightsControl : UserControl
    {
        #region Constants

        #region Colors

        // You can't make color a constant, here is a different approach to the properties of the constant
        private static readonly Color BackgroundColor = Colors.Gray;
        private static readonly Color BorderColor = Colors.Black;
        private static readonly Color CircleBorderColor = Colors.Black;

        private static readonly Color RedLightOnColor = Colors.Red;
        private static readonly Color RedLightOffColor = new Color(255, 60, 0, 0);
        private static readonly Color YellowLightOnColor = Colors.Yellow;
        private static readonly Color YellowLightOffColor = new Color(255, 60, 60, 0);
        private static readonly Color GreenLightOnColor = Colors.Green;
        private static readonly Color GreenLightOffColor = new Color(255, 0, 60, 0);
        
        #endregion

        #region Brushes and pens

        /// <summary>
        /// Brush to draw traffic lights case
        /// </summary>
        private readonly SolidColorBrush CaseFillBrush = new SolidColorBrush(BackgroundColor);
        
        /// <summary>
        /// Pen to draw traffic lights case
        /// </summary>
        private readonly Pen CasePen = new Pen(new SolidColorBrush(BorderColor));
        
        /// <summary>
        /// Pen to draw lights borders
        /// </summary>
        private readonly Pen LightsBordersPen = new Pen(new SolidColorBrush(CircleBorderColor));

        /// <summary>
        /// Brush for shining red light
        /// </summary>
        private readonly IBrush RedLightOnBrush = new SolidColorBrush(RedLightOnColor);
        
        /// <summary>
        /// Brush for off red light
        /// </summary>
        private readonly IBrush RedLightOffBrush = new SolidColorBrush(RedLightOffColor);
        
        /// <summary>
        /// Brush for shining yellow light
        /// </summary>
        private readonly IBrush YellowLightOnBrush = new SolidColorBrush(YellowLightOnColor);
        
        /// <summary>
        /// Brush for off yellow light
        /// </summary>
        private readonly IBrush YellowLightOffBrush = new SolidColorBrush(YellowLightOffColor);
        
        /// <summary>
        /// Brush for shining green light
        /// </summary>
        private readonly IBrush GreenLightOnBrush = new SolidColorBrush(GreenLightOnColor);
        
        /// <summary>
        /// Brush for off green light
        /// </summary>
        private readonly IBrush GreenLightOffBrush = new SolidColorBrush(GreenLightOffColor);
        
        #endregion

        #region Settings

        /// <summary>
        /// Lights radius multiplier
        /// </summary>
        private const double LightsRadiusMultiplier = 0.9;

        #endregion
        
        #endregion

        #region Control size

        /// <summary>
        /// Control width
        /// </summary>
        private double _width;

        /// <summary>
        /// Control height
        /// </summary>
        private double _height;

        /// <summary>
        /// Traffic light case sizes
        /// </summary>
        private Rect _caseSizes = new Rect(0, 0, 1, 1);

        #endregion

        #region Control elements coordinates
        
        /// <summary>
        /// Half width 
        /// </summary>
        private double _halfWidth;

        /// <summary>
        /// Red light center point
        /// </summary>
        private Point _redLightCenter = new Point(0, 0);

        /// <summary>
        /// Yellow light center
        /// </summary>
        private Point _yellowLightCenter = new Point(0, 0);

        /// <summary>
        /// Green light center
        /// </summary>
        private Point _greenLightCenter = new Point(0, 0);

        /// <summary>
        /// Circle radius
        /// </summary>
        private double _lightRadius;

        #endregion

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
        /// Designer
        /// </summary>
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

            _caseSizes = new Rect(0, 0, _width, _height);

            _halfWidth = _width / 2.0;

            var heightSixth = _height / 6.0;

            var radiusH = _height / 6.0;
            var radiusW = _width / 2.0;
            _lightRadius = Math.Min(radiusW, radiusH) * LightsRadiusMultiplier;

            _redLightCenter = new Point(_halfWidth, heightSixth);
            _yellowLightCenter = new Point(_halfWidth, 3 * heightSixth);
            _greenLightCenter = new Point(_halfWidth, 5 * heightSixth);
        }

        /// <summary>
        /// Method for drawing
        /// </summary>
        public override void Render(DrawingContext context)
        {
            base.Render(context);

            // Case
            context.DrawRectangle
            (
                CaseFillBrush,
                CasePen,
                _caseSizes
            );
            
            // Red light
            DrawLight(context, IsRedLightOn ? RedLightOnBrush : RedLightOffBrush, _redLightCenter);
            
            // Yellow light
            DrawLight(context, IsYellowLightOn ? YellowLightOnBrush : YellowLightOffBrush, _yellowLightCenter);
            
            // Green light
            DrawLight(context, IsGreenLightOn ? GreenLightOnBrush : GreenLightOffBrush, _greenLightCenter);
        }

        /// <summary>
        /// Method to draw light
        /// </summary>
        private void DrawLight(DrawingContext context, IBrush lightBrush, Point lightCenter)
        {
            context.DrawEllipse
            (
                lightBrush,
                LightsBordersPen,
                lightCenter,
                _lightRadius,
                _lightRadius
            );
            
        }
    }
}
