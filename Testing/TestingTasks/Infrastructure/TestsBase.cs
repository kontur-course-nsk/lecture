namespace TestingTasks
{
    using NUnit.Framework;
    using TestingTasks.Infrastructure;

    public partial class Tasks_Tests
    {
        private ITasks Tasks { get; set; }

        [SetUp]
        public void SetUp() => this.Tasks = this.CreateTasks();

        public virtual ITasks CreateTasks() => new Tasks();
    }
}