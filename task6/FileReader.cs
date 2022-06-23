using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task6
{
    static class FileReader
    {

        public static string ReadFromFile(string path)
        { 
            StreamReader reader;
            try
            {
                reader = new StreamReader(path);
                return reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                try
                {
                    reader = new StreamReader("..\\..\\..\\" + path);
                    return reader.ReadToEnd();
                }
                catch (FileNotFoundException)
                {
                    return "File not found"; 
                }
            }
            

        }
        public static int[] GetMeterFileInfo(string path)
        {
            int[] res = new int[2];

            string file = ReadFromFile(path);
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var secondSplit = firstSplit[0].Split();

            res[0] = Convert.ToInt32(secondSplit[0]);
            res[1] = Convert.ToInt32(secondSplit[1]);

            return res;
        }
        public static List<Flat> ReadMeterFile(string path)
        {

            string file = ReadFromFile(path);
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int n = GetMeterFileInfo(path)[0];
            int q = GetMeterFileInfo(path)[1];
            List<Flat> res = new List<Flat>();
            //Тут не вихід за межі, а просто ігноруємо перший рядок з даними, який квартал і скільки квартир
            for (int i = 1; i < n+1; i++)
            {
                var secondSplit = firstSplit[i].Split();
                res.Add(new Flat(Convert.ToInt32(secondSplit[0]), secondSplit[1], Convert.ToInt32(secondSplit[2]), Convert.ToInt32(secondSplit[3]), Convert.ToInt32(secondSplit[4]), Convert.ToInt32(secondSplit[5]), Convert.ToInt32(secondSplit[6]), q));

            }

            return res;
        }
    }
}
