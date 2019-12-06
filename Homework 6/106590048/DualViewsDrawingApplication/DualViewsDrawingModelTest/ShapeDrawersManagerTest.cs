﻿using DualViewsDrawingModel.ShapeDrawers;
using DualViewsDrawingModelTest;
using DualViewsDrawingModelTest.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DualViewsDrawingModel.Test
{
    [TestClass()]
    public class ShapeDrawersManagerTest
    {
        private const string MEMBER_VARIABLE_NAME_SHAPE_DRAWERS = "_shapeDrawers";
        private ShapeDrawersManager _shapeDrawersManager;
        private PrivateObject _target;
        private List<ShapeDrawer> _shapeDrawers;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinitions.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _shapeDrawersManager = new ShapeDrawersManager();
            _target = new PrivateObject(_shapeDrawersManager);
            _shapeDrawers = ( List<ShapeDrawer> )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_SHAPE_DRAWERS);
        }

        /// <summary>
        /// Tests the shape drawers manager.
        /// </summary>
        [TestMethod()]
        public void TestShapeDrawersManager()
        {
            var shapeDrawersManager = new ShapeDrawersManager();
            var target = new PrivateObject(shapeDrawersManager);
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_SHAPE_DRAWERS));
        }

        /// <summary>
        /// Tests the add shape drawer.
        /// </summary>
        [TestMethod()]
        public void TestAddShapeDrawer()
        {
            const string SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_STARTING_POINT = "_drawingStartingPoint";
            const string SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_ENDING_POINT = "_drawingEndingPoint";
            var drawingStartingPoint = new Point();
            var drawingEndingPoint = new Point();
            _shapeDrawersManager.AddShapeDrawer(drawingStartingPoint, drawingEndingPoint, ShapeDrawerType.Rectangle);
            Assert.AreEqual(_shapeDrawers.Count, 1);
            ShapeDrawer expectedShapeDrawer = _shapeDrawers[ 0 ];
            var target = new PrivateObject(expectedShapeDrawer);
            Assert.AreSame(target.GetFieldOrProperty(SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_STARTING_POINT), drawingStartingPoint);
            Assert.AreSame(target.GetFieldOrProperty(SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_ENDING_POINT), drawingEndingPoint);
            Assert.IsInstanceOfType(expectedShapeDrawer, typeof(RectangleDrawer));
        }

        /// <summary>
        /// Tests the create shape drawer.
        /// </summary>
        [TestMethod()]
        public void TestCreateShapeDrawer()
        {
            const string SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_STARTING_POINT = "_drawingStartingPoint";
            const string SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_ENDING_POINT = "_drawingEndingPoint";
            var drawingStartingPoint = new Point();
            var drawingEndingPoint = new Point();
            ShapeDrawer expectedShapeDrawer = _shapeDrawersManager.CreateShapeDrawer(drawingStartingPoint, drawingEndingPoint, ShapeDrawerType.Line);
            var target = new PrivateObject(expectedShapeDrawer);
            Assert.AreSame(target.GetFieldOrProperty(SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_STARTING_POINT), drawingStartingPoint);
            Assert.AreSame(target.GetFieldOrProperty(SHAPE_DRAWER_MEMBER_VARIABLE_NAME_DRAWING_ENDING_POINT), drawingEndingPoint);
            Assert.IsInstanceOfType(expectedShapeDrawer, typeof(LineDrawer));
        }

        /// <summary>
        /// Tests the clear.
        /// </summary>
        [TestMethod()]
        public void TestClear()
        {
            _shapeDrawers.Add(new LineDrawer(new Point(), new Point()));
            _shapeDrawers.Add(new RectangleDrawer(new Point(), new Point()));
            _shapeDrawersManager.Clear();
            Assert.AreEqual(_shapeDrawers.Count, 0);
        }

        /// <summary>
        /// Tests the draw.
        /// </summary>
        [TestMethod()]
        public void TestDraw()
        {
            _shapeDrawers.Add(new LineDrawer(new Point(), new Point()));
            _shapeDrawers.Add(new RectangleDrawer(new Point(), new Point()));
            var graphics = new GraphicsMock();
            _shapeDrawersManager.Draw(graphics);
            Assert.IsTrue(graphics.IsCalledDrawLine);
            Assert.IsTrue(graphics.IsCalledDrawRectangle);
        }
    }
}