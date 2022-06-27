using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10.quest1
{
    class Translator
    {
        private Dictionary<string, string> vocabluary;
        private string text;
        private string pathToText;
        private string pathToDictionary;
        private int mistakesLimit = 3;

        public Translator() : this(@"../../../Text.txt", @"../../../Dictionary.txt")
        {

        }

        public Translator(string pathToText, string pathToDictionary)
        {
            vocabluary = new Dictionary<string, string>();
            text = "";
            this.pathToText = pathToText;
            //Для стабільної роботи цього класу треба робити глибоку копію!
            this.pathToDictionary = pathToDictionary;
        }

        public Translator(Dictionary<string, string> vocabluary, string text, string pathToText, string pathToDictionary)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.vocabluary = vocabluary;
            this.text = text;
        }

        public void AddText(string text)
        {
            this.text += text;
        }

        public void AddDictionary(Dictionary<string, string> dictionary)
        {// тут теж
            vocabluary = dictionary;
        }

        public string ChangeWords()
        {
            string result = "";
            var words = text.Split(' ', StringSplitOptions.None);
            foreach (string word in words)
            {
                char temp = ' ';
                string tempWord = "";
                int i = 0;
                if (word.Length > 0)
                {
                    if (char.IsPunctuation(word[word.Length - 1]))
                    {
                        if (word[0..^1].ToLower() == "a" || word[0..^1].ToLower() == "the")
                            continue;
                        temp = word[word.Length - 1];
                        while (!vocabluary.ContainsKey(word[0..^1].ToLower()) && i < mistakesLimit)
                        {
                            AddToDictionary(word[0..^1].ToLower());
                            i++;
                        }
                        tempWord = vocabluary[word[0..^1].ToLower()] + temp;
                    }
                    else
                    {
                        if (word.ToLower() == "a" || word.ToLower() == "the")
                            continue;

                        while (!vocabluary.ContainsKey(word.ToLower()) && i < mistakesLimit)
                        {
                            AddToDictionary(word.ToLower());
                            i++;
                        }
                        tempWord = vocabluary[word.ToLower()];
                    }


                    if (IfFirstUppercase(word))
                        tempWord = FirstCharToUpper(tempWord);
                }
                result += tempWord + " ";

            }

            return result;
        }
        public static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Wrong input for FirstCharToUpper");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
        public static bool IfFirstUppercase(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Wrong input for IfFirstUppercase");

            return char.IsUpper(input[0]) ? true : false;
        }
        //Цей метод слід винести з цього класу.
        private void AddToDictionary(string word)
        {// у модельних класах не організовується діалог.
            Console.WriteLine($"Немає перекладу для слова {word}, введiть переклад");
            string value = Console.ReadLine();
            vocabluary.Add(word, value);
            Reader.WriteToDictionary(word, value, @"../../../Dictionary.txt");
        }
    }
}
