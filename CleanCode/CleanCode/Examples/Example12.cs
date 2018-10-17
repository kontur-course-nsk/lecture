using System.IO;

namespace CleanCode.Examples
{
    public class Example12
    {
        public static void CreateFile(string name, string content, bool temp)
        {
            if (temp)
            {
                File.WriteAllText("./temp/" + name, content);
            }
            else
            {
                File.WriteAllText(name, content);
            }
        }
    }
}
