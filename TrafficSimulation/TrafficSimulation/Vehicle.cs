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
           // check if the route is not empty
            if (route.Count > 1)
            {
                //check if there is more than one car
                   if (carlist.Count > 1)
                {
                    foreach (Vehicle v in carlist)
                    {
                        //for all other cars in the list
                        if (v != this)
                        {
                            //check if there is another car on the position that the car should take next
                            if (v.currentPosition == route[1])
                            {
                                //if the car is moving
                                if (!v.isStopped)
                                {
                                    //then move
                                    currentPosition = route[1];
                                    route.Remove(route[1]);
                                    isStopped = false;
                                    return true;
                                }
                                //else do nothing and get status 'stopped'
                                isStopped = true;
                            }
                        }
                        else
                        {
                            //for car itself
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
                    //if there is only one car then only checking for red ligt is needed
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

            // if route is empty
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
                //draw a rectangle in front of the car
                check = new Rectangle(currentPosition.X + 20, currentPosition.Y, 10, 10);
              foreach (TrafficLight l in lights)
                {
                    //check if there is a traffic light in the rectangle
                    if (check.Contains(l.currentPosition1))
                    {
                        //check if the traffic light is red
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
                check = new Rectangle(currentPosition.X - 20, currentPosition.Y, 10, 10);

                foreach (TrafficLight l in lights)
                {
                    if (check.Contains(l.currentPosition2))
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
                check = new Rectangle(currentPosition.X, currentPosition.Y + 20, 10, 10);

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
                check = new Rectangle(currentPosition.X, currentPosition.Y - 20, 10, 10);

                foreach (TrafficLight l in lights)
                {
                    if (check.Contains(l.currentPosition2))
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
