using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task6
{
    public class Meter
    {
        private int numberOfFlats;
        private int quarter;
        private List<Flat> info;
        public Meter(string path= "file.txt")
        {
            numberOfFlats = FileReader.GetMeterFileInfo(path)[0];
            quarter = FileReader.GetMeterFileInfo(path)[1];
            info = FileReader.ReadMeterFile(path);
        }

        private Flat GetOneLine(int i)
        {
            return info[i];
        }

        public void OutputToFile(string path= "..\\..\\..\\output.txt")
        {
            string res = null;
            for (int i = 0; i < numberOfFlats; i++)
                res += GetOneLine(i);

            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(res);
            writer.Close();
        }

        public Flat GetOneFlat(int FlatN)
        {
            Flat res = null;
            for (int i = 0; i < numberOfFlats; i++)
                if (info[i].FlatNumber == FlatN)
                    res = GetOneLine(i);

            return res;
        }

        public string GetMostDebtor(int pricePerKvt)
        {
            string res = null;
            int max = 0;

            for (int i = 0; i < numberOfFlats; i++)
            {
                if (info[i].EndIndication - info[i].StartIndication > max)
                {
                    max = info[i].EndIndication - info[i].StartIndication;
                    res = info[i].OwnerSurname;
                }
            }

            return "Найбільший боржник = " + res + " з заборгованістю = " + (pricePerKvt * max).ToString();
        }

        public string GetUnusedFlat()
        {
            string res = null;

            for (int i = 0; i < numberOfFlats; i++)
                if (info[i].EndIndication - info[i].StartIndication == 0)
                    res += info[i].FlatNumber.ToString() + ", ";

            return "Номер квартири, в якій не використовувалась електроенергія = " + res;
        }

        public string[] CalculateCosts(int pricePerKvt)
        {
            string[] res = new string[numberOfFlats];

            for (int i = 0; i < numberOfFlats; i++)
                res[i] = "Квартира №" + info[i].FlatNumber.ToString() + " борг = " + (info[i].EndIndication - info[i].StartIndication) * pricePerKvt;

            return res;
        }

        public string[] GetTimePassedFromRecentDate()
        {
            DateTime now = DateTime.Today;
            DateTime recent;
            string[] res = new string[numberOfFlats];

            for (int i = 0; i < numberOfFlats; i++)
            {
                recent = Convert.ToDateTime((info[i].ThirdDate.ToString() + '.' + ((quarter - 1) * 3 + 2) + ".22"));

                res[i] = "Квартира №" + info[i].FlatNumber + " днів пройшло з моменту останнього зняття показу лічильника = " +
                   now.Subtract(recent).Days.ToString();

            }
            return res;
        }
        
    }
}
