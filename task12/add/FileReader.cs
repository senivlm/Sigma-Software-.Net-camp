using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task12.add
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
    }
}
