using System.Drawing;
using System.Windows.Forms;

namespace MixManagementPlatform.Controls
{
    public partial class TipPanel : UserControl
    {
        public Image ImgInfo 
        {
            set
            {
                this.imgInfo.Image = value;
            }
        }
        public string InfoText
        {
            set
            {
                this.lblInfo.Text = value;
            }
        }
        public TipPanel()
        {
            InitializeComponent();
        }
    }
}
