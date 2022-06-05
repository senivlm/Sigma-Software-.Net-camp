using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using task6;

namespace task7
{
   public class Storage
    {
        List<Product> Product_storage;
        Log log;
        #region task2
        public Storage(params Product[] produts)//наповнення інформацією даних шляхом ініціалізації,
        {
            Product_storage = new List<Product>();
            foreach (var item in produts)
                Product_storage.Add(item);
        }
        public Storage()
        {
            Product_storage = new List<Product>();
            log = new Log();
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
        #endregion task2
        #region task7
        private string ReadPlainFromFiles()
        {
            FileReader fr = new FileReader();
            string res = null;
            int i = 0;
            do
            {
                Console.WriteLine("Введіть назву файлу = ");
                fr.Path = Console.ReadLine();
                res = fr.ReadFromFile();
                i++;
            }
            while (i < 3&&res == "Файл не знайдено");
            return res;
        }

        private void Add(List<string> data)
        {

            string name = data[0];
            if (char.IsLower(name[0]))
                name = char.ToUpper(name[0]) + name.Substring(1);
            double price=0, weight=0;

            if (double.TryParse(data[1], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double pr))
                price = pr;
            if (double.TryParse(data[2], NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double wh))
                weight = wh;

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

                    Product_storage.Add(p);
                }
                catch (Exception e)
                {
                    log.Add(e.Message);
                }
                
            }
               
        }

        public void InputFromFiles()
        {
            string file = ReadPlainFromFiles();
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> p;
            for (int i = 0; i < firstSplit.Length; i++)
            {
                p = new List<string>();
                var secondSplit = firstSplit[i].Split(',', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < 5; j++)
                    p.Add(j<secondSplit.Length?secondSplit[j].Trim():null);

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
