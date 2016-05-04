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

        //We need to talk about this direction part.
       // List<Direction> routes { get; set; }
       
        public int NoOfCars { get; set; }
        public int NoOfTrafficLights { get; set; }
        public Crossroad North { get; set; }
        public Crossroad South { get; set; }
        public Crossroad East { get; set; }
        public Crossroad West { get; set; }

        public Crossroad(int NoOfCars, int NoOfTrafficLights)
        {
            this.NoOfCars = 0;
            this.NoOfTrafficLights = 0;
            this.North = null;
            this.South = null;
            this.East = null;
            this.West = null;
          //  routes = new List<Direction>();
        }

        //populates the list of the crossroad's available directions
        public void AddDirections()
        {
            //something like this
            //routes.Add(new Direction([Point(0,0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0)]));
          
        }
        public void Connect()
        { }

        ////public Direction NextDirection()
        ////{
        ////    //just an example ;)
        ////    //direction dir = new Direction( [Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0)])
        ////    //return dir;
        ////    return null; //for now
        ////}
    }
}
