using System;
using System.Collections.Generic;
using System.Text;


namespace task2
{
    class ConsoleInput
    {
        public static Product UserInputProduct()
        {
            string name, category = "", type = "", expiring;
            double price, weight;

            Console.WriteLine("Введіть дані про продукт (Ентер для пропуску):");
            Console.WriteLine("Назва продукту = ");
            name = Console.ReadLine();
            Console.WriteLine("Вартість продукту = ");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вага продукту = ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("(Молочний продукт)Термін придатності = ");
            expiring = Console.ReadLine();
            if (expiring == "")
            {
                Console.WriteLine("(М'ясо) Категорія = ");
                category = Console.ReadLine();
                Console.WriteLine("(М'ясо) Вид = ");
                type = Console.ReadLine();
            }

            Product p ;
            if (expiring != "")
                p = new Dairy_products(Convert.ToInt32(expiring), name, price, weight);
            else if (category != "" && type != "")
                p = new Meat(category, type, name, price, weight);
            else
                p = new Product(name, price, weight);

            return p;
        }
    }
}
