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
    public partial class msg_right : UserControl
    {
        public msg_right()
        {
            InitializeComponent();
        }
 public msg_right(String msg, Image images)
        {
            InitializeComponent();
            msgl.Text = msg;
            image.Image = images;
        }
        private void msg_right_Load(object sender, EventArgs e)
        {
            msg.MaximumSize = new System.Drawing.Size(160, 5000);
        }

        private void image_Click(object sender, EventArgs e)
        {

        }

        private void msg_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
