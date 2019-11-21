using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputInspectingElements.InputInspectors.Test
{
    [TestClass()]
    public class TextBoxIsOfFullLengthInspectorTest
    {
        private const string MEMBER_VARIABLE_NAME_TEXT = "_text";
        private const string MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH = "_maxTextLength";
        private TextBoxIsOfFullLengthInspector _textBoxIsOfFullLengthInspector;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _textBoxIsOfFullLengthInspector = new TextBoxIsOfFullLengthInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER);
            _target = new PrivateObject(_textBoxIsOfFullLengthInspector);
        }

        /// <summary>
        /// Tests the text box is of full length inspector.
        /// </summary>
        [TestMethod()]
        public void TestTextBoxIsOfFullLengthInspector()
        {
            var textBoxIsOfFullLengthInspector = new TextBoxIsOfFullLengthInspector("text", 0);
            var target = new PrivateObject(textBoxIsOfFullLengthInspector);
            Assert.AreEqual(( string )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_TEXT), "text");
            Assert.AreEqual(( int )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH), 0);
        }

        /// <summary>
        /// Tests the is valid.
        /// </summary>
        [TestMethod()]
        public void TestIsValid()
        {
            _textBoxIsOfFullLengthInspector.Set("abc", 4);
            Assert.IsFalse(_textBoxIsOfFullLengthInspector.IsValid());
            _textBoxIsOfFullLengthInspector.Set("abc", 2);
            Assert.IsFalse(_textBoxIsOfFullLengthInspector.IsValid());
            _textBoxIsOfFullLengthInspector.Set("abc", 3);
            Assert.IsTrue(_textBoxIsOfFullLengthInspector.IsValid());
        }

        /// <summary>
        /// Tests the get error.
        /// </summary>
        [TestMethod()]
        public void TestGetError()
        {
            Assert.AreEqual(_textBoxIsOfFullLengthInspector.GetError(), "Textbox is of insufficient length.");
        }
    }
}