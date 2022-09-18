using System;

namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : Ant
    {
        public Soldier(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override char Symbol => 's';

        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}