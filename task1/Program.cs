using NetCamtHT_1.Classes;
using System;

namespace NetCamtHT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Buy b = new Buy();

            Product p = new Product("Ice-cream", (double)23.40, (double)0.08);
            Check.Output(p);
            
            b.Add(p);
            Check.Output(b);
            Console.WriteLine("_________________________");
            Product p2 = new Product("False", (double)-5, (double)10);
            Check.Output(p2);

            b.Add(p2);
            Check.Output(b);
            Console.WriteLine("_________________________");
            Product p3 = new Product("Nuggets", 10, 55);
            Check.Output(p3);

            //(Element not found)
            //b.Remove(p2);
            //Check.Output(b);

            b.Add(p3,12);
            Check.Output(b);
            Console.WriteLine("_________________________");
            b.Add(p);
            Check.Output(b);
            Console.WriteLine("_________________________");
            b.Remove(p);
            Check.Output(b);
            Console.WriteLine("_________________________");
            Console.ReadKey();
        }
    }
}
