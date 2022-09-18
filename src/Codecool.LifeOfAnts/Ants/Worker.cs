using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Worker : Ant
    {
        public Worker(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'w';

        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}