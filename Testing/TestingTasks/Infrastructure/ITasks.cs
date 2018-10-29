namespace TestingTasks.Infrastructure
{
    public interface ITasks
    {
        int SumAbs(int first, int second);

        Point Move(Point point, Direction direction);

        int[] Distinct(int[] array);
    }
}