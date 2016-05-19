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

        //one path inside of a crossroad
        List<Point> points;

        //constructor
        public Direction()
        {
            points = new List<Point>();
        }
    }
}
