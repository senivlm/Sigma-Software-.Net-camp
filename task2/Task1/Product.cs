using System;
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
            set { _ = value > 0 ? price = value : price = 0; }
        }

        double weight;
        public double Weight
        {
            get { return weight; }
            set { _ = value > 0 ? weight = value : weight = 0; }
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public override string ToString()
        {
            return "Product: Name = " + Name + "; Price = " + Price.ToString() + "; Weight = " + Weight.ToString();
        }

        public virtual double ChangePrice(double percent)
        {
            Price += Price * percent / 100;
            return Price;
        }
    }
}
