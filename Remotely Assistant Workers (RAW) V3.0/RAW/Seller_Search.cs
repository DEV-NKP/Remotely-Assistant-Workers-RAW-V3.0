using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace RAW
{
    public partial class Seller_Search : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        SellerSearchPanel[] bsp = new SellerSearchPanel[50];


        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();
        private void customizeSubMenu()
        {
            PanelWorkHouse.Visible = false;
        }
        private void HideSubMenu()
        {

            if (PanelWorkHouse.Visible == true)
                PanelWorkHouse.Visible = false;
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




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_Search()
        {
            InitializeComponent();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Seller_Search_Load(object sender, EventArgs e)
        {
            customizeSubMenu();



            int i = 0;
            SqlConnection con = new SqlConnection(cs);
            String query = "SELECT * FROM JOB_INFO WHERE JOB_STATUS=@jstatus;";
            SqlCommand cmd = new SqlCommand(query, con);
           
            cmd.Parameters.AddWithValue("@jstatus", "ACTIVE");
            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {
                // i = 0;
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



                                    bsp[i] = new SellerSearchPanel(image, bname, bpost, bdet, bprice, btime, apply, stat, bpic, bname1, brating);


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

                // MessageBox.Show(bjp[0].BPAYMENT);
            }


            else
            {


            }

            con.Close();

            label1.Text = i + " Job Available ";
            gunaButton3.Visible = true;
            label1.Visible = true;






            gunaButton3.Visible = false;
            label1.Visible = false;
            SellerName.Text = Seller_Info.USER_NAME;
            label3.Text = Seller_Info.RAW_POST;
            SellerPortalStatus.Text = Seller_Info.STATUS;
            LabelSellerPortalName.Text = "Welcome " + Seller_Info.LAST_NAME + ", " + Seller_Info.FIRST_NAME;
            PictureBoxSellermain.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            PictureBoxSellerPortal.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ButtonSellerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Profile().Show();
        }

        private void ButtonSellerPortalJobPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Job_Directory().Show();
        }

        private void ButtonSellerPortalRecJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Recent_Job().Show();
        }

        private void ButtonSellerPortalSubob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Submitted_Job().Show();
        }

        private void ButtonSellerPortalPreJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Previous_Job().Show();
        }

        private void ButtonSellerPortalCanJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Cancel_Job().Show();
        }

        private void ButtonSellerPortalAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_account().Show();
        }

        private void ButtonSellerPortalChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Messenger().Show();
        }

      

        private void ButtonSellerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

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


        private void gunaButton4_Click(object sender, EventArgs e)
        {
            SearchScrollPanel.Controls.Clear();

            int i=0;
            SqlConnection con = new SqlConnection(cs);
            String query = "SELECT * FROM JOB_INFO WHERE JOB_NAME= @jname AND JOB_STATUS=@jstatus;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@jname", gunaTextBox2.Text);
            cmd.Parameters.AddWithValue("@jstatus", "ACTIVE");
            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {
                // i = 0;
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



                                    bsp[i] = new SellerSearchPanel(image, bname, bpost, bdet, bprice, btime, apply, stat, bpic, bname1, brating);


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
              
                // MessageBox.Show(bjp[0].BPAYMENT);
            }


            else
            {


            }

            con.Close();
            
            label1.Text = i + " Job Found ";
                gunaButton3.Visible = true;
                label1.Visible = true;
        }

        private void PictureBoxSellerPortal_Click(object sender, EventArgs e)
        {
            sup.Visible = false;
            viewp++;

            //  MessageBox.Show(Convert.ToString(viewp));
            if (viewp % 2 == 0)
            {

                this.sup.Location = new System.Drawing.Point(980, 88);
                this.Controls.Add(sup);
                sup.Visible = true;
                sup.BringToFront();
                PictureBoxSellerPortal.BringToFront();
                // bup.Show();
            }
            else
            {
                sup.Hide();
                sup.Visible = false;
                sup.SendToBack();
                this.Controls.Remove(sup);


            }
        }


        /*
        this.Hide();
        new Buyer_Search().Show();*/


    }
}
