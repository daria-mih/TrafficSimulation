using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation
{
    class Grid
    {
        public List<Crossroad> Crossroads { get; set; }

        public Grid()
        {
            Crossroads = new List<Crossroad>();
        }

        public void Draw()
        {
                
        }

        public void AddCrossroad(Crossroad crossroad)
        {
            Crossroads.Add(crossroad);
        }

        public void RemoveCrossroad(Crossroad crossroad)
        {
            Crossroads.Remove(crossroad);
        }
    }
}
