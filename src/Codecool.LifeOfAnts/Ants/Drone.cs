using System;
using System.Runtime.CompilerServices;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Drone : Ant
    {
        private bool _isMating;
        private int _sexyTime = 10;
        private Drone partner;

        public Drone(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'D';

        public override void Act()
        {
            MoveToQueen(out Position queen, out Position drone);
            if (!IsAtSamePos(queen, drone))
            {
                return;
            }

            if (Colony.IsQueenInMood())
            {
                _isMating = true;
                partner = this;
            }

            if (_isMating && partner == this)
            {
                Mate();
            }
            else
            {
                KickAway();
            }
        }

        private void Mate()
        {
            switch (_sexyTime)
            {
                case > 0:
                    _sexyTime--;
                    break;

                default:
                    _isMating = false;
                    _sexyTime = 10;
                    KickAway();
                    return;
            }
        }

        private static bool IsAtSamePos(Position queen, Position drone) => queen.X == drone.X && queen.Y == drone.Y;

        private void MoveToQueen(out Position target, out Position drone)
        {
            target = Colony.GetQueenPos();
            drone = _position;
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
        }

        private void KickAway()
        {
            int rdm = Program.Random.Next(Colony.Width - 1);
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