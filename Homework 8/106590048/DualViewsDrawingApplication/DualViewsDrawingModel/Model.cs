﻿using DualViewsDrawingModel.Shapes;

namespace DualViewsDrawingModel
{
    public class Model
    {
        public CommandsManager.UndoRedoStacksChangedEventHandler UndoRedoStacksChanged
        {
            get
            {
                return _commandsManager.UndoRedoStacksChanged;
            }
            set
            {
                _commandsManager.UndoRedoStacksChanged = value;
            }
        }
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
        public CanvasDrawer.DrawingEndedEventHandler DrawingEnded
        {
            get
            {
                return _canvasManager.DrawingEnded;
            }
            set
            {
                _canvasManager.DrawingEnded = value;
            }
        }
        public CanvasDrawer.CurrentShapeChangedEventHandler CanvasCurrentShapeChanged
        {
            get
            {
                return _canvasManager.CurrentShapeChanged;
            }
            set
            {
                _canvasManager.CurrentShapeChanged = value;
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
        private CommandsManager _commandsManager;
        private CanvasManager _canvasManager;

        public Model()
        {
            _commandsManager = new CommandsManager();
            _canvasManager = new CanvasManager(_commandsManager);
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

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public void Undo()
        {
            _commandsManager.Undo();
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public void Redo()
        {
            _commandsManager.Redo();
        }

        /// <summary>
        /// Determines whether [is empty commands undo stack].
        /// </summary>
        public bool IsEmptyCommandsUndoStack()
        {
            return _commandsManager.IsEmptyUndoStack();
        }

        /// <summary>
        /// Determines whether [is empty commands redo stack].
        /// </summary>
        public bool IsEmptyCommandsRedoStack()
        {
            return _commandsManager.IsEmptyRedoStack();
        }

        /// <summary>
        /// Gets the canvas current shape rectangle.
        /// </summary>
        public Rectangle GetCanvasCurrentShapeRectangle()
        {
            return _canvasManager.GetCurrentShapeRectangle();
        }

        /// <summary>
        /// Gets the type of the canvas current shape.
        /// </summary>
        public ShapeDrawerType GetCanvasCurrentShapeType()
        {
            return _canvasManager.GetCurrentShapeType();
        }
    }
}
