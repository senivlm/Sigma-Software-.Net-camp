using CassApp.Data;
using Task12_3;

namespace CassApp
{
    internal class PersonGenerator
    {

        public List<Person> Generate()
        {
            Reader reader = new Reader();
            List<Person> persons = new List<Person>();
            List<string> otherPersons = reader.ReadExpresion();

            foreach (var item in otherPersons)
            {
                persons.Add(PersonsParser.Parse(item));
            }

            return persons;
        }

        //public void WriteRandomGenerate(int UpRandomNumber)
        //{
        //    for (int i = 0; i < UpRandomNumber; i++)
        //    {
        //        Writer write = new Writer();
        //        write.WritePerson(new Person($"Pasanger{Guid.NewGuid().ToString()[33..]}",
        //            random.Next(0, UpRandomNumber),
        //            Math.Round(random.NextDouble(), 2), $"status{random.Next(1, UpRandomNumber)} ",
        //          random.Next(1, 10)));
        //    }

        //}



    }
}
