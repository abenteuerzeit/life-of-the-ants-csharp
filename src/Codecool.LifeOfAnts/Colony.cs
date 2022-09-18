using Codecool.LifeOfAnts.Ants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public int Width { get; }
        private Queen Queen;
        private List<Ant> _ants;
        private Dictionary<Position, List<Ant>> _colonyMap;

        public Colony(int width)
        {
            Width = width;
            _ants = new List<Ant>();

            Queen = new Queen(new Position(width / 2, width / 2));
            _ants.Add(Queen);

            _colonyMap = new Dictionary<Position, List<Ant>>();
        }

        public void GenerateAnts(int droneCount, int workerCount, int soldierCount)
        {
            for (int i = 0; i < droneCount; i++)
            {
                _ants.Add(new Drone(GetRandomPosInColony(), this));
            }

            for (int j = 0; j < workerCount; j++)
            {
                _ants.Add(new Worker(GetRandomPosInColony(), this));
            }

            for (int i = 0; i < soldierCount; i++)
            {
                _ants.Add(new Soldier(GetRandomPosInColony(), this));
            }
        }

        public void Display()
        {
            Console.Clear();
            var sb = new StringBuilder();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    var antsAtPoint = GetAntsAtPoint(x, y);
                }
            }
        }

        private List<Ant> GetAntsAtPoint(int x, int y)
        {
            var pos = new Position(x, y);
            if (!_colonyMap.ContainsKey(pos))
            {
                _colonyMap.Add(pos, new List<Ant>());
            }
            return _colonyMap[pos];
        }

        private Position GetRandomPosInColony()
        {
            return new Position(Program.Random.Next(Width), Program.Random.Next(Width));
        }
    }
}