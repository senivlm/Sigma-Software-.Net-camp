using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static task6.FileReader;

namespace task6
{
    class Sentence
    {
        public Sentence(string path)
        {// Ви цей об'єкт ніде не зможете застосувати.
        FileReader fr = new FileReader(path);
        }
        public string ParseText()
        {// Де метод читання з файлу? Якась неповна версія.
            string text = ReadFromFile();
            string sent,res="";
            var firstSplit = text.Split('.', StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0;i<firstSplit.Length;i++)
            {
                sent = firstSplit[i];

                //if starts or ends with space
                sent = sent.Trim();

                while (sent.Contains("  "))
                    sent= sent.Replace("  "," ");

                if (sent.Contains('\r'))
                    sent= sent.Replace("\r", "");

                if (sent.Contains('\n'))
                    sent = sent.Replace("\n", "");



                res += sent+'\n';
                
            }
            return res;
        }

        public string PrintAndOutputInFile()
        {// Друк в файл не форматований. Просили таблично, тобто застосовувати до даних формат.
            string output = ParseText();
            // Передавати як параметр
            StreamWriter writer = new StreamWriter("..\\..\\..\\Result.txt");
            writer.WriteLine(output);
            writer.Close();

            string res = null;
            int max, min;
            string maxWord, minWord ;
           // Яка потреба в масиві в Split
            string[] text = output.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0;i< text.Length;i++)
            {
                maxWord = null;
                minWord = null;
                max = 0;
                // Як не хардкодити?
                min = 100;
                var sentArr = text[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var word in sentArr)
                {
                    if (word.Length > max)
                    {
                        max = word.Length;
                        maxWord = word;
                    }
                    if (word.Length < min)
                    {
                        min = word.Length;
                        minWord = word;
                    }
                }
                res += "Найдовше слово = " +maxWord+ " Найкоротше слово = "+minWord +'\n';
            }
            return res;
        }
    }
}
