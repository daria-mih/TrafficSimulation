﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation
{
    
    class CrossroadA : Crossroad
    {
        public int NoOfPedestrians { get; set; }
        public bool Sensor { get; set; }

        public CrossroadA()
        {
           
        }
    }
}
