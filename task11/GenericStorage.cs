using System.Globalization;
using task11.additional;

namespace task11
{
    public class Storage<T> where T : Product
    {
        // Словник використовуємо для швидкого пошуку за ключем, для пошуку по складу за продуктом
        private Dictionary<T, int> product_storage;
        private Log log;
        #region task2

        public T this[int index]//створити індексатор для повного доступу за номером до масиву товарів.
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
        public Storage(params T[] produts)//наповнення інформацією даних шляхом ініціалізації,
        {
            product_storage = new Dictionary<T, int>();
            foreach (T item in produts)
                Add(item);

            log = new Log();
        }
        public Storage()//стандартний конструктор
        {
            product_storage = new Dictionary<T, int>();
            log = new Log();
        }
        public void Add(T p, int c)//додавання декількох продуктів
        {
            if (!product_storage.ContainsKey(p))
                product_storage.Add(p, c > 0 ? c : 0);
            else
                product_storage[p] += c;
        }
        public void Add(T p)//додавання одного продукту
        {

            if (!(p.Weight == 0 || p.Price == 0))
                if (!product_storage.ContainsKey(p))
                    product_storage.Add(p, 1);
                else
                    product_storage[p] += 1;
        }
        public void Remove(T p)//видалення продукту
        {
            if (product_storage.ContainsKey(p))
                product_storage.Remove(p);
            else
                throw new Exception("Element not found");
        }
        public void InputUserDialog()//наповнення інформацією даних у режимі діалогу з користувачем
        {
            T p = (T)ConsoleInput.UserInputProduct();
            Add(p);
        }

        public Storage<Meat> FindMeat()//метод знаходження всіх м’ясних продуктів
        {
            Storage<Meat> res = new Storage<Meat>();
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

        public override string ToString()//виведення з вказаним узагальненим типом
        {
            string res = typeof(T).Name+"_Storage : Product List";
            foreach (var keyVal in product_storage)
                res += '\n' + keyVal.Key.ToString() + "\nCount = " + keyVal.Value;
            return res;
        }
        #endregion task2
        #region task7

        private string ReadPlainFromFiles()//читання з файлу
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

        private void Add(List<string> data)//парсинг тексту у продукт
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

                    Add((T)p);
                }
                catch (Exception e)
                {
                    // пропонувалась фіксація часу виникнення проблеми.
                    //REPLY: це перевантажений метод, з класу Log
                    log.Add(e.Message);
                }

            }

        }

        public void InputFromFiles()//наповнення з файлу
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
                //максимально маємо 5 параметрів: ім'я, ціну, вагу, тип+клас м'яса АБО строк молочного продукту
                for (int j = 0; j < 5; j++)
                    p.Add(j < secondSplit.Length ? secondSplit[j].Trim() : null);

                Add(p);
            }
        }

        public string ShowLogs()//виведення логів
        {
            return log.ToString();
        }
        #endregion task7
    }
}