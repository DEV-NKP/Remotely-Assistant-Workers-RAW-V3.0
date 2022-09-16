using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class msg_left : UserControl
    {
        public msg_left()
        {
            InitializeComponent();
        }
        public msg_left(String msg, Image images)
        {
            InitializeComponent();
            msgl.Text = msg;
            image.Image = images;
        }
        private void msg_left_Load(object sender, EventArgs e)
        {
          //  msg.MaximumSize = new System.Drawing.Size(160, 0);
        }
    }
}
