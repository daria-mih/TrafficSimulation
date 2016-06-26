using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Point> route
        { get; set; }
        public int size
        { get; set; }
        public Pedestrian()
        {
            route = new List<Point>();


        }
        List<Point> IMoveable.route
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Move(List<Vehicle> carlist, List<TrafficLight> lights)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {


        }
        public void MovePedestrian(List<Crossroad> crossroads, List<TrafficLight> trafficlights)
        {
            if (route.Count != 0)
            {
                {
                    if (this.route.Count > 0 && this.route.Count < 500)
                    {
                        currentPosition = this.route[0];

                        this.route.Remove(this.route[0]);
                    }
                }


            }


        }
        public void SetPoints(List<Point> points)
        {
            this.route.Clear();
            if (points != null)
            {
                foreach (Point p in points)
                {
                    this.route.Add(p);
                }
            }
            currentPosition = route[0];
        }



    }
}
