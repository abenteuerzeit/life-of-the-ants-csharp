using System;
using System.ComponentModel.DataAnnotations;

namespace Codecool.LifeOfAnts
{
    /// <summary>
    ///     Position struct
    /// </summary>
    public struct Position
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets X coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        ///     Gets Y coordinate
        /// </summary>
        public int Y { get; }

        public static Position operator +(Position left, Position right)
        {
            return new Position(left.X + right.X, left.Y + right.Y);
        }

        public Position NextPosInDir(Direction direction)
        {
            return this + direction.ToVector();
        }

        public Direction GetRandomDirection()
        {
            return (Direction)Program.Random.Next(4); // Enum
        }

        public static Direction GetNextDirection(Direction direction)
        {
            if (direction == 0)
            {
                return (Direction)Enum.GetNames(typeof(Direction)).Length; ;
            }
            var NextDirection = (int)direction - 1;
            return (Direction)NextDirection;
        }

        public Direction GetDirToTarget(Position target)
        {
            if (target.X > X)
            {
                return Direction.East;
            }
            else if (target.X < X)
            {
                return Direction.West;
            }
            else if (target.Y > Y)
            {
                return Direction.South;
            }
            else
            {
                return Direction.North;
            }
        }
    }
}