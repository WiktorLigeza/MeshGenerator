namespace GeoMeshGUI
{
    partial class CustomDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDialogBox));
            this.OKbutton = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.msg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKbutton
            // 
            this.OKbutton.BackColor = System.Drawing.Color.Fuchsia;
            this.OKbutton.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OKbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OKbutton.ForeColor = System.Drawing.Color.Blue;
            this.OKbutton.Location = new System.Drawing.Point(32, 69);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(145, 44);
            this.OKbutton.TabIndex = 15;
            this.OKbutton.Text = "S A V E ";
            this.OKbutton.UseVisualStyleBackColor = false;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.BackColor = System.Drawing.Color.Blue;
            this.textBoxX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxX.ForeColor = System.Drawing.Color.Fuchsia;
            this.textBoxX.Location = new System.Drawing.Point(12, 37);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(193, 26);
            this.textBoxX.TabIndex = 19;
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.BackColor = System.Drawing.Color.Blue;
            this.msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.msg.ForeColor = System.Drawing.Color.Fuchsia;
            this.msg.Location = new System.Drawing.Point(55, 9);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(103, 25);
            this.msg.TabIndex = 20;
            this.msg.Text = "SAVE-AS";
            // 
            // CustomDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(216, 122);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.OKbutton);
            this.Name = "CustomDialogBox";
            this.Text = "CustomDialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label msg;
    }
}