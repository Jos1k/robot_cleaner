using NUnit.Framework;
using Robot.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace Robot.Tests.Strategies
{
    [TestFixture, Description("Fixture for testing SouthStrategy for Robot Cleaner")]
    public class SouthStrategyTests
    {
        private readonly BaseCleanerStrategy _strategy;
        private Dictionary<int, HashSet<int>> _items;

        public SouthStrategyTests()
        {
            _items = new Dictionary<int, HashSet<int>>();
            _strategy = new SouthStrategy(_items); 
        }

        [Test]
        [Description("Check if current position was changed after the movement")]
        public void Move_Positive_StartRowChanged()
        {
            int startRow = 0, startCell = 0;
            int steps = 5;
            int startRowBefore = startRow;

            _strategy.Move(steps, ref startRow, ref startCell);

            Assert.AreEqual(startRow, startRowBefore + steps);
        }

        [Test]
        [Description("Check if new rows and cells (items) were checked by calling Move method")]
        public void Move_Positive_NewCleanedItemsExpected()
        {
            int startRow = 0, startCell = 0;
            int steps = 3;
            int startRowBefore = startRow;

            _strategy.Move(steps, ref startRow, ref startCell);

            int cellIndex = startCell;
            Assert.AreEqual(steps + 1, _items.Count);

            for(int i = startRowBefore; i <= startRow; i++)
            {
                HashSet<int> row;
                Assert.IsTrue(_items.TryGetValue(i, out row));
                Assert.IsTrue(row.Contains(startCell));
            }
        }

        [Test]
        [Description("Check if cleaned items result was merged after movement on the same cells (places) and rows")]
        public void Move_Positive_TwoTimesOnePlace_ExpectedMergedResult()
        {
            int firstTimeSteps = 2, firstTimeStartCell = 0, firstTimeStartRow = 0;
            int secondTimeSteps = 3, secondTimeStartCell = 2, secondTimeStartRow = 0;

            _strategy.Move(firstTimeSteps, ref firstTimeStartRow, ref firstTimeStartCell);
            _strategy.Move(secondTimeSteps, ref secondTimeStartRow, ref secondTimeStartCell);

            Assert.AreEqual(4, _items.Count);
            Assert.AreEqual(3, _items.Values.Count( x=> x.Count > 1));
        }

        [TearDown]
        public void CleanUp()
        {
            _items.Clear();
        }
    }
}
