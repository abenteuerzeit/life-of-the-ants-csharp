using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Worker : Ant
    {
        public Worker(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'W';

        public override void Act() => MoveInDirection((Direction)Program.Random.Next(4));
    }
}