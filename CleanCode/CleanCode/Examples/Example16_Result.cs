﻿using System.Collections.Generic;
using System.Text;

namespace CleanCode.Examples
{
    class Example16_Result
    {
        static List<string> SplitSentence(string sentence)
        {
            List<string> wordsInSentence = new List<string>();
            for (int i = 0; i < sentence.Length; i++)
            {
                if (IsValidChar(sentence, i))
                {
                    string word = ExtractWordFrom(sentence, i);
                    wordsInSentence.Add(word);
                    i += word.Length;
                }
            }
            return wordsInSentence;
        }

        static string ExtractWordFrom(string sentence, int posFrom)
        {
            StringBuilder wordBuilder = new StringBuilder();
            for (int i = posFrom; i < sentence.Length; i++)
            {
                if (IsValidChar(sentence, i))
                {
                    wordBuilder.Append(sentence[i]);
                }
                else
                {
                    return wordBuilder.ToString().ToLower();
                }
            }
            return wordBuilder.ToString().ToLower();
        }

        private static bool IsValidChar(string sentence, int i)
        {
            return char.IsLetter(sentence[i]) || sentence[i] == '\'';
        }
    }
}
