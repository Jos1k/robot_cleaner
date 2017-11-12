using Robot.Strategies;

namespace Robot.Interfaces
{
    /// <summary>
    /// Factory for constructing new move strategies
    /// </summary>
    public interface ICleanerStrategyFactory
    {
        /// <summary>
        /// Construct new instance of move strategy
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        BaseCleanerStrategy Construct(string direction);
    }
}
