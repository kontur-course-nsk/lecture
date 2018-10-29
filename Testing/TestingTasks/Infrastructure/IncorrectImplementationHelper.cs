namespace TestingTasks.Infrastructure
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class IncorrectImplementationHelper
    {
        public static Type[] GetTypes()
        {
            return GetInheritorsOf<ITasks>()
                .Where(it => it.HasAttribute<IncorrectImplementationAttribute>())
                .ToArray();
        }

        public static IncorrectImplementation_TestsBase[] GetTests()
        {
            return GetInheritorsOf<IncorrectImplementation_TestsBase>()
                .Select(Activator.CreateInstance)
                .Cast<IncorrectImplementation_TestsBase>()
                .ToArray();
        }

        private static bool HasAttribute<TAttribute>(this Type method) where TAttribute : Attribute
        {
            return method.GetCustomAttributes(typeof(TAttribute), true).Any();
        }

        private static Type[] GetInheritorsOf<T>()
        {
            var baseType = typeof(T);
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(baseType.IsAssignableFrom)
                .Where(it => it != baseType && !it.IsAbstract && !it.IsInterface)
                .ToArray();
        }
    }
}