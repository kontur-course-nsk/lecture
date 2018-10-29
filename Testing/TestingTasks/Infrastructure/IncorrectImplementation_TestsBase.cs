namespace TestingTasks.Infrastructure
{
    using System;
    using NUnit.Framework;

    public abstract class IncorrectImplementation_TestsBase : Tasks_Tests
    {
        public override ITasks CreateTasks()
        {
            string ns = typeof(BeSumOfAbs_WhenBothPositive).Namespace;
            var implTypeName = ns + "." + this.GetType().Name.Replace("_Tests", "");
            var implType = this.GetType().Assembly.GetType(implTypeName);

            if (implType == null)
            {
                Assert.Fail("no type {0}", implTypeName);
            }

            return (ITasks)Activator.CreateInstance(implType);
        }
    }
}