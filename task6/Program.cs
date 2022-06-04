using System;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            Meter m = new Meter("file.txt");
            m.OutputToFile();
            Console.WriteLine(m.GetOneFlat(26)); 
            Console.WriteLine(m.GetMostDebtor(100));
            Console.WriteLine(m.GetUnusedFlat());

            string[] t = m.CalculateCosts(100);
            foreach(var item in t)
                Console.WriteLine(item);

            string[] t2 = m.GetTimePassedFromRecentDate();
            foreach (var item in t2)
                Console.WriteLine(item);

            Sentence s = new Sentence("text.txt");
             Console.WriteLine(s.PrintAndOutputInFile());
        }
    }
}
