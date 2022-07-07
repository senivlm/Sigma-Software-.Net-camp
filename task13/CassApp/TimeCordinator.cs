using CassApp.Data;

namespace CassApp
{
    internal class TimeCordinator
    {
        int timeCounter = 5;
        #region added
        private double FindDistance(Cassa c, Person p)
        {
            return Math.Abs(c.Coordinate - p.Coordinate);
        }
        private int ChooseCassa(List<Cassa> casses, Person person)
        {
            int result;
            List<int> cassaQueues = new List<int>();
            List<double> cassaDistances = new List<double>();
            foreach (var cassa in casses)
                cassaQueues.Add(cassa.QueueLength());

            if (cassaQueues.Distinct().Count() != 1)
            {
                result = cassaQueues.IndexOf(cassaQueues.Min());
            }
            else//усі черги однакової довжини
            {
                foreach (var cassa in casses)
                    cassaDistances.Add(FindDistance(cassa, person));

                result = cassaDistances.IndexOf(cassaDistances.Min());
            }
            return result;

        }


        public delegate void CassaOverflow(ref List<Cassa> casses, Cassa c);
        public virtual event CassaOverflow Reprofile;
        protected virtual void OnCassaOverflow(ref List<Cassa> casses, Cassa c)
        {
            Reprofile += ReprofileCassa;
            var a = Reprofile.Method;
            Reprofile?.Invoke(ref casses,c);
        }

        private void ReprofileCassa(ref List<Cassa> casses, Cassa c)
        {
            Person pers;
            List<Person> newQueue = new List<Person>();
            casses.Remove(c);
            int count = c.QueueLength();
            for (int i = 0; i<count;i++)
            {
                pers = c.Dequeue();
                if (pers.Status != "[status2]")
                {
                    var index = ChooseCassa(casses, pers);
                    casses[index].Enqueue(pers);
                }
                else
                    newQueue.Add(pers);

            }
            foreach (var item in newQueue)
                c.Enqueue(item);
            casses.Add(c);
        }
        #endregion added
        public List<string> Cordinate(List<Cassa> casses, string path)
        {
            bool secondReprofile = false;
            bool isProcess = true;
            int counter = 0;
            int time = 0;
            int cassaLimit = 4;
            PersonGenerator pGen = new PersonGenerator();
            List<Person> persons = pGen.Generate();
            List<string> result = new List<string>();

            while (isProcess)
            {
                time++;
                if (time % timeCounter == 0 && counter < persons.Count)
                { 
                    var index = ChooseCassa(casses, persons[counter]);
                    Console.WriteLine($"{persons[counter]}");
                    casses[index].Enqueue(persons[counter++]);

                    if (casses[index].QueueLength() > cassaLimit)
                    {
                        if (secondReprofile == false)
                        {
                            Console.WriteLine(casses[index].ToString() + " overflowed (max = "+cassaLimit+") with customers. "+
                                "Leaving only [status2] customers, others reprofiling.");
                            OnCassaOverflow(ref casses, casses[index]);
                            secondReprofile = true;
                        }
                        else
                        {
                            Console.WriteLine(casses[index].ToString() + " overflowed (max = " + cassaLimit + ") with customers AGAIN. " +
                                "Stopping the flow of customers, until the number of people is reduced to half the limit");
                            while (casses[index].QueueLength() > cassaLimit/2)
                            { 
                            --casses[index].Peek().TimeService;
                            time++;
                                if (--casses[index].Peek().TimeService <= 0)
                                {
                                    result.Add($"Cassa_{casses.IndexOf(casses[index]) + 1}: {casses[index].Dequeue()} has been observed");

                                    Console.WriteLine(result[result.Count - 1]);
                                }
                            }
                           
                        }
                    }

                }

                
                foreach (var item in casses)
                {
                    if (!item.IsEmpty() && --item.Peek().TimeService <= 0)
                    {
                        result.Add($"Cassa_{casses.IndexOf(item)+1}: {item.Dequeue()} has been observed");

                        Console.WriteLine(result[result.Count-1]);
                    }
                    Thread.Sleep(100);
                }
               
            }

            return result;
        }
    }
}
