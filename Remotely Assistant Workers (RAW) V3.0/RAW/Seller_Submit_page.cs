using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Seller_Submit_page : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);



        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        int RATINGVALUE = 0;
        bool click = false;
       // String TotalRating = "";
      //  String RatedBy = "";
        Boolean pas = false;
        Boolean acc = false;
        Boolean click1 = false;
        Boolean click2 = false;
        Boolean click3 = false;

        Boolean click4 = false;
        Boolean click5 = false;
        public Seller_Submit_page()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Recent_Job().Show();
        }

        private void textSubmitLink_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textSubmitLink.Text))
            {
                pas = false;
                EnableButton();
            }
            else
            {
                pas = true;
                EnableButton();

            }
        }

     public void EnableButton()
        {

  if (pas && acc)
            {
                Button_subrate.Enabled = true;
                panel1.Visible = true;
            }
            else
            {
                Button_subrate.Enabled = false;
                panel1.Visible = false;
            }


        }

        private void Acceptcondition_CheckedChanged(object sender, EventArgs e)
        {
            if (Acceptcondition.Checked)
            {
                acc = true;
                EnableButton();

            }
            else {
                acc = false;
                EnableButton();

            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            String SUBTIME = new RAW_Function().dtime();

            SqlConnection con1 = new SqlConnection(cs);





            String query1 = "INSERT INTO SUBMITTED_JOB VALUES(@jid,@subtime,@trans,@sname,@bname,@slink,@cmnt);";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@jid", Job_Info.JOB_ID);
            cmd1.Parameters.AddWithValue("@subtime", SUBTIME);
            cmd1.Parameters.AddWithValue("@trans", "NO");
            cmd1.Parameters.AddWithValue("@sname", Job_Info.SELLER_NAME);
            cmd1.Parameters.AddWithValue("@bname", Job_Info.BUYER_NAME);
            cmd1.Parameters.AddWithValue("@slink", textSubmitLink.Text);
            cmd1.Parameters.AddWithValue("@cmnt", "N/A");



            con1.Open();
            int a = cmd1.ExecuteNonQuery();

            if (a > 0)
            {



                SqlConnection con2 = new SqlConnection(cs);
                String query2 = "UPDATE JOB_INFO SET  JOB_STATUS =@jstatus WHERE JOB_ID=@jid;";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@jid", Job_Info.JOB_ID);
                cmd2.Parameters.AddWithValue("@jstatus", "Submit");



                con2.Open();
                int a2 = cmd2.ExecuteNonQuery();

                if (a2 > 0)
                {

                    MessageBox.Show("Submitted !!! Wait for Buyer responses.");
                    this.Hide();
                    new Seller_Recent_Job().Show();

                }
                else
                {
                    MessageBox.Show("OOPS!! ERROR. Try again.");
                    Application.Exit();
                }
                con2.Close();





            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con1.Close();

        }

        private void Seller_Submit_page_Load(object sender, EventArgs e)
        {
            Picturebox_Img_Job.Image = GetPhoto(Job_Info.JOB_IMAGE);
            TextBoxPaymentName.Text = Job_Info.JOB_NAME;
            TextBoxBuyerPaymentPrice.Text = Job_Info.JOB_PRICE;
            TextBoxBuyerPaymentSkills.Text = Job_Info.JOB_SKILLS;
            TextBoxBuyerPostJobDescription.Text = Job_Info.JOB_DETAILS;
            jobIDLabel.Text = Job_Info.JOB_ID;
            TextBoxBuyerPaymentrDuration.Text = Job_Info.JOB_TIME;
            textBoxPaymentbuyerName.Text = Job_Info.BUYER_NAME;
            TextBoxPaymentsellername.Text = Job_Info.SELLER_NAME;
           

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        public void checkClick()
        {
            if (click1)
            { 
             rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.unfill1_star;
                rate3.Image = Properties.Resources.unfill1_star;
                rate4.Image = Properties.Resources.unfill1_star;
                rate5.Image = Properties.Resources.unfill1_star;
            }
            if (click2)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.unfill1_star;
                rate4.Image = Properties.Resources.unfill1_star;
                rate5.Image = Properties.Resources.unfill1_star;
            }
            if (click3)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.yello_star;
                rate4.Image = Properties.Resources.unfill1_star;
                rate5.Image = Properties.Resources.unfill1_star;
            }

            if (click4)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.yello_star;
                rate4.Image = Properties.Resources.yello_star;
                rate5.Image = Properties.Resources.unfill1_star;
            }

            if (click5)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.yello_star;
                rate4.Image = Properties.Resources.yello_star;
                rate5.Image = Properties.Resources.yello_star;
            }


        }





        private void rate1_Click(object sender, EventArgs e)
        {
            click = true;
            EnableButton();
            RATINGVALUE = 1;
            click1 = true;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            checkClick();
            LabelRating.Text = "1.0 out of 5.0";
        }

        private void rate1_MouseEnter(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.yello_star;
            }
        }

        private void rate2_MouseEnter(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
            }
        }

        private void rate3_MouseEnter(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.yello_star;

            }
        }

            private void rate4_MouseEnter(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.yello_star;
                rate4.Image = Properties.Resources.yello_star;

            }
        }

        private void rate5_MouseEnter(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.yello_star;
                rate2.Image = Properties.Resources.yello_star;
                rate3.Image = Properties.Resources.yello_star;
                rate4.Image = Properties.Resources.yello_star;
                rate5.Image = Properties.Resources.yello_star;
            }
        }

        private void rate1_MouseLeave(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.unfill1_star;
            }
        }

        private void rate2_MouseLeave(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.unfill1_star;
                rate2.Image = Properties.Resources.unfill1_star;
            }
        }

        private void rate3_MouseLeave(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.unfill1_star;
                rate2.Image = Properties.Resources.unfill1_star;
                rate3.Image = Properties.Resources.unfill1_star;
            }
        }

        private void rate4_MouseLeave(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.unfill1_star;
                rate2.Image = Properties.Resources.unfill1_star;
                rate3.Image = Properties.Resources.unfill1_star;
                rate4.Image = Properties.Resources.unfill1_star;

            }
        }

        private void rate5_MouseLeave(object sender, EventArgs e)
        {
            if (!click)
            {
                rate1.Image = Properties.Resources.unfill1_star;
                rate2.Image = Properties.Resources.unfill1_star;
                rate3.Image = Properties.Resources.unfill1_star;
                rate4.Image = Properties.Resources.unfill1_star;
                rate5.Image = Properties.Resources.unfill1_star;
            }
        }

        private void rate2_Click(object sender, EventArgs e)
        {
            click = true;
            EnableButton();
            RATINGVALUE = 2;

            click1 = false;
            click2 = true;
            click3 = false;
            click4 = false;
            click5 = false;
            checkClick();
            LabelRating.Text = "2.0 out of 5.0";
        }

        private void rate3_Click(object sender, EventArgs e)
        {
            click = true;
            EnableButton();
            RATINGVALUE = 3;

            click1 = false;
            click2 = false;
            click3 = true;
            click4 = false;
            click5 = false;
            checkClick();
            LabelRating.Text = "3.0 out of 5.0";

        }

        private void rate4_Click(object sender, EventArgs e)
        {
            click = true;
            EnableButton();
            RATINGVALUE = 4;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = true;
            click5 = false;
            checkClick();
            LabelRating.Text = "4.0 out of 5.0";

        }

        private void rate5_Click(object sender, EventArgs e)
        {
            click = true;
            EnableButton();
            RATINGVALUE = 5;

            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = true;
            checkClick();
            LabelRating.Text = "5.0 out of 5.0";

        }

        private void Button_subrate_Click(object sender, EventArgs e)
        {


            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_TOTAL_RATING WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", Job_Info.BUYER_NAME);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {
                        /* USERNAME = (sda["USER_NAME"].ToString());
                         PASSWORD = (sda["PASSWORD"].ToString());
                         EMAIL = (sda["EMAIL"].ToString());*/

                        String TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                        String TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());

                        /*  
                          string[] afterSplit = label11.Text.Split(' ');

                          MessageBox.Show(afterSplit[0]);*/
                        double ratednumber = Convert.ToDouble(TOTAL_RATED_NUMBER) + 1;
                        double sumrate = (Convert.ToDouble(RATINGVALUE) + Convert.ToDouble(TOTAL_RATING));

                        double totalrating = (sumrate / ratednumber);
                        // MessageBox.Show(afterSplit[0]);





                        SqlConnection con2 = new SqlConnection(cs);
                        String query2 = "UPDATE BUYER_TOTAL_RATING SET  CURRENT_RATING =@cr,  TOTAL_RATED_BY =@trb WHERE USER_NAME=@user;";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@cr", totalrating);
                        cmd2.Parameters.AddWithValue("@trb", Convert.ToString(ratednumber));
                        cmd2.Parameters.AddWithValue("@user", Job_Info.BUYER_NAME);


                        con2.Open();
                        int a2 = cmd2.ExecuteNonQuery();

                        if (a2 > 0)
                        {
                            ButtonSubmit.Visible = true;
                            ButtonSubmit.Enabled = true;
                            Button_subrate.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("OOPS!! ERROR. Try again.");
                            Application.Exit();
                        }
                        con2.Close();

                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }



        }

        private void gunaPictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        /*
private void rate1_MouseClick(object sender, MouseEventArgs e)
{
click = true;
RATINGVALUE = 1;

rate1.Image = Properties.Resources.yello_star;
LabelRating.Text = "1.0 out of 5.0";
}

private void rate2_MouseClick(object sender, MouseEventArgs e)
{
click = true;
RATINGVALUE = 2;

rate1.Image = Properties.Resources.yello_star;
rate2.Image = Properties.Resources.yello_star;
LabelRating.Text = "2.0 out of 5.0";
}

private void rate3_MouseClick(object sender, MouseEventArgs e)
{
click = true;
RATINGVALUE = 3;

rate1.Image = Properties.Resources.yello_star;
rate2.Image = Properties.Resources.yello_star;
rate3.Image = Properties.Resources.yello_star;
LabelRating.Text = "3.0 out of 5.0";
}

private void rate4_MouseClick(object sender, MouseEventArgs e)
{
click = true;
RATINGVALUE = 4;
rate1.Image = Properties.Resources.yello_star;
rate2.Image = Properties.Resources.yello_star;
rate3.Image = Properties.Resources.yello_star;
rate4.Image = Properties.Resources.yello_star;
LabelRating.Text = "4.0 out of 5.0";
}

private void rate5_MouseClick(object sender, MouseEventArgs e)
{
click = true;
RATINGVALUE = 5;

rate1.Image = Properties.Resources.yello_star;
rate2.Image = Properties.Resources.yello_star;
rate3.Image = Properties.Resources.yello_star;
rate4.Image = Properties.Resources.yello_star;
rate5.Image = Properties.Resources.yello_star;
LabelRating.Text = "5.0 out of 5.0";
}*/
    }
}
