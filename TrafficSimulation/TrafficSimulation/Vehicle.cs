using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace TrafficSimulation
{
    [Serializable()]
    public class Vehicle : IMoveable
    {
        public Point currentPosition { get; set; }

        public Point endPoint
        { get; set; }

        public Graphics icon
        { get; set; }
        public List<Point> route
        { get; set; }

        public Color color { get; set; }


        public Rectangle drawing { get; set; }

        public const int car_height = 10;
        public const int car_width = 10;
        public Vehicle(List<Point> _route)
        {
            route = _route;
            currentPosition = _route[0];
            color = GenerateRandomCarColors();
        }
        public bool Move()
        {
            //check if there is a car in front
            //check if there is red light in front
            //yet to be done


            if (route.Count > 0)
            {
                currentPosition = route[1];
                route.Remove(route[1]);
                return true;

            }
            return false;

        }

        public Color GenerateRandomCarColors()
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);
            return randomColor;
        }


    }
}
