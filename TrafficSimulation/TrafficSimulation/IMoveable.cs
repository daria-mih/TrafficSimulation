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
        int size { get; set; }
        Point endPoint { get; set; }
        Graphics icon { get; set; }
        Point currentPosition { get; set; }

        //the whole route that the moveable should follow 
        List<Direction> route { get; set; }


        //takes a route from the list for a moveable to follow
       void Move(Direction direction);
      
    }
}
