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
    public partial class Seller_Recent_Job : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Seller_RecentJob_Panel[] srp = new Seller_RecentJob_Panel[50];
        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_Recent_Job()
        {
            InitializeComponent();
        }
        private void customizeSubMenu()
        {
            PanelWorkHouse.Visible = true;
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

        private void Seller_Recent_Job_Load(object sender, EventArgs e)
        {
            customizeSubMenu();

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM PROGRESS_JOB WHERE SELLER_NAME= @sname;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sname", Seller_Info.USER_NAME);
                
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    int i = 0;
                    int x = 0, y = 0;
                    while (sda.Read())
                    {
                        

                        String sname = "";
                        String acctime = "";
                        String endtime = "";

                        byte[] image;
                        String bname;
                        String bprice;
                        String btime;
                        String bpost;
                        String stat;
                        bpost = (sda["JOB_ID"].ToString());

                        sname = (sda["SELLER_NAME"].ToString());
                        String bname1= (sda["BUYER_NAME"].ToString());
                        acctime = (sda["SELLER_ACCEPT_TIME"].ToString());
                        endtime = (sda["JOB_ENDING_TIME"].ToString());
                        //String bhour = (sda["JOB_DETAILS"].ToString());
                        //String bminute = (sda["JOB_DETAILS"].ToString());
                        //String bsecond = (sda["JOB_DETAILS"].ToString());
                        //String bpayment = (sda["JOB_PRICE"].ToString());
                        //String btime = (sda["JOB_TIME"].ToString());

                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM JOB_INFO WHERE JOB_ID= @id AND JOB_STATUS=@jstatus;";

                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@id", bpost);
                        cmd1.Parameters.AddWithValue("@jstatus", "Progress");
                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {
                                image = ((byte[])(sda1["JOB_IMAGE"]));
                                bname = (sda1["JOB_NAME"].ToString());
                                 bprice = (sda1["JOB_PRICE"].ToString());
                                 btime = (sda1["JOB_TIME"].ToString());
                                 bpost = (sda1["JOB_ID"].ToString());
                                 stat = (sda1["JOB_STATUS"].ToString());

                                
                                //String bhour = (sda["JOB_DETAILS"].ToString());
                                //String bminute = (sda["JOB_DETAILS"].ToString());
                                //String bsecond = (sda["JOB_DETAILS"].ToString());
                                //String bpayment = (sda["JOB_PRICE"].ToString());
                                //String btime = (sda["JOB_TIME"].ToString());

                         srp[i] = new Seller_RecentJob_Panel(image, bname, bpost, endtime, bprice, btime, bname1);
                                SellerRecentJobPanel.Controls.Add(srp[i]);
                        //  MessageBox.Show("Mor mor mor");
                        srp[i].Location = new System.Drawing.Point(x, y);
                        srp[i].Visible = true;
                        srp[i].BringToFront();

                        srp[i].Show();
                        y += (srp[i].Height + 10);

                            }
                        }



                      
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

        private void ButtonSellerPortalJobPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Job_Directory().Show();
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

       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SellerPortalStatus_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxSelPortal_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonSellerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

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
