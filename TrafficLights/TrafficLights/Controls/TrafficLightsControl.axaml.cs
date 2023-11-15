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

        /// <summary>
        /// You canít make color a constant, here is a different approach to the properties of the constant
        /// </summary>
        private static readonly Color BackgroundColor = Colors.Gray;
        private static readonly Color BorderColor = Colors.Black;

        private readonly SolidColorBrush BackgroundFill = new SolidColorBrush(BackgroundColor);
        private readonly Pen HandPen = new Pen(new SolidColorBrush(BorderColor));

        #endregion

        #region —ontrol size

        /// <summary>
        /// Control width
        /// </summary>
        private double _width;

        /// <summary>
        /// Control height
        /// </summary>
        private double _height;

        #endregion

        #region —ontrol elements coordinates

        /// <summary>
        /// Middle control (X), also _first point_ (Y)(T1)
        /// </summary>
        private Point _middlePointX = new Point(0, 0);

        /// <summary>
        /// Second point (Y)(T2)
        /// </summary>
        private Point _secondPointY = new Point(0, 0);

        /// <summary>
        /// Third point (Y)(T3)
        /// </summary>
        private Point _thirdPointY = new Point(0, 0);

        /// <summary>
        /// Fourth point (Y)(T4)
        /// </summary>
        private Point _fourthPointY = new Point(0, 0);

        /// <summary>
        /// Half width 
        /// </summary>
        private double _halfWidth;

        /// <summary>
        /// Third part of length
        /// </summary>
        private double _thirdPartLengthHeight;

        /// <summary>
        /// Point circle center 1
        /// </summary>
        private Point _first—ircleCenter = new Point(0, 0);

        /// <summary>
        /// Point circle center 2
        /// </summary>
        private Point _second—ircleCenter = new Point(0, 0);

        /// <summary>
        /// Point circle center 3
        /// </summary>
        private Point _thirdCircleCenter = new Point(0, 0);

        /// <summary>
        /// Circle radius
        /// </summary>
        private double Radius;

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

            _halfWidth = _width / 2;
            _thirdPartLengthHeight = _height / 3;

            /// “‡Í ÔÓ‰ÛÏ‡Î.. ¿ Á‡˜ÂÏ ÏÌÂ ˝ÚË ÚÓ˜ÍË?) ◊ÚÓ·˚ Ò ÌËÏË Ú‡ÍÓ„Ó Á‡ÏÛÚËÚ¸.. ’)
            _middlePointX = new Point(_halfWidth, 0);
            _secondPointY = new Point(_halfWidth, _thirdPartLengthHeight);
            _thirdPointY = new Point(_halfWidth, _thirdPartLengthHeight * 2);
            _fourthPointY = new Point(_halfWidth, _thirdPartLengthHeight *3);

            Radius = _thirdPartLengthHeight / 2;

            _first—ircleCenter = new Point(_halfWidth, _thirdPartLengthHeight / 2);
            _second—ircleCenter = new Point(_halfWidth, (_thirdPartLengthHeight/2) + (Radius*2));
            _thirdCircleCenter = new Point(_halfWidth, (_thirdPartLengthHeight / 2) + (Radius * 4));




        }

        /// <summary>
        /// Method for drawing
        /// </summary>
        public override void Render(DrawingContext context)
        {
            base.Render(context);

            context.DrawRectangle
            (
                BackgroundFill,
                HandPen,
                new Rect(0, 0, _width, _height)
            );

            context.DrawEllipse
            (
                new SolidColorBrush(Colors.Red),
                new Pen(new SolidColorBrush(Colors.Black)),
                _first—ircleCenter,
                Radius,
                Radius
            );

            context.DrawEllipse
            (
                new SolidColorBrush(Colors.Yellow),
                new Pen(new SolidColorBrush(Colors.Black)),
                _second—ircleCenter,
                Radius,
                Radius
            );

            context.DrawEllipse
            (
                new SolidColorBrush(Colors.Green),
                new Pen(new SolidColorBrush(Colors.Black)),
                _thirdCircleCenter,
                Radius,
                Radius
            );

        }
    }
}
