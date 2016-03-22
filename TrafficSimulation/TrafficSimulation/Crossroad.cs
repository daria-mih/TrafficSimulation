using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    class Crossroad
    {
        //guys, we first put this method in direction but thought it would be better to use it in this class


        List<Direction> routes;
        List<TrafficLight> TrafficLlist= new List<TrafficLight>();
        public int NoOfCars { get; set; }
        public int NoOfTrafficLights { get; set; }
        public

        //populates the list of the crossroad's available directions
        public List<Point> AddNewDirection()
        {
            return direction;
        }
        public void Connect()
        { }
        public int NextDirection()
        {
            return 0;
        }
    }
}
