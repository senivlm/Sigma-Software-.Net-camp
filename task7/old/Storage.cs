using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Globalization;

namespace task7
{
    public class Storage
    {
        private Dictionary<Product, int> product_storage;
        private Log log;
        #region task2

        public Product this[int index]//створити індексатор для повного доступу за номером до масиву товарів.
        {
            get
            {
                if (index >= 0 && index < product_storage.Count)
                {
                    return product_storage.ElementAt(index).Key;
                }
                else
                {
                    throw new Exception("Index out of range array");
                }

            }
            set
            {
                product_storage.Remove(product_storage.ElementAt(index).Key);
                Add(value);
            }
        }
        public Storage(params Product[] produts)//наповнення інформацією даних шляхом ініціалізації,
        {
            product_storage = new Dictionary<Product, int>();
            foreach (var item in produts)
                Add(item);

            log = new Log();
        }
        public Storage()
        {
            product_storage = new Dictionary<Product, int>();
            log = new Log();
        }
        public void Add(Product p, int c)
        {
            if (!product_storage.ContainsKey(p))
                product_storage.Add(p, c > 0 ? c : 0);
            else
                product_storage[p] += c;
        }
        public void Add(Product p)
        {

            if (!(p.Weight == 0 || p.Price == 0))
                if (!product_storage.ContainsKey(p))
                    product_storage.Add(p, 1);
                else
                    product_storage[p] += 1;
        }
        public void Remove(Product p)
        {
            if (product_storage.ContainsKey(p))
                product_storage.Remove(p);
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
            foreach (dynamic item in product_storage)
            {
                if (item.Key is Meat)
                    res.Add(item.Key, item.Value);
            }
            return res;
        }
        public void ChangePrice(double percent)//метод зміни ціни для всіх товарів на заданий відсоток.
        {
            foreach (var item in product_storage)
                item.Key.ChangePrice(percent);
        }

        public override string ToString()
        {
            string res = "Storage : Product List";
            foreach (var keyVal in product_storage)
                res += '\n' + keyVal.Key.ToString() + "\nCount = " + keyVal.Value;
            return res;
        }
        #endregion task2
        #region task7

        private string ReadPlainFromFiles()
        {

            string res = null;
            int i = 0;
            do
            {
                Console.WriteLine("Введіть назву файлу = ");
                string path = Console.ReadLine();
                res = FileReader.ReadFromFile(path);
                i++;
            }
            while (i < 3 && res == "File not found");
            return res;
        }

        private void Add(List<string> data)
        {

            string name = data[0];
            if (char.IsLower(name[0]))
                name = char.ToUpper(name[0]) + name.Substring(1);
            double price = 0, weight = 0;

            if (double.TryParse(data[1], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double pr))
                price = pr;
            //Це виноситься у логи у рядку 156
            //else
            //    throw new Exception("Invalid product price");
            if (double.TryParse(data[2], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double wh))
                weight = wh;
            //else
            //    throw new Exception("Invalid product weight");

            string categoryORexpiring = data[3];
            string type = data[4];


            if (name != null && data[1] != null && data[2] != null)
            {
                Product p;
                try
                {
                    if (int.TryParse(categoryORexpiring, out int ex))
                        p = new Dairy_products(ex, name, price, weight);
                    else if (categoryORexpiring != null && type != null)
                        p = new Meat(categoryORexpiring, type, name, price, weight);
                    else
                        p = new Product(name, price, weight);

                    Add(p);
                }
                catch (Exception e)
                {
                    // пропонувалась фіксація часу виникнення проблеми.
                    //REPLY: це перевантажений метод, з класу Log
                    log.Add(e.Message);
                }

            }

        }

        public void InputFromFiles()
        {
            string file = ReadPlainFromFiles();
            if (file == "File not found")
                throw new Exception("File not found");
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> p;
            for (int i = 0; i < firstSplit.Length; i++)
            {
                p = new List<string>();
                var secondSplit = firstSplit[i].Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < 5; j++)
                    p.Add(j < secondSplit.Length ? secondSplit[j].Trim() : null);

                Add(p);
            }
        }

        public string ShowLogs()
        {
            return log.ToString();
        }
        #endregion task7

    }
}
