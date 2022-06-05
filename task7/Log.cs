using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task7
{
    class Log
    {
        Dictionary<DateTime, string> LogRegister;
        public Log()
        {
            LogRegister = new Dictionary<DateTime, string>();

        }
        public void Add(string s)
        {
            LogRegister.Add(DateTime.Now,s);
            using (StreamWriter sw = File.AppendText("..\\..\\..\\log.txt"))
            {
                sw.WriteLine(DateTime.Now + " => " + s);
            }
        }
        public override string ToString()
        {
            string res = null;
            foreach (var item in LogRegister)
                res += item.Key.ToString() + " => " + item.Value + '\n';

            return res;
        }
    }
}
