using System;
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
        static public bool ShouldStop =false;
        static public List<IMoveable> Moveables = new List<IMoveable>();
        static List<Node> BeginEndPoints;
        public static Grid grid;
        private static List<Node> listOfNodes = new List<Node>();

        private static System.Timers.Timer _carTimer = new System.Timers.Timer();

        private static int counter = 0;
        private static int counter2 = 0;

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            bool notWait = false;
            if (counter > -1)
            {
                for (int i = 0; i <= counter; i++)
                {
                    notWait = Moveables[i].Move(new List<Vehicle>(Moveables.OfType<Vehicle>()), Crossroad.trafficLights);
                    foreach (Crossroad crossroad in grid.Controls.OfType<Crossroad>())
                    {
                        crossroad.Invalidate();
                    }
                    if (Moveables[i].route.Count == 1)
                    {
                        Moveables.Remove(Moveables[i]);
                        counter--;
                        i--;
                    }
                }
               
                //((Vehicle) Moveables[counter]).SetCurrentPosition(new List<Vehicle>(Moveables.OfType<Vehicle>()));

                
                counter2++;
                if (counter2 >= 10)
                {
                    if (notWait)
                    {
                        if (counter >= Moveables.Count - 1)
                        {
                            counter = 0;
                        }
                        else
                        {

                            counter++;
                        }
                        
                    }
                    counter2 = 0;

                }
            }
        }
        //properties
        // public Grid FromGrid { get; set; }

        //methods
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
            BeginEndPoints = new List<Node>();
            foreach (Node crossNode in listOfNodes)
            {
                if (crossNode.crossroad.North == null || crossNode.crossroad.West == null || crossNode.crossroad.South == null || crossNode.crossroad.East == null)
                {
                    // this is an end point
                    // add it to the list
                    if (!BeginEndPoints.Contains(crossNode))
                    BeginEndPoints.Add(crossNode);
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
            directionName = entrances[rnd.Next(0, entrances.Count)]+directionName;
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
               routeDirections.Add( Route[0].crossroad.FindDirection(directionName));
                return routeDirections;
            }
            directionName +=  Route[0].WhichNeighbour(listOfNodes, Route[1]);
            routeDirections.Add(Route[0].crossroad.FindDirection(directionName));
            //the directions with a parent crossroad and a child crossroad
            for (int i = 5; i < Route.Count -1; i++)
            {
                directionName = "-";
                directionName = Route[i-1].WhichNeighbour(listOfNodes, Route[i]) + directionName;
                directionName += Route[i].WhichNeighbour(listOfNodes, Route[i + 1]);
                routeDirections.Add(Route[i].crossroad.FindDirection(directionName));
            }
            //the last direction where the Route will end
            entrances = new List<string>();
            
            if (Route.Last<Node>().crossroad.North != null)
            {
                entrances.Add("North");
            }
            if (Route.Last<Node>().crossroad.East != null)
            {
                entrances.Add("East");
            }
            if (Route.Last<Node>().crossroad.South != null)
            {
                entrances.Add("South");
            }
            if (Route.Last<Node>().crossroad.West != null)
            {
                entrances.Add("West");
            }
            directionName = "-";
            directionName += entrances[rnd.Next(0, entrances.Count)];
            directionName = Route[Route.Count-2].WhichNeighbour(listOfNodes, Route.Last<Node>()) + directionName;
            routeDirections.Add(Route.Last<Node>().crossroad.FindDirection(directionName));
            return routeDirections;
        }
        /// <summary>
        /// uses the A* algorithm to find the shortest route from beginpoint to endpoint 
        /// </summary>
        /// <param name="startPoint">the crossroad/Node that the route starts in</param>
        /// <param name="endPoint">the crossroad/Node that the route ends in</param>
        /// <returns></returns>
        static private List<Direction> GetShortestRoute(Node startPoint, Node endPoint)
        {
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
                    if (current == null)
                    {
                        current = node;
                        continue;
                    }
                    if (current.fDistance >= node.fDistance)
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
                            neighbour.SetDistance( endPoint);
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
            for (int i = 0; i < 5; i++)
            {

            Random random = new Random();
            List<Point> pointlist = new List<Point>();
            while (pointlist.Count < 1)
            {
                Node startpnt = listOfNodes[random.Next(0, listOfNodes.Count)];
                Node endpnt = listOfNodes[random.Next(0, listOfNodes.Count)];
                foreach (Node node in listOfNodes)
                {
                    node.SetDistance( endpnt);
                }
                List<Direction> dirlist = GetShortestRoute(startpnt, endpnt);
                pointlist = new List<Point>();
                foreach (Direction dir in dirlist)
                {
                    foreach (var item in dir.Points)
                    {
                        pointlist.Add(item);
                    }
                }
            }
            Vehicle temp = new Vehicle(pointlist);
             
            Moveables.Add( temp);
            
            }
            _carTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _carTimer.Interval = 50;
            
        }
        static public void MoveMovables()
        {
            //Thread.Sleep(1000
            bool result = false;
            while (!result)
            {
                

            }


        }



       public static void DrawCars(PaintEventArgs pe) {
            if (Moveables.Count > 0)
            {
                foreach (Vehicle car in Moveables.OfType<Vehicle>())
                {
                    Color carColor = car.color;
                    Brush brush = new SolidBrush(carColor);

                    pe.Graphics.FillRectangle(brush, car.currentPosition.X, car.currentPosition.Y, 10, 10);
                }
            }
        

        }
        #endregion
        static private void ChangeTrafficLights()
        {

        }

        static public void Run()
        {
            GetNodes();
            FillEndPoints();
            CreateMovables();
            _carTimer.Start();
            while (!ShouldStop)
            {
                //carTimer.
                //MoveMovables();
                //ChangeTrafficLights();
            }
        }
       
       

    }
}
