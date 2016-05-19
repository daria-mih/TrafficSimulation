using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficSimulation
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

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
                    Crossroad A = new CrossroadA();
                    A.AllowDrop = true;           
                    A.DragOver += Crossroad_DragOver;
                    A.BackgroundImage = Properties.Resources.Crossroad1;
                    A.Width = 200;
                    A.Height = 200;
                    A.BackgroundImageLayout = ImageLayout.Stretch;

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
                        }
                    }

                    //adds the crossroad to the grid
                    grid1.Controls.Add(A);
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
                    B.delete.Click += (sender2, eventArgs2) =>
                    {
                        grid1.Controls.Remove(B);

                    };

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

        private void Crossroad_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
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
       

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Crossroad item in grid1.Controls)
            {
                listBox1.Items.Add(item.Location.ToString() + " --- " + item.GetType().Name);
            }
        }

        private void grid1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
