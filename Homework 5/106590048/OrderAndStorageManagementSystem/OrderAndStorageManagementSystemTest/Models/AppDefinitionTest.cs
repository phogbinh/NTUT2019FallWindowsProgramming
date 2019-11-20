using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;

namespace OrderAndStorageManagementSystem.Models.Test
{
    [TestClass()]
    public class AppDefinitionTest
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.DEPLOYMENT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            /* Body intentionally empty */
        }

        /// <summary>
        /// Tests the index of the get human.
        /// </summary>
        [TestMethod()]
        public void TestGetHumanIndex()
        {
            Assert.ThrowsException<ArgumentException>(() => AppDefinition.GetHumanIndex(-1));
            Assert.AreEqual(AppDefinition.GetHumanIndex(0), 1);
            Assert.AreEqual(AppDefinition.GetHumanIndex(5), 6);
        }

        /// <summary>
        /// Tests the is in interval range.
        /// </summary>
        [TestMethod()]
        public void TestIsInIntervalRange()
        {
            Assert.IsTrue(AppDefinition.IsInIntervalRange(5, 4, 6));
            Assert.IsFalse(AppDefinition.IsInIntervalRange(3, 4, 6));
            Assert.IsFalse(AppDefinition.IsInIntervalRange(5, 6, 4));
        }
    }
}