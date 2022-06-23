using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task6
{
    class Sentence
    {
        public string ParseText(string path)
        {
            string text = FileReader.ReadFromFile(path);
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

        public string PrintAndOutputInFile(string InputPath = "..\\..\\..\\text.txt", string OutputPath= "..\\..\\..\\Result.txt")
        {
            string output = ParseText(InputPath);
            StreamWriter writer = new StreamWriter(OutputPath);
            writer.WriteLine(output);
            writer.Close();

            string res = null;
            int max, min;
            string maxWord, minWord ;
            string[] text = output.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0;i< text.Length;i++)
            {
                maxWord = null;
                minWord = null;
                var sentArr = text[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                min = max = sentArr[0].Length;
                foreach(var word in sentArr)
                {
                    if (word.Length >= max)
                    {
                        max = word.Length;
                        maxWord = word;
                    }
                    if (word.Length <= min)
                    {
                        min = word.Length;
                        minWord = word;
                    }
                }
                res += "Найдовше слово = " + String.Format("{0,20}", maxWord)  + " Найкоротше слово = "+ String.Format("{0,10}", minWord) +'\n';
            }
            return res;
        }
    }
}
