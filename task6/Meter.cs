using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static task6.FileReader;
namespace task6
{
    class Meter
    {// не дуже подобається проектування. Можу усно пояснити проблеми.
        int NumberOfFlats;
        int Quarter;
        string[,] Info;
        public Meter(string path)
        {
            FileReader fr = new FileReader(path);
            NumberOfFlats = GetMeterFileInfo()[0];
            Quarter = GetMeterFileInfo()[1];
            Info = ReadMeterFile();
        }
        private string GetOneLine(int i)
        {
            return
                String.Format("Квартира №{0,3}; Прізвище власника = {1,15}; Початкові покази = {2,5}; Кінцеві покази = {3,5};" +
                " Дати передачі показів :{4,10}, {5,10}, {6,10}",
                Info[i, 0],
                Info[i, 1],
                Info[i, 2],
                Info[i, 3],
                (Info[i, 4] + '.' + (Quarter - 1) * 3 + ".22"),
                (Info[i, 5] + '.' + ((Quarter - 1) * 3 + 1) + ".22"),
                (Info[i, 6] + '.' + ((Quarter - 1) * 3 + 2) + ".22")) + '\n';
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

        public string GetOneFlat(int FlatN)
        {
            string res = "Квартиру не знайдено";
            for (int i = 0; i < NumberOfFlats; i++)
                if (Info[i, 0] == FlatN.ToString())
                    res = GetOneLine(i);

            return res;
        }

        public string GetMostDebtor(int pricePerKvt)
        {
            string res = null;
            int max = 0;

            for (int i = 0; i < NumberOfFlats; i++)
            {
                if (Convert.ToInt32(Info[i, 3]) - Convert.ToInt32(Info[i, 2]) > max)
                {
                    max = Convert.ToInt32(Info[i, 3]) - Convert.ToInt32(Info[i, 2]);
                    res = Info[i, 1];
                }
            }   

            return "Найбільший боржник = "+res+" з заборгованістю = " +(pricePerKvt*max).ToString();
        }

        public string GetUnusedFlat()
        {
            string res = null;

            for (int i = 0; i < NumberOfFlats; i++)
                if (Convert.ToInt32(Info[i, 3]) - Convert.ToInt32(Info[i, 2]) == 0)
                    res+= Info[i, 0]+", ";

            return "Номер квартири, в якій не використовувалась електроенергія = " + res;
        }

        public string[] CalculateCosts(int pricePerKvt)
        {
            string[] res = new string[NumberOfFlats];

            for (int i = 0; i < NumberOfFlats; i++)
                res[i] = "Квартира №" + Info[i, 0] + " борг = "+(Convert.ToInt32(Info[i, 3]) - Convert.ToInt32(Info[i, 2]))* pricePerKvt;

            return res;
        }

        public string[] GetTimePassedFromRecentDate()
        {
            DateTime now = DateTime.Today;
            DateTime recent;
            string[] res = new string[NumberOfFlats];

            for (int i = 0; i < NumberOfFlats; i++)
            {
                recent = Convert.ToDateTime((Info[i, 6] + '.' + ((Quarter - 1) * 3 + 2) + ".22"));

                res[i] = "Квартира №" + Info[i, 0] + " днів пройшло з моменту останнього зняття показу лічильника = " +
                   now.Subtract(recent).Days.ToString();
                
            }
            return res;
        }
    }
}
