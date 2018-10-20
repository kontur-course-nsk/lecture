namespace TextParser
{
    public class App
    {
        public string AppName { get; set; }

        public string AppCategory { get; set; }

        public App(string name, string category)
        {
            AppName = name;
            AppCategory = category;
        }
    }
}
