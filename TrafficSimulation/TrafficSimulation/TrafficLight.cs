using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    class TrafficLight
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public Color State { get; set; }

        public TrafficLight()
        {

        }

        public void ChangeState(Color state)
        {
            State = state;
        }
    }
}
