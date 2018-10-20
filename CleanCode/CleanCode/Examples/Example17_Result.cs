using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode.Examples
{
    class Example17_Result
    {
        public static readonly char[] delimiters = { '!', '.', ':', ';', '?', '(', ')' };

        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentences = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sentence in sentences)
            {
                var listWord = GetListWords(sentence);
                if (listWord.Count > 0)
                {
                    sentencesList.Add(listWord);
                }
            }
            return sentencesList;
        }

        public static List<string> GetListWords(string sentence)
        {
            var listWord = new List<string>();
            var newWord = new StringBuilder();
            foreach (char checkChar in sentence)
            {
                var isValidChar = char.IsLetter(checkChar) || checkChar == '\'';

                if (isValidChar)
                {
                    newWord.Append(char.ToLower(checkChar));
                }
                else
                {
                    if (newWord.Length != 0)
                    {
                        listWord.Add(newWord.ToString());
                        newWord.Clear();
                    }
                }
            }
            if (newWord.Length != 0)
            {
                listWord.Add(newWord.ToString());
            }
            return listWord;
        }
    }
}
