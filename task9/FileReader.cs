using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;


namespace task9
{
    public class FileReader
    {
       
        public static string ReadFromFile(string path)
        { 
            StreamReader reader;
            try
            {
                reader = new StreamReader(path);
                var res = reader.ReadToEnd();
                reader.Close();
                return res;
            }
            catch (FileNotFoundException)
            {
                try
                {
                    reader = new StreamReader("..\\..\\..\\" + path);
                    var res = reader.ReadToEnd();
                    reader.Close();
                    return res;
                }
                catch (FileNotFoundException)
                {
                    return "File not found"; 
                }
            }
            

        }
     
        internal static Menu ReadMenuFile(string path)
        {

            string file = ReadFromFile(path);
            var firstSplit = file.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int limit = firstSplit.Length;
            int n= firstSplit.Where(x => string.IsNullOrEmpty(x)).Count()+1;

            Menu res = new Menu();
            Dish dish=null;
            string item = null;
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                dish = new Dish();
                dish.Name = firstSplit[k];
                k++;
                while (k < limit)
                {
                    item = firstSplit[k];
                    k++;
                    if (item != "")
                    {
                        var secondSplit = item.Split(new string[] { " - " }, StringSplitOptions.None);
                        dish.Add(secondSplit[0], Convert.ToDouble(secondSplit[1])/1000.0);
                    }
                    else
                    {
                        item = null;
                        break;
                    }
                }
                res.Add(dish);
            }
           
            return res;
        }
        internal static PriceKurant ReadPriceFile(string path,string cur)
        {

            string file = ReadFromFile(path);
            var firstSplit = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int n = firstSplit.Length;

            PriceKurant res = new PriceKurant(cur);

            for (int i = 0; i < n; i++)
            {
                var secondSplit = firstSplit[i].Split(new string[] { " - " }, StringSplitOptions.None);
                res.Add(secondSplit[0], Convert.ToDouble(secondSplit[1]));
            }

            return res;
        }
        internal static List<double> ReadCourseFile(string path)
        {

            string file = ReadFromFile(path);
            var firstSplit = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int n = firstSplit.Length;

            List<double> res = new List<double>();

            for (int i = 0; i < n; i++)
                res.Add(Convert.ToDouble(firstSplit[i]));
           

            return res;
        }
    }
}
