using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrafficSimulation
{
    [Serializable()]
    static class Simulation
    {
        //fields
        static public bool ShouldStop;
        //static private List<IMovables> Moveables;
        static List<Point> EndPoints;

        //properties
        // public Grid FromGrid { get; set; }

        //methods
        static private void CreateMovables()
        {

        }

        static private void ChangeTrafficLights()
        {

        }

        static public void Run()
        {
            while (!ShouldStop)
            {
                CreateMovables();
                MoveMovables();
                ChangeTrafficLights();
            }
        }
        static public void FillEndPoints()
        {

        }

        static public void MoveMovables()
        {

        }

    }
}
