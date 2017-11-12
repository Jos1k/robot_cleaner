using NUnit.Framework;
using Robot.Interfaces;
using Robot.Strategies;
using System;
using System.Collections.Generic;

namespace Robot.Tests
{
    [TestFixture, Description("Fixture for testing strategy factory by direction parameter")]
    public class CleanerStrategyFactoryTests
    {
        private readonly ICleanerStrategyFactory _strategyFactory;

        public CleanerStrategyFactoryTests()
        {
            _strategyFactory = new CleanerStrategyFactory(new Dictionary<int, HashSet<int>>());
        }

        [TestCase("N", typeof(NorthStrategy))]
        [TestCase("E", typeof(EastStrategy))]
        [TestCase("S", typeof(SouthStrategy))]
        [TestCase("W", typeof(WestStrategy))]
        [Description("Check corectness of created strategies by direction")]
        public void CheckCreatedTypes_Valid(string direction, Type strategyFactoryType)
        {
            var actualStrategy = _strategyFactory.Construct(direction);
            Assert.IsInstanceOf(strategyFactoryType, actualStrategy);
        }

        [TestCase("NOT EXISTING")]
        [Description("Check if factory throws exception in case of unknown direction")]
        public void CheckCreatedTypes_Invalid_ExceptionExptected(string direction)
        {
            Assert.That(() => 
                _strategyFactory.Construct(direction), 
                Throws.ArgumentException,
                $"Strategy for direction {direction} not found!");
        }
    }
}
