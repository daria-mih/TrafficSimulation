using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrafficSimulation.IMoveable;

namespace TrafficSimulation
{
    [Serializable()]
    public class Pedestrian : IMoveable
    {
        int count = 0;
        public Point currentPosition
        { get; set; }
        public Point endPoint
        { get; set; }
        //public List<Point> route
        //{ get; set; }
        public int size
        { get; set; }
        public List<Point> route { get; set; }
        public Pedestrian()
        {
            route = new List<Point>();


        }
        

        public bool Move(List<Vehicle> carlist, List<TrafficLight> lights)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {


        }
        private Object thisLock = new Object();
        public void MovePedestrian(List<Crossroad> crossroads, List<TrafficLight> trafficlights)
        {
            try
            {
                lock (thisLock)
                {
                    if (this.route.Count >= 1)
                    {
                        currentPosition = this.route[route.Count - 1];
                        this.route.Remove(this.route[route.Count - 1]);
                    }
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("not moving");
            }
            
           


        }
        public void SetPoints(List<Point> points)
        {
            try
            {
                lock (thisLock)
                {
                    this.route.Clear();
                    if (points != null)
                    {
                        foreach (Point p in points)
                        {
                            this.route.Add(p);
                        }
                    }
                    currentPosition = route[route.Count - 1];
                    
                }
               
            }
            catch (Exception)
            {
               Console.WriteLine("not setting");
            }
            
        }
        


    }
}
