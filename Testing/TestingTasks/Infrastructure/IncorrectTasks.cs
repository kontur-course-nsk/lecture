namespace TestingTasks.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    #region Не подглядывать

    [IncorrectImplementation]
    public class BeSumOfAbs_WhenBothPositive : ITasks
    {
        public int SumAbs(int first, int second)
        {
            first = -first;
            second = -second;
            var result = Math.Max(first + Math.Abs(second), Math.Abs(first) + second);
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

    [IncorrectImplementation]
    public class BeSumOfAbs_WhenFirstNegative : ITasks
    {
        public int SumAbs(int first, int second)
        {
            var result = Math.Max(first + Math.Abs(second), Math.Abs(first + second));
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

    [IncorrectImplementation]
    public class BeSumOfAbs_WhenSecondNegative : ITasks
    {
        public int SumAbs(int first, int second)
        {
            var result = Math.Max(Math.Abs(first) + second, Math.Abs(first + second));
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

    [IncorrectImplementation]
    public class BeSumOfAbs_WhenBothNegative : ITasks
    {
        public int SumAbs(int first, int second)
        {
            var result = Math.Max(first + Math.Abs(second), Math.Abs(first) + second);
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

    [IncorrectImplementation]
    public class DecreaseFirst_WhenMoveLeft : ITasks
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
                    return new Point(point.X, point.Y, point.Z);
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

    [IncorrectImplementation]
    public class IncreaseFirst_WhenMoveRight : ITasks
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
                    return new Point(point.X + 1, point.Y + 1, point.Z + 1);
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

    [IncorrectImplementation]
    public class IncreaseSecond_WhenMoveForward : ITasks
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
                    return new Point(point.X, point.Y - 1, point.Z);
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

    [IncorrectImplementation]
    public class DecreaseSecond_WhenMoveBack : ITasks
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
                    return new Point(point.X, -1, point.Z);
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

    [IncorrectImplementation]
    public class IncreaseThird_WhenMoveUp : ITasks
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
                    return new Point(point.X, point.Y, point.Z);
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

    [IncorrectImplementation]
    public class DecreaseThird_WhenMoveDown : ITasks
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
                    return new Point(point.X, point.Y + 1, point.Z - 1);
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

    [IncorrectImplementation]
    public class ExcludeDuplicate_WhenNotFirstElementIsDuplicate : ITasks
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
            var set = new HashSet<int>();

            for (var i = 1; i < array.Length; i++)
            {
                set.Add(array[i]);
            }

            var result = set.ToArray();
            return result;
        }
    }

    [IncorrectImplementation]
    public class ExcludeDuplicate_WhenNotLastElementIsDuplicate : ITasks
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
            var set = new HashSet<int>();

            for (var i = 0; i < array.Length - 1; i++)
            {
                set.Add(array[i]);
            }

            var result = set.ToArray();
            return result;
        }
    }

    [IncorrectImplementation]
    public class Fail_WhenEmptyArray : ITasks
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
            var set = new HashSet<int>();

            var i = 0;

            do
            {
                set.Add(array[i]);
                i++;
            } while (i < array.Length);

            var result = set.ToArray();
            return result;
        }
    }

    [IncorrectImplementation]
    public class ExcludeDuplicate_WhenElementsNotTogether : ITasks
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
            var list = new List<int>();

            for (var i = 0; i < array.Length; i++)
            {
                if (i + 1 < array.Length && array[i] != array[i + 1])
                {
                    list.Add(array[i]);
                }
            }

            var result = list.ToArray();
            return result;
        }
    }

    [IncorrectImplementation]
    public class ExcludeDuplicates_WhenDuplicatesCountIsLarge : ITasks
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
            var i = 0;
            var list = new List<int>();

            for (; i < array.Length; i++)
            {
                if (array.Count(it => it == array[i]) > 1)
                {
                    break;
                }
            }

            for (int j = 0; j < array.Length; j++)
            {
                if (i != j)
                {
                    list.Add(array[j]);
                }
            }

            var result = list.ToArray();
            return result;
        }
    }

    #endregion
}