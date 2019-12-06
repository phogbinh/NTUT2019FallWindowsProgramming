﻿using DualViewsDrawingModel.Shapes;
using System;

namespace DualViewsDrawingModel.ShapeDrawers
{
    public class RectangleDrawer : ShapeDrawer
    {
        public RectangleDrawer(Point drawingStartingPointData, Point drawingEndingPointData) : base(drawingStartingPointData, drawingEndingPointData)
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        public override void Draw(IGraphics graphics)
        {
            if ( graphics == null )
            {
                throw new ArgumentNullException(Definitions.ERROR_GRAPHICS_IS_NULL);
            }
            graphics.Draw(GetRectangle());
        }

        /// <summary>
        /// Gets the rectangle.
        /// </summary>
        private Rectangle GetRectangle()
        {
            return new Rectangle(_drawingStartingPoint, _drawingEndingPoint);
        }
    }
}
