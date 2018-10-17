using System;

namespace CleanCode.Examples
{
    class Example7
    {
        public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
        {
            var random = new Random(seed);
            double x = 1.0, y = 0.0, t;
            for (int i = 0; i < iterationsCount; i++)
            {
                var randomNumber = random.Next(2);
                if (randomNumber == 1)
                {
                    t = x;
                    x = (x * Math.Cos(0.785398) - y * Math.Sin(0.785398)) / Math.Sqrt(2);
                    y = (t * Math.Sin(0.785398) + y * Math.Cos(0.785398)) / Math.Sqrt(2);
                }
                else
                {
                    t = x;
                    x = (x * Math.Cos(2.35619) - y * Math.Sin(2.35619)) / Math.Sqrt(2) + 1;
                    y = (t * Math.Sin(2.35619) + y * Math.Cos(2.33619)) / Math.Sqrt(2);
                }
                pixels.SetPixel(x, y);
            }
        }
    }

    internal class Pixels
    {
        public void SetPixel(double d, double d1)
        {
            throw new NotImplementedException();
        }
    }
}
