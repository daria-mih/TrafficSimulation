using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulation
{
    class Node
    {
        //fields
        public Crossroad crossroad;
        public double fDistance;
        // public double sDistance;
        public List<Node> neighbours = new List<Node>();
        //properties
        //public double Distance
        //{
        //    get { return /*sDistance +*/ fDistance; }
        //}
        public Node parent;

        //constructors
            public Node(Crossroad nodeRoad)
            {
            crossroad = nodeRoad;
            }

        //methods

        /// <summary>
        /// returns the cardinal direction form the current node to the next node
        /// </summary>
        /// <param name="allNodes">the list that contains all the nodes</param>
        /// <param name="nextNode">the node on which direction you want to know of</param>
        /// <returns>"North", "East", "South" or "West"</returns>
        public string WhichNeighbour(List<Node> allNodes, Node nextNode)
        {
            foreach (Node node in allNodes)
            {
                if (nextNode.crossroad == crossroad.North)
                {
                    return "North";
                }
                if (nextNode.crossroad == crossroad.East)
                {
                    return "East";
                }
                if (nextNode.crossroad == crossroad.South)
                {
                    return "South";
                }
                if (nextNode.crossroad == crossroad.West)
                {
                    return "West";
                }
            }
            return null;
        }
        /// <summary>
        /// finds the neighbours by checking the crossroads
        /// </summary>
        /// <param name="allNodes">the list of all the nodes</param>
        public void SetNeighbours(List<Node> allNodes)
        {
            foreach (Node node in allNodes)
            {
                if (node.crossroad == crossroad.North)
                {
                    neighbours.Add(node);
                    continue;
                }
                if (node.crossroad == crossroad.East)
                {
                    neighbours.Add(node);
                    continue;
                }
                if (node.crossroad == crossroad.South)
                {
                    neighbours.Add(node);
                    continue;
                }
                if (node.crossroad == crossroad.West)
                {
                    neighbours.Add(node);
                    continue;
                }
            }
        }
        /// <summary>
        /// Sets the Distance from this to the Finishing node
        /// </summary>
        /// <param name="startNode">*Not needed right now*</param>
        /// <param name="finishNode">the node the check the distance with</param>
        public void SetDistance(Node startNode, Node finishNode)
        {
            /*if (parent != null)
                sDistance = Math.Abs(Convert.ToDouble((crossNode.Location.X + crossNode.Location.Y) - (parent.crossNode.Location.X + parent.crossNode.Location.Y)));
            else
                sDistance = 0;*/
            fDistance = Math.Abs(Convert.ToDouble((crossroad.Location.X + crossroad.Location.Y) - (finishNode.crossroad.Location.X + finishNode.crossroad.Location.Y)));
        }

    }
}
