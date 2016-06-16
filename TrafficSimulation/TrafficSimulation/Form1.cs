using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulation
{
    public partial class Form1 : Form
    {
        FileStream fs;
        List<CrossroadProperties> properties;
        Crossroad selectedCrossroad;
        BinaryFormatter bf;
        private SaveFileDialog saveGrid = new SaveFileDialog();
        private OpenFileDialog openGrid = new OpenFileDialog();
        public bool saved = false;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private int count;
        int counter, counter1, counter2, counter3 = 0;
        // Crossroad currentRoad;
        Point mousePoint;
        public static List<Vehicle> Cars;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        Thread simulation;
        List<Point> sn = new List<Point>(new Point[] { new Point(125, 190), new Point(125, 185), new Point(125, 180), new Point(125, 175), new Point(125, 170), new Point(125, 160), new Point(125, 130), new Point(125, 120), new Point(125, 115), new Point(125, 110), new Point(125, 105), new Point(125, 100), new Point(125, 95), new Point(125, 90), new Point(125, 85), new Point(125, 80), new Point(125, 75), new Point(125, 70), new Point(125, 65), new Point(125, 60), new Point(125, 55), new Point(125, 50), new Point(125, 45), new Point(125, 40), new Point(125, 35), new Point(125, 30), new Point(125, 25), new Point(125, 20), new Point(125, 15), new Point(125, 10), new Point(125, 5) });
        List<Point> ns = new List<Point>(new Point[] { new Point(80, 10), new Point(80, 15), new Point(80, 25), new Point(80, 30), new Point(80, 70), new Point(80, 100), new Point(80, 150), new Point(80, 190) });
        List<Point> nw = new List<Point>(new Point[] { new Point(65, 10), new Point(65, 15), new Point(65, 25), new Point(65, 30), new Point(65, 60), new Point(60, 65), new Point(50, 65), new Point(40, 65), new Point(35, 65), new Point(30, 65), new Point(25, 65), new Point(20, 65), new Point(10, 65) });
        List<Point> sw = new List<Point>(new Point[] { new Point(110, 190), new Point(110, 185), new Point(110, 180), new Point(110, 175), new Point(110, 170), new Point(110, 160), new Point(110, 130), new Point(105, 120), new Point(100, 110), new Point(95, 100), new Point(80, 95), new Point(75, 95), new Point(70, 95), new Point(65, 90), new Point(55, 90), new Point(40, 85), new Point(35, 85), new Point(30, 85), new Point(25, 85), new Point(20, 85), new Point(15, 85), new Point(10, 85) });
        List<Point> wn = new List<Point>(new Point[] { new Point(5, 110), new Point(10, 110), new Point(15, 110), new Point(20, 110), new Point(25, 110), new Point(30, 110), new Point(60, 110), new Point(80, 100), new Point(100, 90), new Point(105, 70), new Point(110, 50), new Point(110, 45), new Point(110, 40), new Point(110, 35), new Point(110, 30), new Point(110, 25), new Point(110, 20), new Point(110, 15), new Point(110, 10) });
        List<Point> ws = new List<Point>(new Point[] { new Point(5, 125), new Point(10, 125), new Point(15, 110), new Point(20, 110), new Point(25, 110), new Point(30, 125), new Point(60, 130), new Point(65, 140), new Point(65, 145), new Point(65, 150), new Point(65, 155), new Point(65, 160), new Point(65, 165), new Point(65, 170), new Point(65, 175), new Point(65, 180), new Point(65, 185), new Point(65, 190), });
        List<Point> en = new List<Point>(new Point[] { new Point(190, 65), new Point(185, 65), new Point(180, 65), new Point(175, 65), new Point(170, 65), new Point(165, 65), new Point(130, 55), new Point(125, 40), new Point(125, 20), new Point(125, 10) });
        List<Point> es = new List<Point>(new Point[] { new Point(190, 80), new Point(185, 80), new Point(180, 80), new Point(175, 80), new Point(170, 80), new Point(165, 80), new Point(120, 95), new Point(85, 120), new Point(85, 150), new Point(85, 190) });
        Vehicle anothercar;
        Vehicle car;
        Vehicle onemorecar;
        private Vehicle car4;
        private Vehicle car5;
        private Vehicle car6;
        Vehicle car7;
        private Vehicle car8;

        public Form1()
        {
            selectedCrossroad = new Crossroad();
            this.ControlBox = false;
            this.Text = String.Empty;
            this.DoubleBuffered = true;

            InitializeComponent();
            //timer1.Interval = 500;
            //timer1.Start();
            Simulation.grid = grid1;
            car = new Vehicle(ns);
            Cars = new List<Vehicle>();
            onemorecar = new Vehicle(sn);
            car5 = new Vehicle(wn);
            car6 = new Vehicle(ws);
            anothercar = new Vehicle(nw);
            car4 = new Vehicle(sw);
            car7 = new Vehicle(en);
            car8 = new Vehicle(es);
            //Crossroad A = new CrossroadA();
            //A.BackgroundImage = Properties.Resources.Crossroad2bw;
            //A.Height = 107;
            //A.Width = 101;
            //pictureBox1.Controls.Add(A);

        }


        private void btnCrossroad1_MouseEnter(object sender, EventArgs e)
        {
            crossroadA1.BackgroundImage = Properties.Resources.Crossroad1;
        }

        private void btnCrossroad1_MouseLeave(object sender, EventArgs e)
        {
            crossroadA1.BackgroundImage = Properties.Resources.Crossroad1bw;
        }

        private void btnCrossroad2_MouseEnter(object sender, EventArgs e)
        {
            crossroadB1.BackgroundImage = Properties.Resources.Crossroad2;
        }

        private void btnCrossroad2_MouseLeave(object sender, EventArgs e)
        {
            crossroadB1.BackgroundImage = Properties.Resources.Crossroad2bw;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.SizeAll;
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnOpen_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnOpen.Image = Properties.Resources.open_icon_mo;
        }

        private void btnOpen_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            btnOpen.Image = Properties.Resources.open_icon;
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnSave.Image = Properties.Resources.save_icon_mo;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            btnSave.Image = Properties.Resources.save_icon;
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnStart.Image = Properties.Resources.start_mo;
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnClose.Image = Properties.Resources.close_mo;
        }

        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            btnStart.Image = Properties.Resources.start;
        }

        private void btnStop_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            btnStop.Image = Properties.Resources.stop_mo;
        }

        private void btnStop_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            btnStop.Image = Properties.Resources.stop;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            btnClose.Image = Properties.Resources.close;
        }

        //DRAG & DROP

        //Grid Events
        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            Crossroad c = (Crossroad)(e.Data.GetData(e.Data.GetFormats()[0]));

            if (c != null)
            {

                if (c.Name == "crossroadA1")
                {
                    Crossroad A = new CrossroadA();
                    A.AllowDrop = true;
                    A.DragOver += Crossroad_DragOver;
                    A.BackgroundImage = Properties.Resources.Crossroad1;

                    A.Width = 200;
                    A.Height = 200;

                    A.BackgroundImageLayout = ImageLayout.Stretch;

                    A.MouseDown += Crossroad_MouseDown;

                    A.MouseUp += crossroadA1_MouseUp;
                    A.delete.Click += (sender2, eventArgs2) =>
                    {
                        grid1.Controls.Remove(A);
                    };

                    //Places the crossroad in the placeholder
                    foreach (var placeholder in grid1.Placeholders)
                    {
                        if (placeholder.Contains(grid1.PointToClient(Cursor.Position)))
                        {
                            A.Location = placeholder.Location;

                            A.PlaceTrafficLights(3000);
                            // A.Paint += new System.Windows.Forms.PaintEventHandler(this.grid1_Paint);

                        }
                    }

                    //adds the crossroad to the grid
                    grid1.Controls.Add(A);
                    //A.AddCarToTheList(car);
                    //A.AddCarToTheList(anothercar);
                    //A.AddCarToTheList(onemorecar);
                    //A.AddCarToTheList(car4);
                    //A.AddCarToTheList(car5);
                    //A.AddCarToTheList(car6);
                    //A.AddCarToTheList(car7);
                    //A.AddCarToTheList(car8);
                    //A.AddCarToTheList(car);
                    //cars.Add(anothercar);
                    //cars.Add(onemorecar);
                    //cars.Add(car4);
                    //cars.Add(car5);
                    //cars.Add(car6);
                    //cars.Add(car7);
                    //cars.Add(car8);

                }
                else if (c.Name == "crossroadB1")
                {
                    Crossroad B = new CrossroadB();
                    B.AllowDrop = true;
                    B.DragOver += Crossroad_DragOver;
                    B.BackgroundImage = Properties.Resources.Crossroad2;
                    B.Location = grid1.PointToClient(Cursor.Position);
                    B.Width = 200;
                    B.Height = 200;
                    B.BackgroundImageLayout = ImageLayout.Stretch;
                    B.MouseDown += Crossroad_MouseDown;
                    B.delete.Click += (sender2, eventArgs2) =>
                    {
                        grid1.Controls.Remove(B);
                    };

                    foreach (var placeholder in grid1.Placeholders)
                    {
                        if (placeholder.Contains(grid1.PointToClient(Cursor.Position)))
                        {
                            B.Location = placeholder.Location;
                            B.PlaceTrafficLights(3000);
                        }
                    }

                    grid1.Controls.Add(B);

                }

            }
        }

        private void Crossroad_MouseDown(object sender, MouseEventArgs e)
        {
            Crossroad cr = (Crossroad)sender;
            selectedCrossroad = cr;

            if (e.Button == MouseButtons.Left)
            {
                //deletes the selected rectangle in all the other crossroads
                foreach (Crossroad c in grid1.Controls)
                {
                    c.Invalidate();
                    c.Update();
                }
                //paints the border to the selected crossroad
                Rectangle borderRectangle = cr.ClientRectangle;
                borderRectangle.Inflate(-3, -3);
                ControlPaint.DrawBorder3D(cr.CreateGraphics(), borderRectangle,
                    Border3DStyle.Etched);
            }



        }

        private void AssignNeighbours(Crossroad c)
        {
            Point Location = c.PointToScreen(Point.Empty);
            Point CenterPoint = new Point(Location.X + 100, Location.Y + 100);
            if (c.North == null || c.South == null || c.West == null || c.East == null)
            {
                foreach (Control control in grid1.Controls.OfType<Crossroad>())
                {
                    Point locationOnForm = control.PointToScreen(Point.Empty);
                    Rectangle crossroadArea = new Rectangle(locationOnForm.X, locationOnForm.Y, 200, 200);

                    if (crossroadArea.Contains(new Point(CenterPoint.X, CenterPoint.Y - 200)))
                    {
                        c.North = (Crossroad)control;
                    }
                    else if (crossroadArea.Contains(new Point(CenterPoint.X, CenterPoint.Y + 200)))
                    {
                        c.South = (Crossroad)control;
                    }
                    else if (crossroadArea.Contains(new Point(CenterPoint.X - 200, CenterPoint.Y)))
                    {
                        c.East = (Crossroad)control;
                    }
                    else if (crossroadArea.Contains(new Point(CenterPoint.X + 200, CenterPoint.Y)))
                    {
                        c.West = (Crossroad)control;
                    }


                }
            }
            if (c.North != null)

                Console.WriteLine(c.North);
            if (c.South != null)

                Console.WriteLine(c.South);
            if (c.East != null)

                Console.WriteLine(c.East);
            if (c.West != null)

                Console.WriteLine(c.West);
        }



        private void Crossroad_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
        }

        private void grid1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //Crossroad Events

        private void crossroadA1_MouseDown(object sender, MouseEventArgs e)
        {
            crossroadA1.DoDragDrop(crossroadA1, DragDropEffects.Copy);

        }

        private void crossroadB1_MouseDown(object sender, MouseEventArgs e)
        {
            crossroadB1.DoDragDrop(crossroadB1, DragDropEffects.Copy);
        }

        private void crossroadA1_MouseUp(object sender, MouseEventArgs e)
        {
            //pump.DoDragDrop(pump, DragDropEffects.Copy);
        }

        private void crossroadB1_MouseUp(object sender, MouseEventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //car.Move(Cars, Crossroad.trafficLights);
            //anothercar.Move(Cars, Crossroad.trafficLights);
            //onemorecar.Move(Cars, Crossroad.trafficLights);
            //car4.Move(Cars, Crossroad.trafficLights);
            //car5.Move(Cars, Crossroad.trafficLights);
            //car6.Move(Cars, Crossroad.trafficLights);
            //car7.Move(Cars, Crossroad.trafficLights);
            //car8.Move(Cars, Crossroad.trafficLights);
            //foreach (var c in Simulation.Moveables)
            //{
            //    c.Move(Cars, Crossroad.trafficLights);
            //}

            this.Invalidate();

            // List<TrafficLight> trafficLights = new List<TrafficLight>();
            //List<TrafficLight> temp = trafficLights;
            // foreach (TrafficLight trafficlight in trafficLights)
            //{
            //trafficlight.Interval--;
            //break;
            //if (trafficlight.Interval.Equals(0))
            //{
            //    Simulation.ChangeTrafficLights();
            //    trafficlight.Interval = temp.IndexOf(trafficlight).Interval;
            //}
            //}

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (grid1.Controls.Count == 0)
            {
                Load();
            }
            else
            {
                if (!saved)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save the current diagram before opening?",
                        "Save As", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        Save();
                        saved = true;
                    }
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (dr == DialogResult.No)
                    {
                        Load();
                        saved = false;
                    }
                }
                //  this.Refresh();
            }
        }
        /// <summary>
        /// To save a properties to file.
        /// </summary>
        private bool Save()
        {
            bf = null;
            fs = null;
            properties = new List<CrossroadProperties>();
            foreach (Control c in grid1.Controls)
            {
                if (c is Crossroad)
                {
                    if (c is CrossroadA)
                    {
                        //this is only a test, will update all properties such as noOfCars etc when everything has been fully implemented
                        properties.Add(new CrossroadProperties() { Location = c.Location, Type = 1 });
                    }
                    else
                    {
                        properties.Add(new CrossroadProperties() { Location = c.Location, Type = 2 });
                    }
                }
            }
            if (!saved)
            {
                saveGrid.FileName = "UntitledGrid.trf";
                saveGrid.Filter = "Traffic Simulation file(*.trf)|*.trf";
                DialogResult dr = saveGrid.ShowDialog();
                if (saveGrid.FileName != "*.trf")
                {
                    try
                    {
                        if (dr.ToString() == "OK")
                        {
                            fs = new FileStream(saveGrid.FileName, FileMode.Create, FileAccess.Write);
                            bf = new BinaryFormatter();
                            bf.Serialize(fs, properties);
                            return true;
                        }
                    }
                    catch (SerializationException)
                    { }

                    finally
                    {
                        if (fs != null) fs.Close();
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// To load a grid from file
        /// </summary>
        /// <returns></returns>
        private void Load()
        {
            List<CrossroadProperties> newProperties = new List<CrossroadProperties>();
            bf = null;
            fs = null;
            try
            {
                DialogResult dr = openGrid.ShowDialog();
                if (dr.ToString() == "OK")
                {
                    fs = new FileStream(openGrid.FileName, FileMode.Open, FileAccess.Read);
                    bf = new BinaryFormatter();
                    fs.Position = 0;

                    newProperties = ((List<CrossroadProperties>)(bf.Deserialize(fs)));

                }
                if (newProperties.Count > 0)
                {

                    grid1.Controls.Clear();
                    foreach (CrossroadProperties prop in newProperties)
                    {
                        if (prop.Type == 1)
                        {
                            Crossroad A = new CrossroadA();
                            A.AllowDrop = true;
                            A.DragOver += Crossroad_DragOver;
                            A.BackgroundImage = Properties.Resources.Crossroad1;

                            A.Width = 200;
                            A.Height = 200;

                            A.BackgroundImageLayout = ImageLayout.Stretch;
                            A.MouseClick += crossroadA1_MouseDown;
                            A.MouseUp += crossroadA1_MouseUp;
                            A.delete.Click += (sender2, eventArgs2) =>
                            {
                                grid1.Controls.Remove(A);
                            };
                            A.Location = prop.Location;
                            grid1.Controls.Add(A);
                        }
                        else
                        {
                            Crossroad B = new CrossroadB();
                            B.AllowDrop = true;
                            B.DragOver += Crossroad_DragOver;
                            B.BackgroundImage = Properties.Resources.Crossroad2;
                            B.Location = grid1.PointToClient(Cursor.Position);
                            B.Width = 200;
                            B.Height = 200;
                            B.BackgroundImageLayout = ImageLayout.Stretch;
                            B.delete.Click += (sender2, eventArgs2) =>
                            {
                                grid1.Controls.Remove(B);
                            };
                            B.Location = prop.Location;
                            grid1.Controls.Add(B);

                        }
                    }
                    int controls = grid1.Controls.Count;

                }
            }
            catch (SerializationException) { }
            finally
            {
                if (fs != null) fs.Close();
            }
            saved = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grid1.Controls.Count != 0)
            {
                saved = Save();
            }
            else { MessageBox.Show("There are no crossroads on the grid to save"); }
            this.Refresh();
        }

        private void grid1_ControlAdded(object sender, ControlEventArgs e)
        {
            saved = false;
            foreach (Control control in grid1.Controls.OfType<Crossroad>())
            {
                AssignNeighbours((Crossroad)control);
            }
        }

        private void grid1_ControlRemoved(object sender, ControlEventArgs e)
        {
            saved = false;
            RemoveNeighbours(selectedCrossroad);
        }


        private void RemoveNeighbours(Crossroad crossroad)
        {
            foreach (Control control in grid1.Controls.OfType<Crossroad>())
            {
                if (((Crossroad)control).East == crossroad)
                {
                    ((Crossroad)control).East = null;
                }
                else if (((Crossroad)control).West == crossroad)
                {
                    ((Crossroad)control).West = null;
                }
                else if (((Crossroad)control).North == crossroad)
                {
                    ((Crossroad)control).North = null;
                }
                else if (((Crossroad)control).South == crossroad)
                {
                    ((Crossroad)control).South = null;
                }
            }
            selectedCrossroad = null;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Simulation.ShouldStop = false;
            simulation = new Thread(Simulation.Run);
            simulation.Start();

        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Simulation.DrawCars(e);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Simulation.ShouldStop = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2000;

            timer2.Interval = 3000;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            count++;
            //Vehicle c =
            //       new Vehicle(
            //           new List<Point>(new Point[]
            //            {
            //                new Point(85, 10), new Point(85, 15), new Point(85, 25), new Point(85, 40), new Point(85, 70),
            //                new Point(85, 100), new Point(85, 150), new Point(85, 190)
            //            }));
            //cars.Add(c);

            if (checkBox1.Checked)
            {
                counter++;

                if (count % 2 == 0)
                {
                    if (counter % 4 == 0)
                    {
                        // north to south
                        Vehicle c =
                            new Vehicle(
                                new List<Point>(new Point[]
                                {
                                                new Point(85, 10), new Point(85, 15), new Point(85, 25),
                                                new Point(85, 40),
                                                new Point(85, 70),
                                                new Point(85, 100), new Point(85, 150), new Point(85, 190)
                                }));

                        // Cars.Add(c);
                    }
                    else
                    {
                        //north to east
                        Vehicle c =
                            new Vehicle(
                                new List<Point>(new Point[]
                                {
                                                new Point(85, 10), new Point(85, 15), new Point(85, 20), new Point(85, 25),
                                                new Point(85, 30), new Point(95, 60), new Point(100, 80),  new Point(105, 100), new Point(115, 110), new Point(120, 110), new Point(125, 110), new Point(130, 110), new Point(135, 110), new Point(140, 110), new Point(145, 110), new Point(150, 110), new Point(155, 110), new Point(160, 110), new Point(165, 110), new Point(170, 110), new Point(175, 110), new Point(180, 110), new Point(185, 110), new Point(190, 110)
                                }));

                        // Cars.Add(c);
                    }
                }
                else if (count % 2 == 1)
                {
                    //north to west
                    Vehicle c =
                        new Vehicle(
                            new List<Point>(new Point[]
                            {
                                            new Point(65, 10), new Point(65, 40), new Point(65, 55), new Point(60, 65),
                                            new Point(40, 70),
                                            new Point(10, 70)
                            }));

                    //  Cars.Add(c);
                }

            }

            if (checkBox2.Checked)
            {
                counter1++;
                if (count % 2 == 0)
                {
                    if (counter1 % 4 == 0)
                    {
                        // south to north
                        Vehicle c =
                            new Vehicle(
                                 new List<Point>(new Point[] { new Point(110, 190), new Point(110, 185), new Point(110, 180),
                                                 new Point(110, 175), new Point(110, 170), new Point(110, 165), new Point(110, 160), new Point(110, 130), new Point(110, 125),
                                                 new Point(110, 120), new Point(110, 115), new Point(110, 110), new Point(110, 105), new Point(110, 100), new Point(110, 95), new Point(125, 90),
                                                 new Point(110, 85), new Point(110, 80), new Point(110, 75), new Point(110, 70), new Point(110, 65), new Point(110, 60), new Point(110, 55), new Point(110, 50),
                                                 new Point(110, 45), new Point(110, 40), new Point(110, 35), new Point(110, 30), new Point(110, 25), new Point(110, 20), new Point(110, 15), new Point(110, 10),
                                                 new Point(110, 5) }));

                        //  Cars.Add(c);
                    }
                    else
                    {
                        // south to west
                        Vehicle c =
                         new Vehicle(
                              new List<Point>(new Point[]
                              {
                                              new Point(110, 190), new Point(110, 185), new Point(110, 180), new Point(110, 175),
                                              new Point(110, 170), new Point(110, 160), new Point(110, 130), new Point(105, 120), new Point(100, 110), new Point(95, 100), new Point(80, 95),
                                              new Point(75, 95), new Point(70, 95), new Point(65, 90), new Point(55, 90), new Point(40, 85), new Point(35, 85), new Point(30, 85), new Point(25, 85),
                                              new Point(20, 85), new Point(15, 85), new Point(10, 85)
                              }));

                        // Cars.Add(c);
                    }
                }

                if (count % 2 == 1)
                {
                    //south to east
                    Vehicle c =
                        new Vehicle(
                            new List<Point>(new Point[]
                            {
                                            new Point(130, 190), new Point(130, 150), new Point(135, 135),
                                            new Point(145, 130),
                                            new Point(170, 130), new Point(190, 130)
                            }));

                    // Cars.Add(c);
                }
            }

            if (checkBox3.Checked)
            {
                counter2++;
                if (count % 2 == 0)
                {
                    if (counter2 % 4 == 0)
                    {
                        //west to east
                        Vehicle c =
                            new Vehicle(
                                new List<Point>(new Point[]
                                {
                                                new Point(5, 108), new Point(30, 108), new Point(80, 108),
                                                new Point(110, 108),
                                                new Point(150, 108), new Point(190, 108)
                                }));

                        //  Cars.Add(c);
                    }
                    else
                    {
                        //west to north
                        Vehicle c =
                           new Vehicle(
                               new List<Point>(new Point[]
                               {
                                               new Point(5, 110), new Point(10, 110), new Point(15, 110), new Point(20, 110),
                                               new Point(25, 110), new Point(30, 110), new Point(60, 110), new Point(80, 100), new Point(100, 90),
                                               new Point(105, 70), new Point(110, 50), new Point(110, 45), new Point(110, 40), new Point(110, 35), new Point(110, 30),
                                               new Point(110, 25), new Point(110, 20), new Point(110, 15), new Point(110, 10)
                               }));

                        //Cars.Add(c);
                    }
                }
                if (count % 2 == 1)
                {
                    // west to south
                    Vehicle c =
                        new Vehicle(
                            new List<Point>(new Point[]
                            {
                                            new Point(5, 125), new Point(30, 125), new Point(50, 130),
                                            new Point(65, 140),
                                            new Point(65, 155), new Point(65, 190)
                            }));

                    // Cars.Add(c);
                }
            }

            if (checkBox4.Checked)
            {
                counter3++;
                if (count % 2 == 0)
                {
                    // east to north
                    Vehicle c =
                        new Vehicle(new List<Point>(new Point[]
                        {
                                        new Point(190, 65), new Point(155, 65), new Point(130, 55), new Point(125, 40),
                                        new Point(125, 20), new Point(125, 10)
                        }));

                    // Cars.Add(c);

                }

                if (count % 2 == 1)
                {
                    if (counter3 % 4 == 0)
                    {
                        //east to west
                        Vehicle c =
                            new Vehicle(new List<Point>(new Point[]
                            {
                                new Point(190, 65), new Point(185, 65), new Point(180, 65), new Point(175, 65),
                                new Point(170, 65), new Point(165, 65),
                                new Point(130, 65), new Point(125, 65), new Point(120, 65), new Point(115, 65),
                                new Point(110, 65), new Point(105, 65), new Point(100, 65),
                                new Point(95, 65), new Point(90, 65), new Point(85, 65), new Point(80, 65),
                                new Point(75, 65), new Point(70, 65), new Point(65, 65),
                                new Point(60, 65), new Point(55, 65), new Point(50, 65), new Point(45, 65),
                                new Point(40, 65), new Point(35, 65), new Point(30, 65), new Point(25, 65),
                                new Point(20, 65), new Point(15, 65), new Point(10, 65)
                            }));

                        // Cars.Add(c);
                    }
                    else
                    {
                        // east to north
                        Vehicle c =
                            new Vehicle(new List<Point>(new Point[]
                            {
                                new Point(190, 82), new Point(170, 82), new Point(120, 95),
                                new Point(85, 120),
                                new Point(85, 150), new Point(85, 190)
                            }))

                    ;

                        // Cars.Add(c);
                    }
                }

            }
        }
    }
}
