namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        protected Position _position;

        protected Ant(Position pos)
        {
            _position = pos;
            //Colony = colony;
        }

        public abstract char Symbol { get; }

        public abstract void Act();

        protected Colony Colony;

        protected void MoveInDirection(Direction direction)
        {
            Position nextPos = _position.NextPosInDir(direction);
            if (!IsValidMove(nextPos))
            {
                return;
            }
            _position = nextPos;
        }

        private bool IsValidMove(Position pos)
        {
            return pos.X >= 0 && pos.X <= Colony.Width && pos.Y >= 0 && pos.Y <= Colony.Width;
        }
    }
}