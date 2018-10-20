using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace TextParser.Tests
{
    [TestFixture]
    class ParserTests
    {
        [Test]
        public void Test()
        {
            var assemblyDirectory = AssemblyDirectory;

            var result = Parser.Parse(Path.Combine(assemblyDirectory, "1.txt"),
                Path.Combine(assemblyDirectory, "2.txt"));

            CollectionAssert.AreEqual(new[]
            {
                "Top app: Duolingo: Learn Languages Free with mark 167",
                "Top category: GAME with mark 1527"
            }, result);
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
