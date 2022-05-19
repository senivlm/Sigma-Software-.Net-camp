using NetCamtHT_1.Classes;
using System;

namespace NetCamtHT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product("Ice-cream", (decimal)23.40, (decimal)0.08);
            Buy b = new Buy(p, 10);
            Check.Output(p);
            Check.Output(b);

            Product p2 = new Product("Ice-cream", (decimal)-5, (decimal)-1);
            Buy b2 = new Buy(p2, 10);
            Check.Output(p2);
            Check.Output(b2);
            Console.ReadKey();
        }
    }
}
