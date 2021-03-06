﻿using System.Collections.Generic;

namespace CleanCode.Examples
{
    class Example15_Result
    {
        private static Dictionary<string, Dictionary<string, int>> BuildFrequencyDictionary(List<List<string>> text)
        {
            var requencyDictionary = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < text.Count; i++)
            {
                for (int j = 0; j < text[i].Count - 1; j++)
                {
                    var firstWord = text[i][j];
                    var secondWord = text[i][j + 1];

                    AddNgram(requencyDictionary, firstWord, secondWord);
                }

                for (int j = 0; j < text[i].Count - 2; j++)
                {
                    var firstWord = text[i][j];
                    var secondWord = text[i][j + 1];

                    string begin = firstWord + " " + secondWord;
                    string end = text[i][j + 2];
                    AddNgram(requencyDictionary, begin, end);
                }
            }
            return requencyDictionary;
        }

        private static void AddNgram(Dictionary<string, Dictionary<string, int>> result, string begin, string end)
        {
        }
    }
}
