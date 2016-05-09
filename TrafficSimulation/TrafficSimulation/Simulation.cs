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
        static public bool ShouldStop =false;
        //static private List<IMovables> Moveables;
        static List<Point> EndPoints;
        public static Grid grid;
        private static List<Node> listOfNodes = new List<Node>();
        
        //properties
        // public Grid FromGrid { get; set; }

        //methods
        static private void GetNodes()
        {
            foreach (Crossroad cRoad in grid.Controls)
            {
                listOfNodes.Add(new Node(cRoad));
            }
            foreach (Node node in listOfNodes)
            {
                node.SetNeighbours(listOfNodes);
            }
            
        }
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
                    List<Direction> templist = new List<Direction>();
                    // templist.Insert(0, current.crossNode.the direction);
                    while (current.parent != null)
                    {
                        // templist.Insert(0, current.crossNode.the direction);
                        current = current.parent;
                    }
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
                            neighbour.SetDistance(startPoint, endPoint);
                        }

                    }
                }

            }
            return null;
        }
        static private void CreateMovables()
        {
            
            Random random = new Random();
            Node startpnt = listOfNodes[random.Next(0, listOfNodes.Count)];
            Node endpnt = listOfNodes[random.Next(0, listOfNodes.Count)];
            foreach (Node node in listOfNodes)
            {
                node.SetDistance(startpnt, endpnt);
            }
            GetShortestRoute(startpnt, endpnt);
        }

        static private void ChangeTrafficLights()
        {

        }

        static public void Run()
        {
            GetNodes();
            //FillEndPoints();
            while (!ShouldStop)
            {
                CreateMovables();
                //MoveMovables();
                //ChangeTrafficLights();
            }
        }
        static public void FillEndPoints()
        {
            foreach (Crossroad crossrd in grid.Controls)
            {
                if (crossrd.North == null)
                {
                    // this is an end point
                    // add it to the list
                }
                if (crossrd.West == null)
                {
                    // this is an end point
                    // add it to the list
                }
                if (crossrd.South == null)
                {
                    // this is an end point
                    // add it to the list
                }
                if (crossrd.East == null)
                {
                    // this is an end point
                    // add it to the list
                }
            }
        }

        static public void MoveMovables()
        {

        }

    }
}
