using DrawingModel;
using System.Drawing;

namespace DrawingForm
{
    public class FormGraphicsAdapter : IGraphics
    {
        Graphics _graphics;

        public FormGraphicsAdapter(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void ClearAll()
        {
            // The canvas is automatically cleared when OnPaint() is invoked.
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, ( float )x1, ( float )y1, ( float )x2, ( float )y2);
        }
    }
}
