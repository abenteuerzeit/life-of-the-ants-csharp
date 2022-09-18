using System;

namespace Codecool.LifeOfAnts.Ants
{
    internal class Queen : Ant
    {
        private int _feelingSexy;

        public Queen(Position pos) : base(pos)
        {
        }

        public override char Symbol => 'Q';

        public override void Act()
        {
            _feelingSexy = _feelingSexy >= 0 ? _feelingSexy : Program.Random.Next(50, 101);
            _feelingSexy--;
        }

        public bool GetMood() => _feelingSexy == 0;
    }
}