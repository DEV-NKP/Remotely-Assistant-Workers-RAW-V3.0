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
    public partial class Buyer_Payment : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);




        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
     //   String TotalRating1 ="";
       // String TotalRating2 = "";
     //   String RatedBy = "";
        String SLINK = "";
        String SNAME = "";
        int RATINGVALUE = 0;
        Boolean click = false;
        Boolean click1 = false;
        Boolean click2 = false;
        Boolean click3 = false;

        Boolean click4 = false;
        Boolean click5 = false;
        public Buyer_Payment()
        {
            InitializeComponent();
        }
        public Buyer_Payment(String slink, String sname)
        {
            InitializeComponent();
            SLINK = slink;
            SNAME = sname;

        }
        private void Buyer_Payment_Load(object sender, EventArgs e)
        {
            TextBoxPaymentName.Text = Job_Info.JOB_NAME;
            TextBoxBuyerPaymentPrice.Text = Job_Info.JOB_PRICE;
            TextBoxBuyerPaymentSkills.Text = Job_Info.JOB_SKILLS;
            TextBoxBuyerPostJobDescription.Text = Job_Info.JOB_DETAILS;
            jobIDLabel.Text = Job_Info.JOB_ID;
            TextBoxBuyerPaymentrDuration.Text = Job_Info.JOB_TIME;
            textBoxPaymentbuyerName.Text = Job_Info.BUYER_NAME;
            TextBoxPaymentsellername.Text = Job_Info.SELLER_NAME;
            Paymentlink.Text = Job_Info.SUBMITTED_LINK;

            Picturebox_Img_Job.Image = GetPhoto(Job_Info.JOB_IMAGE);




        }

        private void textBoxPaymentbuyerName_TextChanged(object sender, EventArgs e)
        {

        }


        private void ButtonPayment_Click(object sender, EventArgs e)
        {
            Boolean entry = false;
            String AMOUNT = "";
    

            if (Convert.ToDouble(TextBoxBuyerPaymentPrice.Text) > Convert.ToDouble(Buyer_Info.AMOUNT))
            {
                MessageBox.Show("You have not enough money", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                AMOUNT = Convert.ToString(Convert.ToDouble(Buyer_Info.AMOUNT) - Convert.ToDouble(TextBoxBuyerPaymentPrice.Text));


                entry = true;

            }

            if (entry)
            {


                SqlConnection con1 = new SqlConnection(cs);
                string query1 = "DELETE FROM PROGRESS_JOB WHERE JOB_ID=@id";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@id", Job_Info.JOB_ID);

                con1.Open();
                int a1 = cmd1.ExecuteNonQuery();
                if (a1 > 0)
                {

                    SqlConnection con2 = new SqlConnection(cs);
                    String query2 = "UPDATE JOB_INFO SET  JOB_STATUS =@jstatus WHERE JOB_ID=@jid;";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@jid", Job_Info.JOB_ID);
                    cmd2.Parameters.AddWithValue("@jstatus", "Complete");



                    con2.Open();
                    int a2 = cmd2.ExecuteNonQuery();

                    if (a2 > 0)
                    {

                        SqlConnection con3 = new SqlConnection(cs);
                        String query3 = "UPDATE SUBMITTED_JOB SET  TRANSACTION_ID =@trans WHERE JOB_ID=@jid;";
                        SqlCommand cmd3 = new SqlCommand(query3, con3);
                        cmd3.Parameters.AddWithValue("@jid", Job_Info.JOB_ID);
                        cmd3.Parameters.AddWithValue("@trans", "YES");



                        con3.Open();
                        int a3 = cmd3.ExecuteNonQuery();

                        if (a3 > 0)
                        {

                        }
                        else
                        {
                            MessageBox.Show("OOPS!! ERROR. Try again.");
                            Application.Exit();
                        }
                        con3.Close();


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

                    MessageBox.Show("OOPS!! an Error Ocured. Please Try Again.");
                    Application.Exit();
                }
                con1.Close();




                SqlConnection con = new SqlConnection(cs);
                string query = "UPDATE ACCOUNT SET AMOUNT=@amoun where USER_NAME=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@amoun", AMOUNT);

                cmd.Parameters.AddWithValue("@id", Buyer_Info.USER_NAME);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {



                    SqlConnection con5 = new SqlConnection(cs);
                    String query5 = "SELECT * FROM ACCOUNT WHERE USER_NAME= @user;";
                    SqlCommand cmd5 = new SqlCommand(query5, con5);
                    cmd5.Parameters.AddWithValue("@user", Job_Info.SELLER_NAME);

                    con5.Open();
                    SqlDataReader sda5 = cmd5.ExecuteReader();
                    if (sda5.HasRows == true)
                    {

                        while (sda5.Read())
                        {


                            String sAMOUNT = (sda5["AMOUNT"].ToString());
                            sAMOUNT = Convert.ToString(Convert.ToDouble(sAMOUNT) + Convert.ToDouble(TextBoxBuyerPaymentPrice.Text));


                            SqlConnection con6 = new SqlConnection(cs);
                            string query6 = "UPDATE ACCOUNT SET AMOUNT=@amoun where USER_NAME=@id";
                            SqlCommand cmd6 = new SqlCommand(query6, con6);
                            cmd6.Parameters.AddWithValue("@amoun", sAMOUNT);

                            cmd6.Parameters.AddWithValue("@id", Job_Info.SELLER_NAME);
                            con6.Open();
                            int a6 = cmd6.ExecuteNonQuery();
                            if (a6 > 0)
                            {


                                DialogResult ok = MessageBox.Show("Transaction Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                                if (ok == DialogResult.OK)
                                {
                                    label3.Visible = true;
                                    Paymentlink.Visible = true;
                                    ButtonCancel.Visible = false;
                                    //  ButtonGoBack.Visible = true;
                                    //  ButtonGoBack.Enabled = true;
                                    ButtonPayment.Visible = false;
                                    panel1.Visible = true;
                                }
                                else
                                {
                                    label3.Visible = true;
                                    Paymentlink.Visible = true;
                                    ButtonCancel.Visible = false;
                                    //  ButtonGoBack.Visible = true;
                                    //  ButtonGoBack.Enabled = true;
                                    panel1.Visible = true;
                                    ButtonPayment.Visible = false;

                                }

                            }
                            else
                            {
                                MessageBox.Show("OOPS!! an Error Ocured. Please Try Again.");
                                Application.Exit();
                            }
                            con6.Close();
                        }

                    }

                    else
                    {
                        MessageBox.Show("OOPS!!! Sorry. An error occured6. Please try again.");
                        Application.Exit();

                    }

                    con5.Close();




                }
                else
                {
                    MessageBox.Show("OOPS!! an Error Ocured. Please Try Again.");
                    Application.Exit();
                }

                con.Close();






            }
        }



        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        private void Acceptcondition_CheckedChanged(object sender, EventArgs e)
        {
            if (Acceptcondition.Checked)
            {
                ButtonPayment.Enabled = true;
            }
            else {

                ButtonPayment.Enabled = false;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();
        }

        private void ButtonGoBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();
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
            RATINGVALUE = 1;
            click1 = true;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = false;
            checkClick();
            label11.Text = "1.0 out of 5.0";

        }

        private void rate2_Click(object sender, EventArgs e)
        {
            click = true;
            RATINGVALUE = 2;

            click1 = false;
            click2 = true;
            click3 = false;
            click4 = false;
            click5 = false;
            checkClick();
            label11.Text = "2.0 out of 5.0";





        }

        private void rate3_Click(object sender, EventArgs e)
        {
            click = true;
            RATINGVALUE = 3;

            click1 = false;
            click2 = false;
            click3 = true;
            click4 = false;
            click5 = false;
            checkClick();
            label11.Text = "3.0 out of 5.0";





        }

        private void rate4_Click(object sender, EventArgs e)
        {
            click = true;
            RATINGVALUE = 4;
            click1 = false;
            click2 = false;
            click3 = false;
            click4 = true;
            click5 = false;
            checkClick();
            label11.Text = "4.0 out of 5.0";





        }

      

        private void rate5_Click(object sender, EventArgs e)
        {
            click = true;
            RATINGVALUE = 5;

            click1 = false;
            click2 = false;
            click3 = false;
            click4 = false;
            click5 = true;
            checkClick();
            label11.Text = "5.0 out of 5.0";




        }

        private void Button_subrate_Click(object sender, EventArgs e)
        {

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SELLER_TOTAL_RATING WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", Job_Info.SELLER_NAME);

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
                        double ratednumber = Convert.ToDouble(TOTAL_RATED_NUMBER)+1;
                        double sumrate = (Convert.ToDouble(RATINGVALUE) + Convert.ToDouble(TOTAL_RATING));

                        double totalrating = (sumrate / ratednumber);
                       // MessageBox.Show(afterSplit[0]);
                       


                       

                        SqlConnection con2 = new SqlConnection(cs);
                        String query2 = "UPDATE SELLER_TOTAL_RATING SET  CURRENT_RATING =@cr,  TOTAL_RATED_BY =@trb WHERE USER_NAME=@user;";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@cr", totalrating);
                        cmd2.Parameters.AddWithValue("@trb", Convert.ToString(ratednumber));
                        cmd2.Parameters.AddWithValue("@user", Job_Info.SELLER_NAME);


                        con2.Open();
                        int a2 = cmd2.ExecuteNonQuery();

                        if (a2 > 0)
                        {
                            ButtonGoBack.Visible = true;
                            ButtonGoBack.Enabled = true;
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

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
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
   label11.Text = "1.0 out of 5.0";
}

private void rate2_MouseClick(object sender, MouseEventArgs e)
{
   click = true;
   RATINGVALUE = 2;

   rate1.Image = Properties.Resources.yello_star;
   rate2.Image = Properties.Resources.yello_star;
   label11.Text = "2.0 out of 5.0";
}

private void rate3_MouseClick(object sender, MouseEventArgs e)
{
   click = true;
   RATINGVALUE = 3;

   rate1.Image = Properties.Resources.yello_star;
   rate2.Image = Properties.Resources.yello_star;
   rate3.Image = Properties.Resources.yello_star;
   label11.Text = "3.0 out of 5.0";


}

private void rate4_MouseClick(object sender, MouseEventArgs e)
{
   click = true;
   RATINGVALUE = 4;
   rate1.Image = Properties.Resources.yello_star;
   rate2.Image = Properties.Resources.yello_star;
   rate3.Image = Properties.Resources.yello_star;
   rate4.Image = Properties.Resources.yello_star;
   label11.Text = "4.0 out of 5.0";


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
   label11.Text = "5.0 out of 5.0";

}*/
    }
}
