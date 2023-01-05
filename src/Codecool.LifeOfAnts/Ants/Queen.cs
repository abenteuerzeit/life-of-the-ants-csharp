namespace Codecool.LifeOfAnts.Ants
{
    internal class Queen : Ant
    {
        private const int MinValue = 50;
        private const int MaxValue = 101;
        private int _feelingSexy;
        private bool _isWaitingForDrone;
        public Drone Partner { get; set; }

        public override char Symbol => 'Q';

        public Queen(Position pos, Colony colony) : base(pos, colony)
        {
        }

        public override void Act()
        {
            if (_isWaitingForDrone && Partner != null) _isWaitingForDrone = false; // new method delete
            if (_feelingSexy == 0) _isWaitingForDrone = true;
            _feelingSexy = _feelingSexy > 0 ? --_feelingSexy : Program.Random.Next(MinValue, MaxValue); // Move Random to method
        }

        public bool IsReady()
        {
            return _isWaitingForDrone;
        }

        public void ReleaseQueen()
        {
            // TODO set partner to null
        }
    }
}