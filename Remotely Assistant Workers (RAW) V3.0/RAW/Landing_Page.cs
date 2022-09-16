using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Landing_Page : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        public Landing_Page()
        {
            InitializeComponent();
            this.label1.Location = new System.Drawing.Point(175, 34);
            label1.Parent = gunaPictureBox4;
           
            label1.BackColor = Color.Transparent;
            label1.BringToFront();

            TotalUserLabel.Parent = gunaPictureBox4;
            this.TotalUserLabel.Location = new System.Drawing.Point(220, 62);
            TotalUserLabel.BackColor = Color.Transparent;
            TotalUserLabel.BringToFront();


            

        label2.Parent = gunaPictureBox3;
            this.label2.Location = new System.Drawing.Point(80, 40);
            label2.BackColor = Color.Transparent;
            label2.BringToFront();

          TotalBuyerLabel.Parent = gunaPictureBox3;
            this.TotalBuyerLabel.Location = new System.Drawing.Point(92, 16);
            TotalBuyerLabel.BackColor = Color.Transparent;
            TotalBuyerLabel.BringToFront();



            label5.Parent = gunaPictureBox3;
            this.label5.Location = new System.Drawing.Point(320, 40);
            label5.BackColor = Color.Transparent;
            label5.BringToFront();

          TotalSellerLabel.Parent = gunaPictureBox3;
            this.TotalSellerLabel.Location = new System.Drawing.Point(332, 16);
            TotalSellerLabel.BackColor = Color.Transparent;
            TotalSellerLabel.BringToFront();



            gunaLinePanel2.Parent = gunaPictureBox3;
            this.gunaLinePanel2.Location = new System.Drawing.Point(225, 10);
           // gunaLinePanel2.BackColor = Color.Transparent;
            gunaLinePanel2.BringToFront();



            TotalBuyerLabel.Text = Convert.ToString(countBuyer());

            TotalSellerLabel.Text = Convert.ToString(countSeller());

            TotalUserLabel.Text = Convert.ToString((countSeller()+countBuyer()));
        }



        public int countBuyer()
        {
            int count = 0;
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS;";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {

                        count++;


                    }
                    return count;
                }

                else
                {
                  /*  MessageBox.Show("OOPS!!! Sorry. An error occured3. Please try again.");
                    Application.Exit();*/
                    return count;
                }

               // con.Close();
            }


        }

        public int countSeller()
        {
            int count = 0;
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS;";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {

                        count++;


                    }
                    return count;
                }

                else
                {
                  /*  MessageBox.Show("OOPS!!! Sorry. An error occured3. Please try again.");
                    Application.Exit();*/
                    return count;
                }

               // con.Close();
            }


        }







        private void FACEBOOK_PANEL_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void INSTAGRAM_PANEL_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void LINKEDINE_PANEL_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void TWITTER_PANEL_Paint(object sender, PaintEventArgs e)
        {
           
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void FACEBOOK_PANEL_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void INSTAGRAM_PANEL_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void LINKEDINE_PANEL_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/home/?originalSubdomain=bd");
        }

        private void TWITTER_PANEL_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/?lang=en");
        }

        private void HOME_BUTTON_Click(object sender, EventArgs e)
        {
            //new Landing_Page().Show();
         /*   new About().Hide();
            new Contact().Hide();
            new Repost_User().Hide();
            new FeedBack().Hide();
           
            */
            
            HOME_BUTTON.BorderColor = Color.FromArgb(53, 188, 191);
        }

        private void ABOUT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
            new About().Show();
           
        }

        private void CONTACT_BUTTON_Click(object sender, EventArgs e)
        {

            this.Hide();
            new Contact().Show();
        }

        private void FEEDBACK_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FeedBack().Show();
        }

        private void REPORT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Repost_User().Show();
        }

        private void ButtonLandingLog_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LogIn().Show();
        }

        private void ButtonLandingSign_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp_Menu().Show();
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EXIT_BUTTON_Click(object sender, EventArgs e)
        {
            DialogResult yesno =  MessageBox.Show("Do you really want to quit?", "Information", MessageBoxButtons.OKCancel);
            if(yesno == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {

        }

        int upx = 112;
        int upy = -20;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (upy >= 52)
            {
                timer1.Stop();
                timer2.Start();
            }
             else
                { 
            
             this.gunaPictureBox4.Location = new System.Drawing.Point(upx, upy);
          //  upx++;
            upy+=1;
            }
          

        }

        int dox = 112;
        int doy = 755;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (doy <= 661)
            {
                timer2.Stop();
                //timer2.Start();
            }
            else
            {

                this.gunaPictureBox3.Location = new System.Drawing.Point(dox, doy);
                //  upx++;
                doy -= 1;
            }
        }

        private void Landing_Page_Load(object sender, EventArgs e)
        {
            this.gunaPictureBox3.Location = new System.Drawing.Point(dox, doy);
            timer1.Start();
           // timer2.Start();
        }
    }
}
