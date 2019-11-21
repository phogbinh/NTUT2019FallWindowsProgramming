using InputInspectingElements.InputInspectors;
using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace InputInspectingElements.InputInspectorsCollections.Test
{
    [TestClass()]
    public class InputInspectorsCollectionTest
    {
        private const string MEMBER_VARIABLE_NAME_INSPECTORS = "_inspectors";
        private InputInspectorsCollection _inputInspectorsCollection;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _inputInspectorsCollection = new InputInspectorsCollection();
            _target = new PrivateObject(_inputInspectorsCollection);
        }

        /// <summary>
        /// Tests the input inspectors collection.
        /// </summary>
        [TestMethod()]
        public void TestInputInspectorsCollection()
        {
            var inputInspectorsCollection = new InputInspectorsCollection();
            var target = new PrivateObject(inputInspectorsCollection);
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_INSPECTORS));
        }

        /// <summary>
        /// Tests the are all valid input inspectors.
        /// </summary>
        [TestMethod()]
        public void TestAreAllValidInputInspectors()
        {
            List<IInputInspector> inspectors = new List<IInputInspector>() { new TextBoxIsNotEmptyInspector("", TestDefinition.DUMP_INTEGER), new DropDownListIsSelectedInspector(TestDefinition.DUMP_INTEGER) };
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_INSPECTORS, inspectors);
            Assert.IsFalse(_inputInspectorsCollection.AreAllValidInputInspectors());
            inspectors = new List<IInputInspector>() { new TextBoxIsNotEmptyInspector("aaa", TestDefinition.DUMP_INTEGER), new DropDownListIsSelectedInspector(0) };
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_INSPECTORS, inspectors);
            Assert.IsTrue(_inputInspectorsCollection.AreAllValidInputInspectors());
        }

        /// <summary>
        /// Tests the get error.
        /// </summary>
        [TestMethod()]
        public void TestGetError()
        {
            List<IInputInspector> inspectors = new List<IInputInspector>() { new TextBoxIsNotEmptyInspector("", TestDefinition.DUMP_INTEGER), new DropDownListIsSelectedInspector(TestDefinition.DUMP_INTEGER) };
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_INSPECTORS, inspectors);
            Assert.AreEqual(_inputInspectorsCollection.GetError(), "This field is empty.");
            inspectors = new List<IInputInspector>() { new TextBoxIsNotEmptyInspector("aaa", TestDefinition.DUMP_INTEGER), new DropDownListIsSelectedInspector(0) };
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_INSPECTORS, inspectors);
            Assert.AreEqual(_inputInspectorsCollection.GetError(), "");
        }

        /// <summary>
        /// Tests the get inspector error.
        /// </summary>
        [TestMethod()]
        public void TestGetInspectorError()
        {
            const string MEMBER_FUNCTION_NAME_GET_INSPECTOR_ERROR = "GetInspectorError";
            var arguments = new object[] { null };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_GET_INSPECTOR_ERROR, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentNullException));
            arguments = new object[] { new DropDownListIsSelectedInspector(TestDefinition.DUMP_INTEGER) };
            Assert.AreEqual(( string )_target.Invoke(MEMBER_FUNCTION_NAME_GET_INSPECTOR_ERROR, arguments), "Drop-down list is not selected.");
        }

        /// <summary>
        /// Tests the add input inspectors list.
        /// </summary>
        [TestMethod()]
        public void TestAddInputInspectorsList()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _inputInspectorsCollection.AddInputInspectorsList(null));
            List<IInputInspector> inspectors = new List<IInputInspector>() { new TextBoxIsNotEmptyInspector(TestDefinition.DUMP_STRING, TestDefinition.DUMP_INTEGER), new DropDownListIsSelectedInspector(TestDefinition.DUMP_INTEGER) };
            _inputInspectorsCollection.AddInputInspectorsList(inspectors);
            List<IInputInspector> expectedInspectors = ( List<IInputInspector> )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_INSPECTORS);
            Assert.AreSame(expectedInspectors[ 0 ], inspectors[ 0 ]);
            Assert.AreSame(expectedInspectors[ 1 ], inspectors[ 1 ]);
            Assert.AreEqual(expectedInspectors.Count, 2);
        }
    }
}