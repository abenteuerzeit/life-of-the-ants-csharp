using Codecool.LifeOfAnts.Ants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public int Width { get; }
        private readonly Queen Queen;
        private List<Ant> _ants;
        private readonly Dictionary<Position, List<Ant>> _colonyMap;

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

            for (int i = 0; i < workerCount; i++)
            {
                _ants.Add(new Worker(GetRandomPosInColony(), this));
            }

            for (int i = 0; i < soldierCount; i++)
            {
                _ants.Add(new Soldier(GetRandomPosInColony(), this));
            }

            foreach (Ant ant in _ants.Where(ant => !_colonyMap.ContainsKey(ant._position)))
            {
                _colonyMap.Add(ant._position, new List<Ant>() { ant });
            }
        }

        public void Display()
        {
            Console.Clear();
            StringBuilder sb = new();
            sb.Append("  ");
            for (int i = 0; i < Width; i++)
            {
                sb.Append($"{i} ");
            }
            sb.AppendLine();

            for (int x = 0; x < Width; x++)
            {
                sb.Append($"{x} ");
                for (int y = 0; y < Width; y++)
                {
                    List<Ant> antsAtPoint = GetAntsAtPoint(x, y);

                    switch (antsAtPoint.Count)
                    {
                        case 0:
                            sb.Append("  ");
                            break;

                        case 1:
                            sb.Append($"{antsAtPoint[0].Symbol} ");
                            break;

                        default:
                            sb.Append("X ");
                            break;
                    }
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb);
        }

        private List<Ant> GetAntsAtPoint(int x, int y)
        {
            var antsAtPoint = new List<Ant>();
            foreach (Ant ant in _ants)
            {
                if (ant._position.X == x && ant._position.Y == y)
                {
                    antsAtPoint.Add(ant);
                }
            }
            return antsAtPoint;
        }

        private Position GetRandomPosInColony()
        {
            return new Position(Program.Random.Next(Width), Program.Random.Next(Width));
        }
    }
}