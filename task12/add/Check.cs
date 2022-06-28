﻿using System;
using System.Collections.Generic;
using System.Text;

namespace task12.add
{
    class Check
    {
        public static void Output<T>(T input) where T : class
        {
            Console.WriteLine(input.ToString());
        }
        public static void Output(Product p)
        {
            Console.WriteLine(p.ToString());
        }
        public static void Output(Dairy_products d)
        {
            Console.WriteLine(d.ToString());
        }
        public static void Output(Meat m)
        {
            Console.WriteLine(m.ToString());
        }
    }
}
