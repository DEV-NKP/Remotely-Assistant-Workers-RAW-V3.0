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
    public partial class Seller_Job_Directory : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Seller_JobDirectory_Panel[] sjdp = new Seller_JobDirectory_Panel[50];

        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_Job_Directory()
        {
            InitializeComponent();
        }

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
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Seller_Job_Directory_Load(object sender, EventArgs e)
        {
            customizeSubMenu();
            SellerName.Text = Seller_Info.USER_NAME;
            label3.Text = Seller_Info.RAW_POST;
            SellerPortalStatus.Text = Seller_Info.STATUS;
            LabelSellerPortalName.Text = "Welcome " + Seller_Info.LAST_NAME + ", " + Seller_Info.FIRST_NAME;
            PictureBoxSellermain.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            PictureBoxSellerPortal.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);



            {


  SqlConnection con4 = new SqlConnection(cs);
                String query4 = "SELECT * FROM APPLY_JOB WHERE SELLER_NAME=@sname;";
                SqlCommand cmd4 = new SqlCommand(query4, con4);
                cmd4.Parameters.AddWithValue("@sname", Seller_Info.USER_NAME);
               
                con4.Open();
                SqlDataReader sda4 = cmd4.ExecuteReader();
                if (sda4.HasRows == true)
                {
                    int i = 0;
                    int x = 0, y = 0;
                    while (sda4.Read())
                    {

                        String jobid = (sda4["JOB_ID"].ToString());

                        SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM JOB_INFO WHERE JOB_ID= @jname;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@jname", jobid);
               
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    
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



                                        sjdp[i] = new Seller_JobDirectory_Panel(image, bname, bpost, bdet, bprice, btime, apply, stat, bpic, bname1, brating);


                                        //  MessageBox.Show(bname);


                                        sellerjobDirectoryPanel.Controls.Add(sjdp[i]);
                                        sjdp[i].Location = new System.Drawing.Point(x, y);
                                        sjdp[i].Visible = true;
                                        sjdp[i].BringToFront();

                                        sjdp[i].Show();

                                        y += (sjdp[i].Height + 10);
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

                    }
                    // MessageBox.Show(bjp[0].BPAYMENT);
                }


                else
                {


                }

                con4.Close();
            }



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

        private void ButtonSellerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);





        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonSellerPortalJobPost_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSellerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Profile().Show();
        }

        private void ButtonSellerPortalSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Search().Show();
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

      

        private void PictureBoxSelPortal_Click(object sender, EventArgs e)
        {
            
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
    }
}
