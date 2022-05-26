using System;
using task3;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vec = new Vector(20);
            vec.RandomInitialization();
            Console.WriteLine("Vector = \n" + vec.ToString());
            Console.WriteLine("BubbleSort = \n" + vec.BubbleSort().ToString());

            Vector vec1 = new Vector(10);
            vec1.RandomInitialization();
            Console.WriteLine("Vector = \n" + vec1.ToString());
            Console.WriteLine(" QuickSortFirst = \n" + vec1.QuickSort(0, 9, Vector.Pivot.First).ToString());

            Vector vec2 = new Vector(10);
            vec2.RandomInitialization();
            Console.WriteLine("Vector = \n" + vec2.ToString());
            Console.WriteLine(" QuickSortLast = \n" + vec2.QuickSort(0, 9, Vector.Pivot.Last).ToString());

            Vector vec3 = new Vector(10);
            vec3.RandomInitialization();
            Console.WriteLine("Vector = \n" + vec3.ToString());
            Console.WriteLine(" QuickSortMid = \n" + vec3.QuickSort(0, 9, Vector.Pivot.Mid).ToString());
            Console.ReadLine();
        }
    }
}
