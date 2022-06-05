using System;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {

            Storage s = new Storage();
            s.InputFromFiles();
            s.Output();
            Console.WriteLine(s.ShowLogs());

        }
    }
}
