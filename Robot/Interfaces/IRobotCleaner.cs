namespace Robot.Interfaces
{
    /// <summary>
    /// Interface for RobotCleaner. Could be using for implement new types of RobotCleaner
    /// </summary>
    public interface IRobotCleaner
    {
        /// <summary>
        /// Use for Move functionality by direction and steps count
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="steps"></param>
        void Move(string directory, int steps);

        /// <summary>
        /// Return number of unique cleaned places
        /// </summary>
        int Cleaned { get; }
    }
}
