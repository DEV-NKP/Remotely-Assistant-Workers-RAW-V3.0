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
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace RAW
{



    public partial class Buyer_Search : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        BuyerSearch_Panel[] bsp = new BuyerSearch_Panel[50];

        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
    private extern static void ReleaseCapture();
    [DllImport("user32.DLL", EntryPoint = "SendMessage")]
    private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void customizeSubMenu()
        {
            JobPanel.Visible = false;
            workPanel.Visible = false;
        }
        private void HideSubMenu()
        {
            if (JobPanel.Visible == true)
                JobPanel.Visible = false;
            if (workPanel.Visible == true)
                workPanel.Visible = false;
        }
        private void ShowSubMenu(Panel submenu)
        {
            if (submenu.Visible == true)
            {
                submenu.Visible = false;
            }
            else
            {
                HideSubMenu();
                submenu.Visible = true;
            }
        }
        public Buyer_Search()
        {
            InitializeComponent();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Buyer_Search_Load(object sender, EventArgs e)
        {
            customizeSubMenu();
            gunaButton5.Visible = false;
            label2.Visible = false;



            int i = 0;
            {

                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM JOB_INFO WHERE JOB_STATUS=@jstatus;";
                SqlCommand cmd = new SqlCommand(query, con);
               
                cmd.Parameters.AddWithValue("@jstatus", "ACTIVE");
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    i = 0;
                    int x = 0, y = 0;
                    while (sda.Read())
                    {

                        byte[] image = ((byte[])(sda["JOB_IMAGE"]));
                        String bname = (sda["JOB_NAME"].ToString());
                        String bpost = (sda["JOB_ID"].ToString());
                        String bdet = (sda["JOB_DETAILS"].ToString());
                        String bprice = (sda["JOB_PRICE"].ToString());
                        String btime = (sda["JOB_TIME"].ToString());
                        String stat = (sda["JOB_STATUS"].ToString());
                        String bname1 = (sda["BUYER_NAME"].ToString());
                        String apply = Convert.ToString(FindApply(bpost));
                        String brating = "";




                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM BUYER_TOTAL_RATING WHERE USER_NAME= @user;";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@user", bname1);

                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {


                                brating = (sda1["CURRENT_RATING"].ToString()) + " (" + (sda1["TOTAL_RATED_BY"].ToString()) + ")";



                                SqlConnection con2 = new SqlConnection(cs);
                                String query2 = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                                SqlCommand cmd2 = new SqlCommand(query2, con2);
                                cmd2.Parameters.AddWithValue("@user", bname1);

                                con2.Open();
                                SqlDataReader sda2 = cmd2.ExecuteReader();
                                if (sda2.HasRows == true)
                                {

                                    while (sda2.Read())
                                    {

                                        byte[] bpic = ((byte[])(sda2["PROFILE_PICTURE"]));



                                        bsp[i] = new BuyerSearch_Panel(image, bname, bpost, bdet, bprice, btime, apply, stat, bpic, bname1, brating);


                                        //  MessageBox.Show(bname);


                                        SearchScrollPanel.Controls.Add(bsp[i]);
                                        bsp[i].Location = new System.Drawing.Point(x, y);
                                        bsp[i].Visible = true;
                                        bsp[i].BringToFront();

                                        bsp[i].Show();

                                        y += (bsp[i].Height + 10);
                                    }
                                    // MessageBox.Show(bjp[0].BPAYMENT);
                                }


                                else
                                {


                                }

                                con2.Close();
                                //job.Add(bjp[0]);

                                /*  TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                                  TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());*/
                            }
                            // MessageBox.Show(bjp[0].BPAYMENT);
                        }


                        else
                        {


                        }

                        con1.Close();








                        i++;
                        //job.Add(bjp[0]);

                        /*  TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                          TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());*/
                    }
                    ////////////////

                    // MessageBox.Show(bjp[0].BPAYMENT);
                }


                else
                {


                }

                con.Close();
            }

            label2.Text = i + " Job Available ";
            gunaButton5.Visible = true;
            label2.Visible = true;


            LabelBuyerName.Text = Buyer_Info.USER_NAME;
            label1.Text = Buyer_Info.RAW_POST;
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            PictureBoxBuyermain.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);

        }



        public int FindApply(String id)
        {
            int i1 = 0;

            SqlConnection con = new SqlConnection(cs);
            String query = "SELECT * FROM APPLY_JOB WHERE JOB_ID= @id;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {


                while (sda.Read())
                {


                    i1++;

                }

            }


            else
            {
                i1 = 0;

            }

            con.Close();

            return i1;

        }

        private void ButtonBuyerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }


        private void ButtonBuyerPortalPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Post_Job().Show();

        }

        private void ButtonBuyerManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();

        }

        private void ButtonBuyerRecent_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Recent_Job().Show();

        }

        private void ButtonBuyerSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();

        }

        private void ButtonBuyerPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Previous_Job().Show();

        }

        private void ButtonBuyerCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Cancel_Job().Show();

        }

        private void ButtonBuyerAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Account().Show();

        }

        private void ButtonBuyerMessenger_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Messenger().Show();

        }

       
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelJobPost_Click(object sender, EventArgs e)
        {
            ShowSubMenu(JobPanel);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelWorkHouse_Click(object sender, EventArgs e)
        {
            ShowSubMenu(workPanel);

        }

        private void PictureBoxBuyerPortal_Click(object sender, EventArgs e)
        {
            // this.Controls.Add(bup);
            bup.Visible = false;
            viewp++;

            //  MessageBox.Show(Convert.ToString(viewp));
            if (viewp % 2 == 0)
            {

                this.bup.Location = new System.Drawing.Point(980, 88);
                this.Controls.Add(bup);
                bup.Visible = true;
                bup.BringToFront();
                PictureBoxBuyerPortal.BringToFront();
                // bup.Show();
            }
            else
            {
                bup.Hide();
                bup.Visible = false;
                bup.SendToBack();
                this.Controls.Remove(bup);


            }
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            SearchScrollPanel.Controls.Clear();
            int i=0; 
            {
             
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM JOB_INFO WHERE JOB_NAME= @jname AND JOB_STATUS=@jstatus;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@jname", gunaTextBox2.Text);
                cmd.Parameters.AddWithValue("@jstatus", "ACTIVE");
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    i = 0;
                    int x = 0, y = 0;
                    while (sda.Read())
                    {

                        byte[] image = ((byte[])(sda["JOB_IMAGE"]));
                        String bname = (sda["JOB_NAME"].ToString());
                        String bpost = (sda["JOB_ID"].ToString());
                        String bdet = (sda["JOB_DETAILS"].ToString());
                        String bprice = (sda["JOB_PRICE"].ToString());
                        String btime = (sda["JOB_TIME"].ToString());
                        String stat = (sda["JOB_STATUS"].ToString());
                        String bname1 = (sda["BUYER_NAME"].ToString());
                        String apply = Convert.ToString(FindApply(bpost));
                        String brating = "";




                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM BUYER_TOTAL_RATING WHERE USER_NAME= @user;";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@user", bname1);

                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {


                                brating = (sda1["CURRENT_RATING"].ToString()) + " (" + (sda1["TOTAL_RATED_BY"].ToString()) + ")";



                                SqlConnection con2 = new SqlConnection(cs);
                                String query2 = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                                SqlCommand cmd2 = new SqlCommand(query2, con2);
                                cmd2.Parameters.AddWithValue("@user", bname1);

                                con2.Open();
                                SqlDataReader sda2 = cmd2.ExecuteReader();
                                if (sda2.HasRows == true)
                                {

                                    while (sda2.Read())
                                    {

                                        byte[] bpic = ((byte[])(sda2["PROFILE_PICTURE"]));



                                        bsp[i] = new BuyerSearch_Panel(image, bname, bpost, bdet, bprice, btime, apply, stat, bpic, bname1, brating);


                                        //  MessageBox.Show(bname);

                                       
                                       SearchScrollPanel.Controls.Add(bsp[i]);
                                        bsp[i].Location = new System.Drawing.Point(x, y);
                                        bsp[i].Visible = true;
                                        bsp[i].BringToFront();

                                        bsp[i].Show();

                                        y += (bsp[i].Height + 10);
                                    }
                                    // MessageBox.Show(bjp[0].BPAYMENT);
                                }


                                else
                                {


                                }

                                con2.Close();
                                //job.Add(bjp[0]);

                                /*  TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                                  TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());*/
                            }
                            // MessageBox.Show(bjp[0].BPAYMENT);
                        }


                        else
                        {


                        }

                        con1.Close();








                        i++;
                        //job.Add(bjp[0]);

                        /*  TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                          TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());*/
                    }
                    ////////////////
                   
                    // MessageBox.Show(bjp[0].BPAYMENT);
                }


                else
                {


                }

                con.Close();
            }

 label2.Text = i + " Job Found ";
                    gunaButton5.Visible = true;
                    label2.Visible = true;
            /*
            this.Hide();
            new Buyer_Search().Show();*/


        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
