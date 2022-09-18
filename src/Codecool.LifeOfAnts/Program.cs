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
            Console.WriteLine("Hello, Ants!");
            Colony colony = new(12);
            colony.GenerateAnts(3, 3, 3);
            colony.Display();
            while (true)
            {
                colony.Update();
                colony.Display();
                Console.ReadKey();
            }
        }
    }
}