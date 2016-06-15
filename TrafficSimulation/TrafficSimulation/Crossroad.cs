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
    public class Crossroad : Control
    {
        public MenuItem delete { get; set; }
        //guys, we first put this method in direction but thought it would be better to use it in this class

        public List<Direction> Directions { get; set; }
        public static List<TrafficLight> trafficLights;
        private int counter;
        private Timer lightTimer;
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
            trafficLights = new List<TrafficLight>();
            lightTimer = new Timer();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
           // counter++;
            ChangeState();

        }

        private void ChangeState()
        {
            TrafficLight tempLight = null;
            if (counter >= 0)
            {
                tempLight = trafficLights[counter];
                tempLight.state = Color.Lime;
                foreach (TrafficLight trafficLight in trafficLights)
                {
                    if (trafficLight != tempLight)
                    {
                        trafficLight.state = Color.Red;
                    }
                }
               // counter++;
                if (counter >=3)
                    counter = 0;
                else
                {
                    counter++;
                }
                this.Refresh();
            }

        }

        private void InitializeTimer()
        {
            counter = 0;
            lightTimer.Interval = 1000;
            lightTimer.Enabled = true;
            timer1_Tick(null, null);

            lightTimer.Tick += new EventHandler(timer1_Tick);
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
            //fixed sn
            List<Point> sn = new List<Point>(new Point[] { new Point(125, 190), new Point(125, 185), new Point(125, 180), new Point(125, 175), new Point(125, 170), new Point(125, 165),  new Point(125, 160), new Point(125, 130), new Point(125, 125),  new Point(125, 120), new Point(125, 115), new Point(125, 110), new Point(125, 105), new Point(125, 100), new Point(125, 95), new Point(125, 90), new Point(125, 85), new Point(125, 80), new Point(125, 75), new Point(125, 70), new Point(125, 65), new Point(125, 60), new Point(125, 55), new Point(125, 50), new Point(125, 45), new Point(125, 40), new Point(125, 35), new Point(125, 30), new Point(125, 25), new Point(125, 20), new Point(125, 15), new Point(125, 10), new Point(125, 5) });
            List<Point> sw = new List<Point>(new Point[] { new Point(110, 190), new Point(110, 185), new Point(110, 180), new Point(110, 175), new Point(110, 170), new Point(110, 160), new Point(110, 130), new Point(105, 120), new Point(100, 110), new Point(95, 100), new Point(80, 95), new Point(75, 95), new Point(70, 95), new Point(65, 90), new Point(55, 90), new Point(40, 85), new Point(35, 85), new Point(30, 85), new Point(25, 85), new Point(20, 85), new Point(15, 85), new Point(10, 85) });
            List<Point> se = new List<Point>(new Point[] { new Point(125, 190), new Point(125, 185), new Point(125, 180), new Point(125, 175), new Point(125, 170), new Point(125, 165),  new Point(125, 160), new Point(135, 135), new Point(145, 130), new Point(150, 130), new Point(155, 130), new Point(160, 130), new Point(165, 130),new Point(170, 130), new Point(175, 130), new Point(180, 130), new Point(185, 130), new Point(190, 130) });
            //East
            List<Point> en = new List<Point>(new Point[] { new Point(190, 65), new Point(185, 65), new Point(180, 65), new Point(175, 65), new Point(170, 65), new Point(165, 65), new Point(130, 55), new Point(125, 40), new Point(125, 35), new Point(125, 30), new Point(125,25), new Point(125, 20), new Point(125, 15), new Point(125, 10)  });
            List<Point> es = new List<Point>(new Point[] { new Point(190, 80), new Point(185, 80), new Point(180, 80), new Point(175, 80), new Point(170, 80), new Point(165, 80), new Point(120, 95), new Point(85, 120), new Point(85, 125), new Point(85, 130), new Point(85, 140), new Point(85, 145), new Point(85, 150), new Point(85, 155), new Point(85, 160), new Point(85, 165), new Point(85, 170), new Point(85, 175), new Point(85, 180), new Point(85, 185), new Point(85, 190) });
            List<Point> ew = new List<Point>(new Point[] { new Point(190, 65), new Point(185, 65), new Point(180, 65), new Point(175, 65), new Point(170, 65), new Point(165, 65), new Point(130, 65), new Point(125, 65), new Point(120, 65), new Point(115, 65), new Point(110, 65), new Point(105, 65), new Point(100, 65), new Point(95, 65), new Point(90, 65), new Point(85, 65), new Point(80, 65), new Point(75, 65), new Point(70, 65), new Point(65,65), new Point(60, 65), new Point(55, 65), new Point(50, 65), new Point(45, 65), new Point(40, 65), new Point(35, 65), new Point(30, 65), new Point(25, 65), new Point(20, 65), new Point(15, 65), new Point(10, 65) });
            //West
            List<Point> we = new List<Point>(new Point[] { new Point(5, 125), new Point(10, 125), new Point(15, 125), new Point(20,125), new Point(25, 125), new Point(30, 125), new Point(60, 125), new Point(65,125), new Point(70,125), new Point(75,125), new Point(80, 125), new Point(85,125), new Point(90,125), new Point(95,125), new Point(100,125), new Point(105,125), new Point(110, 125), new Point(115,125), new Point(120,125), new Point(125,125), new Point(130,125), new Point(135,125), new Point(140, 125), new Point(145,125), new Point(150, 125), new Point(155, 125), new Point(160,125), new Point(165, 125), new Point(170, 125), new Point(175, 125), new Point(180,125), new Point(185,125), new Point(190, 125) });
            List<Point> ws = new List<Point>(new Point[] { new Point(5, 125), new Point(10,125),  new Point(15, 110), new Point(20,110), new Point(25,110),   new Point(30, 125), new Point(60, 130), new Point(65, 140), new Point(65,145), new Point(65, 150),   new Point(65, 155), new Point(65, 160), new Point(65, 165), new Point(65, 170), new Point(65, 175), new Point(65, 180), new Point(65,185),    new Point(65, 190), new Point(65, 195),  });
            List<Point> wn = new List<Point>(new Point[] { new Point(5, 110), new Point(10, 110), new Point(15, 110), new Point(20,110), new Point(25, 110),  new Point(30, 110), new Point(60, 110), new Point(80, 100),  new Point(100, 90), new Point(105, 70),  new Point(110, 50), new Point(110, 45), new Point(110, 40), new Point(110, 35), new Point(110, 30), new Point(110, 25), new Point(110, 20), new Point(110,15), new Point(110, 10) });
            //North
            List<Point> ns = new List<Point>(new Point[] { new Point(65, 10), new Point(65, 15), new Point(65, 20), new Point(65, 25), new Point(65, 30), new Point(65, 60), new Point(65, 65),   new Point(65, 70), new Point(65, 75), new Point(65, 80), new Point(65, 85), new Point(65, 90), new Point(65, 95), new Point(65, 100), new Point(65, 105), new Point(65, 110), new Point(65, 115),new Point(65, 120), new Point(65, 125), new Point(65, 130), new Point(65, 135), new Point(65, 140), new Point(65, 145), new Point(65, 150), new Point(65, 155), new Point(65, 160), new Point(65, 165), new Point(65, 170), new Point(65, 175), new Point(65, 180), new Point(65, 185), new Point(65, 190) });
            List<Point> ne = new List<Point>(new Point[] { new Point(85, 10), new Point(85, 15), new Point(85, 20), new Point(85, 25), new Point(85, 30), new Point(95, 60), new Point(100, 80),  new Point(105, 100), new Point(115, 110), new Point(120, 110), new Point(125, 110), new Point(130, 110), new Point(135, 110), new Point(140, 110), new Point(145, 110), new Point(150, 110), new Point(155, 110), new Point(160, 110), new Point(165, 110), new Point(170, 110), new Point(175, 110), new Point(180, 110), new Point(185, 110), new Point(190, 110) });
            List<Point> nw = new List<Point>(new Point[] { new Point(65, 10), new Point(65, 15), new Point(65, 20),  new Point(65, 25), new Point(65, 30), new Point(65, 60), new Point(60, 65), new Point(55, 65),  new Point(50, 65), new Point(45, 65),  new Point(40, 65), new Point(35, 65), new Point(30, 65), new Point(25, 65), new Point(20, 65),new Point(15, 65),  new Point(10, 65) });

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

/*
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
*/
       

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // if(Form1.Cars.Count > 0)
            Simulation.DrawCars(pe);

            foreach (TrafficLight tl in trafficLights)
            {
                Brush b = new SolidBrush(tl.state);
                switch (tl.Id)
                {
                    case 1:
                        {
                            pe.Graphics.FillEllipse(b, 80, 50, 9, 9);
                            tl.currentPosition1 = new Point(80, 50);
                            pe.Graphics.FillEllipse(b, 110, 140, 9, 9);
                            tl.currentPosition2 = new Point(110, 140);
                            break;
                        }
                    case 2:
                        {
                            //right
                            pe.Graphics.FillEllipse(b, 65, 50, 9, 9);
                            tl.currentPosition1 = new Point(65, 50);
                            pe.Graphics.FillEllipse(b, 125, 140, 9, 9);
                            tl.currentPosition2 = new Point(125, 140);

                            break;
                        }
                    case 3:
                        {

                            pe.Graphics.FillEllipse(b, 50, 125, 9, 9);
                            tl.currentPosition1 = new Point(50, 125);
                            pe.Graphics.FillEllipse(b, 140, 65, 9, 9);
                            tl.currentPosition2 = new Point(140, 65);
                            break;
                        }
                    case 4:
                        {

                            pe.Graphics.FillEllipse(b, 50, 110, 9, 9);
                            tl.currentPosition1 = new Point(50, 110);
                            pe.Graphics.FillEllipse(b, 140, 80, 9, 9);
                            tl.currentPosition2 = new Point(140, 80);
                            break;
                        }

                }

            }

        }
        public void PlaceTrafficLights(int timer)
        {

            for (int i = 0; i < 4; i++)
            {
                trafficLights.Add(new TrafficLight(i + 1, Color.Red));
            }
            InitializeTimer();
        }
        public void ChangeTimer(int seconds)
        {
            lightTimer.Interval = seconds * 1000;
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
           
            
        //}
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

        public void AddCarToTheList(Vehicle car)
        {
            Form1.Cars.Add(car);
        }
    }
}
