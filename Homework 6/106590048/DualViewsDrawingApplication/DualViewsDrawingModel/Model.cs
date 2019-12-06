﻿using System;

namespace DualViewsDrawingModel
{
    public class Model
    {
        public CanvasDrawer.CanvasRefreshDrawRequestedEventHandler CanvasRefreshDrawRequested
        {
            get
            {
                return _canvasManager.CanvasRefreshDrawRequested;
            }
            set
            {
                _canvasManager.CanvasRefreshDrawRequested = value;
            }
        }
        public double CanvasWidth
        {
            get
            {
                return _canvasManager.CanvasWidth;
            }
        }
        public double CanvasHeight
        {
            get
            {
                return _canvasManager.CanvasHeight;
            }
        }
        private const string ERROR_CANVAS_MANAGER_IS_NULL = "The given canvas manager is null.";
        private CanvasManager _canvasManager;

        public Model(CanvasManager canvasManagerData)
        {
            if ( canvasManagerData == null )
            {
                throw new ArgumentNullException(ERROR_CANVAS_MANAGER_IS_NULL);
            }
            _canvasManager = canvasManagerData;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize(double canvasWidth, double canvasHeight, ShapeDrawerType shapeDrawerType)
        {
            _canvasManager.Initialize(canvasWidth, canvasHeight, shapeDrawerType);
        }

        /// <summary>
        /// Sets the size of the canvas.
        /// </summary>
        public void SetCanvasSize(double canvasWidth, double canvasHeight)
        {
            _canvasManager.SetCanvasSize(canvasWidth, canvasHeight);
        }

        /// <summary>
        /// Sets the type of the current shape drawer.
        /// </summary>
        public void SetCurrentShapeDrawerType(ShapeDrawerType shapeDrawerType)
        {
            _canvasManager.SetCurrentShapeDrawerType(shapeDrawerType);
        }

        /// <summary>
        /// Clears the canvas.
        /// </summary>
        public void ClearCanvas()
        {
            _canvasManager.ClearCanvas();
        }

        /// <summary>
        /// Handles the canvas left mouse pressed.
        /// </summary>
        public void HandleCanvasLeftMousePressed(Point mousePosition)
        {
            _canvasManager.HandleCanvasLeftMousePressed(mousePosition);
        }

        /// <summary>
        /// Handles the canvas left mouse moved.
        /// </summary>
        public void HandleCanvasLeftMouseMoved(Point mousePosition)
        {
            _canvasManager.HandleCanvasLeftMouseMoved(mousePosition);
        }

        /// <summary>
        /// Handles the canvas left mouse released.
        /// </summary>
        public void HandleCanvasLeftMouseReleased(Point mousePosition)
        {
            _canvasManager.HandleCanvasLeftMouseReleased(mousePosition);
        }

        /// <summary>
        /// Redraw the canvas.
        /// </summary>
        public void RefreshDrawCanvas(IGraphics graphics)
        {
            _canvasManager.RefreshDrawCanvas(graphics);
        }
    }
}
