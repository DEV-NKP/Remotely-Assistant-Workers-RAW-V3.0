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
    public partial class messageUserSearch_Seller : UserControl
    {
        public messageUserSearch_Seller()
        {
            InitializeComponent();
        }

        public messageUserSearch_Seller(String unames, String fnames, Image images)
        {
            InitializeComponent();

            recName.Text = unames;
            recFName.Text = fnames;
            image.Image = images;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            messenger_create_Seller mc = new messenger_create_Seller();
            mc.setRecName(Seller_Info.USER_NAME, recName.Text);
        }
    }
}
