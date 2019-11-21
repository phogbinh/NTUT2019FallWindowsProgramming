using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputInspectingElements.InputInspectors.Test
{
    [TestClass()]
    public class TextBoxIsNotEmptyInspectorTest
    {
        private const string MEMBER_VARIABLE_NAME_TEXT = "_text";
        private const string MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH = "_maxTextLength";
        private TextBoxIsNotEmptyInspector _textBoxIsNotEmptyInspector;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _textBoxIsNotEmptyInspector = new TextBoxIsNotEmptyInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER);
            _target = new PrivateObject(_textBoxIsNotEmptyInspector);
        }

        /// <summary>
        /// Tests the text box is not empty inspector.
        /// </summary>
        [TestMethod()]
        public void TestTextBoxIsNotEmptyInspector()
        {
            var textBoxIsNotEmptyInspector = new TextBoxIsNotEmptyInspector("text", 0);
            var target = new PrivateObject(textBoxIsNotEmptyInspector);
            Assert.AreEqual(( string )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_TEXT), "text");
            Assert.AreEqual(( int )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH), 0);
        }

        /// <summary>
        /// Tests the is valid.
        /// </summary>
        [TestMethod()]
        public void TestIsValid()
        {
            _textBoxIsNotEmptyInspector.Set(null, TestDefinition.DUMP_INTEGER);
            Assert.IsFalse(_textBoxIsNotEmptyInspector.IsValid());
            _textBoxIsNotEmptyInspector.Set("", TestDefinition.DUMP_INTEGER);
            Assert.IsFalse(_textBoxIsNotEmptyInspector.IsValid());
            _textBoxIsNotEmptyInspector.Set("   ", TestDefinition.DUMP_INTEGER);
            Assert.IsFalse(_textBoxIsNotEmptyInspector.IsValid());
            _textBoxIsNotEmptyInspector.Set(" a", TestDefinition.DUMP_INTEGER);
            Assert.IsTrue(_textBoxIsNotEmptyInspector.IsValid());
        }

        /// <summary>
        /// Tests the get error.
        /// </summary>
        [TestMethod()]
        public void TestGetError()
        {
            Assert.AreEqual(_textBoxIsNotEmptyInspector.GetError(), "This field is empty.");
        }
    }
}