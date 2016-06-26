using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;
namespace TrafficSimulation
{
    [Serializable()]

    public class TrafficLight
    {
        public int Id { get; set; }

        public Color state { get; set; }

        public bool stateChanged { get; set; }

        public Point currentPosition1 { get; set; }
        public Point currentPosition2 { get; set; }


        public TrafficLight(int id, Color _state)
        {
            Id = id;
            state = _state;

        }





    }

}
