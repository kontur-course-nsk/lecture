namespace TestingTasks.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using NUnit.Engine;

    public static class Program
    {
        public static void Main()
        {
            var testPackage = new TestPackage(Assembly.GetExecutingAssembly().Location);

            using (var engine = new TestEngine())
            using (var testRunner = engine.GetRunner(testPackage))
                if (TestsAreValid(testRunner))
                {
                    var incorrectImplementations = IncorrectImplementationHelper.GetTypes();
                    var results = GetIncorrectImplementationResults(testRunner, incorrectImplementations).ToList();

                    var task1Results = results.Take(4);
                    var task2Results = results.Skip(4).Take(6);
                    var task3Results = results.Skip(10);

                    Console.WriteLine();
                    Console.WriteLine("Task1. SumAbs");

                    foreach (var result in task1Results)
                    {
                        WriteImplementationResultToConsole(result);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Task2. Move");

                    foreach (var result in task2Results)
                    {
                        WriteImplementationResultToConsole(result);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Task3. Distinct");

                    foreach (var result in task3Results)
                    {
                        WriteImplementationResultToConsole(result);
                    }
                }
        }

        private static bool TestsAreValid(ITestRunner testRunner)
        {
            var failed = new List<string>();
            failed.AddRange(GetFailedTests(testRunner, typeof(Tasks), typeof(Tasks_Tests)).ToList());

            if (failed.Any())
            {
                ConsoleWriteLineWithColor("Incorrect tests detected: " + string.Join(", ", failed), ConsoleColor.Red);
                return false;
            }

            ConsoleWriteLineWithColor("Tests are OK!", ConsoleColor.Green);
            return true;
        }

        private static IEnumerable<ImplementationResult> GetIncorrectImplementationResults(
            ITestRunner testRunner,
            IEnumerable<Type> implementations)
        {
            var implTypeToTestsType = IncorrectImplementationHelper.GetTests()
                .ToDictionary(it => it.CreateTasks().GetType(), it => it.GetType());

            foreach (var implementation in implementations)
            {
                var failed = GetFailedTests(testRunner, implementation, implTypeToTestsType[implementation]).ToArray();
                yield return new ImplementationResult(implementation.Name, failed);
            }
        }

        private static void WriteImplementationResultToConsole(ImplementationResult result)
        {
            var paddedName = result.Name.PadRight(60, ' ');

            if (result.Fails.Any())
            {
                var text = TrimToConsole(paddedName + "fails on: " + string.Join(", ", result.Fails));
                ConsoleWriteLineWithColor(text, ConsoleColor.Green);
            }
            else
            {
                ConsoleWriteLineWithColor(paddedName + "write tests to kill it", ConsoleColor.Red);
            }
        }

        private static void ConsoleWriteLineWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string TrimToConsole(string text)
        {
            try
            {
                var windowWidth = Console.WindowWidth - 1;
                return text.Length > windowWidth ? text.Substring(0, windowWidth) : text;
            }
            catch (IOException)
            {
                return text;
            }
        }

        private static IEnumerable<string> GetFailedTests(
            ITestRunner testRunner,
            Type implementationType,
            Type testsType)
        {
            var builder = new TestFilterBuilder();
            builder.AddTest(testsType.FullName);
            var report = testRunner.Run(null, builder.GetFilter());
            Debug.Assert(report != null);
            File.WriteAllText($"{implementationType.Name}.nunitReport.xml", report.OuterXml);
            var failedTestCases = report.SelectNodes("//test-case[@result='Failed']");
            Debug.Assert(failedTestCases != null);
            foreach (var xmlNode in failedTestCases.Cast<XmlNode>())
            {
                Debug.Assert(xmlNode.Attributes != null);
                yield return xmlNode.Attributes["name"].Value;
            }
        }
    }
}