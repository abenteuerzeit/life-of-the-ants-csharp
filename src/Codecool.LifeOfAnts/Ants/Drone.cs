using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Drone : Ant
    {
        public Drone(Position pos, Colony colony) : base(pos)
        {
            Colony = colony;
        }

        public override char Symbol => throw new NotImplementedException();

        public Func<Position> GetRandomPosInColony { get; }

        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}