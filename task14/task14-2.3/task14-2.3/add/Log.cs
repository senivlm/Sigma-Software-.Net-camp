using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task14_2._3.add
{
    static class Log
    {
        private static Dictionary<DateTime, string> LogRegister = new Dictionary<DateTime, string>();

        static public void Add(string s)
        {
            LogRegister.Add(DateTime.Now, s);
            using (StreamWriter sw = File.AppendText("..\\..\\..\\log.txt"))
            {
                sw.WriteLine(DateTime.Now + " => " + s);
            }
        }
        public static string ShowLogs()
        {
            string res = null;
            foreach (var item in LogRegister)
                res += item.Key.ToString() + " => " + item.Value + '\n';

            return res;
        }
    }
}
