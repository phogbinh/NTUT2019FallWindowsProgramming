using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InputInspectingElements.InputInspectors.Test
{
    public class TextBoxInspectorMock : TextBoxInspector
    {
        public TextBoxInspectorMock(string textData, int maxTextLengthData) : base(textData, maxTextLengthData)
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Returns true.
        /// </summary>
        public override bool IsValid()
        {
            return true;
        }

        /// <summary>
        /// Return an empty string.
        /// </summary>
        public override string GetError()
        {
            return "";
        }
    }

    [TestClass()]
    public class TextBoxInspectorTest
    {
        private const string MEMBER_VARIABLE_NAME_TEXT = "_text";
        private const string MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH = "_maxTextLength";
        private TextBoxInspector _textBoxInspector;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _textBoxInspector = new TextBoxInspectorMock(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER);
            _target = new PrivateObject(_textBoxInspector);
        }

        /// <summary>
        /// Tests the text box inspector.
        /// </summary>
        [TestMethod()]
        public void TestTextBoxInspector()
        {
            Assert.ThrowsException<ArgumentException>(() => new TextBoxInspectorMock(TestDefinition.DUMP_STRING, -1));
            var textBoxInspector = new TextBoxInspectorMock("text", 0);
            var target = new PrivateObject(textBoxInspector);
            Assert.AreEqual(( string )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_TEXT), "text");
            Assert.AreEqual(( int )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH), 0);
        }

        /// <summary>
        /// Tests the set.
        /// </summary>
        [TestMethod()]
        public void TestSet()
        {
            Assert.ThrowsException<ArgumentException>(() => _textBoxInspector.Set(TestDefinition.DUMP_STRING, -1));
            _textBoxInspector.Set("text", 0);
            Assert.AreEqual(( string )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_TEXT), "text");
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH), 0);
        }

        /// <summary>
        /// Tests the is valid.
        /// </summary>
        [TestMethod()]
        public void TestIsValid()
        {
            Assert.IsTrue(_textBoxInspector.IsValid());
        }

        /// <summary>
        /// Tests the get error.
        /// </summary>
        [TestMethod()]
        public void TestGetError()
        {
            Assert.AreEqual(_textBoxInspector.GetError(), "");
        }
    }
}