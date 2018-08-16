using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MixManagementPlatform.Layouts
{
    public partial class Universaldisplay : UserControl
    {
        private string path;
      //  private bool hasConfigFile; //是否存在对应的配置文件

        public Universaldisplay(string path)
        {
            InitializeComponent();
            Size = new Size(385, 220);
            this.path = path;
            if (path != null && !string.IsNullOrWhiteSpace(path))
            {
                InitData();
            }
        }

        private void InitData()
        {
            try
            {
              
            }
            catch(Exception e)
            {
             
            }
        }

        public bool SaveData()
        {
            try
            {
               
                return true;
            }
            catch
            {
                return false;
            }
        }

    

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                base.OnPaintBackground(e);
            }
            catch
            {
                e.Graphics.FillRectangle(Brushes.Transparent, ClientRectangle);
            }
        }

    }
}
