using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace DrawingInWindowsStoreApps
{
    public sealed partial class MainPage : Page
    {
        private const int CANVAS_SIZE = 400;
        private const int BALL_SIZE = 50;
        private const double STROKE_THICKNESS = 5;
        private SolidColorBrush _whiteColor = new SolidColorBrush(Colors.White);
        private SolidColorBrush _blueColor = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush _blackColor = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _yellowColor = new SolidColorBrush(Colors.Yellow);
        private SolidColorBrush _greenYellowColor = new SolidColorBrush(Colors.GreenYellow);
        private SolidColorBrush _purpleColor = new SolidColorBrush(Colors.Purple);

        public MainPage()
        {
            this.InitializeComponent();
            _canvas.Width = CANVAS_SIZE;
            _canvas.Height = CANVAS_SIZE;
            _canvas.Background = _whiteColor;
            Rectangle rectangle = new Rectangle();
            InitializeShape(rectangle, 0, 0, 150, 100, _blueColor);
            _canvas.Children.Add(rectangle);

            rectangle = new Rectangle();
            InitializeShape(rectangle, 0, 250, 150, 150, _blueColor);
            _canvas.Children.Add(rectangle);

            rectangle = new Rectangle();
            InitializeShape(rectangle, 300, 0, 100, 275, _blueColor);
            _canvas.Children.Add(rectangle);

            // Five balls
            Ellipse ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 25, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Add(ellipse);

            ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 125, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Add(ellipse);

            ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 225, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Add(ellipse);

            ellipse = new Ellipse();
            InitializeShape(ellipse, 200, 325, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Add(ellipse);

            ellipse = new Ellipse();
            InitializeShape(ellipse, 300, 325, BALL_SIZE, BALL_SIZE, _greenYellowColor);
            _canvas.Children.Add(ellipse);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private Shape InitializeShape(Shape shape, int left, int top, int right, int bottom, SolidColorBrush fillColorBrush)
        {
            shape.Margin = new Windows.UI.Xaml.Thickness(left, top, right, bottom);
            shape.Width = right;
            shape.Height = bottom;
            shape.Fill = fillColorBrush;
            shape.Stroke = _purpleColor;
            shape.StrokeThickness = STROKE_THICKNESS;
            return shape;
        }
    }
}
