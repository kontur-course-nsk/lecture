using System.Collections.Generic;

namespace CleanCode.Examples
{
    class Example15_Result_2
    {
        private static Dictionary<string, Dictionary<string, int>> BuildFrequencyDictionary(List<List<string>> text)
        {
            var frequencyDictionary = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < text.Count; i++)
            {
                for (int j = 0; j < text[i].Count - 1; j++)
                {
                    string bigramKey = text[i][j];
                    string bigramValue = text[i][j + 1];
                    AddNgram(frequencyDictionary, bigramKey, bigramValue);

                    if (j < text[i].Count - 2)
                    {
                        string trigramKey = bigramKey + " " + bigramValue;
                        string trigramValue = text[i][j + 2];
                        AddNgram(frequencyDictionary, trigramKey, trigramValue);
                    }
                }
            }
            return frequencyDictionary;
        }

        private static void AddNgram(Dictionary<string, Dictionary<string, int>> result, string begin, string end)
        {
        }
    }
}
