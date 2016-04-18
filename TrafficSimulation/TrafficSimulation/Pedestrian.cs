using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation
{
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

        public void Move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
