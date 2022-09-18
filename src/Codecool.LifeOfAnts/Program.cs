using System;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Simulation main class
    /// </summary>
    public static class Program
    {
        public static readonly Random Random = new();

        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
            Colony colony = new(12);
            colony.GenerateAnts(3, 3, 3);
            int timepassed = 0;
            do
            {
                colony.Display();
                colony.Update();
                timepassed++;
            } while (isRunning());
        }

        private static bool isRunning() => Console.ReadLine().ToLower() is not "q";
    }
}