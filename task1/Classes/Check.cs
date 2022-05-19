using System;
using System.Collections.Generic;
using System.Text;

namespace NetCamtHT_1.Classes
{
    class Check
    {
        public static void Output(Product p)
        {
            Console.WriteLine("Product: Name = " +  p.Name + "; Price = " + p.Price.ToString() + "; Weight = " + p.Weight.ToString());
        }
        public static void Output(Buy b)
        {
            Console.WriteLine("Buy: Count = " + b.Count + "; TotalPrice = " + b.TotalPrice.ToString() + "; TotalWeight = " + b.TotalWeight.ToString());
        }
    }
}
