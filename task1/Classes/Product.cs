using System;
using System.Collections.Generic;
using System.Text;

namespace NetCamtHT_1.Classes
{
    class Product
    {
        public string Name { get; set; }

        decimal price;
        public decimal Price
        {
            get { return price; }   
            set { if (value > 0) price = value; else price = 0; }  
        }

        decimal weight;
        public decimal Weight
        {
            get { return weight; }
            set { if (value > 0) weight = value; else weight = 0; }
        }

        public Product(string name, decimal price, decimal weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        Product()
        {

        }

    }
}
