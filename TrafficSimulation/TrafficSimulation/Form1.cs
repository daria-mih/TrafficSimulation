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
        }
        public void StopSimulation()
        {

        }
        //public bool Save(Grid grid)
        //{
        //    throw new NotImplementedException();
        //}
        //public Grid  Load()
        //{
        //    throw new NotImplementedException();
        //}

        public void SelectCrossroad(object sender, EventArgs e)
        {

        }
        private void btnCrossroad1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void btnCrossroad1_MouseEnter(object sender, EventArgs e)
        {
            btnCrossroad1.Image = Properties.Resources.Crossroad1;
        }

        private void btnCrossroad1_MouseLeave(object sender, EventArgs e)
        {
            btnCrossroad1.Image = Properties.Resources.Crossroad1bw;
        }

        private void btnCrossroad2_MouseEnter(object sender, EventArgs e)
        {
            btnCrossroad2.Image = Properties.Resources.Crossroad2;
        }

        private void btnCrossroad2_MouseLeave(object sender, EventArgs e)
        {
            btnCrossroad2.Image = Properties.Resources.Crossroad2bw;
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

        
    }
}
