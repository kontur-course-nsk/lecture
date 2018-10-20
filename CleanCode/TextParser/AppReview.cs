namespace TextParser
{
    public class AppReview
    {
        public string AppName { get; set; }

        public int M { get; set; }

        public AppReview(string appName, int m)
        {
            AppName = appName;
            M = m;
        }
    }
}
