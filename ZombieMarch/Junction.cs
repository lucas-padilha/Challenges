using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieMarch
{
    public class Junction
    {
        public int IdJunction { get; set; }
        public int ZombiePop { get; set; }
        public int NewZombiePop { get; set; }
        public List<Junction> Roads { get; set; }

        public Junction()
        {
            Roads = new List<Junction>();
        }

        public Junction(int id) {
            IdJunction = id;
            NewZombiePop = 0;
            Roads = new List<Junction>();
        }

        public IEnumerable<Junction> CreateJunctions(int num)
        {
            var listJunctions = new List<Junction>();

            for (int i = 0; i < num; i++)
            {
                listJunctions.Add(new Junction(i));
            }

            return listJunctions;
        }

        public void ConnectJuntions(Junction juncA, Junction juncB)
        {
            if(!juncA.Roads.Any(x=> x.IdJunction == juncB.IdJunction))
                juncA.Roads.Add(juncB);
            if (!juncB.Roads.Any(x => x.IdJunction == juncA.IdJunction))
                juncB.Roads.Add(juncA);
        }

        public void AddZombieInJunctions(Junction junc, int pop)
        {
            junc.NewZombiePop += pop;
        }

        public void RoadToJunction(Junction junc)
        {            
            int countRoads = junc.Roads.Count();

            var a = ( junc.ZombiePop / countRoads);

            if (countRoads > 0)
            {
                foreach (var item in junc.Roads)
                {
                    AddZombieInJunctions(item, a);
                }
            }
            else
                AddZombieInJunctions(junc, junc.ZombiePop);

            //Random r = new Random();
            //for (int i = 0; i < junc.ZombiePop; i++)
            //{
            //    if (countRoads > 0)
            //    {
            //        var element = r.Next(0, countRoads);
            //        AddZombieInJunctions(junc.Roads[element], 1);
            //    }
            //    else
            //        AddZombieInJunctions(junc, 1);
            //}            
        }        

    }
}
