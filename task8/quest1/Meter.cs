using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static task8.FileReader;
namespace task8
{
    class Meter
    {
        #region task6
        int NumberOfFlats;
        int Quarter;
        FlatList Info;
        public Meter(string path)
        {
            FileReader fr = new FileReader(path);
            NumberOfFlats = GetMeterFileInfo()[0];
            Quarter = GetMeterFileInfo()[1];
            Info = ReadMeterFile();
        }
        private Flat GetOneLine(int i)
        {
            return Info[i];
        }
        public void OutputToFile()
        {
            string res = null;
            for (int i = 0; i < NumberOfFlats; i++)
                res += GetOneLine(i);

            StreamWriter writer = new StreamWriter("..\\..\\..\\output.txt");
            writer.WriteLine(res);
            writer.Close();
        }

        public Flat GetOneFlat(int FlatN)
        {
            Flat res=null;
            for (int i = 0; i < NumberOfFlats; i++)
                if (Info[i].FlatNumber == FlatN)
                    res = GetOneLine(i);

            return res;
        }

        public string GetMostDebtor(int pricePerKvt)
        {
            string res = null;
            int max = 0;

            for (int i = 0; i < NumberOfFlats; i++)
            {
                if (Info[i].EndIndication - Info[i].StartIndication > max)
                {
                    max = Info[i].EndIndication - Info[i].StartIndication;
                    res = Info[i].OwnerSurname;
                }
            }   

            return "Найбільший боржник = "+res+" з заборгованістю = " +(pricePerKvt*max).ToString();
        }

        public string GetUnusedFlat()
        {
            string res = null;

            for (int i = 0; i < NumberOfFlats; i++)
                if (Info[i].EndIndication - Info[i].StartIndication == 0)
                    res+= Info[i].FlatNumber.ToString() + ", ";

            return "Номер квартири, в якій не використовувалась електроенергія = " + res;
        }

        public string[] CalculateCosts(int pricePerKvt)
        {
            string[] res = new string[NumberOfFlats];

            for (int i = 0; i < NumberOfFlats; i++)
                res[i] = "Квартира №" + Info[i].FlatNumber.ToString() + " борг = "+(Info[i].EndIndication - Info[i].StartIndication) * pricePerKvt;

            return res;
        }

        public string[] GetTimePassedFromRecentDate()
        {
            DateTime now = DateTime.Today;
            DateTime recent;
            string[] res = new string[NumberOfFlats];

            for (int i = 0; i < NumberOfFlats; i++)
            {
                recent = Convert.ToDateTime((Info[i].ThirdDate.ToString() + '.' + ((Quarter - 1) * 3 + 2) + ".22"));

                res[i] = "Квартира №" + Info[i].FlatNumber + " днів пройшло з моменту останнього зняття показу лічильника = " +
                   now.Subtract(recent).Days.ToString();
                
            }
            return res;
        }
        #endregion task6

        #region task8
        private FlatList TestPlusOverride(FlatList a, FlatList b)
        {
            NumberOfFlats = a.Count + b.Count;
            return a + b;
        }
        public void TestPlusOverride()
        {

            var a = Info;
            var b = new FlatList();
            b.Add(new Flat(33,"Likachev",1234,4567,5,12,4,Quarter));
            b.Add(new Flat(34, "Borisov", 4321, 6543, 21, 2, 1, Quarter));

            Info = TestPlusOverride(a,b);
        }

        private FlatList TestMinusOverride(FlatList a, FlatList b)
        {
            NumberOfFlats = (a-b).Count;
            return a - b;
        }
        public void TestMinusOverride()
        {

            var a = Info;
            var b = new FlatList();
            b.Add(new Flat(33, "Likachev", 1234, 4567, 5, 12, 4, Quarter));
            b.Add(new Flat(35, "Noname", 4123, 5555, 2, 2, 1, Quarter));

            Info = TestMinusOverride(a, b);
        }

        public override string ToString()
        {
            string res="";
            foreach (var a in Info)
                res += a.ToString();
            return res;
        }
        #endregion task8
    }
}
