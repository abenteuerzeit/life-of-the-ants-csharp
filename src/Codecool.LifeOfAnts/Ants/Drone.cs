using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Drone : Ant
    {
        public Drone(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 'd';

        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}