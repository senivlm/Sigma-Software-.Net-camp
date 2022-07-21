using System.Globalization;
using task14_2._3.add;

namespace task14_2._3
{

    public delegate void ExpiringNotify(string name,DateTime d);
    public class Storage<T> where T : Product
    {
        private static Storage<T> instance;
        public static Storage<T> Instance()
        {
            if (instance == null)
                instance = new Storage<T>();
            //else
            //    throw new Exception("SIngleton instance already exists");
            return instance;
        }
        // Словник використовуємо для швидкого пошуку за ключем, для пошуку по складу за продуктом
        Dictionary<T, int> product_storage;
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
        // при наявності відкритих конструкторів клас не може бути Одинаком.!!!
        public Storage(params T[] produts)//наповнення інформацією даних шляхом ініціалізації,
        {
            product_storage = new Dictionary<T, int>();
            foreach (T item in produts)
                Add(item);


        }
        public Storage(Dictionary<T, int> product_storage)//наповнення інформацією даних шляхом ініціалізації,
        {
            this.product_storage = product_storage;
            
        }
        public Storage()//стандартний конструктор
        {
            product_storage = new Dictionary<T, int>();

        }
        public void Add(T p, int c)//додавання декількох продуктів
        {
            if (!product_storage.ContainsKey(p))
                product_storage.Add(p, c > 0 ? c : 0);
            else
                product_storage[p] += c;
        }
        public Dictionary<T, int> GetAll()
        {
            return product_storage;
        }
        #endregion task2
        #region task10.quest1
        public virtual event ExpiringNotify DateExpied;
        protected virtual void OnDateExpired(T p)
        {
            DateExpied?.Invoke(p.Name,(p as Dairy_products).ExpireDate.Date);
        }
       
        public void Add(T p)//додавання одного продукту
        {
            if (p is Dairy_products )
            {
                if((p as Dairy_products)?.ExpireDate.Date< DateTime.Now.Date)
                    OnDateExpired(p);
            }
            if (!(p.Weight == 0 || p.Price == 0))
                if (!product_storage.ContainsKey(p))
                    product_storage.Add(p, 1);
                else
                    product_storage[p] += 1;
        }
        #endregion task10.quest1
        #region task10.quest2

        public List<T> Search(string request)//пошук одного продукту
        {
 
            if (request == null)
                throw new Exception("Invalid search request");
            try
            {
                var doubleParsed = double.TryParse(request, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out double requestToDouble);
                var dateParsed = DateTime.TryParse(request, out DateTime requestToDate);
                Category categoryOfMeat = Category.First;
                MeatType typeOfMeat = MeatType.Chicken;
                var categoryParsed = Enum.IsDefined(typeof(Category), request);
                var typeParsed = Enum.IsDefined(typeof(MeatType), request);
                if (categoryParsed)
                    categoryOfMeat = Enum.Parse<Category>(request);
                if (typeParsed)
                    typeOfMeat = Enum.Parse<MeatType>(request);


                List<T> res = new List<T>();

                List<T> keyList = new List<T>(this.product_storage.Keys);

                if (keyList.Exists(x => x.Name.Contains(request)))
                    res.AddRange(keyList.FindAll(x => x.Name.Contains(request)));

                else if (doubleParsed && keyList.Exists(x => x.Price == requestToDouble))
                    res.AddRange(keyList.FindAll(x => x.Price == requestToDouble));

                else if (doubleParsed && keyList.Exists(x => x.Weight == requestToDouble))
                    res.AddRange(keyList.FindAll(x => x.Weight == requestToDouble));

                else if (dateParsed && keyList.Exists(x => (x as Dairy_products)?.ExpireDate.Date == requestToDate))
                    res.AddRange(keyList.FindAll(x => (x as Dairy_products)?.ExpireDate.Date == requestToDate));

                else if (categoryParsed && keyList.Exists(x => (x as Meat)?.CategoryOfMeat == categoryOfMeat))
                    res.AddRange(keyList.FindAll(x => (x as Meat)?.CategoryOfMeat == categoryOfMeat));

                else if (typeParsed && keyList.Exists(x => (x as Meat)?.TypeOfMeat == typeOfMeat))
                    res.AddRange(keyList.FindAll(x => (x as Meat)?.TypeOfMeat == typeOfMeat));

                return res;
            }
            catch (Exception e)
            {

                // пропонувалась фіксація часу виникнення проблеми.
                //REPLY: це перевантажений метод, з класу Log
                Log.Add(e.Message);
                return null;
            }

        }
        #endregion task10.quest2
        #region task2
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
                    if (DateTime.TryParse(categoryORexpiring, out DateTime ex))
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
                    Log.Add(e.Message);
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

       
        #endregion task7
    }
}
