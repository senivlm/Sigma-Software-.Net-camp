using System;
using System.Collections.Generic;
using System.Text;

namespace task11.additional
{
    public enum Category { Highest, First, Second }
    public enum MeatType { Lamb, Veal, Pork, Chicken }
    //баранина, телятина, свинина, курятина
    public class Meat : Product
    {

        public Category CategoryOfMeat { get; }
        public MeatType TypeOfMeat { get; }
        public Meat(Category c, MeatType t, string name, double price, double weight) :
           base(name, price, weight)
        {
            CategoryOfMeat = c;
            TypeOfMeat = t;
        }

        public Meat(string category, string type, string name, double price, double weight) :
           base(name, price, weight)
        {

            if (Enum.IsDefined(typeof(Category), category) && Enum.IsDefined(typeof(MeatType), type))
            {
                CategoryOfMeat = Enum.Parse<Category>(category);
                TypeOfMeat = Enum.Parse<MeatType>(type);
            }
            else
            {
                throw new Exception("Немає такого типу (Highest ,First,Second) або виду (Lamb, Veal, Pork, Chicken) м'яса");
            }

        }

        public override double ChangePrice(double percent)
        {
            // відповідно до категорії м’яса.
            double temp;
            switch (CategoryOfMeat)
            {
                case Category.Highest:
                    temp = 30;
                    break;
                case Category.First:
                    temp = 20;
                    break;
                case Category.Second:
                    temp = 10;
                    break;

                default:
                    temp = 0;
                    break;
            }

            Price += Price * (percent + temp) / 100; ;
            return Price;
        }
        public override string ToString()
        {
            return "Meat: Category = " + CategoryOfMeat + " ; Type = " + TypeOfMeat + " ; Name = " + Name + "; Price = " + Price.ToString() + "; Weight = " + Weight.ToString();
        }
    }
}
