using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace task2
{
    public class Storage
    {
        private Dictionary<Product, int> Product_storage;
        public Product this[int index]//створити індексатор для повного доступу за номером до масиву товарів.
        { 
            get
            {
                if (index >= 0 && index < Product_storage.Count)
                {
                    return Product_storage.ElementAt(index).Key;
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
                
            }
            set
            {
                Product_storage.Remove(Product_storage.ElementAt(index).Key);
                Add(value);
            }   
        }
        public Storage(params Product[] produts)//наповнення інформацією даних шляхом ініціалізації,
        {
            Product_storage = new Dictionary<Product, int>();
            foreach (var item in produts)
                Add(item);
        }
        public Storage()
        {
            Product_storage = new Dictionary<Product, int>();
        }
        public void Add(Product p, int c)
        {
            if (!Product_storage.ContainsKey(p))
                Product_storage.Add(p, c > 0 ? c : 0);
            else
                Product_storage[p] += c;
        }
        public void Add(Product p)
        {
            
            if (!(p.Weight == 0 || p.Price == 0))
                if (!Product_storage.ContainsKey(p))
                    Product_storage.Add(p, 1);
                else
                    Product_storage[p] += 1;
        }
        public void Remove(Product p)
        {
            if (Product_storage.ContainsKey(p))
                Product_storage.Remove(p);
            else
                throw new Exception("Element not found");
        }
        public void InputUserDialog()//наповнення інформацією даних у режимі діалогу з користувачем
        {
            Product p = ConsoleInput.UserInputProduct();
            Add(p);
        }

        public Storage FindMeat()//метод знаходження всіх м’ясних продуктів
        {
            Storage res = new Storage();
            foreach (dynamic item in Product_storage)
            {
                if (item.Key is Meat)
                    res.Add(item.Key,item.Value);
            }
            return res;
        }
        public void ChangePrice(double percent)//метод зміни ціни для всіх товарів на заданий відсоток.
        {
            foreach (var item in Product_storage)
                item.Key.ChangePrice(percent);
        }

        

        public override string ToString()
        {
            string res = "Storage : Product List";
            foreach (var keyVal in Product_storage)
                res += '\n' + keyVal.Key.ToString() + "\nCount = " + keyVal.Value;
            return res;
        }
    }
}