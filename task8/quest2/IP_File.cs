using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static task8.FileReader;

namespace task8
{
    class IP_File
    {
       public struct IP
        {
            public enum DaysOfWeek {sunday, monday, tuesday, wednesday, thursday, friday, saturday }
            public string IP_Address{get;set;}
            public TimeSpan AccessTime { get; set; }
            public DaysOfWeek WeekDay { get; set; }
            public IP(string ip, DateTime time, string day)
            {
                IP_Address = ip;
                AccessTime = time.TimeOfDay;
                if (Enum.IsDefined(typeof(DaysOfWeek), day))
                    WeekDay = Enum.Parse<DaysOfWeek>(day);
                else
                    throw new Exception("Немає такого типу дня");

            }
            public override string ToString()
            {
                return "IP = " + IP_Address + " Time = " + AccessTime.ToString() + " Day = " + WeekDay;
            }
        }

        private List<IP> Info { get; set; }
        public IP_File(string path)
        {
            FileReader fr = new FileReader(path);
            Info = ReadIPFile();
        }
        public Dictionary<string,int>  CountVisitsByIP()
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            for(int i = 0; i<Info.Count;i++)
            {
                if (!res.ContainsKey(Info[i].IP_Address))
                    res.Add(Info[i].IP_Address, 1);
                else
                    res[Info[i].IP_Address]++;
            }

            return res;
        }
        private string MostPopularDayForOne(string userIP)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            for (int i = 0; i < Info.Count; i++)
            {
                if (Info[i].IP_Address != userIP)
                    continue;
                if (!res.ContainsKey(Info[i].WeekDay.ToString()))
                    res.Add(Info[i].WeekDay.ToString(), 1);
                else
                    res[Info[i].WeekDay.ToString()]++;
            }
            var keyOfMostPopular =res.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMostPopular;
        }
        public Dictionary<string, string> MostPopularDayForEvery()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();

            for (int i = 0; i < Info.Count; i++)
                if(!res.ContainsKey(Info[i].IP_Address))
                    res.Add(Info[i].IP_Address, MostPopularDayForOne(Info[i].IP_Address));

            return res;
        }
        private string RushHour(string userIP)
        {
            Dictionary<TimeSpan, int> res = new Dictionary<TimeSpan, int>();

            for (int i = 0; i < 23; i++)
                for (int j = 0; j < Info.Count; j++)
                {
                    if (Info[j].IP_Address != userIP)
                        continue;
                    TimeSpan time = new TimeSpan(i, 0, 0);
                    if (time<Info[j].AccessTime && Info[j].AccessTime<time+ TimeSpan.FromHours(1))
                    {
                        if (!res.ContainsKey(time))
                            res.Add(time, 1);
                        else
                            res[time]++;
                    }
                }

            var keyOfMostPopular = res.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMostPopular.ToString() + " - " + (keyOfMostPopular + TimeSpan.FromHours(1)).ToString();
        }
       
        public Dictionary<string, string> RushHour()
        {
            Dictionary<string, string> res = new Dictionary<string, string>();

            for (int i = 0; i < Info.Count; i++)
                    if (!res.ContainsKey(Info[i].IP_Address))
                    res.Add(Info[i].IP_Address, RushHour(Info[i].IP_Address));

            return res;
        }
        public string RushHourGeneral()
        {
            Dictionary<TimeSpan, int> res = new Dictionary<TimeSpan, int>();

            for (int i = 0; i < 23; i++)
                for (int j = 0; j < Info.Count; j++)
                {
                    TimeSpan time = new TimeSpan(i, 0, 0);
                    if (time < Info[j].AccessTime && Info[j].AccessTime < time + TimeSpan.FromHours(1))
                    {
                        if (!res.ContainsKey(time))
                            res.Add(time, 1);
                        else
                            res[time]++;
                    }
                }

            var keyOfMostPopular = res.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMostPopular.ToString() + " - " + (keyOfMostPopular + TimeSpan.FromHours(1)).ToString();
        }
    }
}
