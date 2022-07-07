namespace CassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimeCordinator timeCordinator = new TimeCordinator();

            timeCordinator.Cordinate(new List<Cassa>
            {
                (new Cassa (1.0)),
                (new Cassa (0.5)),
                (new Cassa (00.0))
            },
            "..\\..\\..\\Files\\Person.txt");

            Console.ReadLine();

        }
    }
}