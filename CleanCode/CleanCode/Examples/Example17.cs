using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode.Examples
{
    class Example17
    {
        //список разделителей
        public static readonly char[] delimiters = { '!', '.', ':', ';', '?', '(', ')' };

        public static List<List<string>> ParseSentences(string text)
        {
            var list = new List<List<string>>(); //список слов
            var sentences = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sentence in sentences)
            {
                var list2 = GetList(sentence); //получаем список слов
                if (list2.Count > 0) //если есть словаы
                {
                    list.Add(list2);
                }
            }
            return list;
        }

        public static List<string> GetList(string sentence)
        {
            var listWord = new List<string>();
            var newWord = new StringBuilder();
            foreach (char checkChar in sentence)
            {
                if (char.IsLetter(checkChar) || checkChar == '\'') //проверяем допустимые символы
                {
                    newWord.Append(char.ToLower(checkChar)); //переводим символы в верхний регистр
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
