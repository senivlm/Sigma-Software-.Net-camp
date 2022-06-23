using System;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            try { 
            Storage s = new Storage();
            s.InputFromFiles();
            Check.Output(s);
            Console.WriteLine(s.ShowLogs());
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            //Не побачила другої частини завдання.
            //Теоретичне завдання. Визначити ситуації, коли метод фіналізації винятків не буде спрацьовувати.
            //    Єдине, що може перешкодити виконанню блоку finally -нескінченний цикл або несподіване завершення процесу.
        }
    }
}
