﻿using System;
using System.Collections.Generic;
using System.Text;

namespace task2.Task1.task2
{
    class Dairy_products:Product
    {

        // поле термін придатності, визначений в днях.
        int expireDate;
        public int ExpireDate
        {
            get { return expireDate; }
            set { if (value > 0) expireDate = value; else expireDate = 0; }
        }

        public Dairy_products(int d, string name, double price, double weight):
            base (name,price,weight)
        {
                ExpireDate = d;
        }
        public override double ChangePrice(double percent)
        {
            double temp;
            if (ExpireDate > 7)
                temp = 0;
            else if (ExpireDate < 3)
                temp = 30;
            else
                temp = 20;
            Price += Price * (percent-temp) / 100; ;
            return Price;
        }
    }
}
