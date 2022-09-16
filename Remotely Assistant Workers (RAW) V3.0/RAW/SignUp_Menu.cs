using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class SignUp_Menu : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        public SignUp_Menu()
        {
            InitializeComponent();
        }

        private void Buyer_SignUp_Option_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_SignUp1().Show();

        }

        private void Seller_SignUp_Option_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_SignUp1().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Landing_Page().Show();
        }

        private void SignUp_Menu_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_SignUp1().Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_SignUp1().Show();

        }

        private void gunaPictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
