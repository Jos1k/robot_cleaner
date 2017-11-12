using System.Collections.Generic;
using System.Linq;
using Robot.Interfaces;
using System;
using Robot.Strategies;

namespace Robot
{
    public class RobotCleaner : IRobotCleaner
    {
        private readonly ICleanerStrategyFactory _strategyFactory;
        private Dictionary<int, HashSet<int>> _checkedPlaces = new Dictionary<int, HashSet<int>>();
        private int _currentRow, _currentCell;

        /// <summary>
        /// Constructor for building RobotCleaner. Accepts start coordinates for robot.
        /// </summary>
        /// <param name="startX">start position on X axis</param>
        /// <param name="startY">start position on Y axis</param>
        public RobotCleaner(int startX, int startY)
        {
            _strategyFactory = new CleanerStrategyFactory(_checkedPlaces);

            _currentRow = startX;
            _currentCell = startY;
            _checkedPlaces.Add(_currentRow, new HashSet<int>() { _currentCell });
        }

        public int Cleaned => _checkedPlaces.Sum(x => x.Value.Count());

        public void Move(string directory, int steps)
        {
            try
            {
                BaseCleanerStrategy strategy = _strategyFactory.Construct(directory);
                strategy.Move(steps, ref _currentRow, ref _currentCell);
            }
            catch (ArgumentException)
            {
                return;
            }

        }
    }
}
