namespace TestingTasks
{
    using NUnit.Framework;

    [TestFixture]
    public partial class Tasks_Tests
    {
        // Не создавай новый Tasks, используй this.Tasks для тестирования

        // Добавь TestCase для каждого направления
        [TestCase(new[] { 0, 0, 0 }, Direction.Left, new[] { 0, 0, 0 }, TestName = "example")]
        public void MoveTests(int[] source, Direction direction, int[] expected)
        {
            // Напиши тест тут
        }
    }
}