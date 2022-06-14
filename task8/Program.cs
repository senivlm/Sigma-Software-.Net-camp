using System;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Meter m = new Meter("file.txt");

            m.TestPlusOverride();
            Console.WriteLine(m);
            Console.WriteLine("_____________");
            m.TestMinusOverride();
            Console.WriteLine(m);

            IP_File i = new IP_File("IP_file.txt");
            var microtask1 = i.CountVisitsByIP();
            foreach (var keyVal in microtask1)
                Console.WriteLine("IP = " + keyVal.Key + " Count =" + keyVal.Value);
            Console.WriteLine("_____________");
            Console.WriteLine("MostPopularDay = " + i.MostPopularDay());
            Console.WriteLine("_____________");
            Console.WriteLine("RushHour = " + i.RushHour());
            Console.WriteLine("_____________");

            Product[] arr = new Product[4];
            arr[0] = new Product("Ice-cream", 22, 0.08);
            arr[1] = new Dairy_products(10, "Milk", 100, 0.9);
            arr[2] = new Meat(Category.Highest, MeatType.Lamb, "Lamb", 100, 50);
            arr[3] = new Product("Sandwich", 40, 0.05);
            Storage storage1 = new Storage(arr);

            Product[] arr2 = new Product[3];
            arr2[0] = new Product("Ice-cream", 100, 0.08);
            arr2[1] = new Dairy_products(10, "Milk", 100, 0.9);
            arr2[2] = new Meat(Category.Second, MeatType.Chicken, "Nuggets", 100, 50);
            
            Storage storage2 = new Storage(arr2);

            var res = Storage.FirstExceptSecond(storage1, storage2);
            res.Output();
            //можна було б використати одні функції в інших, але вже дуже піздно
            var res2 = Storage.SameInFirstAndSecond(storage1, storage2);
            res2.Output();

            var res3 = Storage.SelectAllDistinct(storage1, storage2);
            res3.Output();
        }
    }
}
