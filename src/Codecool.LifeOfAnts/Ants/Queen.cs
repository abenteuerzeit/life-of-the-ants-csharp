using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Queen : Ant
    {
        public Queen(Position pos) : base(pos)
        {
        }

        public override char Symbol => 'Q';

        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}