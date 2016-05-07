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

        private static List<Node> listOfNotes = new List<Node>();
        
        //properties
        // public Grid FromGrid { get; set; }

        //methods
        static private void GetNodes(Grid gridOfCrossroads)
        {
            foreach (Crossroad cRoad in gridOfCrossroads.Controls)
            {
                listOfNotes.Add(new Node(cRoad));
            }
            foreach (Node node in listOfNotes)
            {
                node.SetNeighbours(listOfNotes);
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
                    if (current.Distance > node.Distance)
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
                    if (!openNodes.Contains(neighbour))
                    {
                        openNodes.Add(neighbour);
                    }
                }

            }
            return null;
        }
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
