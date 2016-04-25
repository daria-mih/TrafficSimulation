using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrafficSimulation
{
    public class Vehicle : IMoveable
    {
        public Point currentPosition { get; set; }
       
        public Point endPoint
        { get; set; }

        public Graphics icon
        { get; set; }
        public List<Direction> route
        { get; set; }

        public int size
        { get; set; }

        public void Move(Direction direction) //should be a return method?
        {
            //temporary list of directions
            List<Direction> tempRoute = new List<Direction>();
            Crossroad _crossroad = new Crossroad();
            Crossroad prevCrossroad = new Crossroad();
            List<Crossroad> tempCrossroads = new List<Crossroad>();
            //Check which crossroad contains the currentposition
            // -- Foreach crossroad in Grid, if crossroad contains currentposition, _crossroad = crossroad;
            //Check if crossroad contains endpoint
            //if(_crossroad.Contains(endPoint))
            //{

            //tempRoute = ; 
            //Select route that starts at currentPosition and ends at endPoint
            //}
            //else do a recursive check with all the neighbours of c
            //else
            //{
            //    prevCrossroad = _crossroad;
            //    if(prevCrossroad.East.Contains(endPoint) || prevCrossroad.North.Contains(endPoint) || prevCrossroad.South.Contains(endPoint)|| prevCrossroad.West.Contains(endPoint))
            //    {
            //_crossroad =  //Crossroad containing endpoint.
            //tempRoute = ; //add route from prevCrossroad to _crossroad
            //tempRoute = ; // add route from _crossroad to endpoint

            //}
            //else
            //{
            //do a check to see if (north, south, east or west of the neighbour of prevCrossroad contains point)
            //else do another check to see if neighbours of the neighbours of prevCrossroad contains the endpoint)
            //        }
            //    }
        }
    }
}
