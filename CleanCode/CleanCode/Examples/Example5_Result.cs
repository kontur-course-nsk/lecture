using System.IO;

namespace CleanCode.Examples
{
    class Example5_Result
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
            public void Append(string fileName, string text)
            {
                File.AppendAllText(fileName, text);
            }
        }
    }
}
