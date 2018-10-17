using System.IO;

namespace CleanCode.Examples
{
    class Example12_Result
    {
        public static void CreateTempFile(string name, string content)
        {
            File.WriteAllText("./temp/" + name, content);
        }

        public static void CreateFile(string name, string content)
        {
            File.WriteAllText(name, content);
        }
    }
}
