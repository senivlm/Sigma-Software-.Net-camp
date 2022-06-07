using System;
using System.IO;
using task3;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
// Проміжні файли бажано зачищати
            Vector vec = new Vector();
            StreamReader reader = new StreamReader("..\\..\\..\\file.txt");
            Console.WriteLine("Before external merge sort = \n" + reader.ReadLine());
            vec.ExternalMergeSort("file.txt");
             reader = new StreamReader("..\\..\\..\\sortedAll.txt");
            Console.WriteLine("After = \n" + reader.ReadLine());

            Vector vec2 = new Vector(15);
            vec2.RandomInitialization();
            Console.WriteLine("Before PyramidSort = \n" + vec2.ToString());
            vec2.PyramidSort();
            Console.WriteLine("After = \n" + vec2.ToString());

            Console.ReadLine();
        }
    }
}
