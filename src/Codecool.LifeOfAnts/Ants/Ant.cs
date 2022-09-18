namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position _position;

        protected Ant(Position pos)
        {
            _position = pos;
        }

        protected Ant(Position pos, Colony colony)
        {
            _position = pos;
            Colony = colony;
        }

        public abstract char Symbol { get; }

        public abstract void Act();

        protected Colony Colony;

        protected void MoveInDirection(Direction direction)
        {
            Position nextPos = _position.NextPosInDir(direction);
            if (IsValidMove(nextPos))
            {
                _position = nextPos;
            }
        }

        private bool IsValidMove(Position pos)
        {
            return pos.X >= 0 && pos.X <= Colony.Width - 1 && pos.Y >= 0 && pos.Y <= Colony.Width - 1;
        }
    }
}