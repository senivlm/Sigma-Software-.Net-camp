﻿using System;
using System.Collections.Generic;
using System.Text;
using task2.Task1.task2;

namespace task2
{
    class Check
    {
        public static void Output(Product p)
        {
            Console.WriteLine("Product: Name = " +  p.Name + "; Price = " + p.Price.ToString() + "; Weight = " + p.Weight.ToString());
        }
        public static void Output(Dairy_products d)
        {
            Console.WriteLine("Dairy: Expiring in = " + d.ExpireDate + "days ; Name = " + d.Name + "; Price = " + d.Price.ToString() + "; Weight = " + d.Weight.ToString());
        }
        public static void Output(Meat m)
        {
            Console.WriteLine("Meat: Category = " + m.CategoryOfMeat + " ; Type = " + m.TypeOfMeat + " ; Name = " + m.Name + "; Price = " + m.Price.ToString() + "; Weight = " + m.Weight.ToString());
        }
    }
}
