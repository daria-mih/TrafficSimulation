using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    //[Serializable()]
    public interface IMoveable
    {
        Point endPoint { get; set; }
        Graphics icon { get; set; }
        Point currentPosition { get; set; }

        //the whole route that the moveable should follow 
        List<Point> route { get; set; }


        //takes a route from the list for a moveable to follow
       bool Move();
      
    }
}
