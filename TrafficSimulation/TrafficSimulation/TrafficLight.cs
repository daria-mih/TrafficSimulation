using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    [Serializable()]
    class TrafficLight
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public Color State { get; set; }

        public TrafficLight(int id, int time, Color state)
        {
            Id = id;
            Time = time;
            State = state;
        }

        public void ChangeState(Color state)
        {
            State = state;
        }
    }
}
