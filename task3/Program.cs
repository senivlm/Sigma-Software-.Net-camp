using System;
using task2;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            

            try
            {
                Vector vec = new Vector(new int[] { 1, 3, 5, 3, 1 });
                Console.WriteLine("Start value = \n"+vec.ToString());
                Console.WriteLine("Is palindrome = " + vec.IsPalindrome());

                Vector vec2 = new Vector(10);
                vec2.RandomInitialization();
                Console.WriteLine("New vector = \n" + vec2.ToString());
                vec2.ReverseFromScratch();
                Console.WriteLine("Reverse from scratch = \n" + vec2.ToString());
                vec2.ReverseBuiltIn();
                Console.WriteLine("Reverse built in = \n" + vec2.ToString());

                Vector vec3 = new Vector(new int[] { 1, 3, 3, 2, 2, 2, 1, 1 });
                Console.WriteLine("New vector = \n" + vec3.ToString());
                Console.WriteLine("Longest subsequence = \n" + vec3.FindSubsequence().ToString());

                Matrix matrix1 = new Matrix(6, 6);
                Console.WriteLine("__Fill Diagonal Right Snake__");
                matrix1.FillDiagonalSnake(Matrix.startAngle.Right);
                matrix1.Output();

                Matrix matrix2 = new Matrix(6, 6);
                Console.WriteLine("__Fill Diagonal Down Snake__");
                matrix2.FillDiagonalSnake(Matrix.startAngle.Down);
                matrix2.Output();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }
    }
}

