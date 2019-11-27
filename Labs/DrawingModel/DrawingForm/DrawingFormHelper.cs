using DrawingModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm
{
    public class DrawingFormHelper
    {
        Model _model;
        public DrawingFormHelper(Model model)
        {
            _model = model;
        }

        public void Draw(Graphics graphics)
        {
            // OnPaint will instantiate a new Graphics object whenever it is invoked, thus FormGraphicsAdapter needs to be instantiated accordingly.
            _model.Draw(new FormGraphicsAdapter(graphics));
        }
    }
}
