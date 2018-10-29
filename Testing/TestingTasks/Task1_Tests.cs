namespace TestingTasks
{
    using NUnit.Framework;

    [TestFixture]
    public partial class Tasks_Tests
    {
        // Не создавай новый Tasks, используй this.Tasks для тестирования

        [Test]
        public void BeSumOfAbs_WhenBothPositive()
        {
            // Допиши тест тут

            var actual = this.Tasks.SumAbs(1, 2);
        }

        [Test]
        public void BeSumOfAbs_WhenFirstNegative()
        {
            // Напиши тест тут
        }

        [Test]
        public void BeSumOfAbs_WhenSecondNegative()
        {
            // Напиши тест тут
        }

        [Test]
        public void BeSumOfAbs_WhenBothNegative()
        {
            // Напиши тест тут
        }
    }
}