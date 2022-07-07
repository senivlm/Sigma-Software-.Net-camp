using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Data
{
    internal class Person
    {
        public Guid Id { get; }
        string name;
        int timeService;
        int age;
        double coordinate;
        string status;

        public int TimeService 
        { 
            get => timeService;
            set
            {
                timeService = value;
            }
        }

        public string Status { get => status; }
        public int Age { get => age; }
        public double Coordinate { get => coordinate; }

        public Person() : this("", default, default, default, default) { }

        public Person(string status,string name, int age, double coordinate, int timeService)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.age = age;
            this.coordinate = coordinate;
            this.status = status;
            this.timeService = timeService;
        }

        public override string ToString()
        {
            return $"[{status}] - Name = {name} Age = {age} Coord = {coordinate} Time = {timeService}";
        }
    }
}
