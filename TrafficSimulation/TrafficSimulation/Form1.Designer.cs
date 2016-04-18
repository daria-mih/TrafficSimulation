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
<<<<<<< HEAD
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
=======
            this.components = new System.ComponentModel.Container();
>>>>>>> 7fce1bc945763c9db590314bc2ed37886ffd1189
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
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
<<<<<<< HEAD
            this.crossroadB1 = new TrafficSimulation.CrossroadB();
            this.crossroadA1 = new TrafficSimulation.CrossroadA();
            this.grid1 = new TrafficSimulation.Grid();
=======
            this.timer1 = new System.Windows.Forms.Timer(this.components);
>>>>>>> 7fce1bc945763c9db590314bc2ed37886ffd1189
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 4);
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
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Location = new System.Drawing.Point(127, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 601);
            this.panel3.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::TrafficSimulation.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(773, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseClick);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.crossroadB1);
            this.panel2.Controls.Add(this.crossroadA1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(4, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(117, 234);
            this.panel2.TabIndex = 0;
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
            this.panel4.Controls.Add(this.checkBox4);
            this.panel4.Controls.Add(this.checkBox3);
            this.panel4.Controls.Add(this.checkBox2);
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.numericUpDown3);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.numericUpDown2);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.numericUpDown1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(4, 312);
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
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox4.Location = new System.Drawing.Point(21, 182);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(57, 21);
            this.checkBox4.TabIndex = 12;
            this.checkBox4.Text = "Right";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox3.Location = new System.Drawing.Point(21, 165);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 21);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Left";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Location = new System.Drawing.Point(21, 147);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(69, 21);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Bottom";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(21, 129);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 21);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Top";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(-1, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Feed lanes:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(75, 80);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown3.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(0, 83);
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
            this.panel5.Location = new System.Drawing.Point(4, 546);
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
            this.btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            // 
<<<<<<< HEAD
            // crossroadB1
            // 
            this.crossroadB1.BackgroundImage = global::TrafficSimulation.Properties.Resources.Crossroad2bw;
            this.crossroadB1.East = null;
            this.crossroadB1.Location = new System.Drawing.Point(4, 126);
            this.crossroadB1.Name = "crossroadB1";
            this.crossroadB1.NoOfCars = 0;
            this.crossroadB1.NoOfTrafficLights = 0;
            this.crossroadB1.North = null;
            this.crossroadB1.Size = new System.Drawing.Size(107, 101);
            this.crossroadB1.South = null;
            this.crossroadB1.TabIndex = 3;
            this.crossroadB1.Text = "crossroadB1";
            this.crossroadB1.West = null;
            this.crossroadB1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.crossroadB1_MouseDown);
            this.crossroadB1.MouseEnter += new System.EventHandler(this.btnCrossroad2_MouseEnter);
            this.crossroadB1.MouseLeave += new System.EventHandler(this.btnCrossroad2_MouseLeave);
            this.crossroadB1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.crossroadB1_MouseUp);
            // 
            // crossroadA1
            // 
            this.crossroadA1.BackgroundImage = global::TrafficSimulation.Properties.Resources.Crossroad1bw;
            this.crossroadA1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.crossroadA1.East = null;
            this.crossroadA1.Location = new System.Drawing.Point(4, 21);
            this.crossroadA1.Name = "crossroadA1";
            this.crossroadA1.NoOfCars = 0;
            this.crossroadA1.NoOfPedestrians = 0;
            this.crossroadA1.NoOfTrafficLights = 0;
            this.crossroadA1.North = null;
            this.crossroadA1.Sensor = false;
            this.crossroadA1.Size = new System.Drawing.Size(107, 101);
            this.crossroadA1.South = null;
            this.crossroadA1.TabIndex = 2;
            this.crossroadA1.Text = "crossroadA1";
            this.crossroadA1.West = null;
            this.crossroadA1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.crossroadA1_MouseDown);
            this.crossroadA1.MouseEnter += new System.EventHandler(this.btnCrossroad1_MouseEnter);
            this.crossroadA1.MouseLeave += new System.EventHandler(this.btnCrossroad1_MouseLeave);
            this.crossroadA1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.crossroadA1_MouseUp);
            // 
            // grid1
            // 
            this.grid1.AllowDrop = true;
            this.grid1.BackgroundImage = global::TrafficSimulation.Properties.Resources.grid;
            this.grid1.Location = new System.Drawing.Point(-1, -1);
            this.grid1.Name = "grid1";
            this.grid1.Placeholders = ((System.Collections.Generic.List<System.Drawing.Rectangle>)(resources.GetObject("grid1.Placeholders")));
            this.grid1.Size = new System.Drawing.Size(800, 602);
            this.grid1.TabIndex = 2;
            this.grid1.Text = "grid1";
            this.grid1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.grid1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
=======
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
>>>>>>> 7fce1bc945763c9db590314bc2ed37886ffd1189
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(933, 610);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpen)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnStop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
<<<<<<< HEAD
        private CrossroadA crossroadA1;
        private CrossroadB crossroadB1;
        private Grid grid1;
=======
        private System.Windows.Forms.Timer timer1;
>>>>>>> 7fce1bc945763c9db590314bc2ed37886ffd1189
    }
}

