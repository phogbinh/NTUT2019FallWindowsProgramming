﻿using DualViewsDrawingModel.ShapeDrawers;
using DualViewsDrawingModelTest;
using DualViewsDrawingModelTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace DualViewsDrawingModel.CanvasDrawerStates.Test
{
    [TestClass()]
    public class CanvasDrawerDrawingStateTest
    {
        private const string MEMBER_VARIABLE_NAME_CANVAS_DRAWER = "_canvasDrawer";
        private const string MEMBER_VARIABLE_NAME_CURRENT_DRAWING_SHAPE_DRAWING_STARTING_POINT = "_currentDrawingShapeDrawingStartingPoint";
        private const string MEMBER_VARIABLE_NAME_CURRENT_DRAWING_SHAPE_HINT_SHAPE_DRAWER = "_currentDrawingShapeHintShapeDrawer";
        private CanvasDrawerDrawingState _canvasDrawerDrawingState;
        private PrivateObject _target;
        private CanvasDrawerMock _canvasDrawer;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinitions.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _canvasDrawer = new CanvasDrawerMock(new CommandsManager());
            _canvasDrawer.SetCurrentShapeDrawerType(ShapeDrawerType.Line);
            _canvasDrawerDrawingState = new CanvasDrawerDrawingState(_canvasDrawer, new Point());
            _target = new PrivateObject(_canvasDrawerDrawingState);
        }

        /// <summary>
        /// Tests the state of the canvas drawer drawing.
        /// </summary>
        [TestMethod()]
        public void TestCanvasDrawerDrawingState()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CanvasDrawerDrawingState(null, new Point()));
            Assert.ThrowsException<ArgumentNullException>(() => new CanvasDrawerDrawingState(new CanvasDrawerMock(new CommandsManager()), null));
            var canvasDrawer = new CanvasDrawerMock(new CommandsManager());
            canvasDrawer.SetCurrentShapeDrawerType(ShapeDrawerType.Rectangle);
            var currentDrawingShapeDrawingStartingPoint = new Point();
            var canvasDrawerDrawingState = new CanvasDrawerDrawingState(canvasDrawer, currentDrawingShapeDrawingStartingPoint);
            var target = new PrivateObject(canvasDrawerDrawingState);
            Assert.AreSame(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CANVAS_DRAWER), canvasDrawer);
            Assert.AreSame(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_DRAWING_SHAPE_DRAWING_STARTING_POINT), currentDrawingShapeDrawingStartingPoint);
            Assert.IsInstanceOfType(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_DRAWING_SHAPE_HINT_SHAPE_DRAWER), typeof(RectangleDrawer));
        }

        /// <summary>
        /// Tests the clear canvas.
        /// </summary>
        [TestMethod()]
        public void TestClearCanvas()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _canvasDrawerDrawingState.ClearCanvas());
        }

        /// <summary>
        /// Tests the handle canvas left mouse pressed.
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasLeftMousePressed()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _canvasDrawerDrawingState.HandleCanvasLeftMousePressed(new Point()));
        }

        /// <summary>
        /// Tests the handle canvas left mouse moved.
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasLeftMouseMoved()
        {
            _canvasDrawerDrawingState.HandleCanvasLeftMouseMoved(new Point());
            Assert.IsTrue(_canvasDrawer.IsCalledNotifyCanvasRefreshDrawRequested);
        }

        /// <summary>
        /// Tests the update current drawing shape hint.
        /// </summary>
        [TestMethod()]
        public void TestUpdateCurrentDrawingShapeHint()
        {
            const string MEMBER_FUNCTION_NAME_UPDATE_CURRENT_DRAWING_SHAPE_HINT = "UpdateCurrentDrawingShapeHint";
            var arguments = new object[] { null };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_UPDATE_CURRENT_DRAWING_SHAPE_HINT, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentNullException));
            var mousePosition = new Point();
            arguments = new object[] { mousePosition };
            _target.Invoke(MEMBER_FUNCTION_NAME_UPDATE_CURRENT_DRAWING_SHAPE_HINT, arguments);
            ShapeDrawer expectedCurrentDrawingShapeHintShapeDrawer = ( ShapeDrawer )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_DRAWING_SHAPE_HINT_SHAPE_DRAWER);
            Assert.AreSame(expectedCurrentDrawingShapeHintShapeDrawer.DrawingEndingPoint, mousePosition);
            Assert.IsTrue(_canvasDrawer.IsCalledNotifyCanvasRefreshDrawRequested);
        }

        /// <summary>
        /// Tests the handle canvas left mouse released.
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasLeftMouseReleased()
        {
            _canvasDrawerDrawingState.HandleCanvasLeftMouseReleased(new Point());
            Assert.IsTrue(_canvasDrawer.IsCalledCreateThenExecuteDrawingCommandToDrawShapeUsingCurrentShapeDrawer);
            Assert.IsTrue(_canvasDrawer.IsCalledNotifyDrawingEnded);
            Assert.IsTrue(_canvasDrawer.IsCalledSetCurrentState);
            Assert.IsInstanceOfType(_canvasDrawer.CurrentState, typeof(CanvasDrawerPointerState));
            Assert.IsTrue(_canvasDrawer.IsCalledNotifyCurrentShapeChanged);
        }

        /// <summary>
        /// Tests the end drawing.
        /// </summary>
        [TestMethod()]
        public void TestEndDrawing()
        {
            const string MEMBER_FUNCTION_NAME_END_DRAWING = "EndDrawing";
            var arguments = new object[] { new Point() };
            _target.Invoke(MEMBER_FUNCTION_NAME_END_DRAWING, arguments);
            Assert.IsTrue(_canvasDrawer.IsCalledCreateThenExecuteDrawingCommandToDrawShapeUsingCurrentShapeDrawer);
            Assert.IsTrue(_canvasDrawer.IsCalledNotifyDrawingEnded);
        }

        /// <summary>
        /// Tests the draw.
        /// </summary>
        [TestMethod()]
        public void TestDraw()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_DRAWING_SHAPE_HINT_SHAPE_DRAWER, new LineDrawer(new Point(), new Point()));
            var graphics = new GraphicsMock();
            _canvasDrawerDrawingState.Draw(graphics);
            Assert.IsTrue(graphics.IsCalledDrawLine);
        }

        /// <summary>
        /// Tests the get current shape rectangle.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentShapeRectangle()
        {
            Assert.IsNull(_canvasDrawerDrawingState.GetCurrentShapeRectangle());
        }

        /// <summary>
        /// Tests the type of the get current shape.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentShapeType()
        {
            Assert.AreEqual(_canvasDrawerDrawingState.GetCurrentShapeType(), ShapeDrawerType.None);
        }
    }
}