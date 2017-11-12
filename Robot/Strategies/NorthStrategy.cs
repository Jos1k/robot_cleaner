using System.Collections.Generic;

namespace Robot.Strategies
{
    /// <summary>
    /// Strategy for moving to the North direction (upper from the start)
    /// </summary>
    public class NorthStrategy : BaseCleanerStrategy
    {
        public NorthStrategy(Dictionary<int, HashSet<int>> items) : base(items) {}

        protected override void ActionMove(int steps, ref int startRow, ref int startCell)
        {
            for (int i = 0; i < steps; i++)
            {
                startRow--;
                GetItemsRow(startRow).Add(startCell);
            }
        }
    }
}
