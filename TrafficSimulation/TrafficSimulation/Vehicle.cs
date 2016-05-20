using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    [Serializable()]
    public class Vehicle : IMoveable
    {
        public Point currentPosition { get; set; }
       
        public Point endPoint
        { get; set; }

        public Graphics icon
        { get; set; }
        public List<Point> route
        { get; set; }

        public int size
        { get; set; }

        public Vehicle(List<Point> _route, Point startposition)
        {
            route = _route;
            size = 5;
            currentPosition = startposition;
        }
       //created by chiel
        public Vehicle(List<Point> _route)
        {
            route = _route;
            size = 5;
        }

        public void Move()
        {
            //check if there is a car in front
            //check if there is red light in front
            //yet to be done
            currentPosition = route[0];
            route.Remove(route[0]); 
            
        }
    }
}
