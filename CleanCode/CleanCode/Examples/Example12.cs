using System.IO;

namespace CleanCode.Examples
{
    class Example12
    {
        public void CreateFile(string name, string content, bool temp = false)
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
