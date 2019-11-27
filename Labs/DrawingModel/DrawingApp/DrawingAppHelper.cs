using DrawingModel;
using Windows.UI.Xaml.Controls;

namespace DrawingApp
{
    public class DrawingAppHelper
    {
        Model _model;
        IGraphics _graphics;

        public DrawingAppHelper(Model model, Canvas canvas)
        {
            _model = model;
            _graphics = new AppGraphicsAdapter(canvas);
        }

        public void Draw()
        {
            _model.Draw(_graphics);
        }
    }
}
