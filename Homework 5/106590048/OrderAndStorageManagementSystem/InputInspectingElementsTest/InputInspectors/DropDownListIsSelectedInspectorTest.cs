using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputInspectingElements.InputInspectors.Test
{
    [TestClass()]
    public class DropDownListIsSelectedInspectorTest
    {
        private const string MEMBER_VARIABLE_NAME_SELECTED_INDEX = "_selectedIndex";
        private DropDownListIsSelectedInspector _dropDownListIsSelectedInspector;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _dropDownListIsSelectedInspector = new DropDownListIsSelectedInspector(TestDefinition.DUMP_INTEGER);
            _target = new PrivateObject(_dropDownListIsSelectedInspector);
        }

        /// <summary>
        /// Tests the drop down list is selected inspector.
        /// </summary>
        [TestMethod()]
        public void TestDropDownListIsSelectedInspector()
        {
            var dropDownListIsSelectedInspector = new DropDownListIsSelectedInspector(2);
            var target = new PrivateObject(dropDownListIsSelectedInspector);
            Assert.AreEqual(( int )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_SELECTED_INDEX), 2);
        }

        /// <summary>
        /// Tests the is valid.
        /// </summary>
        [TestMethod()]
        public void TestIsValid()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_SELECTED_INDEX, -1);
            Assert.IsFalse(_dropDownListIsSelectedInspector.IsValid());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_SELECTED_INDEX, 0);
            Assert.IsTrue(_dropDownListIsSelectedInspector.IsValid());
        }

        /// <summary>
        /// Tests the set.
        /// </summary>
        [TestMethod()]
        public void TestSet()
        {
            _dropDownListIsSelectedInspector.Set(-5);
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_SELECTED_INDEX), -5);
        }

        /// <summary>
        /// Tests the get error.
        /// </summary>
        [TestMethod()]
        public void TestGetError()
        {
            Assert.AreEqual(( string )_dropDownListIsSelectedInspector.GetError(), "Drop-down list is not selected.");
        }
    }
}