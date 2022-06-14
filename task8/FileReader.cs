using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using static task8.IP_File;

namespace task8
{
    class FileReader
    {
        public static string Path { get; set; }
        public FileReader(string path)
        {
            Path = path;
        }
        public FileReader(): this(null) { }

        public override string ToString()
        {
            using (StreamReader sr = new StreamReader(Path))
                return sr.ReadToEnd();
        }
        public static string ReadFromFile()
        { 
            StreamReader reader;
            try
            {
                reader = new StreamReader(Path);
                return reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                try
                {
                    reader = new StreamReader("..\\..\\..\\" + Path);
                    return reader.ReadToEnd();
                }
                catch (FileNotFoundException)
                {
                    return "File not found"; 
                }
            }
            

        }
        public static int[] GetMeterFileInfo()
        {
            int[] res = new int[2];

            string file = ReadFromFile();
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var secondSplit = firstSplit[0].Split();

            res[0] =Convert.ToInt32(secondSplit[0]);
            res[1] = Convert.ToInt32(secondSplit[1]);

            return res;
        }
        public static FlatList ReadMeterFile()
        {

            string file = ReadFromFile();
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int n = GetMeterFileInfo()[0];
            int q = GetMeterFileInfo()[1];
            FlatList res = new FlatList();
            for (int i = 0; i<n;i++)
            {
                var secondSplit = firstSplit[i+1].Split();
                res.Add(new Flat(Convert.ToInt32(secondSplit[0]), secondSplit[1], Convert.ToInt32(secondSplit[2]), Convert.ToInt32(secondSplit[3]), Convert.ToInt32(secondSplit[4]), Convert.ToInt32(secondSplit[5]), Convert.ToInt32(secondSplit[6]),q));
 
            }

            return res;
        }

        public static List<IP> ReadIPFile()
        {

            string file = ReadFromFile();
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int n = firstSplit.Length;

            List<IP> res = new List<IP>();

            for (int i = 0; i < n; i++)
            {
                var secondSplit = firstSplit[i].Split();
                res.Add(new IP(secondSplit[0], DateTime.ParseExact(secondSplit[1], "HH:mm:ss", CultureInfo.InvariantCulture), secondSplit[2]));
            }

            return res;
        }
    }
}
