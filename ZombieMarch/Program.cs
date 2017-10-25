using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZombieMarch
{
    class Program
    {
        public static IEnumerable<Junction> junctionList = null;
        //public static LinkedList<Junction> junctionList = null;

        static void Main(string[] args)
        {
            //junctionList = new LinkedList<Junction>();


            var entrada = int.Parse(Console.ReadLine());
            var teste = new RunTest();

            for (int i = 0; i < entrada; i++)
            {
                junctionList = null;
                var j = new Junction();
                string result = "";

                //var cordenadas = Console.ReadLine().Split(' ');

                // automação de entradas para teste
                var cordenadas = teste.FillJunctionsTests().Split(' ');
                Console.WriteLine(teste.FillJunctionsTests());
                // ------------------------------------------

                int numJunctions = int.Parse(cordenadas[0]);
                int numRoads = int.Parse(cordenadas[1]);
                int timeStep = int.Parse(cordenadas[2]);

                junctionList = j.CreateJunctions(numJunctions);

                InsertJuncionRoads(numRoads);
                InsertSetupZombies();

                RunStep(timeStep);
                                
                junctionList.OrderByDescending(x => x.ZombiePop).Take(5).ToList().ForEach(x=> result += x.ZombiePop + " ");

                Console.WriteLine(result);

                Console.ReadKey();
            }
        }

        public static void InsertJuncionRoads(int numRoads)
        {
            var j = new Junction();
            var t = new RunTest();

            for (int i = 0; i < numRoads; i++)
            {
                //var road = Console.ReadLine().Split(' ');

                var road = t.FillRoadTests()[i].Split(' ');
                Console.WriteLine(t.FillRoadTests()[i]);

                var juncA = junctionList.FirstOrDefault(x => x.IdJunction == int.Parse(road[0]));
                var juncB = junctionList.FirstOrDefault(x => x.IdJunction == int.Parse(road[1]));

                j.ConnectJuntions(juncA, juncB);
            }
        }

        public static void InsertSetupZombies()
        {
            var t = new RunTest();

            foreach (var item in junctionList)
            {
                //item.ZombiePop = int.Parse(Console.ReadLine());
                item.ZombiePop = 4;
                Console.WriteLine(4);
            }
        }

        public static void RunStep(int numTimeStep)
        {

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            var num = junctionList.Count();
            sw.Start();

            for (int i = 0; i < numTimeStep; i++)
            {
                foreach (var item in junctionList)
                {
                    item.RoadToJunction(item);
                }
                FinishStep();
            }
            sw.Stop();
            var tempo = sw.Elapsed.TotalMilliseconds;
        }
        
        public static void FinishStep()
        {
            foreach (var item in junctionList)
            {
                item.ZombiePop = item.NewZombiePop;
                item.NewZombiePop = 0;
            }
        }

       



    }
}
