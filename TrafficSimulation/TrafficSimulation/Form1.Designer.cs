using System.Windows.Forms;

namespace TrafficSimulation
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grid1 = new TrafficSimulation.Grid();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbCrossroadB = new System.Windows.Forms.PictureBox();
            this.crossroadB1 = new TrafficSimulation.CrossroadB();
            this.crossroadA1 = new TrafficSimulation.CrossroadA();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.graphicalOverlay1 = new CodeProject.GraphicalOverlay(this.components);
            this.pbCrossroadA = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossroadB)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossroadA)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::TrafficSimulation.Properties.Resources.save_icon;
            this.btnSave.Location = new System.Drawing.Point(60, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 53);
            this.btnSave.TabIndex = 2;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::TrafficSimulation.Properties.Resources.open_icon;
            this.btnOpen.Location = new System.Drawing.Point(4, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(56, 53);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.TabStop = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            this.btnOpen.MouseEnter += new System.EventHandler(this.btnOpen_MouseEnter);
            this.btnOpen.MouseLeave += new System.EventHandler(this.btnOpen_MouseLeave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.grid1);
            this.panel3.Location = new System.Drawing.Point(127, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 601);
            this.panel3.TabIndex = 2;
            // 
            // grid1
            // 
            this.grid1.AllowDrop = true;
            this.grid1.BackgroundImage = global::TrafficSimulation.Properties.Resources.grid;
            this.grid1.Location = new System.Drawing.Point(-1, -2);
            this.grid1.Name = "grid1";
            this.grid1.Placeholders = ((System.Collections.Generic.List<System.Drawing.Rectangle>)(resources.GetObject("grid1.Placeholders")));
            this.grid1.Size = new System.Drawing.Size(800, 602);
            this.grid1.TabIndex = 2;
            this.grid1.Text = "grid1";
            this.grid1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.grid1_ControlAdded);
            this.grid1.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.grid1_ControlRemoved);
            this.grid1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.grid1.DragEnter += new System.Windows.Forms.DragEventHandler(this.grid1_DragEnter);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::TrafficSimulation.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(901, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbCrossroadB);
            this.panel2.Controls.Add(this.pbCrossroadA);
            this.panel2.Controls.Add(this.crossroadB1);
            this.panel2.Controls.Add(this.crossroadA1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(117, 234);
            this.panel2.TabIndex = 0;
            // 
            // pbCrossroadB
            // 
            this.pbCrossroadB.BackgroundImage = global::TrafficSimulation.Properties.Resources.Crossroad2bw;
            this.pbCrossroadB.Location = new System.Drawing.Point(4, 126);
            this.pbCrossroadB.Name = "pbCrossroadB";
            this.pbCrossroadB.Size = new System.Drawing.Size(107, 101);
            this.pbCrossroadB.TabIndex = 5;
            this.pbCrossroadB.TabStop = false;
            this.pbCrossroadB.Visible = false;
            // 
            // crossroadB1
            // 
            this.crossroadB1.BackgroundImage = global::TrafficSimulation.Properties.Resources.Crossroad2bw;
            this.crossroadB1.Directions = null;
            this.crossroadB1.East = null;
            this.crossroadB1.Location = new System.Drawing.Point(4, 126);
            this.crossroadB1.Name = "crossroadB1";
            this.crossroadB1.NoOfTrafficLights = 0;
            this.crossroadB1.North = null;
            this.crossroadB1.Size = new System.Drawing.Size(107, 101);
            this.crossroadB1.South = null;
            this.crossroadB1.TabIndex = 3;
            this.crossroadB1.Text = "crossroadB1";
            this.crossroadB1.West = null;
            this.crossroadB1.DragOver += new System.Windows.Forms.DragEventHandler(this.Crossroad_DragOver);
            this.crossroadB1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.crossroadB1_MouseDown);
            this.crossroadB1.MouseEnter += new System.EventHandler(this.btnCrossroad2_MouseEnter);
            this.crossroadB1.MouseLeave += new System.EventHandler(this.btnCrossroad2_MouseLeave);
            // 
            // crossroadA1
            // 
            this.crossroadA1.BackgroundImage = global::TrafficSimulation.Properties.Resources.Crossroad1bw;
            this.crossroadA1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.crossroadA1.Directions = null;
            this.crossroadA1.East = null;
            this.crossroadA1.Location = new System.Drawing.Point(4, 21);
            this.crossroadA1.Name = "crossroadA1";
            this.crossroadA1.NoOfPedestrians = 0;
            this.crossroadA1.NoOfTrafficLights = 0;
            this.crossroadA1.North = null;
            this.crossroadA1.Sensor = false;
            this.crossroadA1.Size = new System.Drawing.Size(107, 101);
            this.crossroadA1.South = null;
            this.crossroadA1.TabIndex = 2;
            this.crossroadA1.Text = "crossroadA22";
            this.crossroadA1.West = null;
            this.crossroadA1.DragOver += new System.Windows.Forms.DragEventHandler(this.Crossroad_DragOver);
            this.crossroadA1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.crossroadA1_MouseDown);
            this.crossroadA1.MouseEnter += new System.EventHandler(this.btnCrossroad1_MouseEnter);
            this.crossroadA1.MouseLeave += new System.EventHandler(this.btnCrossroad1_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crossroads";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.numericUpDown3);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.numericUpDown2);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.numericUpDown1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(4, 332);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(117, 228);
            this.panel4.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(75, 81);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown3.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(-1, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Timer(secs):";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(75, 54);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown2.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(-1, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Pedestrians:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(75, 28);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(-1, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cars:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Properties";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnStop);
            this.panel5.Controls.Add(this.btnStart);
            this.panel5.Location = new System.Drawing.Point(4, 566);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(117, 60);
            this.panel5.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Image = global::TrafficSimulation.Properties.Resources.stop;
            this.btnStop.Location = new System.Drawing.Point(60, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(56, 50);
            this.btnStop.TabIndex = 4;
            this.btnStop.TabStop = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            this.btnStop.MouseEnter += new System.EventHandler(this.btnStop_MouseEnter);
            this.btnStop.MouseLeave += new System.EventHandler(this.btnStop_MouseLeave);
            // 
            // btnStart
            // 
            this.btnStart.Image = global::TrafficSimulation.Properties.Resources.start;
            this.btnStart.Location = new System.Drawing.Point(4, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(56, 50);
            this.btnStart.TabIndex = 3;
            this.btnStart.TabStop = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Traffic Simulation Application";
            // 
            // graphicalOverlay1
            // 
            this.graphicalOverlay1.Paint += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.graphicalOverlay1_Paint);
            // 
            // pbCrossroadA
            // 
            this.pbCrossroadA.BackgroundImage = global::TrafficSimulation.Properties.Resources.Crossroad1bw;
            this.pbCrossroadA.Location = new System.Drawing.Point(4, 21);
            this.pbCrossroadA.Name = "pbCrossroadA";
            this.pbCrossroadA.Size = new System.Drawing.Size(107, 101);
            this.pbCrossroadA.TabIndex = 4;
            this.pbCrossroadA.TabStop = false;
            this.pbCrossroadA.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(933, 634);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossroadB)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossroadA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnOpen;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private CrossroadA crossroadA1;
        private CrossroadB crossroadB1;
        private Grid grid1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private Timer timer2;
        private CodeProject.GraphicalOverlay graphicalOverlay1;
        private PictureBox pbCrossroadB;
        private PictureBox pbCrossroadA;
    }
}
