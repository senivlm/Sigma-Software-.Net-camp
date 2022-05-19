using System;
using System.Collections.Generic;
using System.Text;

namespace NetCamtHT_1.Classes
{
    class Buy
    {
        Product Product { get; }

        int count;
        public int Count
        {
            get {return count; }
            set { if (value > 0) count = value; else count = 0; }
        }
        public decimal TotalPrice { get; }
        public decimal TotalWeight { get; }

        public Buy(Product p , int c)
        {
            Product = p;
            Count = c;
            if (Product != null)
            {
                TotalPrice = p.Price * c;
                TotalWeight = p.Weight * c;
            }
        }
        public Buy()
        {
            if (Product != null)
            {
                TotalPrice = Product.Price * Count;
                TotalWeight = Product.Weight * Count;
            }
        }
    }
}
