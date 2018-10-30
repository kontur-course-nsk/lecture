namespace TestingTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingTasks.Infrastructure;

    public sealed class Tasks : ITasks
    {
        public int SumAbs(int first, int second)
        {
            var result = Math.Abs(first) + Math.Abs(second);
            return result;
        }

        public Point Move(Point point, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return new Point(point.X - 1, point.Y, point.Z);
                case Direction.Right:
                    return new Point(point.X + 1, point.Y, point.Z);
                case Direction.Forward:
                    return new Point(point.X, point.Y + 1, point.Z);
                case Direction.Back:
                    return new Point(point.X, point.Y - 1, point.Z);
                case Direction.Up:
                    return new Point(point.X, point.Y, point.Z + 1);
                case Direction.Down:
                    return new Point(point.X, point.Y, point.Z - 1);
                default:
                    throw new ArgumentException($"Unexpected direction \"{direction}\"", nameof(direction));
            }
        }

        public int[] Distinct(int[] array)
        {
            var set = new HashSet<int>(array);
            var result = set.ToArray();
            return result;
        }
    }
}