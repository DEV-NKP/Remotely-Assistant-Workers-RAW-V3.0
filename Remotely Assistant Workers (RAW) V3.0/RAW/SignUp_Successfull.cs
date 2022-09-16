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
    public partial class SignUp_Successfull : Form
    {
        public SignUp_Successfull()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void SellerSignUp_ResetAll_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Landing_Page().Show();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LogIn().Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
