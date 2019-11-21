using InputInspectingElementsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace InputInspectingElements.Test
{
    [TestClass()]
    public class BinaryNumberHelperTest
    {
        private PrivateType _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _target = new PrivateType(typeof(BinaryNumberHelper));
        }

        /// <summary>
        /// Tests the is containing one binary number on flag.
        /// </summary>
        [TestMethod()]
        public void TestIsContainingOneBinaryNumberOnFlag()
        {
            Assert.ThrowsException<ArgumentException>(() => BinaryNumberHelper.IsContainingOneBinaryNumberOnFlag(TestDefinition.DUMP_INTEGER, 5));
            Assert.IsTrue(BinaryNumberHelper.IsContainingOneBinaryNumberOnFlag(5, 4));
            Assert.IsFalse(BinaryNumberHelper.IsContainingOneBinaryNumberOnFlag(9, 4));
        }

        /// <summary>
        /// Tests the is one binary number on flag.
        /// </summary>
        [TestMethod()]
        public void TestIsOneBinaryNumberOnFlag()
        {
            const string MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG = "IsOneBinaryNumberOnFlag";
            var arguments = new object[] { 0 };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentException));
            arguments = new object[] { 1 }; // flag binary format 001
            Assert.IsTrue(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            arguments = new object[] { 2 }; // flag binary format 010
            Assert.IsTrue(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            arguments = new object[] { 3 }; // flag binary format 011
            Assert.IsFalse(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            arguments = new object[] { 4 }; // flag binary format 100
            Assert.IsTrue(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            arguments = new object[] { 5 }; // flag binary format 101
            Assert.IsFalse(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            arguments = new object[] { 6 }; // flag binary format 110
            Assert.IsFalse(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
            arguments = new object[] { 7 }; // flag binary format 111
            Assert.IsFalse(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_ONE_BINARY_NUMBER_ON_FLAG, arguments));
        }

        /// <summary>
        /// Tests the is containing flag.
        /// </summary>
        [TestMethod()]
        public void TestIsContainingFlag()
        {
            const string MEMBER_FUNCTION_NAME_IS_CONTAINING_FLAG = "IsContainingFlag";
            var arguments = new object[] { 5, 2 };
            Assert.IsFalse(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_CONTAINING_FLAG, arguments));
            arguments = new object[] { 5, 4 };
            Assert.IsTrue(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_CONTAINING_FLAG, arguments));
            arguments = new object[] { 5, 1 };
            Assert.IsTrue(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_CONTAINING_FLAG, arguments));
            arguments = new object[] { 5, 5 };
            Assert.IsTrue(( bool )_target.InvokeStatic(MEMBER_FUNCTION_NAME_IS_CONTAINING_FLAG, arguments));
        }
    }
}