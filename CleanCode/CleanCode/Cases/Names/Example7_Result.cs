using System;

namespace CleanCode.Cases.Names
{
    class Example7_Result
    {
        private static double angle1 = Math.PI / 4;
        private static double angle2 = 3 * Math.PI / 4;

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
                    x = (x * Math.Cos(angle1) - y * Math.Sin(angle1)) / Math.Sqrt(2);
                    y = (t * Math.Sin(angle1) + y * Math.Cos(angle1)) / Math.Sqrt(2);
                }
                else
                {
                    t = x;
                    x = (x * Math.Cos(angle2) - y * Math.Sin(angle2)) / Math.Sqrt(2) + 1;
                    y = (t * Math.Sin(angle2) + y * Math.Cos(angle2)) / Math.Sqrt(2);
                }
                pixels.SetPixel(x, y);
            }
        }
    }
}
