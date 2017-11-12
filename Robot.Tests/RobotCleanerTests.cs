using NUnit.Framework;
using Robot.Interfaces;
using System;

namespace Robot.Tests
{
    [TestFixture,Description("Testing RobotCleaner. Cleaned and Move methods functionality")]
    public class RobotCleanerTests
    {
        IRobotCleaner _robotCleaner;

        [SetUp]
        public void SetupBeforeEach()
        {
            _robotCleaner = new RobotCleaner(0,0);
        }

        [TestCase(null,100, Description = "Check behavior if direction is null")]
        [TestCase("INCORRECT DIRECTION", 100, Description = "Check behavior if direction is unknown")]
        [TestCase("W", -10, Description = "Check behavior if steps is negative value")]
        [TestCase("E", 0, Description = "Check behavior if steps value is 0")]
        public void Move_IncorrectCommand_CleanedDontChange(string direction, int steps)
        {
            _robotCleaner.Move(direction, steps);
            Assert.AreEqual(1, _robotCleaner.Cleaned);
        }

        [TestCaseSource("Cleaned_TestCases")]
        [Description("Checks corectness of calculation of unique cleaned items by different movements")]
        public void Cleaned_Positive_CheckScenario(Tuple<string,int>[] movements, int exptectedCleanedPlaces)
        {
           foreach(var movement in movements)
            {
                _robotCleaner.Move(movement.Item1, movement.Item2);
            }

            Assert.AreEqual(exptectedCleanedPlaces, _robotCleaner.Cleaned);
        }

        private static object[] Cleaned_TestCases =
        {
            new object[] {
                new Tuple<string, int>[]{},
                1
            },
            new object[]
            {
                new Tuple<string, int>[]
                {
                    new Tuple<string, int>("E",2),
                    new Tuple<string, int>("N",1),
                },
                4
            },
            new object[]
            {
                new Tuple<string, int>[]
                {
                    new Tuple<string, int>("E",2),
                    new Tuple<string, int>("E",-2),
                    new Tuple<string, int>("N",1),
                    new Tuple<string, int>("TEST",10),
                },
                4
            },
            new object[]
            {
                new Tuple<string, int>[]
                {
                    new Tuple<string, int>("E",5),
                    new Tuple<string, int>("N",5),
                    new Tuple<string, int>("W",5),
                    new Tuple<string, int>("S",5),
                },
                20
            },
            new object[]
            {
                new Tuple<string, int>[]
                {
                    new Tuple<string, int>("E",1),
                    new Tuple<string, int>("W",1),
                    new Tuple<string, int>("N",1),
                    new Tuple<string, int>("S",1),
                },
                3
            }
        };
    }
}
