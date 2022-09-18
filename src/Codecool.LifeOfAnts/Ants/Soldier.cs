using System;

namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : Ant
    {
        public Soldier(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'S';

        public override void Act()
        {
            Direction target = (Direction)Program.Random.Next(0, 4);
            MoveInDirection(target);
            switch (target)
            {
                case Direction.North:
                    MoveInDirection(Direction.West);
                    break;

                case Direction.South:
                    MoveInDirection(Direction.East);
                    break;

                case Direction.West:
                    MoveInDirection(Direction.South);
                    break;

                case Direction.East:
                    MoveInDirection(Direction.North);
                    break;
            }
        }
    }
}