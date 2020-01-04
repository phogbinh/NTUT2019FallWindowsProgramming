﻿using DualViewsDrawingModel;

namespace DualViewsDrawingModelTest.Mocks
{
    public class ButtonEnabledStatesManagerMock : ButtonEnabledStatesManager
    {
        public bool IsCalledInitialize
        {
            get; set;
        }
        public bool IsCalledHandleDrawingEnded
        {
            get; set;
        }
        public bool IsCalledHandleRectangleButtonClicked
        {
            get; set;
        }
        public bool IsCalledHandleLineButtonClicked
        {
            get; set;
        }
        public bool IsCalledHandleClearButtonClicked
        {
            get; set;
        }

        public ButtonEnabledStatesManagerMock() : base()
        {
            IsCalledInitialize = false;
            IsCalledHandleDrawingEnded = false;
            IsCalledHandleRectangleButtonClicked = false;
            IsCalledHandleLineButtonClicked = false;
            IsCalledHandleClearButtonClicked = false;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override void Initialize()
        {
            IsCalledInitialize = true;
        }

        /// <summary>
        /// Handles the drawing ended.
        /// </summary>
        public override void HandleDrawingEnded()
        {
            IsCalledHandleDrawingEnded = true;
        }

        /// <summary>
        /// Handles the rectangle button clicked.
        /// </summary>
        public override void HandleRectangleButtonClicked()
        {
            IsCalledHandleRectangleButtonClicked = true;
        }

        /// <summary>
        /// Handles the line button clicked.
        /// </summary>
        public override void HandleLineButtonClicked()
        {
            IsCalledHandleLineButtonClicked = true;
        }

        /// <summary>
        /// Handles the clear button clicked.
        /// </summary>
        public override void HandleClearButtonClicked()
        {
            IsCalledHandleClearButtonClicked = true;
        }
    }
}
