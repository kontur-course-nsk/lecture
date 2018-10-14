using System.IO;

namespace CleanCode.Examples
{
    class Example12_Result
    {
        public void CreateTempFile(string name, string content)
        {
            File.WriteAllText("./temp/" + name, content);
        }

        public void CreateFile(string name, string content)
        {
            File.WriteAllText(name, content);
        }
    }
}
