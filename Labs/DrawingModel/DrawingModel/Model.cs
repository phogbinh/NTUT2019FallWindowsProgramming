using System.Collections.Generic;

namespace DrawingModel
{
    public class Model
    {
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _modelChanged;
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Line> _lines = new List<Line>();
        Line _hint = new Line();

        public void HandlePointerPressed(double x, double y)
        {
            if ( x > 0 && y > 0 )
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint.x1 = _firstPointX;
                _hint.y1 = _firstPointY;
                _isPressed = true;
            }
        }

        public void HandlePointerMoved(double x, double y)
        {
            if ( _isPressed )
            {
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }

        public void HandlePointerReleased(double x, double y)
        {
            if ( _isPressed )
            {
                _isPressed = false;
                Line hint = new Line();
                hint.x1 = _firstPointX;
                hint.y1 = _firstPointY;
                hint.x2 = x;
                hint.y2 = y;
                _lines.Add(hint);
                NotifyModelChanged();
            }
        }

        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            NotifyModelChanged();
        }

        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach ( Line line in _lines )
            {
                line.Draw(graphics);
            }
            if ( _isPressed )
            {
                _hint.Draw(graphics);
            }
        }

        void NotifyModelChanged()
        {
            if ( _modelChanged != null )
            {
                _modelChanged();
            }
        }
    }
}
