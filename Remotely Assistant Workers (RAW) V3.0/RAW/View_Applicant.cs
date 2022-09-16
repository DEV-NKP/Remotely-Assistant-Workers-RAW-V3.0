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
    public partial class View_Applicant : Form
    {
        String JOBID = "";
       // byte[] image;
      //  String sname = "";
      //  String rating = "";
        String amsg = "";
       // String jprice = "";
       // String jtime = "";
       // String apptime = "";
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        // ArrayList job = new ArrayList();

        Applicant_User_Control[] aup = new Applicant_User_Control[50];
        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void customizeSubMenu()
        {
            PanelPostJob.Visible = false;
            PanelWork.Visible = false;
        }
        private void HideSubMenu()
        {
            if (PanelPostJob.Visible == true)
                PanelPostJob.Visible = false;
            if (PanelWork.Visible == true)
                PanelWork.Visible = false;
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
        public View_Applicant()
        {
            InitializeComponent();
        }
        public View_Applicant(String id)
        {
            InitializeComponent();
            JOBID = id;

        }

        private void View_Applicant_Load(object sender, EventArgs e)
        {
            {
                customizeSubMenu();
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM APPLY_JOB WHERE JOB_ID=@id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", JOBID);
                
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    int i = 0;
                    int x = 0, y = 0;
                    while (sda.Read())
                    {






                        byte[] image;
                        String sname = (sda["SELLER_NAME"].ToString());
                        String rating="";
                       // String amsg = (sda["SELLER_COMMENT"].ToString());

                        String jprice = "";
                        String jtime = "";
                        String jdetails = "";
                        String apptime = (sda["APPLY_TIME"].ToString());
                      //  String jid = (sda["JOB_STATUS"].ToString());


                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM SELLER_TOTAL_RATING WHERE USER_NAME= @name;";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@name", sname);
                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {

                                rating = (sda1["CURRENT_RATING"].ToString())+" ("+ (sda1["TOTAL_RATED_BY"].ToString()) + ")";


                                SqlConnection con2 = new SqlConnection(cs);
                                String query2 = "SELECT * FROM JOB_INFO WHERE JOB_ID= @id;";
                                SqlCommand cmd2 = new SqlCommand(query2, con2);
                                cmd2.Parameters.AddWithValue("@id", JOBID);
                                con2.Open();
                                SqlDataReader sda2 = cmd2.ExecuteReader();
                                if (sda2.HasRows == true)
                                {

                                    while (sda2.Read())
                                    {

                                      

                                        jprice = (sda2["JOB_PRICE"].ToString());
                                        jtime = (sda2["JOB_TIME"].ToString());
                                        jdetails = (sda2["JOB_DETAILS"].ToString());

                                        SqlConnection con4 = new SqlConnection(cs);
                                        String query4 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME= @name;";
                                        SqlCommand cmd4 = new SqlCommand(query4, con4);
                                        cmd4.Parameters.AddWithValue("@name", sname);
                                        con4.Open();
                                        SqlDataReader sda4 = cmd4.ExecuteReader();
                                        if (sda4.HasRows == true)
                                        {

                                            while (sda4.Read())
                                            { 
                                                image = ((byte[])(sda4["PROFILE_PICTURE"]));


                                                aup[i] = new Applicant_User_Control(image, sname, rating, jdetails, jprice, jtime, apptime, JOBID);




                                        panel1.Controls.Add(aup[i]);
                                        aup[i].Location = new System.Drawing.Point(x, y);
                                        aup[i].Visible = true;
                                        aup[i].BringToFront();

                                        aup[i].Show();

                                        y += (aup[i].Height + 10);
                                            }
                                            // MessageBox.Show(bjp[0].BPAYMENT);
                                        }


                                        else
                                        {


                                        }

                                        con4.Close();
                                    }
                                }


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
            BuyerName.Text = Buyer_Info.USER_NAME;
            label5.Text = Buyer_Info.RAW_POST;
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            BuyerPicture.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);


        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        private void ButtonWorkHouse_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWork);

        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ButtobJob_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelPostJob);

        }

        private void ButtonProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Search().Show();
        }

        private void ButtonPostJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Post_Job().Show();
        }

        private void ButtonManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();
        }

        private void ButtonRecent_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Recent_Job().Show();
        }

        private void ButtonSunmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Previous_Job().Show();

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Cancel_Job().Show();
        }

        private void ButtonAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Account().Show();
        }

        private void ButtonMsg_Click(object sender, EventArgs e)
        {

            this.Hide();
            new Buyer_Messenger().Show();
        }

    

        private void PictureBoxBuyerPortal_Click(object sender, EventArgs e)
        {
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











        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BuyerPicture_Click(object sender, EventArgs e)
        {

        }
    }
}
