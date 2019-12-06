﻿using DualViewsDrawingModelTest;
using DualViewsDrawingModelTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DualViewsDrawingModel.Test
{
    [TestClass()]
    public class ModelTest
    {
        private const string MEMBER_VARIABLE_NAME_CANVAS_MANAGER = "_canvasManager";
        private CanvasManagerMock _canvasManager;
        private Model _model;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinitions.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _canvasManager = new CanvasManagerMock();
            _model = new Model(_canvasManager);
            _target = new PrivateObject(_model);
        }

        /// <summary>
        /// Tests the set property canvas refresh draw requested.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyCanvasRefreshDrawRequested()
        {
            _model.CanvasRefreshDrawRequested += () => { };
            Assert.IsNotNull(_model.CanvasRefreshDrawRequested);
        }

        /// <summary>
        /// Tests the width of the get property canvas.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyCanvasWidth()
        {
            Assert.AreEqual(_model.CanvasWidth, _canvasManager.CanvasWidth);
        }

        /// <summary>
        /// Tests the height of the get property canvas.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyCanvasHeight()
        {
            Assert.AreEqual(_model.CanvasHeight, _canvasManager.CanvasHeight);
        }

        /// <summary>
        /// Tests the model.
        /// </summary>
        [TestMethod()]
        public void TestModel()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Model(null));
            var canvasManager = new CanvasManagerMock();
            var model = new Model(canvasManager);
            var target = new PrivateObject(model);
            Assert.AreSame(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CANVAS_MANAGER), canvasManager);
        }

        /// <summary>
        /// Tests the initialize.
        /// </summary>
        [TestMethod()]
        public void TestInitialize()
        {
            _model.Initialize(TestDefinitions.DUMP_DOUBLE, TestDefinitions.DUMP_DOUBLE, ShapeDrawerType.None);
            Assert.IsTrue(_canvasManager.IsCalledInitialize);
        }

        /// <summary>
        /// Tests the size of the set canvas.
        /// </summary>
        [TestMethod()]
        public void TestSetCanvasSize()
        {
            _model.SetCanvasSize(TestDefinitions.DUMP_DOUBLE, TestDefinitions.DUMP_DOUBLE);
            Assert.IsTrue(_canvasManager.IsCalledSetCanvasSize);
        }

        /// <summary>
        /// Tests the type of the set current shape drawer.
        /// </summary>
        [TestMethod()]
        public void TestSetCurrentShapeDrawerType()
        {
            _model.SetCurrentShapeDrawerType(ShapeDrawerType.None);
            Assert.IsTrue(_canvasManager.IsCalledSetCurrentShapeDrawerType);
        }

        /// <summary>
        /// Tests the clear canvas.
        /// </summary>
        [TestMethod()]
        public void TestClearCanvas()
        {
            _model.ClearCanvas();
            Assert.IsTrue(_canvasManager.IsCalledClearCanvas);
        }

        /// <summary>
        /// Tests the handle canvas left mouse pressed.
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasLeftMousePressed()
        {
            _model.HandleCanvasLeftMousePressed(new Point());
            Assert.IsTrue(_canvasManager.IsCalledHandleCanvasLeftMousePressed);
        }

        /// <summary>
        /// Tests the handle canvas left mouse moved.
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasLeftMouseMoved()
        {
            _model.HandleCanvasLeftMouseMoved(new Point());
            Assert.IsTrue(_canvasManager.IsCalledHandleCanvasLeftMouseMoved);
        }

        /// <summary>
        /// Tests the handle canvas left mouse released.
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasLeftMouseReleased()
        {
            _model.HandleCanvasLeftMouseReleased(new Point());
            Assert.IsTrue(_canvasManager.IsCalledHandleCanvasLeftMouseReleased);
        }

        /// <summary>
        /// Tests the refresh draw canvas.
        /// </summary>
        [TestMethod()]
        public void TestRefreshDrawCanvas()
        {
            _model.RefreshDrawCanvas(new GraphicsMock());
            Assert.IsTrue(_canvasManager.IsCalledRefreshDrawCanvas);
        }
    }
}