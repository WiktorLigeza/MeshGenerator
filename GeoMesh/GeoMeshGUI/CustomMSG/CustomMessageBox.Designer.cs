namespace GeoMeshGUI
{
    partial class CustomMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
            this.msg = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.BackColor = System.Drawing.Color.Blue;
            this.msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.msg.ForeColor = System.Drawing.Color.Fuchsia;
            this.msg.Location = new System.Drawing.Point(27, 27);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(84, 25);
            this.msg.TabIndex = 13;
            this.msg.Text = "T E X T";
            // 
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.Color.Fuchsia;
            this.OKbutton.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OKbutton.ForeColor = System.Drawing.Color.Blue;
            this.OKbutton.Location = new System.Drawing.Point(389, 96);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(68, 44);
            this.OKbutton.TabIndex = 14;
            this.OKbutton.Text = "O K";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(482, 141);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.msg);
            this.Name = "CustomMessageBox";
            this.Text = "CustomMessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Button OKbutton;
    }
}