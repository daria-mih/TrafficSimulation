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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulation
{
    public partial class Form1 : Form
    {
        FileStream fs;
        BinaryFormatter bf;
        private SaveFileDialog saveGrid = new SaveFileDialog();
        private OpenFileDialog openGrid = new OpenFileDialog();
        public bool saved = false;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // Crossroad currentRoad;
        Point mousePoint;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {

            this.ControlBox = false;
            this.Text = String.Empty;
            InitializeComponent();

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
                    Crossroad A = new Crossroad();
                    A.BackgroundImage = Properties.Resources.Crossroad1;

                    A.Width = 200;
                    A.Height = 200;
                    A.BackgroundImageLayout = ImageLayout.Stretch;
                    A.MouseClick += crossroadA1_MouseDown;
                    A.MouseUp += crossroadA1_MouseUp;

                    //Places the crossroad in the placeholder
                    foreach (var placeholder in grid1.Placeholders)
                    {
                        if (placeholder.Contains(grid1.PointToClient(Cursor.Position)))
                        {
                            A.Location = placeholder.Location;
                        }
                    }

                    //adds the crossroad to the grid
                    grid1.Controls.Add(A);
                }
                else if (c.Name == "crossroadB1")
                {
                    Crossroad B = new CrossroadB();
                    B.BackgroundImage = Properties.Resources.Crossroad2;
                    B.Location = grid1.PointToClient(Cursor.Position);
                    B.Width = 200;
                    B.Height = 200;
                    B.BackgroundImageLayout = ImageLayout.Stretch;
                    B.MouseClick += crossroadB1_MouseDown;
                    B.MouseUp += crossroadB1_MouseUp;

                    foreach (var placeholder in grid1.Placeholders)
                    {
                        if (placeholder.Contains(grid1.PointToClient(Cursor.Position)))
                        {
                            B.Location = placeholder.Location;
                        }
                    }

                    grid1.Controls.Add(B);
                }
            }
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
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

            List<TrafficLight> trafficLights = new List<TrafficLight>();
            List<TrafficLight> temp = trafficLights;
            foreach (TrafficLight trafficlight in trafficLights)
            {
                //trafficlight.Interval--;
                //break;
                //if (trafficlight.Interval.Equals(0))
                //{
                //    Simulation.ChangeTrafficLights();
                //    trafficlight.Interval = temp.IndexOf(trafficlight).Interval;
                //}
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(grid1.Controls.Count == 0)
            {
                grid1 = Load();
            }
            else
            {
                if (!saved)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save the current diagram before opening?",
                        "Save As", MessageBoxButtons.YesNoCancel);
                    if (dr == DialogResult.Yes)
                    {
                        Save(grid1);
                        saved = true;
                    }
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    if (dr == DialogResult.No)
                    {
                        grid1 = Load();
                    }
                }
                this.Refresh();
            }
        }
        /// <summary>
        /// To save a grid to file.
        /// </summary>
        /// <param name="grid"></param>
        private bool Save(Grid grid)
        {
            bf = null;
            fs = null;
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
                            bf.Serialize(fs, grid);
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
        private Grid Load()
        {
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
                    Grid _grid = ((Grid)(bf.Deserialize(fs)));
                    return _grid;
                }
            }
            catch (SerializationException) { }
            finally
            {
                if (fs != null) fs.Close();
            }
            saved = true;
            return null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(grid1.Controls.Count != 0)
            {
                saved = Save(grid1);

            }
            else { MessageBox.Show("There are no crossroads on the grid to save"); }
            this.Refresh();
        }
    }
}
