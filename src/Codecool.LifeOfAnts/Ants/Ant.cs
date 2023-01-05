namespace Codecool.LifeOfAnts.Ants
{
    public abstract class Ant
    {
        public Position Position;

        // Get private set


        protected Ant(Position position, Colony colony)
        {
            Position = position;
            Colony = colony;
        }

        public abstract char Symbol { get; }

        public abstract void Act();

        protected Colony Colony;

        protected void MoveInDirection(Direction direction)
        {
            Position nextPos = Position.NextPosInDir(direction);
            if (IsValidMove(nextPos))
            {
                Position = nextPos;
            }
        }

        private bool IsValidMove(Position pos)
        {
            return pos.X >= 0 && pos.X <= Colony.Width - 1 && pos.Y >= 0 && pos.Y <= Colony.Width - 1;
        }
    }
}