﻿using System.Collections.Generic;

namespace Robot.Strategies
{
    /// <summary>
    /// Strategy for moving to the East direction (left from the start)
    /// </summary>
    public class WestStrategy : BaseCleanerStrategy
    {
        public WestStrategy(Dictionary<int, HashSet<int>> items) : base(items) {}

        protected override void ActionMove(int steps, ref int startRow, ref int startCell)
        {
            for (int i = 0; i < steps; i++)
            {
                startCell--;
                GetItemsRow(startRow).Add(startCell);
            }
        }
    }
}
