using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation
{
    [Serializable()]
    public class CrossroadProperties
    {
        public Point Location;
        public int Type;
        public List<FeederLane> lanes;
        public int Cars;
        public int Pedestrians;
        public int TrafficLightTimer;

    }
    public enum FeederLane
    {
        Top, Bottom, Left, Right
    }
}
