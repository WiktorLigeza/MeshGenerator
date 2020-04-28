using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoMeshGUI
{
    public partial class CustomDialogBox : Form
    {
        public string fileName;
        public CustomDialogBox( string txt, string btn)
        {
            InitializeComponent();
            msg.Text = txt;
            OKbutton.Text = btn;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            fileName = textBoxX.Text;
        }
    }
}
