using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextParser
{
    public class Parser
    {
        public static List<App> _list;

        //файлы с приложениями и отзывами
        public static string[] Parse(string file1, string file2)
        {
            _list = GetApps(file1);

            var reviews = ParseReview(file2);

            var apps = new Dictionary<string, int>();
            var categories = new Dictionary<string, int>();

            foreach (var review in reviews)
            {
                if (!apps.ContainsKey(review.AppName))
                {
                    apps.Add(review.AppName, review.M);
                }

                if (review.M != 0)
                {
                    apps[review.AppName] = apps[review.AppName] + review.M;
                }
            }

            foreach (var review in reviews)
            {
                var category = GetCategory(review.AppName);
                if (!categories.ContainsKey(category))
                {
                    categories.Add(category, review.M);
                }

                if (review.M != 0)
                {
                    categories[category] = categories[category] + review.M;
                }
            }

            var topApp = apps.First();

            foreach (var app in apps)
            {
                if (app.Value > topApp.Value)
                {
                    topApp = app;
                }
            }

            var topCat = categories.First();

            foreach (var cat in categories)
            {
                if (cat.Value > topCat.Value)
                {
                    topCat = cat;
                }
            }

            return new[] 
            {
                string.Format("Top app: {0} with mark {1}", topApp.Key, topApp.Value),
                string.Format("Top category: {0} with mark {1}", topCat.Key, topCat.Value)
            };
        }

        private static string GetCategory(string appName)
        {
            foreach (var app in _list)
            {
                if (app.AppName == appName)
                {
                    return app.AppCategory;
                }
            }

            return string.Empty;
        }

        private static List<AppReview> ParseReview(string file)
        {
            //считываем все строки из файла
            var data1 = File.ReadAllLines(file);

            var list = new List<AppReview>();

            for (int i = 1; i < data1.Length; i++)
            {
                if (data1[i][0] == '"') //название содержит спец.символы
                {
                    var t = data1[i].IndexOf('"', 1);
                    var name = data1[i].Substring(1, t - 1); //берем все название в кавычках
                    var mark = 0;
                    if (data1[i].Contains("Positive"))
                    {
                        mark = 1;
                    }
                    else if (data1[i].Contains("Neutral"))
                    {
                        mark = 0;
                    }
                    else if (data1[i].Contains("Negative"))
                    {
                        mark = -1;
                    }
                    else
                    {
                        continue;
                    }

                    list.Add(new AppReview(name, mark));
                }
                else
                {
                    var name = data1[i].Split(',')[0];
                    var category = data1[i].Split(',')[1];
                    var mark = 0;
                    if (data1[i].Contains("Positive"))
                    {
                        mark = 1;
                    }
                    else if (data1[i].Contains("Neutrak"))
                    {
                        mark = 0;
                    }
                    else if (data1[i].Contains("Negative"))
                    {
                        mark = -1;
                    }
                    else
                    {
                        continue;
                    }

                    list.Add(new AppReview(name, mark));
                }
            }

            return list;
        }

        private static List<App> GetApps(string file)
        {
            var data1 = File.ReadAllLines(file);

            var list = new List<App>();

            for (int i = 1; i < data1.Length; i++)
            {
                var notStartsWith = data1[i][0] != '"';

                if (!notStartsWith) //название содержит спец.символы
                {
                    var t = data1[i].IndexOf('"', 1); //берем все название в кавычках
                    var name = data1[i].Substring(1, t - 1);
                    var category = data1[i].Substring(t + 2).Split(',')[0];
                    list.Add(new App(name, category));
                }
                else
                {
                    var name = data1[i].Split(',')[0];
                    var category = data1[i].Split(',')[1];
                    list.Add(new App(name, category));
                }
            }

            return list;
        }
    }
}
