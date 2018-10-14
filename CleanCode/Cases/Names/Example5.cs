using System.IO;

namespace CleanCode.Cases.Names
{
    class Example5
    {
        class NumberWriter
        {
            public void Add(string fileName, int number)
            {
                File.WriteAllText(fileName, number.ToString());
            }
        }

        class StringWriter
        {
            public void Add(string fileName, string text)
            {
                File.AppendAllText(fileName, text);
            }
        }
    }
}
