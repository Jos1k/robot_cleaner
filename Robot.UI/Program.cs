using Robot.Interfaces;
using System;
using System.Collections.Generic;

namespace Robot.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<Tuple<string, int>> movements = new List<Tuple<string, int>>(); 
            int commandsCount = int.Parse(Console.ReadLine());

            string[] startPos = Console.ReadLine().Split(' ');

            IRobotCleaner robotCleaner = new RobotCleaner(
                startX: int.Parse(startPos[0]), 
                startY: int.Parse(startPos[1]));
            
            for(int i = 0; i < commandsCount; i++)
            {
                string[] newMovement = Console.ReadLine().Split(' ');
                robotCleaner.Move(newMovement[0], int.Parse(newMovement[1]));
            }

            Console.WriteLine($"=> Cleaned: {robotCleaner.Cleaned}");
            Console.ReadKey();
        }
    }
}
