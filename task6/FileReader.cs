﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task6
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
        //Виклик у Sentance мав відбутись через FileReader.ReadFromFile()
        public static string ReadFromFile()
        { 
            StreamReader reader;
            try
            {
                reader = new StreamReader(Path);
                return reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {//Не універсально! 
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
        public static string[,] ReadMeterFile()
        {

            string file = ReadFromFile();
            var firstSplit = file.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int n = GetMeterFileInfo()[0];
            //чому так?
            string[,] res = new string[n,7];
            for (int i = 0; i<n;i++)
            {//Вихід за межі.
                var secondSplit = firstSplit[i+1].Split();
                for(int j = 0;j<7;j++)
                    res[i,j] = secondSplit[j];
 
            }

            return res;
        }
    }
}
