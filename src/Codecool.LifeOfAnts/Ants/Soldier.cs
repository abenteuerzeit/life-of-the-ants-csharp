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
            var nextDirection = Position.GetNextDirection(target);
            MoveInDirection(nextDirection);
        }
    }
}