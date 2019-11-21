using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InputInspectingElements.Test
{
    [TestClass()]
    public class InputInspectorTypeHelperTest
    {
        private PrivateType _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _target = new PrivateType(typeof(InputInspectorTypeHelper));
        }

        /// <summary>
        /// Tests the is in range of text box inspector types.
        /// </summary>
        [TestMethod()]
        public void TestIsInRangeOfTextBoxInspectorTypes()
        {
            Assert.IsFalse(InputInspectorTypeHelper.IsInRangeOfTextBoxInspectorTypes(0));
            Assert.IsFalse(InputInspectorTypeHelper.IsInRangeOfTextBoxInspectorTypes(8));
            for ( int flag = 1; flag <= 7; flag++ )
            {
                Assert.IsTrue(InputInspectorTypeHelper.IsInRangeOfTextBoxInspectorTypes(flag));
            }
        }

        /// <summary>
        /// Tests the is in range of drop down list inspector types.
        /// </summary>
        [TestMethod()]
        public void TestIsInRangeOfDropDownListInspectorTypes()
        {
            Assert.IsFalse(InputInspectorTypeHelper.IsInRangeOfDropDownListInspectorTypes(7));
            Assert.IsTrue(InputInspectorTypeHelper.IsInRangeOfDropDownListInspectorTypes(8));
            Assert.IsFalse(InputInspectorTypeHelper.IsInRangeOfDropDownListInspectorTypes(9));
        }

        /// <summary>
        /// Tests the is containing text box is mail flag.
        /// </summary>
        [TestMethod()]
        public void TestIsContainingTextBoxIsMailFlag()
        {
            Assert.IsTrue(InputInspectorTypeHelper.IsContainingTextBoxIsMailFlag(15));
            Assert.IsFalse(InputInspectorTypeHelper.IsContainingTextBoxIsMailFlag(10));
        }

        /// <summary>
        /// Tests the is containing text box is not empty flag.
        /// </summary>
        [TestMethod()]
        public void TestIsContainingTextBoxIsNotEmptyFlag()
        {
            Assert.IsTrue(InputInspectorTypeHelper.IsContainingTextBoxIsNotEmptyFlag(14));
            Assert.IsFalse(InputInspectorTypeHelper.IsContainingTextBoxIsNotEmptyFlag(9));
        }

        /// <summary>
        /// Tests the is containing text box is of full length flag.
        /// </summary>
        [TestMethod()]
        public void TestIsContainingTextBoxIsOfFullLengthFlag()
        {
            Assert.IsTrue(InputInspectorTypeHelper.IsContainingTextBoxIsOfFullLengthFlag(4));
            Assert.IsFalse(InputInspectorTypeHelper.IsContainingTextBoxIsOfFullLengthFlag(80));
        }

        /// <summary>
        /// Tests the is containing drop down list is selected flag.
        /// </summary>
        [TestMethod()]
        public void TestIsContainingDropDownListIsSelectedFlag()
        {
            Assert.IsTrue(InputInspectorTypeHelper.IsContainingDropDownListIsSelectedFlag(24));
            Assert.IsFalse(InputInspectorTypeHelper.IsContainingDropDownListIsSelectedFlag(16));
        }
    }
}