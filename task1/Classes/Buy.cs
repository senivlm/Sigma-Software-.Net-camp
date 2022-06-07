using System;
using System.Collections.Generic;
using System.Text;

namespace NetCamtHT_1.Classes
{
    class Buy
    {

        private Dictionary<Product, int> Basket;

        private double TotalPrice;
        private double TotalWeight;
        public Buy()
        {
            Basket = new Dictionary<Product, int>();
        }
        public void Add(Product p, int c)
        {
            if (!Basket.ContainsKey(p))
                Basket.Add(p, c > 0 ? c : 0);
            else
                Basket[p] += c;
        }
        public void Add(Product p)
        {
            if (!(p.Weight == 0 || p.Price == 0))
                if (!Basket.ContainsKey(p))
                    Basket.Add(p, 1);
                else
                    Basket[p] += 1;
        }
        public void Remove(Product p)
        {
            if (Basket.ContainsKey(p))
                Basket.Remove(p);
            else
                throw new Exception("Element not found");
        }
        public void GetTotal()
        {
            TotalPrice = 0;
            TotalWeight = 0;
            foreach (var keyVal in Basket)
            {
                TotalPrice += keyVal.Key.Price * keyVal.Value;
                TotalWeight += keyVal.Key.Weight * keyVal.Value;
            }
        }

        public override string ToString()
        {
            GetTotal();
            string res = "Buy: Product List\n" + "TotalPrice = " + TotalPrice.ToString() + "\nTotalWeight = " + TotalWeight.ToString();
            foreach (var keyVal in Basket)
                res += '\n' + keyVal.Key.ToString() + "\nCount = " + keyVal.Value;
            return res;
        }
    }
}
