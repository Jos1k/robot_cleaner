using NUnit.Framework;
using Robot.Strategies;
using System;
using System.Collections.Generic;

namespace Robot.Tests
{
    [TestFixture, Description("Fixture for testing Base functionality for robot cleaner strategies")]
    public class BaseCleanerStrategyTests
    {
        private readonly DoNothingCleanerStrategy _baseCleanerStrategy;
        private Dictionary<int, HashSet<int>> _items;

        public BaseCleanerStrategyTests()
        {
            _items = new Dictionary<int, HashSet<int>>();
            _baseCleanerStrategy = new DoNothingCleanerStrategy(_items);
        }

        [Test]
        [Description("Check if GetItemsRow return new row in case of absence")]
        public void GetItemsRow_Valid_ReturnNewRow()
        {
            Assert.IsNotNull(_baseCleanerStrategy.GetItemsRow(new Random().Next()));
        }

        [Test]
        [Description("Check if GetItemsRow return existing row in case of presence")]
        public void GetItemsRow_Valid_ReturnExistingRow()
        {
            var firstTimeResult = _baseCleanerStrategy.GetItemsRow(5);
            firstTimeResult.Add(new Random().Next());
            var secondTimeResult = _baseCleanerStrategy.GetItemsRow(5);

            Assert.AreEqual(firstTimeResult.Count, secondTimeResult.Count);
        }

        [Test]
        [Description("Check count of created rows by twice calling GetItemsRow with different parameters")]
        public void GetItemsRow_Valid_CreatesNewRows()
        {
            _baseCleanerStrategy.GetItemsRow(0);
            _baseCleanerStrategy.GetItemsRow(1);

            Assert.AreEqual(2, _items.Count);
        }

        [Test]
        [Description("Check count of created rows by twice calling GetItemsRow with same parameters")]
        public void GetItemsRows_Valid_GetExisting()
        {
            _baseCleanerStrategy.GetItemsRow(1);
            _baseCleanerStrategy.GetItemsRow(1);

            Assert.AreEqual(1, _items.Count);
        }

        [Test]
        [Description("Check if Move method throw exception in case of incorrect parameter: negative steps count")]
        public void Move_Negative_NegativeStepsCount_ExpectedArgumentException()
        {
            int startRow = 0, startCell = 0;
            int steps = -5;

            Assert.That(() => _baseCleanerStrategy.Move(steps, ref startRow, ref startCell),
                Throws.ArgumentException);

        }

        [TearDown]
        public void Cleanup()
        {
            _items.Clear();
        }

        /// <summary>
        /// Class for testing methods in abstract class
        /// </summary>
        private class DoNothingCleanerStrategy : BaseCleanerStrategy
        {
            public DoNothingCleanerStrategy(Dictionary<int, HashSet<int>> items) 
                : base(items) {}

            protected override void ActionMove(int steps, ref int startRow, ref int startCell){}

            /// <summary>
            /// Hiding base protected method and make it public
            /// </summary>
            /// <param name="rowIndex"></param>
            /// <returns>Items row</returns>
            public new HashSet<int> GetItemsRow(int rowIndex)
            {
                return base.GetItemsRow(rowIndex);
            }
        }
    }
}
