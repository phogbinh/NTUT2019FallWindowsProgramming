using System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MouseEventsInWindowsStoreApps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const int CANVAS_SIZE = 400;
        private const String MESSAGE = "Where is the mouse?";
        private SolidColorBrush _whiteColor = new SolidColorBrush(Colors.White);

        public MainPage()
        {
            this.InitializeComponent();
            _textBlock.Text = MESSAGE;
            _canvas.Width = CANVAS_SIZE;
            _canvas.Height = CANVAS_SIZE;
            _canvas.Background = _whiteColor;
            _canvas.PointerPressed += PressOnCanvas;
            _canvas.PointerMoved += MoveOnCanvas;
        }

        private void MoveOnCanvas(object sender, PointerRoutedEventArgs e)
        {
            double moveX = Math.Round(e.GetCurrentPoint(_canvas).Position.X, 2);
            double moveY = Math.Round(e.GetCurrentPoint(_canvas).Position.Y, 2);
            _textBlock.Text = "You moved on (" + moveX + ", " + moveY + ")";
        }
        private void PressOnCanvas(object sender, PointerRoutedEventArgs e)
        {
            double pressX = Math.Round(e.GetCurrentPoint(_canvas).Position.X, 2);
            double pressY = Math.Round(e.GetCurrentPoint(_canvas).Position.Y, 2);
            _textBlock.Text = "You pressed on (" + pressX + ", " + pressY + ")";
        }
    }
}
