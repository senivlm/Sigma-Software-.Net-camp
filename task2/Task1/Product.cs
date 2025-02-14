﻿using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    public class Product
    {
        public string Name { get; set; }

        double price;
        public double Price
        {
            get { return price; }   
            set { if (value > 0) price = value; else price = 0; }  
        }

        double weight;
        public double Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; else weight = 0; }
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public Product()
        {

        }
        public virtual double ChangePrice(double percent)
        {
            Price += Price * percent / 100;
            return Price;
        }
    }
}
