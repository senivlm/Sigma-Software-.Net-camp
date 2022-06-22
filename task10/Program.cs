using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using task10.quest1;
using task10.quest2;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region task1
            //Dictionary<string, string> dictionary;
            //List<string> text;
            //try
            //{
            //    text = Reader.ReadText(@"../../../Text.txt");
            //    dictionary = Reader.ReadDictionary(@"../../../Dictionary.txt");
            //    Translator translator = new Translator();
            //    translator.AddDictionary(dictionary);
            //    foreach (string i in text)
            //    {
            //        translator.AddText(i);
            //    }

            //    string changedText = translator.ChangeWords();
            //    Console.WriteLine(changedText);
            //}
            //catch (FileNotFoundException)
            //{
            //    Console.WriteLine("FileNotFoundException");
            //}
            //catch (ArgumentException)
            //{
            //    Console.WriteLine("ArgumentException");
            //}
            //#endregion task1

            #region task2

            Matrix matrix1 = new Matrix(8, 4);
            matrix1.Fill();
            Console.WriteLine(matrix1);

            foreach(var item in matrix1)
                Console.WriteLine(item);

            #endregion task2
        }
    }
}