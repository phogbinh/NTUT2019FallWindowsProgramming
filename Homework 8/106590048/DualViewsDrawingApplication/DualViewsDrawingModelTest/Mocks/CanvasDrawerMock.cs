﻿using DualViewsDrawingModel;
using DualViewsDrawingModel.CanvasDrawerStates;
using DualViewsDrawingModel.ShapeDrawers;
using DualViewsDrawingModel.Shapes;

namespace DualViewsDrawingModelTest.Mocks
{
    public class CanvasDrawerMock : CanvasDrawer
    {
        public bool IsCalledInitialize
        {
            get; set;
        }
        public bool IsCalledClearShapeDrawersManager
        {
            get; set;
        }
        public bool IsCalledSetCurrentShapeDrawerType
        {
            get; set;
        }
        public bool IsCalledClearCanvas
        {
            get; set;
        }
        public bool IsCalledHandleCanvasLeftMousePressed
        {
            get; set;
        }
        public bool IsCalledHandleCanvasLeftMouseMoved
        {
            get; set;
        }
        public bool IsCalledHandleCanvasLeftMouseReleased
        {
            get; set;
        }
        public bool IsCalledRefreshDrawCanvas
        {
            get; set;
        }
        public bool IsCalledSetCurrentState
        {
            get; set;
        }
        public bool IsCalledNotifyCanvasRefreshDrawRequested
        {
            get; set;
        }
        public bool IsCalledNotifyDrawingEnded
        {
            get; set;
        }
        public bool IsCalledCreateThenExecuteDrawingCommandToDrawShapeUsingCurrentShapeDrawer
        {
            get; set;
        }
        public bool IsCalledCreateThenExecuteResizingCommand
        {
            get; set;
        }
        public bool IsCalledGetSelectedShapeShapeDrawer
        {
            get; set;
        }
        public bool IsCalledGetSelectedResizingShapeDrawer
        {
            get; set;
        }
        public bool IsCalledNotifyCurrentShapeChanged
        {
            get; set;
        }
        public bool IsCalledGetCurrentShapeRectangle
        {
            get; set;
        }
        public bool IsCalledGetCurrentShapeType
        {
            get; set;
        }
        public ICanvasDrawerState CurrentState
        {
            get; set;
        }

        public CanvasDrawerMock(CommandsManager commandsManagerData) : base(commandsManagerData)
        {
            IsCalledInitialize = false;
            IsCalledClearShapeDrawersManager = false;
            IsCalledSetCurrentShapeDrawerType = false;
            IsCalledClearCanvas = false;
            IsCalledHandleCanvasLeftMousePressed = false;
            IsCalledHandleCanvasLeftMouseMoved = false;
            IsCalledHandleCanvasLeftMouseReleased = false;
            IsCalledRefreshDrawCanvas = false;
            IsCalledSetCurrentState = false;
            IsCalledNotifyCanvasRefreshDrawRequested = false;
            IsCalledNotifyDrawingEnded = false;
            IsCalledCreateThenExecuteDrawingCommandToDrawShapeUsingCurrentShapeDrawer = false;
            IsCalledCreateThenExecuteResizingCommand = false;
            IsCalledGetSelectedShapeShapeDrawer = false;
            IsCalledGetSelectedResizingShapeDrawer = false;
            IsCalledNotifyCurrentShapeChanged = false;
            IsCalledGetCurrentShapeRectangle = false;
            IsCalledGetCurrentShapeType = false;
            CurrentState = null;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize(ShapeDrawerType shapeDrawerType)
        {
            IsCalledInitialize = true;
        }

        /// <summary>
        /// Clears the shape drawers manager.
        /// </summary>
        public override void ClearShapeDrawersManager()
        {
            IsCalledClearShapeDrawersManager = true;
        }

        /// <summary>
        /// Sets the type of the current drawing shape.
        /// </summary>
        public override void SetCurrentShapeDrawerType(ShapeDrawerType drawingShapeType)
        {
            IsCalledSetCurrentShapeDrawerType = true;
            _currentShapeDrawerType = drawingShapeType;
        }

        /// <summary>
        /// Clears the canvas.
        /// </summary>
        public override void ClearCanvas()
        {
            IsCalledClearCanvas = true;
        }

        /// <summary>
        /// Handles the canvas left mouse pressed.
        /// </summary>
        public override void HandleCanvasLeftMousePressed(Point mousePosition)
        {
            IsCalledHandleCanvasLeftMousePressed = true;
        }

        /// <summary>
        /// Handles the canvas left mouse moved.
        /// </summary>
        public override void HandleCanvasLeftMouseMoved(Point mousePosition)
        {
            IsCalledHandleCanvasLeftMouseMoved = true;
        }

        /// <summary>
        /// Handles the canvas left mouse released.
        /// </summary>
        public override void HandleCanvasLeftMouseReleased(Point mousePosition)
        {
            IsCalledHandleCanvasLeftMouseReleased = true;
        }

        /// <summary>
        /// Redraw the canvas.
        /// </summary>
        public override void RefreshDrawCanvas(IGraphics graphics)
        {
            IsCalledRefreshDrawCanvas = true;
        }

        /// <summary>
        /// Sets the state of the current.
        /// </summary>
        public override void SetCurrentState(ICanvasDrawerState value)
        {
            IsCalledSetCurrentState = true;
            CurrentState = value;
        }

        /// <summary>
        /// Notifies the canvas refresh draw requested.
        /// </summary>
        public override void NotifyCanvasRefreshDrawRequested()
        {
            IsCalledNotifyCanvasRefreshDrawRequested = true;
        }

        /// <summary>
        /// Notifies the canvas refresh draw requested.
        /// </summary>
        public override void NotifyDrawingEnded()
        {
            IsCalledNotifyDrawingEnded = true;
        }

        /// <summary>
        /// Creates then executes the drawing command to draw shape using current shape drawer.
        /// </summary>
        public override void CreateThenExecuteDrawingCommandToDrawShapeUsingCurrentShapeDrawer(Point drawingStartingPoint, Point drawingEndingPoint)
        {
            IsCalledCreateThenExecuteDrawingCommandToDrawShapeUsingCurrentShapeDrawer = true;
        }

        /// <summary>
        /// Creates the then execute resizing command.
        /// </summary>
        public override void CreateThenExecuteResizingCommand(ShapeDrawer shapeDrawer, Point oldDrawingEndingPoint, Point newDrawingEndingPoint)
        {
            IsCalledCreateThenExecuteResizingCommand = true;
        }

        /// <summary>
        /// Gets the selected shape shape drawer.
        /// </summary>
        public override ShapeDrawer GetSelectedShapeShapeDrawer(Point leftMousePressedPosition)
        {
            IsCalledGetSelectedShapeShapeDrawer = true;
            return null;
        }

        /// <summary>
        /// Gets the selected resizing shape drawer.
        /// </summary>
        public override ShapeDrawer GetSelectedResizingShapeDrawer(Point leftMousePressedPosition)
        {
            IsCalledGetSelectedResizingShapeDrawer = true;
            return null;
        }

        /// <summary>
        /// Notifies the current shape changed.
        /// </summary>
        public override void NotifyCurrentShapeChanged()
        {
            IsCalledNotifyCurrentShapeChanged = true;
        }

        /// <summary>
        /// Gets the current shape rectangle.
        /// </summary>
        public override Rectangle GetCurrentShapeRectangle()
        {
            IsCalledGetCurrentShapeRectangle = true;
            return null;
        }

        /// <summary>
        /// Gets the type of the current shape.
        /// </summary>
        public override ShapeDrawerType GetCurrentShapeType()
        {
            IsCalledGetCurrentShapeType = true;
            return ShapeDrawerType.None;
        }
    }
}
