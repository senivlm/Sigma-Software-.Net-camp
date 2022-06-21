using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task9
{
    internal class PriceKurant
    {
        public enum Currency { UAH, USD, EUR }
        public Currency CurrentCurrency { get; set; } = Currency.UAH;
        private double course;
        private Dictionary<string, double> _productPrice;
        public PriceKurant(string currency)
        {
            _productPrice = new();

            if (Enum.IsDefined(typeof(Currency), currency))
                CurrentCurrency = Enum.Parse<Currency>(currency);
            else
                throw new Exception("Немає такої валюти (UAH ,USD,EUR)");

            GetCourse("Course.txt");

        }
        public PriceKurant(Dictionary<string, double> productPrice, string currency) : this(currency)
        {
            _productPrice = productPrice;

            if (Enum.IsDefined(typeof(Currency), currency))
                CurrentCurrency = Enum.Parse<Currency>(currency);
            else
                throw new Exception("Немає такої валюти (UAH ,USD,EUR)");

            GetCourse("Course.txt");
        }
        public bool TryGetProductPrice(string productName, out double price)
        {
            if (!_productPrice.TryGetValue(productName, out double result))
            {             
                price = default;
                throw new Exception("No such product in price list " + productName);
                
            }
            price = result/course;
            return true;
        }
        public void Add(string ingr, double price)
        {
            _productPrice.Add(ingr, price);
        }
        private void GetCourse(string path)
        {
            List<double> courses = FileReader.ReadCourseFile(path);
            switch (CurrentCurrency)
            {
                case Currency.UAH:
                    course = courses[0];
                    break;
                case Currency.USD:
                    course = courses[1];
                    break;
                case Currency.EUR:
                    course = courses[2];
                    break;
                default:
                    course = 1;
                    break;
            }
        }
    }
}
