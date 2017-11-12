using System;
using System.Collections.Generic;

namespace Robot.Strategies
{
    /// <summary>
    /// Base funcionality for all strategies
    /// </summary>
    public abstract class BaseCleanerStrategy
    {
        protected Dictionary<int, HashSet<int>> _items;

        public BaseCleanerStrategy(Dictionary<int, HashSet<int>> items)
        {
            _items = items;
        }

        /// <summary>
        /// Method for make movement. Also is used for making basic prevalidation
        /// </summary>
        /// <param name="steps">amount of steps to be done</param>
        /// <param name="startRow">start movement point X axis</param>
        /// <param name="startCell">start movement point Y axis</param>
        public void Move(int steps, ref int startRow, ref int startCell)
        {
            if (steps < 0) throw new ArgumentException("Steps count could not have negative value!");

            GetItemsRow(startRow).Add(startCell);
            ActionMove(steps, ref startRow, ref startCell);
        }

        /// <summary>
        /// Exactly movement method. Every derived strategy need to implement own algorithm.
        /// </summary>
        /// <param name="steps">amount of steps to be done</param>
        /// <param name="startRow">start movement point X axis</param>
        /// <param name="startCell">start movement point Y axis</param>
        protected abstract void ActionMove(int steps, ref int startRow, ref int startCell);

        /// <summary>
        /// Get row of items by index. In case of absence - create new one and return it.
        /// </summary>
        /// <param name="rowIndex">index of the row</param>
        /// <returns>row of items</returns>
        protected HashSet<int> GetItemsRow(int rowIndex)
        {
            _items.TryAdd(rowIndex, new HashSet<int>());
            return _items[rowIndex];
        }
    }
}
