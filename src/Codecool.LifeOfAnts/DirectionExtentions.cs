using System;

namespace Codecool.LifeOfAnts
{
    public static class DirectionExtentions
    {
        public static Direction[] Directions => (Direction[])Enum.GetValues(typeof(Direction));

        public static Position ToVector(this Direction dir)
        {
            return dir switch
            {
                Direction.North => new Position(x: 0, y: 1),
                Direction.South => new Position(x: 0, y: -1),
                Direction.East => new Position(x: -1, y: 0),
                Direction.West => new Position(x: 1, y: 0),
                _ => throw new System.ArgumentOutOfRangeException(dir.ToString()),
            };
        }

        public static Direction GetRandomDirection()
        {
            return (Direction)Program.Random.Next();
        }
    }
}