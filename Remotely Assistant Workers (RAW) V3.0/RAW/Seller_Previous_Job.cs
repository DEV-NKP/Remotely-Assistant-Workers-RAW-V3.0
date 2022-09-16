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
    public partial class Seller_Previous_Job : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Seller_PreviousJob_Panel[] spjp = new Seller_PreviousJob_Panel[50];

        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_Previous_Job()
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

        private void Seller_Previous_Job_Load(object sender, EventArgs e)
        {
            customizeSubMenu();

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SUBMITTED_JOB WHERE TRANSACTION_ID=@trans AND SELLER_NAME=@user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", Seller_Info.USER_NAME);
                cmd.Parameters.AddWithValue("@trans", "YES");
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    int i = 0;
                    int x = 0, y = 0;
                    while (sda.Read())
                    {

                        String bpost = (sda["JOB_ID"].ToString());
                        String sname = (sda["BUYER_NAME"].ToString());
                        String slink = (sda["SUBMITTED_LINK"].ToString());




                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM JOB_INFO WHERE JOB_ID= @id;";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@id", bpost);

                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {
                                byte[] image = ((byte[])(sda1["JOB_IMAGE"]));
                                String bname = (sda1["JOB_NAME"].ToString());


                                String bprice = (sda1["JOB_PRICE"].ToString());
                                String btime = (sda1["JOB_TIME"].ToString());




                                spjp[i] = new Seller_PreviousJob_Panel(image, bname, bpost, slink, bprice, btime, sname);

                                sellerpreviousJobPanel.Controls.Add(spjp[i]);
                                spjp[i].Location = new System.Drawing.Point(x, y);
                                spjp[i].Visible = true;
                                spjp[i].BringToFront();

                                spjp[i].Show();

                                y += (spjp[i].Height + 10);

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
