using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    [Serializable()]
    public class Direction
    {
        public string Name { get; set; }
        public List<Point> Points { get; set; }
        public Direction(List<Point> points, string name)
        {
            Name = name;
            Points = points;
        }


    }
}
