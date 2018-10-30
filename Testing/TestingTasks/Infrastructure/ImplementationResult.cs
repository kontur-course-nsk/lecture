namespace TestingTasks.Infrastructure
{
    public class ImplementationResult
    {
        public ImplementationResult(string name, string[] fails)
        {
            this.Name = name;
            this.Fails = fails;
        }

        public readonly string Name;
        public readonly string[] Fails;
    }
}