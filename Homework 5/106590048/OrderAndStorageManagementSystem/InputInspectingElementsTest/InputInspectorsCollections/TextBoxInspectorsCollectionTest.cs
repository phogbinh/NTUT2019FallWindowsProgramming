using InputInspectingElements.InputInspectors;
using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace InputInspectingElements.InputInspectorsCollections.Test
{
    [TestClass()]
    public class TextBoxInspectorsCollectionTest
    {
        private TextBoxInspectorsCollection _textBoxInspectorsCollection;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _textBoxInspectorsCollection = new TextBoxInspectorsCollection();
            _target = new PrivateObject(_textBoxInspectorsCollection);
        }

        /// <summary>
        /// Tests the add text box inspectors.
        /// </summary>
        [TestMethod()]
        public void TestAddTextBoxInspectors()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _textBoxInspectorsCollection.AddTextBoxInspectors(0, TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _textBoxInspectorsCollection.AddTextBoxInspectors(8, TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER));
            _textBoxInspectorsCollection.AddTextBoxInspectors(1, "Anna", TestDefinition.DUMP_INTEGER); // flag binary format 001
            Assert.AreEqual(( ( TextBoxIsMailInspector )_textBoxInspectorsCollection.Inspectors[ 0 ] ).Text, "Anna");
            _textBoxInspectorsCollection.AddTextBoxInspectors(5, "Bill", 3); // flag binary format 101
            for ( int index = 1; index <= 2; index++ )
            {
                Assert.AreEqual(( ( TextBoxInspector )_textBoxInspectorsCollection.Inspectors[ index ] ).Text, "Bill");
                Assert.AreEqual(( ( TextBoxInspector )_textBoxInspectorsCollection.Inspectors[ index ] ).MaxTextLength, 3);
            }
            _textBoxInspectorsCollection.AddTextBoxInspectors(7, "Chris", 0); // flag binary format 111
            for ( int index = 3; index <= 5; index++ )
            {
                Assert.AreEqual(( ( TextBoxInspector )_textBoxInspectorsCollection.Inspectors[ index ] ).Text, "Chris");
                Assert.AreEqual(( ( TextBoxInspector )_textBoxInspectorsCollection.Inspectors[ index ] ).MaxTextLength, 0);
            }
        }

        /// <summary>
        /// Tests the update.
        /// </summary>
        [TestMethod()]
        public void TestUpdate()
        {
            _textBoxInspectorsCollection.Inspectors.AddRange(new List<IInputInspector> { new TextBoxIsMailInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER), new TextBoxIsNotEmptyInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER), new TextBoxIsOfFullLengthInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER) });
            _textBoxInspectorsCollection.Update("賀", 999);
            for ( int index = 0; index <= 2; index++ )
            {
                Assert.AreEqual(( ( TextBoxInspector )_textBoxInspectorsCollection.Inspectors[ index ] ).Text, "賀");
                Assert.AreEqual(( ( TextBoxInspector )_textBoxInspectorsCollection.Inspectors[ index ] ).MaxTextLength, 999);
            }
        }
    }
}