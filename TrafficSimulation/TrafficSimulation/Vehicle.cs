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

        public bool isStopped = false;

        public Graphics icon
        { get; set; }
        public List<Point> route
        { get; set; }

        public Color color { get; set; }


        public Rectangle drawing { get; set; }

        public Vehicle(List<Point> _route)
        {
            route = _route;
            currentPosition = _route[0];
            color = GenerateRandomCarColors();
        }
        public bool Move(List<Vehicle> carlist, List<TrafficLight> lights)
        {
            //check if there is a car in front
            //check if there is red light in front
            //yet to be done
            if (route.Count > 1)
            {
                   if (carlist.Count > 1)
                {
                    foreach (Vehicle v in carlist)
                    {
                        if (v != this)
                        {
                            if (!v.isStopped)
                            {
                                currentPosition = route[1];
                                route.Remove(route[1]);
                                isStopped = false;
                                return true;
                            }
                            isStopped = true;
                        }
                        else
                        {
                            if (!checkForRed(lights))
                            {
                                currentPosition = route[1];
                                route.Remove(route[1]);
                                isStopped = false;
                                return true;
                            }
                            isStopped = true;
                        }
                    }
                }
                else if (carlist.Count == 1)
                {
                    if (!checkForRed(lights))
                    {
                        currentPosition = route[1];
                        route.Remove(route[1]);
                        isStopped = false;
                        return true;
                    }
                    isStopped = true;
                }
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


        public bool checkForRed(List<TrafficLight> lights)
        {
            Rectangle check;

            if ((route[1].X - currentPosition.X) >0)
            {
                // cars go from the left to the right 
                check = new Rectangle(currentPosition.X + 1, currentPosition.Y, 10, 10);
              foreach (TrafficLight l in lights)
                {
                    if (check.Contains(l.currentPosition1))
                    {
                        if (l.state == Color.Red )
                        {
                            isStopped = true;
                            return true;
                        }
                    }
                }
            }

            if ((route[1].X - currentPosition.X) < 0)
                {
                //cars go from the right to the left
                check = new Rectangle(currentPosition.X - 1, currentPosition.Y, 10, 10);

                foreach (TrafficLight l in lights)
                {
                    if (check.Contains(l.currentPosition1))
                    {
                        if (l.state == Color.Red)
                        {
                            isStopped = true;
                            return true;
                        }
                    }
                }

            }

            if ((route[1].Y - currentPosition.Y) > 0)
            {
                // cars go from top to bottom
                check = new Rectangle(currentPosition.X, currentPosition.Y + 1, 10, 10);

                foreach (TrafficLight l in lights)
                {
                    if (check.Contains(l.currentPosition1))
                    {
                        if (l.state == Color.Red)
                        {
                            isStopped = true;
                            return true;
                        }
                    }
                }


            }
            if ((route[1].Y - currentPosition.Y) < 0)
            {
                // cars go from bottom to top
                check = new Rectangle(currentPosition.X, currentPosition.Y - 1, 10, 10);

                foreach (TrafficLight l in lights)
                {
                    if (check.Contains(l.currentPosition1))
                    {
                        if (l.state == Color.Red)
                        {
                            isStopped = true;
                            return true;
                        }
                    }
                }
            }
            isStopped = false;
            return false;
        }

    }
}
