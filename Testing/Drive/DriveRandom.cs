using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing
{
    [Flags]
    public enum SymbolTypes
    {
        Digits = 0x1,
        Latin = 0x2,
        Cyrillic = 0x4
    }

    public static class DriveRandom
    {
        private static readonly string RealHumanBean = "RealHero";

        private static readonly Random DefaultRandom = new Random();

        public static string GetString(int length, SymbolTypes symbolTypes = SymbolTypes.Digits | SymbolTypes.Latin)
        {
            return DefaultRandom.GetString(length, symbolTypes);
        }

        public static int GetInt(int maxValue)
        {
            return DefaultRandom.Next(maxValue);
        }

        public static int GetInt(int minValue, int maxValue)
        {
            return DefaultRandom.Next(minValue, maxValue);
        }

        public static char GetChar(SymbolTypes symbolTypes)
        {
            return DefaultRandom.GetChar(symbolTypes);
        }

        public static string GetGuid() => Guid.NewGuid().ToString();

        public static string GetDefaultString() => $"{nameof(RealHumanBean)}, and a {RealHumanBean}";

        public static IEnumerable<T> Mix<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            return Shuffle(first.Concat(second));
        }

        public static IEnumerable<T> MixWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return Mix(first, second);
        }

        public static IEnumerable<T> Mix<T>(params IEnumerable<T>[] enumerables)
        {
            return Shuffle(
                enumerables.Aggregate(
                    Enumerable.Empty<T>(),
                    (x, y) => x.Concat(y)));
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> values, Random random = null)
        {
            if (random == null)
            {
                random = new Random();
            }

            return values.OrderBy(x => random.Next());
        }

        private static string GetString(this Random random, int length,
            SymbolTypes symbolTypes = SymbolTypes.Digits | SymbolTypes.Latin)
        {
            if (length < 0)
            {
                throw new ArgumentException("Length should be greater or equal than zero.", nameof(length));
            }

            if (length == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                builder.Append(random.GetChar(symbolTypes));
            }

            return builder.ToString();
        }

        private static char GetChar(this Random random, SymbolTypes symbolTypes)
        {
            var numberOfTypes = 0;
            if (symbolTypes.HasFlag(SymbolTypes.Digits)) numberOfTypes++;
            if (symbolTypes.HasFlag(SymbolTypes.Latin)) numberOfTypes++;
            if (symbolTypes.HasFlag(SymbolTypes.Cyrillic)) numberOfTypes++;

            var power = random.Next(numberOfTypes);

            var concreteType = (SymbolTypes) Math.Pow(2, power);

            switch (concreteType)
            {
                case SymbolTypes.Digits:
                    return random.GetDigitChar();
                case SymbolTypes.Latin:
                    return random.GetLatinChar();
                case SymbolTypes.Cyrillic:
                    return random.GetCyrillicChar();
                default:
                    throw new ArgumentOutOfRangeException(nameof(concreteType));
            }
        }

        private static char GetDigitChar(this Random random)
        {
            return random.NextChar('0', '9');
        }

        private static char GetLatinChar(this Random random)
        {
            return random.NextBool() ? random.NextChar('a', 'z') : random.NextChar('A', 'Z');
        }

        private static char GetCyrillicChar(this Random random)
        {
            return random.NextBool() ? random.NextChar('а', 'я') : random.NextChar('А', 'Я');
        }

        private static bool NextBool(this Random random)
        {
            return random.Next(0, 1) == 0;
        }

        private static char NextChar(this Random random, char minValue, char maxValue)
        {
            return (char) random.Next(minValue, maxValue);
        }
    }
}