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
        private static bool  pedestriansDone = false;
        static public bool ShouldStop = false;
        static public List<IMoveable> Moveables = new List<IMoveable>();
        static List<Node> BeginEndPoints = new List<Node>();
        public static Grid grid;
        private static List<Node> listOfNodes = new List<Node>();
        static List<Pedestrian> pedestrians = new List<Pedestrian>();
        public static int AmountOfCars;

        private static System.Timers.Timer _pedestrianTimer = new System.Timers.Timer();


     
        static List<TrafficLight> allTrafficLights = new List<TrafficLight>();


        private static void Refresh()
        {
            // f1.Invalidate();
            
            f1.Invoke((MethodInvoker) delegate
                {
                    // Show the current time in the form's title bar.
                   // f1.Invalidate();
                   // f1.Refresh();
                   f1.Refresh();
                });
            
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

        private static List<TrafficLight> GetTrafficLight(Vehicle car)
        {
            Rectangle area;
            foreach (Crossroad c in grid.Controls.OfType<Crossroad>())
            {
                area = new Rectangle(c.Location, new Size(200, 200));
                if (area.Contains(car.currentPosition))
                {
                    return c.trafficLights;
                }
            }
            return null;
        }

        // does the moving of cars on every tick
        //private static void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    try
        //    {
        //        List<IMoveable> copyMoveables = new List<IMoveable>(Moveables);


        //        bool notWait = false;
        //        if (counter > -1)
        //        {
        //            for (int i = 0; i <= counter; i++)
        //            {

        //                //Step 1: moves one car
        //                notWait = copyMoveables[i].Move(new List<Vehicle>(copyMoveables.OfType<Vehicle>()), allTrafficLights);
        //                f1.Invalidate();
        //                //redraws cars that have been moved
        //                //crossroad.Invalidate();
        //                if (Moveables[i].route.Count == 1)
        //                {
        //                    Moveables.Remove(Moveables[i]);
        //                    counter--;
        //                    i--;
        //                }
        //            }

        //            counter2++;
        //            //step 2: loops through at everytick - for ten times(delay) and then places next car
        //            if (counter2 >= 10)
        //            {
        //                if (notWait)
        //                {
        //                    if (counter >= copyMoveables.Count - 1)
        //                    {
        //                        counter = 0;
        //                    }
        //                    else
        //                    {

        //                        counter++;
        //                    }

        //                }
        //                counter2 = 0;

        //            }
        //        }

        //        int temp = 0;
        //        for (int i = 0; i <= Moveables.Count * 10; i++)
        //        {
        //            if (i % 10 == 0)
        //            {
        //                temp = i / 10;
        //            }
        //            if (i == Moveables.Count * 10)
        //            {
        //                i = 0;
        //                temp = 0;
        //            }

        //            Moveables[temp].Move(new List<Vehicle>(Moveables.OfType<Vehicle>()), allTrafficLights);

        //        }

        //    }
        //    catch (Exception exception)
        //    {

        //        MessageBox.Show(exception.Message);
        //    }

        //}

        private static void TimedPedestriansEvent(object source, ElapsedEventArgs e)
        {
            if (pedestrians.Count != 0)
            {
                if (pedestrians[0].route.Count != 0)
                {
                    foreach (Pedestrian p in pedestrians)
                    {
                        if (p.route.Count != 0)
                        {
                            p.Move();
                        }

                        foreach (Crossroad crossroad in grid.Controls.OfType<Crossroad>())
                        {
                            crossroad.Invalidate();
                        }
                    }
                }
                else
                {
                    Crossroad.AddPedestrianDirections();
                   CreatePedestrians();
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
            {
                ShouldStop = true;
                return;
            }
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

            try
            {
                 List<Vehicle> tempCars = new List<Vehicle>();
                foreach (Vehicle car in Moveables.OfType<Vehicle>())
                {
                    car.Move(new List<Vehicle>(Moveables.OfType<Vehicle>()), allTrafficLights);


                    //redraws cars that have been moved
                    //crossroad.Invalidate();
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

        public static void CreatePedestrians()
        {
            pedestrians.Clear();
            Crossroad.AddPedestrianDirections();
            foreach (Direction d in Crossroad.PedestrianDirections)
            {
                if (d.Points.Count != 0)
                {
                    pedestrians.Add(new Pedestrian(d.Points));
                }
            }

        }

        public static void DrawPedestrians(PaintEventArgs pe)
        {
            Color pColor = Color.Beige;
            SolidBrush p = new SolidBrush(pColor);
            if (pedestrians.Count > 1)
            {
                foreach (Pedestrian pedestrian in pedestrians)
                {
                    pe.Graphics.FillEllipse(p, pedestrian.currentPosition.X, pedestrian.currentPosition.Y, 10, 10);
                }
            }
        }

        #endregion

        static private void ChangeTrafficLights()
        {

        }

        private static Form1 f1;

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
           
            _pedestrianTimer.Start();
           // refreshment.Start();
          
            GetAllTrafficLights();

            // Execution
            while (!ShouldStop)
            {
                CreateMovables();
                MoveMoveables();
                Refresh();
               
            }
            
            _pedestrianTimer.Stop();


        }

      

    
    }

}
