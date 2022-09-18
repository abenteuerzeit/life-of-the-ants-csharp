using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Drone : Ant
    {
        public Drone(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'D';

        public override void Act()
        {
            Position target = Colony.GetQueenPos();
            Position drone = _position;
            if (target.X > drone.X)
            {
                MoveInDirection(Direction.East);
            }
            else if (target.X < drone.X)
            {
                MoveInDirection(Direction.West);
            }
            else if (target.Y > drone.Y)
            {
                MoveInDirection(Direction.South);
            }
            else if (target.Y < drone.Y)
            {
                MoveInDirection(Direction.North);
            }

            if (target.X == drone.X && target.Y == drone.Y)
            {
                int rdm = Program.Random.Next(Colony.Width);
                switch (Program.Random.Next(4))
                {
                    case 0:
                        _position = new Position(0, rdm);
                        break;

                    case 1:
                        _position = new Position(rdm, 0);
                        break;

                    case 2:
                        _position = new Position(Colony.Width - 1, rdm);
                        break;

                    case 3:
                        _position = new Position(rdm, Colony.Width - 1);
                        break;
                }
            }
        }
    }
}