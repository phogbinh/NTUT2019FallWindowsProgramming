﻿using DrawingModel;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DrawingApp
{
    public class AppGraphicsAdapter : IGraphics
    {
        Canvas _canvas;

        public AppGraphicsAdapter(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void ClearAll()
        {
            _canvas.Children.Clear();
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = new SolidColorBrush(Colors.Black);
            _canvas.Children.Add(line);
        }
    }
}
