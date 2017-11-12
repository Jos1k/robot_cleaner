using NUnit.Framework;
using Robot.Strategies;
using System.Collections.Generic;

namespace Robot.Tests.Strategies
{
    [TestFixture, Description("Fixture for testing EastStrategy for Robot Cleaner")]
    public class EastStrategyTests
    {
        private readonly BaseCleanerStrategy _strategy;
        private Dictionary<int, HashSet<int>> _items;

        public EastStrategyTests()
        {
            _items = new Dictionary<int, HashSet<int>>();
            _strategy = new EastStrategy(_items); 
        }

        [Test]
        [Description("Check if current position was changed after the movement")]
        public void Move_Positive_StartCellChanged()
        {
            int startRow = 0, startCell = 0;
            int steps = 5;
            int startCellBefore = startCell;

            _strategy.Move(steps, ref startRow, ref startCell);

            Assert.AreEqual(startCell, startCellBefore + steps);
        }

        [Test]
        [Description("Check if correct items was checked as cleaned after Move method of strategy")]
        public void Move_Positive_NewCleanedItemsExpected()
        {
            int startRow = 0, startCell = 0;
            int steps = 3;
            int startCellBefore = startCell;

            _strategy.Move(steps, ref startRow, ref startCell);

            HashSet<int> currentRow = _items[startRow];
            Assert.AreEqual(steps + 1, currentRow.Count);
            for(int i = startCellBefore; i <= startCell; i++)
            {
                Assert.IsTrue(currentRow.Contains(i));
            }
        }

        [Test]
        [Description("Check if cleaned items result was merged after movement on the same cells (places)")]
        public void Move_Positive_TwoTimesOnePlace_ExpectedMergedResult()
        {
            int startRow = 0;
            int firstTimeSteps = 2, firstTimeStartCell = 0;
            int secondTimeSteps = 4, secondTimeStartCell = -2;

            _strategy.Move(firstTimeSteps, ref startRow, ref firstTimeStartCell);
            _strategy.Move(secondTimeSteps, ref startRow, ref secondTimeStartCell);

            Assert.AreEqual(5, _items[startRow].Count);
        }

        [TearDown]
        public void CleanUp()
        {
            _items.Clear();
        }
    }
}
