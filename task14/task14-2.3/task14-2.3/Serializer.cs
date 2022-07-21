using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using task14_2._3.add;

namespace task14_2._3
{
    internal class Serializer
    {
        private XmlSerializer formatter;
        public Serializer()
        {
            formatter = new XmlSerializer(typeof(List<Entry>), new Type[] { typeof(Product) });
        }
        public void SerializeItem(Storage<Product> storage,string fileName="myData.xml")
        {
            FileStream s = new FileStream(fileName, FileMode.Create);
            var dictionary = storage.GetAll();

            List<Entry> entries = new List<Entry>(dictionary.Count);
            foreach (object key in dictionary.Keys)
                entries.Add(new Entry(key, dictionary[(Product)key]));

            
            formatter.Serialize(s, entries);
            s.Close();
        }
        public Storage<Product> DeserializeItem(string fileName = "myData.xml")
        {
            
            FileStream s = new FileStream(fileName, FileMode.Open);
            List<Entry> list = (List<Entry>)formatter.Deserialize(s);
            Dictionary<Product, int> dictionary = new Dictionary<Product, int>();

            foreach (Entry entry in list)
            {
                dictionary[(Product)entry.Key] = (int)entry.Value;
            }
            Storage<Product> res = new Storage<Product>(dictionary);
            s.Close();
            return res;
        }
    }//є запитання до цього класу. Попрошу залишитись на обговорення.
    public class Entry
    {
        public object Key;
        public object Value;
        public Entry()
        {
        }

        public Entry(object key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
