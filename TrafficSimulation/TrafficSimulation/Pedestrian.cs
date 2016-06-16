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
        public Point currentPosition
        { get; set; }
        public Point endPoint
        { get; set; }

        public Graphics icon
        { get; set; }
        public List<Point> route
        { get; set; }

        public int size
        { get; set; }

        public Pedestrian(List<Point> _route)
        {
            this.route = _route;
            currentPosition = route[0];
          
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
        public void Move(List<Pedestrian> pedestrians)
        {
            foreach (Pedestrian pedestrian in pedestrians)
            {
                if (pedestrian.route.Count != 0)
                {
                    pedestrian.currentPosition = pedestrian.route[0];
                    pedestrian.route.Remove(pedestrian.route[0]);
                }
            }

        }


    }
}
