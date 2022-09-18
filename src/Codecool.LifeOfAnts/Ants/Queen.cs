namespace Codecool.LifeOfAnts.Ants
{
    internal class Queen : Ant
    {
        private int _feelingSexy;
        private bool _isWaitingForDrone;
        public Drone Partner { get; set; }

        public Queen(Position pos) : base(pos)
        {
        }

        public override char Symbol => 'Q';

        public override void Act()
        {
            if (_isWaitingForDrone && Partner != null) _isWaitingForDrone = false;
            if (_feelingSexy == 0) _isWaitingForDrone = true;
            _feelingSexy = _feelingSexy > 0 ? _feelingSexy : Program.Random.Next(50, 101);
            _feelingSexy--;
        }

        public bool IsReady()
        {
            return _isWaitingForDrone;
        }
    }
}