using Codecool.LifeOfAnts.Ants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Codecool.LifeOfAnts
{
    public class Colony
    {
        public int Width { get; }
        private readonly Queen _queen;
        private readonly List<Ant> _ants;
        private readonly Dictionary<Position, List<Ant>> _colonyMap;

        public Colony(int width)
        {
            Width = width;
            _ants = new List<Ant>();

            _queen = new Queen(new Position(width / 2, width / 2), this);
            _ants.Add(_queen);

            _colonyMap = new Dictionary<Position, List<Ant>>();
        }

        private List<Ant> GetAntsAtPoint(int x, int y) => _ants.Where(ant => ant.Position.X == x && ant.Position.Y == y).ToList();

        // Change x, y to Position;

        private Position GetRandomPosInColony() => new(Program.Random.Next(Width), Program.Random.Next(Width));

        // Move to Position class;

        public void Update() => _ants.ForEach(ant => ant.Act());

        public Position GetQueenPos() => _queen.Position;

        public bool IsQueenInMood() => _queen.IsReady();

        public void SetQueenPartner(Drone drone) => _queen.Partner = drone;

        // move to Queen class, set _isWaitingForDrone = false there in a method called SetPartner(Drone drone);
        public void ReleaseQueen()
        {
            _queen.ReleaseQueen();
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

            // AddAntToColony(Ant ant) { _ants.Add(ant); isPosInDict ? _colonyMap[pos].Add(ant) : _colonyMap.Add(pos, new List<Ant> { ant }); }
            foreach (Ant ant in _ants)//.Where(ant => !_colonyMap.ContainsKey(ant.Position)))
            {
                _colonyMap.Add(ant.Position, new List<Ant>() { ant });
            }
        }

        public void Display()
        {
            Console.Clear();
            StringBuilder sb = new();
            sb.Append("  ");
            for (int i = 0; i < Width; i++)
            {
                if (i < 10) sb.Append($"{i} ");
                else sb.Append($"{i}");
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
    }
}