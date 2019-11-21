using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputInspectingElements.InputInspectors.Test
{
    [TestClass()]
    public class TextBoxIsMailInspectorTest
    {
        private const string MEMBER_VARIABLE_NAME_TEXT = "_text";
        private const string MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH = "_maxTextLength";
        private TextBoxIsMailInspector _textBoxIsMailInspector;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _textBoxIsMailInspector = new TextBoxIsMailInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER);
            _target = new PrivateObject(_textBoxIsMailInspector);
        }

        /// <summary>
        /// Tests the text box is mail inspector.
        /// </summary>
        [TestMethod()]
        public void TestTextBoxIsMailInspector()
        {
            var textBoxIsMailInspector = new TextBoxIsMailInspector("text", 0);
            var target = new PrivateObject(textBoxIsMailInspector);
            Assert.AreEqual(( string )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_TEXT), "text");
            Assert.AreEqual(( int )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MAX_TEXT_LENGTH), 0);
        }

        /// <summary>
        /// Tests the is valid.
        /// </summary>
        [TestMethod()]
        public void TestIsValid()
        {
            _textBoxIsMailInspector.Set("a", TestDefinition.DUMP_INTEGER);
            Assert.IsFalse(_textBoxIsMailInspector.IsValid());
            _textBoxIsMailInspector.Set("a@a", TestDefinition.DUMP_INTEGER);
            Assert.IsTrue(_textBoxIsMailInspector.IsValid());
        }

        /// <summary>
        /// Tests the get error.
        /// </summary>
        [TestMethod()]
        public void TestGetError()
        {
            Assert.AreEqual(_textBoxIsMailInspector.GetError(), "Textbox is not an email.");
        }
    }
}