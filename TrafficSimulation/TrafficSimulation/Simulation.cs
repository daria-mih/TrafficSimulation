﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace TrafficSimulation
{
    [Serializable()]
    static class Simulation
    {
        //fields
        static public bool ShouldStop = false;
        static public List<IMoveable> Moveables = new List<IMoveable>();
        static List<Node> BeginEndPoints = new List<Node>();
        public static Grid grid;
        private static List<Node> listOfNodes = new List<Node>();
        static List<Pedestrian> pedestrians = new List<Pedestrian>();
        public static int AmountOfCars;
        private static System.Timers.Timer _pedestrianTimer = new System.Timers.Timer();
        static List<TrafficLight> allTrafficLights = new List<TrafficLight>();
        private static Form1 f1;

        //methods 

        private static void Refresh()
        {
            try
            {
                if (!f1.closing)
                {
                    f1.Invoke((MethodInvoker)delegate
                        {
                            // Show the current time in the form's title bar.

                            f1.Refresh();
                        });
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static void GetAllTrafficLights()
        {
            foreach (Crossroad crossroad in grid.Controls.OfType<Crossroad>())
            {
                foreach (TrafficLight trafficLight in crossroad.trafficLights)
                {
                    allTrafficLights.Add(trafficLight);
                }
            }
        }

        #region Route finding 

        /// <summary>
        /// takes all the crossroad from the grid and transforms them into a node
        /// </summary>
        static private void GetNodes()
        {
            //put all nodes in the list
            foreach (Crossroad cRoad in grid.Controls)
            {
                listOfNodes.Add(new Node(cRoad));
            }
            //connect all the neighbours with eachother
            foreach (Node node in listOfNodes)
            {
                node.SetNeighbours(listOfNodes);
            }

        }

        /// <summary>
        /// checks which crossroads have an begin or endpoint so a movable can start or end in that crossroad
        /// </summary>
        static public void FillEndPoints()
        {

            foreach (Node node in listOfNodes)
            {
                if (node.neighbours.Count < 4)
                {
                    BeginEndPoints.Add(node);
                }
            }
        }


        /// <summary>
        /// this is only called when the route is created*
        /// </summary>
        /// <param name="EndNode"></param>
        static private List<Direction> ReconstructPath(Node EndNode)
        {

            List<Node> Route = new List<Node>();
            Route.Insert(0, EndNode);
            Node current = EndNode;
            // put every piece of the road in a list
            while (current.parent != null)
            {
                Route.Insert(0, current.parent);
                current = current.parent;
            }
            // construct the road
            //pick a startpoint on the crossroad at random
            List<string> entrances = new List<string>();
            if (Route[0].crossroad.North == null)
            {
                entrances.Add("North");
            }
            if (Route[0].crossroad.East == null)
            {
                entrances.Add("East");
            }
            if (Route[0].crossroad.South == null)
            {
                entrances.Add("South");
            }
            if (Route[0].crossroad.West == null)
            {
                entrances.Add("West");
            }
            Random rnd = new Random();
            List<Direction> routeDirections = new List<Direction>();
            string directionName = "-";

            directionName = entrances[rnd.Next(0, entrances.Count)] + directionName;
            //the first direction
            //if there is only one crossroad
            if (Route.Count == 1)
            {
                string endDirectionname = entrances[rnd.Next(0, entrances.Count)];
                while (directionName.Contains(endDirectionname))
                {
                    endDirectionname = entrances[rnd.Next(0, entrances.Count)];
                }
                directionName += endDirectionname;
                Direction tempDirection = Route[0].crossroad.FindDirection(directionName);

                routeDirections.Add(tempDirection);
                return routeDirections;
            }
            directionName += Route[0].WhichNeighbour(Route[1]);
            Direction direction = Route[0].crossroad.FindDirection(directionName);

            routeDirections.Add(direction);
            //the directions with a parent crossroad and a child crossroad
            for (int i = 1; i < Route.Count - 1; i++)
            {
                directionName = "-";
                directionName = Route[i].WhichNeighbour(Route[i - 1]) + directionName;

                directionName += Route[i].WhichNeighbour(Route[i + 1]);

                direction = Route[i].crossroad.FindDirection(directionName);

                routeDirections.Add(direction);

            }
            //the last direction where the Route will end
            entrances = new List<string>();

            if (Route.Last<Node>().crossroad.North == null)
            {
                entrances.Add("North");
            }
            if (Route.Last<Node>().crossroad.East == null)
            {
                entrances.Add("East");
            }
            if (Route.Last<Node>().crossroad.South == null)
            {
                entrances.Add("South");
            }
            if (Route.Last<Node>().crossroad.West == null)
            {
                entrances.Add("West");
            }
            directionName = "-";
            directionName += entrances[rnd.Next(0, entrances.Count)];
            directionName = Route.Last<Node>().WhichNeighbour(Route[Route.Count - 2]) + directionName;

            direction = Route.Last().crossroad.FindDirection(directionName);

            routeDirections.Add(direction);

            return routeDirections;
        }

        /// <summary>
        /// this updates the points in the direction with the correct points on the form
        /// </summary>
        /// <param name="cros">we need crossroad position</param>
        /// <param name="direction">the direction that needs new points</param>
        /// <returns></returns>
        static private void AssignPoints()
        {

            foreach (Crossroad crossroad in grid.Controls.OfType<Crossroad>())
            {
                if (crossroad.HasAssignedPoints)
                    continue;
                foreach (Direction direction in crossroad.Directions)
                {
                    if (direction == null)
                        return;
                    for (int i = 0; i < direction.Points.Count; i++)
                    {

                        direction.Points[i] = new Point(crossroad.Location.X + direction.Points[i].X,
                            crossroad.Location.Y + direction.Points[i].Y);
                    }
                }

                foreach (TrafficLight trafficlight in crossroad.trafficLights)
                {
                    if (trafficlight == null)
                        continue;
                    trafficlight.currentPosition1 = new Point(crossroad.Location.X + trafficlight.currentPosition1.X,
                            crossroad.Location.Y + trafficlight.currentPosition1.Y);
                    trafficlight.currentPosition2 = new Point(crossroad.Location.X + trafficlight.currentPosition2.X,
                            crossroad.Location.Y + trafficlight.currentPosition2.Y);
                    allTrafficLights.Add(trafficlight);
                }
                crossroad.HasAssignedPoints = true;
            }

        }

        /// <summary>
        /// uses the A* algorithm to find the shortest route from beginpoint to endpoint 
        /// </summary>
        /// <param name="startPoint">the crossroad/Node that the route starts in</param>
        /// <param name="endPoint">the crossroad/Node that the route ends in</param>
        /// <returns></returns>
        static private List<Direction> GetShortestRoute(Node startPoint, Node endPoint)
        {
            foreach (Node node in listOfNodes)
            {
                node.parent = null;
            }
            //nodes to be processed
            List<Node> openNodes = new List<Node>();
            //nodes that are already processed
            List<Node> closedNodes = new List<Node>();
            //we need to start by adding the starting node as a node that needs to be proccessed
            Node current = null;
            openNodes.Add(startPoint);

            while (openNodes.Count != 0)
            {
                foreach (Node node in openNodes)
                {
                    if (closedNodes.Contains(current))
                    {
                        current = null;
                    }
                    if (current == null)
                    {
                        current = node;
                        continue;
                    }
                    if (current.fDistance > node.fDistance)
                    {
                        current = node;
                    }
                }
                closedNodes.Add(current);
                openNodes.Remove(current);
                //you found the destination
                if (current == endPoint)
                {
                    //time to create the Route
                    //you are at the end so you will have to put the list from end to start
                    List<Direction> templist = new List<Direction>(ReconstructPath(current));
                    return templist;
                }

                //checking the neighbours
                foreach (Node neighbour in current.neighbours)
                {
                    if (neighbour != current.parent)
                    {

                        if (!openNodes.Contains(neighbour) && !closedNodes.Contains(neighbour))
                        {
                            openNodes.Add(neighbour);
                        }
                        if (neighbour.parent == null)
                        {
                            neighbour.parent = current;

                        }

                    }
                }

            }
            return null;
        }

        #endregion

        #region Movables

        static private void CreateMovables()
        {
            if (AmountOfCars == 0)
                return;

            if (Moveables.Count > listOfNodes.Count * 5)
                return;

            Random random = new Random();
            List<Direction> dirlist = null;
            while (dirlist == null)

            {
                Node startpnt = BeginEndPoints[random.Next(0, BeginEndPoints.Count)];
                Node endpnt = BeginEndPoints[random.Next(0, BeginEndPoints.Count)];
                foreach (Node node in listOfNodes)
                {
                    node.SetDistance(endpnt);
                }
                dirlist = GetShortestRoute(startpnt, endpnt);
            }
            List<Point> pointlist = new List<Point>();
            foreach (Direction dir in dirlist)
            {
                foreach (var item in dir.Points)
                {
                    pointlist.Add(item);
                }
            }

            Vehicle temp = new Vehicle(new List<Point>(pointlist));


            Moveables.Add(temp);
            AmountOfCars--;
        }

        static private void MoveMoveables()
        {
            if (Moveables.Count == 0)
                ShouldStop = true;

            try
            {
                List<Vehicle> tempCars = new List<Vehicle>();
                foreach (Vehicle car in Moveables.OfType<Vehicle>())
                {
                    
                    car.Move(new List<Vehicle>(Moveables.OfType<Vehicle>()), allTrafficLights);
                    if (car.route.Count == 1)
                    {
                        tempCars.Add(car);

                    }
                }
                foreach (Vehicle v in tempCars)
                {
                    Moveables.Remove(v);
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }

        }
        private static void TimedPedestriansEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                if (pedestrians.Count != 0)
                {
                    if (pedestrians[0].route.Count != 0)
                    {
                        foreach (Pedestrian p in pedestrians)
                        {
                            if (p.route.Count != 0)
                            {
                                p.MovePedestrian(new List<Crossroad>(grid.Controls.OfType<Crossroad>()), allTrafficLights);
                            }

                            foreach (Crossroad crossroad in grid.Controls.OfType<Crossroad>())
                            {
                                crossroad.Invalidate();
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < pedestrians.Count; i++)
                        {
                            pedestrians[i].SetPoints(Crossroad.PedestrianDirections[i].Points);
                            if (i > 4)
                            {
                                i = 0;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Timer disrupted");
             }
            

        }

        public static void CreatePedestrians()
        {
            pedestrians.Clear();
            Crossroad.AddPedestrianDirections();
            Random rand = new Random();
            foreach (Direction d in Crossroad.PedestrianDirections)
            {
                if (d.Points.Count != 0)
                {
                    Pedestrian p = new Pedestrian();
                    pedestrians.Add(p);
                    p.SetPoints(d.Points);
                }
            }

            
        }

        public static void DrawPedestrians(PaintEventArgs pe)
        {
            Color pColor = Color.Beige;
            SolidBrush p = new SolidBrush(pColor);
            if (pedestrians.Count > 1)
            {

                for (int i = 0; i < pedestrians.Count; i++)
                {
                    {
                        pe.Graphics.FillEllipse(p, pedestrians[i].currentPosition.X, pedestrians[i].currentPosition.Y, 10, 10);
                    }
                }
            }
        }

        #endregion



        public static void SetForm(Form1 form1)
        {
            f1 = form1;
        }

        static public void Run()
        {
            //setup
            Moveables = new List<IMoveable>();
            BeginEndPoints = new List<Node>();
            listOfNodes = new List<Node>();
            pedestrians = new List<Pedestrian>();
            GetNodes();
            FillEndPoints();
            AssignPoints();


            CreatePedestrians();
            _pedestrianTimer.Elapsed += TimedPedestriansEvent;
            _pedestrianTimer.Interval = 150;
            _pedestrianTimer.Start();
            
            while (!ShouldStop)
            {
                CreateMovables();
                MoveMoveables();
                Refresh();

            }
            try
            {

            
            Moveables.Clear();
                _pedestrianTimer.Stop();
            foreach (Crossroad cross in grid.Controls)
            {
                cross.KillTrafficTimer();
            }
            f1.Invoke((MethodInvoker)delegate {
                f1.stopRunning();
            });
            f1.Invoke((MethodInvoker)delegate { Refresh(); });
            }
            catch (Exception)
            {

                
            }
        }




    }

}
