using System;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
//Не побачила другої частини завдання.
            Storage s = new Storage();
            s.InputFromFiles();
            s.Output();
            Console.WriteLine(s.ShowLogs());

        }
    }
}
