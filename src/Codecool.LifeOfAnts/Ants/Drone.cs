using System;

namespace Codecool.LifeOfAnts.Ants
{
    public class Drone : Ant
    {
        private bool _isMating;
        private int _sexyTime = 10;
        public static Drone _partner; // Save partner in Queen class

        public Drone(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'D';

        public override void Act()
        {
            var queenPosition = Colony.GetQueenPos();
            MoveToQueen(queenPosition);
            if (!IsAtSamePos(queenPosition, Position)) // move to Position
            {
                return;
            }
            if (Colony.IsQueenInMood())
            {
                _isMating = true;
                Mate();
                _partner = this; // Queen has a partner
            }
            else
            {
                KickAway();
            }
        }

        private void Mate()
        {
            Colony.SetQueenPartner(this);
            switch (_sexyTime)
            {
                case > 0:
                    _sexyTime--;
                    break;

                default:
                    _isMating = false;
                    _sexyTime = 10;
                    Colony.ReleaseQueen();
                    KickAway();
                    return;
            }
        }

        private static bool IsAtSamePos(Position queen, Position drone) => queen.X == drone.X && queen.Y == drone.Y;

        private void MoveToQueen(Position target)
        {
            var dronePosition = Position;
            var direction = Position.GetDirToTarget(target);
            MoveInDirection(direction);
        }

        private void KickAway()
        {
            int randomCoordinate = Program.Random.Next(Colony.Width - 1);
            Direction direction = (Direction)Program.Random.Next(Enum.GetNames(typeof(Direction)).Length);
            switch (direction)
            {
                case Direction.North:
                    Position = new Position(0, randomCoordinate);
                    break;

                case Direction.East:
                    Position = new Position(randomCoordinate, 0);
                    break;

                case Direction.South:
                    Position = new Position(Colony.Width - 1, randomCoordinate);
                    break;

                case Direction.West:
                    Position = new Position(randomCoordinate, Colony.Width - 1);
                    break;
            }
        }
    }
}