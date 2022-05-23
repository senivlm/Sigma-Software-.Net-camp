using System;
using System.Collections.Generic;
using System.Text;
using task2.Task1.task2;

namespace task2.Task1
{
   public class Storage
    {
        List<Product> Product_storage { get; }

        public Storage(params Product[] produts)//наповнення інформацією даних шляхом ініціалізації,
        {
            Product_storage = new List<Product>();
            foreach (var item in produts)
                Product_storage.Add(item);
        }
        public Storage()
        {
            Product_storage = new List<Product>();
        }
        public void UserInput()//наповнення інформацією даних у режимі діалогу з користувачем
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
            if (expiring == "") { 
                Console.WriteLine("(М'ясо) Категорія = ");
             category = Console.ReadLine();
            Console.WriteLine("(М'ясо) Вид = ");
             type = Console.ReadLine();}

            Product p;
            if(expiring!="")
                p = new Dairy_products(Convert.ToInt32(expiring), name, price, weight);
            else if(category!= "" && type != "")
                p = new Meat(category, type, name, price, weight);
            else
                p = new Product(name,price,weight);

            Product_storage.Add(p);
        }
        public void Output()//друку повної інформації про всі товари,
        {
            Console.WriteLine("__Storage__");
            foreach (dynamic item in Product_storage)
                Check.Output(item);

        }
        public void FindMeat()//метод знаходження всіх м’ясних продуктів
        {
            Console.WriteLine("__Only meat__");
            foreach (var item in Product_storage)
            {
                if(item is Meat)
                    Check.Output(item);
            }
        }
        public void ChangePrice(double percent)//метод зміни ціни для всіх товарів на заданий відсоток.
        {
            foreach (var item in Product_storage)
                item.ChangePrice(percent);
        }

        public Product this[int index]//створити індексатор для повного доступу за номером до масиву товарів.
        {
            get
            {
                if (index >= 0 && index < Product_storage.Count)
                {
                    return Product_storage[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                Product_storage[index] = value;
            }
        }

    }
}
