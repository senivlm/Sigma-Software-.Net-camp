using System;
using System.Collections.Generic;
using System.Text;

namespace task12.add
{
    class Dairy_products : Product
    {

        public DateTime ExpireDate
        {
            get;
            set;
        }

        public Dairy_products(DateTime d, string name, double price, double weight) :
            base(name, price, weight)
        {
            ExpireDate = d;
        }
        //public override double ChangePrice(double percent)
        //{
        //    double temp;
        //    if (ExpireDate > 7)
        //        temp = 0;
        //    else if (ExpireDate < 3)
        //        temp = 30;
        //    else
        //        temp = 20;
        //    Price += Price * (percent - temp) / 100; ;
        //    return Price;
        //}
        public override string ToString()
        {
            return "Dairy: Expiring on = " + ExpireDate.Date + " ; Name = " + Name + "; Price = " + Price.ToString() + "; Weight = " + Weight.ToString();
        }
    }
}
