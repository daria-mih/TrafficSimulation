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
        public Crossroad crossNode;
        public double fDistance;
        public double sDistance;
        public List<Node> neighbours;
        //properties
        public double Distance
        {
            get { return sDistance + fDistance; }
        }

        public Node parent;

        //constructors
            public Node(Crossroad nodeRoad)
        {
            crossNode = nodeRoad;
        }
        //methods
        public void SetNeighbours(List<Node> allNodes)
        {
            foreach (Node node in allNodes)
            {
                if (node.crossNode == crossNode.North)
                {
                    neighbours.Add(node);
                    continue;
                }
                if (node.crossNode == crossNode.East)
                {
                    neighbours.Add(node);
                    continue;
                }
                if (node.crossNode == crossNode.South)
                {
                    neighbours.Add(node);
                    continue;
                }
                if (node.crossNode == crossNode.West)
                {
                    neighbours.Add(node);
                    continue;
                }
            }
        }
        public void SetDistance(Node startNode, Node finishNode)
        {
            if (parent != null)
                sDistance = Math.Abs(Convert.ToDouble((crossNode.Location.X + crossNode.Location.Y) - (parent.crossNode.Location.X + parent.crossNode.Location.Y)));
            else
                sDistance = 0;
            fDistance = Math.Abs(Convert.ToDouble((crossNode.Location.X + crossNode.Location.Y) - (finishNode.crossNode.Location.X + finishNode.crossNode.Location.Y)));
        }

    }
}
