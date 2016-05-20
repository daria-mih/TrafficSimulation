using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TrafficSimulation
{
    [Serializable()]
    class Crossroad : Control
    {
        public MenuItem delete { get; set; }
        //guys, we first put this method in direction but thought it would be better to use it in this class

        public List<Direction> Directions { get; set; }

        public int NoOfCars { get; set; }
        public int NoOfTrafficLights { get; set; }
        public Crossroad North { get; set; }
        public Crossroad South { get; set; }
        public Crossroad East { get; set; }
        public Crossroad West { get; set; }

        public Crossroad()
        {
            this.NoOfCars = 0;
            this.NoOfTrafficLights = 0;
            this.North = null;
            this.South = null;
            this.East = null;
            this.West = null;
            delete = new MenuItem();
            Directions = new List<Direction>();
            AddDirections();
        }

        

        /// <summary>
        /// Gives the directions with the specific name
        /// </summary>
        /// <param name="name">name of the crossroad, EXAMPLE:"North-East"</param>
        /// <returns></returns>
        public Direction FindDirection(string name)
        {
            foreach (Direction dir in Directions)
            {
                if (dir.Name.Contains(name))
                    return dir;
            }
            return null;
        }

        //populates the list of the crossroad's available directions
        public void AddDirections()
        {
            //South
            List<Point> sn = new List<Point>(new Point[] { new Point(130, 3), new Point(130, 40), new Point(130, 80), new Point(130, 120), new Point(130, 160), new Point(130, 200) });
            List<Point> sw = new List<Point>(new Point[] { new Point(110, 190), new Point(110, 160), new Point(95, 100), new Point(80, 95 ), new Point(40, 85), new Point(10, 85) });
            List<Point> se = new List<Point>(new Point[] { new Point(130, 190), new Point(130, 150), new Point(135, 135), new Point(145, 130), new Point(170, 130), new Point(190, 130) });
            //East
            List<Point> en = new List<Point>(new Point[] { new Point(190, 65), new Point(155, 65), new Point(130, 55), new Point(125, 40), new Point(125, 20), new Point(125, 10) });
            List<Point> es = new List<Point>(new Point[] { new Point(190, 85), new Point(170, 85), new Point(120, 95), new Point(85, 120), new Point(85, 150), new Point(85, 190) });
            List<Point> ew = new List<Point>(new Point[] { new Point(190, 65), new Point(170, 65), new Point(110, 65), new Point(90, 65), new Point(40, 65), new Point(20, 65) });
            //West
            List<Point> we = new List<Point>(new Point[] { new Point(5, 125), new Point(30, 125), new Point(80, 125), new Point(110, 125), new Point(150, 125), new Point(190, 125) });
            List<Point> ws = new List<Point>(new Point[] { new Point(5, 125), new Point(30, 125), new Point(50, 130), new Point(65, 140), new Point(65, 155), new Point(65, 190) });
            List<Point> wn = new List<Point>(new Point[] { new Point(5, 110), new Point(25, 110), new Point(60, 110), new Point(100, 90), new Point(110, 50), new Point(110, 10) });
            //North
            List<Point> ns = new List<Point>(new Point[] { new Point(85, 10), new Point(85, 40), new Point(85, 70), new Point(85, 100), new Point(85, 150), new Point(85, 190) });
            List<Point> ne = new List<Point>(new Point[] { new Point(85, 10), new Point(85, 40), new Point(95, 70), new Point(105, 100), new Point(145, 130), new Point(192, 130) });
            List<Point> nw = new List<Point>(new Point[] { new Point(65, 10), new Point(65, 40), new Point(65, 55), new Point(60, 65), new Point(40, 70), new Point(10, 70) });

            //from -> to
            //SN stands for south to north and so on
            //south
            Directions.Add(new Direction(sn, "South-North"));
            Directions.Add(new Direction(se, "South-East"));
            Directions.Add(new Direction(sw, "South-West"));
            ////East
            Directions.Add(new Direction(en, "East-North"));
            Directions.Add(new Direction(es, "East-South"));
            Directions.Add(new Direction(ew, "East-West"));
            ////West
            Directions.Add(new Direction(we, "West-East"));
            Directions.Add(new Direction(ws, "West-South"));
            Directions.Add(new Direction(wn, "West-North"));
            //North
            Directions.Add(new Direction(ns, "North-South"));
            Directions.Add(new Direction(ne, "North-East"));
            Directions.Add(new Direction(nw, "North-West"));


        }
        public void Connect()
        { }

        //public Direction NextDirection()
        //{
        //    //just an example ;)
        //    //direction dir = new Direction( [Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0), Point(0, 0)])
        //    //return dir;
        //    return null; //for now
        //}


        void DrawDirections(PaintEventArgs pe)
        {
            foreach (Direction dir in Directions)
            {
                foreach (Point p in dir.Points)
                {
                    Brush aBrush = (Brush)Brushes.Red;

                    pe.Graphics.FillRectangle(aBrush, p.X, p.Y, 5, 5);

                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            DrawDirections(pe);

            base.OnPaint(pe);
           
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
           
            
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                delete.Text = "Delete";
                cm.MenuItems.Add(delete);
                ContextMenu = cm;
            }
              
            base.OnMouseUp(e);
        }

        public override string ToString()
        {
            string s = this.Location.ToString() ;
            if (this.South != null)
            {
                s += "\n\t south: " + this.South.Location.ToString();
            }
            if (this.West != null)
            {
                s += "\n\t West: " + this.West.Location.ToString();
            }
            if (this.East != null)
            {
                s += "\n\t East: " + this.East.Location.ToString();
            }
            if (this.North != null)
            {
                s += "\n\t North: " + this.North.Location.ToString();
            }
            return s;

        }



    }
}
