using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_3
{
    internal class Writer
    {
        private string filePath;

        public string FilePAth
        {
            get => filePath;
            set
            {
                if (value != null) filePath = value;
            }
        }

        public Writer(string filePath)
        {
            this.filePath = filePath;
        }

        public Writer()
        {
            filePath = "..\\..\\..\\Files\\Person.txt";
        }

        public void WritePerson(Person person, string filePath = "..\\..\\..\\Files\\Person.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                    sw.WriteLine(person.ToString());
                sw.Close();
            }
        }
    }
}
