namespace TestingTasks
{
    public sealed class Point
    {
        public Point(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; }
        public int Y { get; }
        public int Z { get; }
    }
}