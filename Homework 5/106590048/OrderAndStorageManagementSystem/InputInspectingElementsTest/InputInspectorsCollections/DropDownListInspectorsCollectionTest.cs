using InputInspectingElements.InputInspectors;
using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InputInspectingElements.InputInspectorsCollections.Test
{
    [TestClass()]
    public class DropDownListInspectorsCollectionTest
    {
        private DropDownListInspectorsCollection _dropDownListInspectorsCollection;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _dropDownListInspectorsCollection = new DropDownListInspectorsCollection();
            _target = new PrivateObject(_dropDownListInspectorsCollection);
        }

        /// <summary>
        /// Tests the add drop down list inspectors.
        /// </summary>
        [TestMethod()]
        public void TestAddDropDownListInspectors()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _dropDownListInspectorsCollection.AddDropDownListInspectors(7, TestDefinition.DUMP_INTEGER));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _dropDownListInspectorsCollection.AddDropDownListInspectors(9, TestDefinition.DUMP_INTEGER));
            _dropDownListInspectorsCollection.AddDropDownListInspectors(8, 5);
            Assert.AreEqual(( ( DropDownListIsSelectedInspector )_dropDownListInspectorsCollection.Inspectors[ 0 ] ).SelectedIndex, 5);
        }

        /// <summary>
        /// Tests the update.
        /// </summary>
        [TestMethod()]
        public void TestUpdate()
        {
            _dropDownListInspectorsCollection.Inspectors.AddRange(new List<IInputInspector> { new DropDownListIsSelectedInspector(0), new DropDownListIsSelectedInspector(-1) });
            _dropDownListInspectorsCollection.Update(1);
            Assert.AreEqual(( ( DropDownListIsSelectedInspector )_dropDownListInspectorsCollection.Inspectors[ 0 ] ).SelectedIndex, 1);
            Assert.AreEqual(( ( DropDownListIsSelectedInspector )_dropDownListInspectorsCollection.Inspectors[ 1 ] ).SelectedIndex, 1);
        }
    }
}