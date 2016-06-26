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
        Point currentPosition { get; set; }
        List<Point> route { get; set; }
        bool Move(List<Vehicle> carlist, List<TrafficLight> lights);
    }
}
