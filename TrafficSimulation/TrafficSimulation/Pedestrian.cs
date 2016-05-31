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
        public List<Direction> route
        { get; set; }

        public int size
        { get; set; }

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

        public bool Move(List<Vehicle> carlist)
        {
            throw new NotImplementedException();
        }

        public void Move(Direction direction)
        {
           
            
        }
    }
}
