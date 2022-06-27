using System;
using System.Collections.Generic;
using static task9.PriceKurant;

namespace task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            loop:
            Console.WriteLine("Input currency = ");
            string currency = Console.ReadLine();
            try
            {
                Menu m = FileReader.ReadMenuFile("Menu.txt");
                PriceKurant pc = FileReader.ReadPriceFile("Prices.txt", currency);
                double price = 0;
                string result = "";
                //за умовою задачі треба було вивести також всі різні продукти, які треба закупити та їх об'єм, а також надати користувачеві вибір грошової одиниці,з якою працюєте.
                for (int i = 0; i < m.Length; i++)
                    if (MenuService.TryGetDishPrice(m[i], pc, out price))
                        result += "Total price of " + m[i].Name + " in " + pc.CurrentCurrency + " = " + price + '\n';

                Console.WriteLine(result);

                StreamWriter writer = new StreamWriter("..\\..\\..\\result.txt");
                writer.WriteLine(result);
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if(flag&&ex.Message.Contains("No such product in price list"))
                {
                    flag = false;
                    Console.WriteLine("Input ingridient name and price for 1kg");
                    Console.WriteLine("Name = ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Price = ");
                    double price = double.Parse(Console.ReadLine());
                    StreamWriter writer = new StreamWriter("..\\..\\..\\Prices.txt", true);
                    writer.WriteLine(name + " - " + price.ToString());
                    writer.Close();
                    
                    //краще обходитись "вічним циклом"
                    goto loop;
                }
                else
                    Console.WriteLine("Again no price for ingridient, exiting");
            }    

        }
    }
}
