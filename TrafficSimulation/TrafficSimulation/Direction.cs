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
        //name for easy tracking example:"North-South"
        public string Name { get; set; }
        //one path inside of a crossroad
        public List<Point> Points { get; set; }

        //constructor
        public Direction(List<Point> points, string name)
        {
            Name = name;
            Points = points;
        }
        
        
    }
}
