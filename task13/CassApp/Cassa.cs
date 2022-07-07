using CassApp.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal class Cassa 
    {
        double coordinate;
        public double Coordinate { get => coordinate; }

        PriorityQueue<Person, string> queuePersons;

        public Cassa()
        {
            queuePersons = new();
            coordinate = 0;
        }

        public Cassa(double cordinate)
        {
            queuePersons = new();
            this.coordinate = cordinate;
        }

        public bool IsEmpty()
        {
            return queuePersons.Count == 0;
        }

        public void Enqueue(Person person)
        {
            queuePersons.Enqueue(person, person.Status);
        }
        public void EnqueueAge(Person person)
        {
            queuePersons.Enqueue(person, person.Age.ToString());
        }

        public Person Dequeue()
        {
            return queuePersons.Dequeue();
        }

        public Person Peek()
        {
            return queuePersons.Peek();
        }
        #region added
       
        public int QueueLength()
        {
            return queuePersons.Count;
        }
        public double GetCoordinates()
        {
            return coordinate;
        }
        public override string ToString()
        {
            return "Cassa coordinates = " + Coordinate;
        }
        #endregion added
    }
}
