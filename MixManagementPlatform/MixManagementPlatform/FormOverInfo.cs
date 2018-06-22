using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MixManagementPlatform
{
    public partial class FormOverInfo : Form
    {
        public FormOverInfo(string infoMsg)
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.FromArgb(100, 127, 127, 127);
        }

        private void lblInfo_TextChanged(object sender, EventArgs e)
        {
            Point p = new Point((Width - lblInfo.Width) / 2, (Height - lblInfo.Height) / 2);
            lblInfo.Location = p;
        }
    }
}
