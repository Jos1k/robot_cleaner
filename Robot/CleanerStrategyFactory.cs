using Robot.Strategies;
using System;
using System.Collections.Generic;

namespace Robot.Interfaces
{
    /// <summary>
    /// Factory for creating new strategies
    /// </summary>
    public class CleanerStrategyFactory : ICleanerStrategyFactory
    {
        private readonly Dictionary<int, HashSet<int>> _cleanedPlaces;

        /// <summary>
        /// Use cleaned items for initialization strategies
        /// </summary>
        /// <param name="cleanedPlaces">dictionary with items which will be changed by movement</param>
        public CleanerStrategyFactory(Dictionary<int, HashSet<int>> cleanedPlaces)
        {
            _cleanedPlaces = cleanedPlaces;
        }

        public BaseCleanerStrategy Construct(string direction)
        {
            switch (direction)
            {
                case "E": return new EastStrategy(_cleanedPlaces);
                case "W": return new WestStrategy(_cleanedPlaces);
                case "S": return new SouthStrategy(_cleanedPlaces);
                case "N": return new NorthStrategy(_cleanedPlaces);
                default: throw new ArgumentException("Unknown direction");
            }
        }
    }
}