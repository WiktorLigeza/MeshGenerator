namespace GeoMeshGUI
{
    partial class Cockpit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cockpit));
            this.tmrMoving = new System.Windows.Forms.Timer(this.components);
            this.graph = new System.Windows.Forms.Panel();
            this.labelAxis = new System.Windows.Forms.Label();
            this.TRIANGULARbutton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.RHOMBULARbutton = new System.Windows.Forms.RadioButton();
            this.TRAPEZOIDALbutton = new System.Windows.Forms.RadioButton();
            this.QUADRANGULRbutton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SAVEbutton = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OPENbutton = new System.Windows.Forms.Button();
            this.QTbutton = new System.Windows.Forms.RadioButton();
            this.RAYCASTINGutton = new System.Windows.Forms.RadioButton();
            this.QTTbutton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tmrMoving
            // 
            this.tmrMoving.Enabled = true;
            this.tmrMoving.Interval = 1;
            this.tmrMoving.Tick += new System.EventHandler(this.tmrMoving_Tick);
            // 
            // graph
            // 
            this.graph.BackColor = System.Drawing.Color.BlueViolet;
            this.graph.ForeColor = System.Drawing.Color.Black;
            this.graph.Location = new System.Drawing.Point(366, 166);
            this.graph.Margin = new System.Windows.Forms.Padding(2);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(567, 376);
            this.graph.TabIndex = 8;
            this.graph.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_Paint);
            this.graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graph_MouseMove);
            // 
            // labelAxis
            // 
            this.labelAxis.AutoSize = true;
            this.labelAxis.BackColor = System.Drawing.Color.Transparent;
            this.labelAxis.ForeColor = System.Drawing.Color.Blue;
            this.labelAxis.Location = new System.Drawing.Point(363, 544);
            this.labelAxis.Name = "labelAxis";
            this.labelAxis.Size = new System.Drawing.Size(25, 13);
            this.labelAxis.TabIndex = 9;
            this.labelAxis.Text = "axis";
            // 
            // TRIANGULARbutton
            // 
            this.TRIANGULARbutton.AutoSize = true;
            this.TRIANGULARbutton.BackColor = System.Drawing.Color.Transparent;
            this.TRIANGULARbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.TRIANGULARbutton.Location = new System.Drawing.Point(938, 190);
            this.TRIANGULARbutton.Name = "TRIANGULARbutton";
            this.TRIANGULARbutton.Size = new System.Drawing.Size(122, 17);
            this.TRIANGULARbutton.TabIndex = 10;
            this.TRIANGULARbutton.Text = "T R I A N G U L A R";
            this.TRIANGULARbutton.UseVisualStyleBackColor = false;
            this.TRIANGULARbutton.Click += new System.EventHandler(this.TRIANGULARbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Fuchsia;
            this.label1.Location = new System.Drawing.Point(939, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "- - - - - - - - - M E S H - - - - - - - -";
            // 
            // RHOMBULARbutton
            // 
            this.RHOMBULARbutton.AutoSize = true;
            this.RHOMBULARbutton.BackColor = System.Drawing.Color.Transparent;
            this.RHOMBULARbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.RHOMBULARbutton.Location = new System.Drawing.Point(935, 312);
            this.RHOMBULARbutton.Name = "RHOMBULARbutton";
            this.RHOMBULARbutton.Size = new System.Drawing.Size(80, 17);
            this.RHOMBULARbutton.TabIndex = 13;
            this.RHOMBULARbutton.Text = "R H O M B ";
            this.RHOMBULARbutton.UseVisualStyleBackColor = false;
            this.RHOMBULARbutton.Click += new System.EventHandler(this.RHOMBULARbutton_Click);
            // 
            // TRAPEZOIDALbutton
            // 
            this.TRAPEZOIDALbutton.AutoSize = true;
            this.TRAPEZOIDALbutton.BackColor = System.Drawing.Color.Transparent;
            this.TRAPEZOIDALbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.TRAPEZOIDALbutton.Location = new System.Drawing.Point(935, 335);
            this.TRAPEZOIDALbutton.Name = "TRAPEZOIDALbutton";
            this.TRAPEZOIDALbutton.Size = new System.Drawing.Size(83, 17);
            this.TRAPEZOIDALbutton.TabIndex = 14;
            this.TRAPEZOIDALbutton.Text = "T R A P E Z";
            this.TRAPEZOIDALbutton.UseVisualStyleBackColor = false;
            this.TRAPEZOIDALbutton.Click += new System.EventHandler(this.TRAPEZOIDALbutton_Click);
            // 
            // QUADRANGULRbutton
            // 
            this.QUADRANGULRbutton.AutoSize = true;
            this.QUADRANGULRbutton.BackColor = System.Drawing.Color.Transparent;
            this.QUADRANGULRbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.QUADRANGULRbutton.Location = new System.Drawing.Point(938, 213);
            this.QUADRANGULRbutton.Name = "QUADRANGULRbutton";
            this.QUADRANGULRbutton.Size = new System.Drawing.Size(149, 17);
            this.QUADRANGULRbutton.TabIndex = 15;
            this.QUADRANGULRbutton.Text = "Q U A D R A N G U L A R";
            this.QUADRANGULRbutton.UseVisualStyleBackColor = false;
            this.QUADRANGULRbutton.Click += new System.EventHandler(this.QUADRANGULRbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Fuchsia;
            this.label2.Location = new System.Drawing.Point(935, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "- - - - - - - - - T E S T - - - - - - - - -";
            // 
            // SAVEbutton
            // 
            this.SAVEbutton.BackColor = System.Drawing.Color.BlueViolet;
            this.SAVEbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAVEbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.SAVEbutton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SAVEbutton.Location = new System.Drawing.Point(9, 9);
            this.SAVEbutton.Margin = new System.Windows.Forms.Padding(0);
            this.SAVEbutton.Name = "SAVEbutton";
            this.SAVEbutton.Size = new System.Drawing.Size(75, 23);
            this.SAVEbutton.TabIndex = 17;
            this.SAVEbutton.Text = "S A V E ";
            this.SAVEbutton.UseVisualStyleBackColor = false;
            this.SAVEbutton.Click += new System.EventHandler(this.SAVEbutton_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBoxX.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxX.Location = new System.Drawing.Point(322, 189);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(39, 20);
            this.textBoxX.TabIndex = 18;
            // 
            // textBoxY
            // 
            this.textBoxY.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.textBoxY.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxY.Location = new System.Drawing.Point(322, 213);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(39, 20);
            this.textBoxY.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Fuchsia;
            this.label3.Location = new System.Drawing.Point(211, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "- - - - - - - N U M B E R  - - - - - -";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Fuchsia;
            this.label4.Location = new System.Drawing.Point(296, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "X :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Fuchsia;
            this.label5.Location = new System.Drawing.Point(296, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y :";
            // 
            // OPENbutton
            // 
            this.OPENbutton.BackColor = System.Drawing.Color.BlueViolet;
            this.OPENbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OPENbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.OPENbutton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.OPENbutton.Location = new System.Drawing.Point(9, 44);
            this.OPENbutton.Margin = new System.Windows.Forms.Padding(0);
            this.OPENbutton.Name = "OPENbutton";
            this.OPENbutton.Size = new System.Drawing.Size(75, 23);
            this.OPENbutton.TabIndex = 23;
            this.OPENbutton.Text = "O P E N ";
            this.OPENbutton.UseVisualStyleBackColor = false;
            this.OPENbutton.Click += new System.EventHandler(this.OPENbutton_Click);
            // 
            // QTbutton
            // 
            this.QTbutton.AutoSize = true;
            this.QTbutton.BackColor = System.Drawing.Color.Transparent;
            this.QTbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.QTbutton.Location = new System.Drawing.Point(939, 236);
            this.QTbutton.Name = "QTbutton";
            this.QTbutton.Size = new System.Drawing.Size(106, 17);
            this.QTbutton.TabIndex = 24;
            this.QTbutton.Text = "Q U A D T R E E";
            this.QTbutton.UseVisualStyleBackColor = false;
            this.QTbutton.Click += new System.EventHandler(this.QTbutton_Click);
            // 
            // RAYCASTINGutton
            // 
            this.RAYCASTINGutton.AutoSize = true;
            this.RAYCASTINGutton.BackColor = System.Drawing.Color.Transparent;
            this.RAYCASTINGutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.RAYCASTINGutton.Location = new System.Drawing.Point(935, 358);
            this.RAYCASTINGutton.Name = "RAYCASTINGutton";
            this.RAYCASTINGutton.Size = new System.Drawing.Size(121, 17);
            this.RAYCASTINGutton.TabIndex = 25;
            this.RAYCASTINGutton.Text = "R A Y C A S T I N G";
            this.RAYCASTINGutton.UseVisualStyleBackColor = false;
            this.RAYCASTINGutton.Click += new System.EventHandler(this.RAYCASTINGutton_Click_1);
            // 
            // QTTbutton
            // 
            this.QTTbutton.AutoSize = true;
            this.QTTbutton.BackColor = System.Drawing.Color.Transparent;
            this.QTTbutton.ForeColor = System.Drawing.Color.Fuchsia;
            this.QTTbutton.Location = new System.Drawing.Point(939, 257);
            this.QTTbutton.Name = "QTTbutton";
            this.QTTbutton.Size = new System.Drawing.Size(169, 17);
            this.QTTbutton.TabIndex = 26;
            this.QTTbutton.Text = "Q U A D T R E E (TRIANGLE)";
            this.QTTbutton.UseVisualStyleBackColor = false;
            this.QTTbutton.Click += new System.EventHandler(this.QTTbutton_Click);
            // 
            // Cockpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1176, 697);
            this.Controls.Add(this.QTTbutton);
            this.Controls.Add(this.RAYCASTINGutton);
            this.Controls.Add(this.QTbutton);
            this.Controls.Add(this.OPENbutton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.SAVEbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QUADRANGULRbutton);
            this.Controls.Add(this.TRAPEZOIDALbutton);
            this.Controls.Add(this.RHOMBULARbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TRIANGULARbutton);
            this.Controls.Add(this.labelAxis);
            this.Controls.Add(this.graph);
            this.DoubleBuffered = true;
            this.Name = "Cockpit";
            this.Text = "Cockpit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel graph;
        private System.Windows.Forms.Label labelAxis;
        private System.Windows.Forms.RadioButton TRIANGULARbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RHOMBULARbutton;
        private System.Windows.Forms.RadioButton TRAPEZOIDALbutton;
        private System.Windows.Forms.RadioButton QUADRANGULRbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SAVEbutton;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OPENbutton;
        private System.Windows.Forms.RadioButton QTbutton;
        private System.Windows.Forms.RadioButton RAYCASTINGutton;
        private System.Windows.Forms.RadioButton QTTbutton;
        private System.Windows.Forms.Timer tmrMoving;

    }
}