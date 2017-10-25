using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    class Program
    {
        public static List<Ticket> listDest;
       
        static void Main(string[] args)
        {
            var config = Console.ReadLine().Split(' ');

            var numPeople = int.Parse(config[0]);
            var numWindows = int.Parse(config[1]);
            var numDestination = int.Parse(config[2]);
                        
            List<Queue<Ticket>> WindowQueue = new List<Queue<Ticket>>();
            listDest = new List<Ticket>();
            //Dictionary<int, Ticket> result = new Dictionary<int, Ticket>();
            

            setupDestinations(numDestination, listDest);

            setupWindows(numWindows, WindowQueue);

            Queue<Ticket> PeopleQueue = SetupPeopleQueue(numPeople);

            Console.WriteLine(RunPeopleQueue(WindowQueue, PeopleQueue));

            
            for (int i = 0; i <= numPeople ; i++)
            {
                for (int j = 0; j <= WindowQueue[i].Count; j++)
                {
                    if (WindowQueue[j].Any(x => x.Index == i))
                    {
                        Console.WriteLine(j + 1);
                        break;
                    }
                }
            }
            
            Console.Read();  

        }

        public static Queue<Ticket> SetupPeopleQueue(int numPeople) {

            Queue<Ticket> queue = new Queue<Ticket>();

            for (int i = 0; i < numPeople; i++)
            {
                var entry = Console.ReadLine();

                var t = new Ticket()
                {
                    Index = i,
                    DestinationName = entry,
                    Price = listDest.FirstOrDefault(x => x.DestinationName == entry).Price
                };
                    
                queue.Enqueue(t);
            }

            return queue;
        }

        public static void setupWindows(int numWindows, List<Queue<Ticket>> WindowQueue)
        {
            for (int i = 0; i < numWindows; i++)
            {
                WindowQueue.Add(new Queue<Ticket>());
            }
        }

        public static void setupDestinations(int numDest, List<Ticket> destinations)
        {
            for (int i = 0; i < numDest; i++)
            {
                var d = Console.ReadLine().Split(' ');

                destinations.Add(new Ticket()
                {                    
                    DestinationName = d[0],
                    Price = int.Parse(d[1])
                });
            }
        }

        public static double RunPeopleQueue(List<Queue<Ticket>> WindowQueue, Queue<Ticket> PeopleQueue)
        {            
            var lenght = PeopleQueue.Count;
            double totalCost = 0;
                        
            List<Ticket> reservedWindows;

            for (int i = 0; i < lenght; i++)
            {
                reservedWindows = new List<Ticket>();
                

                if (WindowQueue.Any(x => x.Count > 0 && x.Last().DestinationName == PeopleQueue.Peek().DestinationName))
                {
                    var t = ApplyOffer(PeopleQueue.Peek());                   
                    totalCost += t.Price;

                    WindowQueue.FirstOrDefault(x => x.Last().DestinationName == PeopleQueue.Peek().DestinationName).Enqueue(t);
                    PeopleQueue.Dequeue();
                }
                else if (WindowQueue.Any(x => x.Count == 0))
                {                    
                    totalCost += PeopleQueue.Peek().Price;
                    WindowQueue.Where(x => x.Count == 0).First().Enqueue(PeopleQueue.Dequeue());
                }
                else 
                {                    
                    for (int j = 0; j < PeopleQueue.Count(); j++)
                    {
                        if (WindowQueue.Any(x => x.Last().DestinationName == PeopleQueue.ElementAt(j).DestinationName))
                        {
                            if(!reservedWindows.Any(x=>x.DestinationName == PeopleQueue.ElementAt(j).DestinationName))
                            reservedWindows.Add(new Ticket() { DestinationName = PeopleQueue.ElementAt(j).DestinationName });

                            if (WindowQueue.Count() - 1== reservedWindows.Count)
                                break;
                        }                        
                    }

                    totalCost += PeopleQueue.Peek().Price;

                    WindowQueue.Where(x => !reservedWindows.Select(y => y.DestinationName).Contains(x.Last().DestinationName)).OrderBy(x=>x.Count).FirstOrDefault().Enqueue(PeopleQueue.Dequeue());                 

                }
            }

            return totalCost;
        }

        public static Ticket ApplyOffer(Ticket ticket) {
            ticket.Price *= 0.8;
            return ticket;
        }

    }

}
