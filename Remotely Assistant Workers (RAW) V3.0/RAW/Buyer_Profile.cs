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
using System.Data.SqlClient;
using System.Configuration;

namespace RAW
{
    public partial class Buyer_Profile : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        Boolean searchac = false;

        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Buyer_Profile()
        {
            InitializeComponent();
        }

        private void customizeSubMenu()
        {
            PanelJobPost.Visible = false;
            PanelWorkHouse.Visible = false;
        }
        private void HideSubMenu()
        {
            if (PanelJobPost.Visible == true)
                PanelJobPost.Visible = false;
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

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LabelBuyerName_Click(object sender, EventArgs e)
        {

        }

        private void Buyer_Profile_Load(object sender, EventArgs e)
        {
            customizeSubMenu();
            LabelBuyerName.Text = Buyer_Info.USER_NAME;
            label1.Text = Buyer_Info.RAW_POST;
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            PictureBoxBuyermain.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);

            pictureBox2.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            label22.Text= Buyer_Info.USER_NAME;
            label9.Text="Email: "+ Buyer_Info.EMAIL;
            label3.Text="Country: "+ Buyer_Info.COUNTRY;
            label6.Text="Status: "+ Buyer_Info.STATUS_MESSAGE;
            label5.Text= Buyer_Info.TOTAL_RATING;

            //MessageBox.Show(Buyer_Info.DATE_OF_BIRTH);


            PD_label1.Text= Buyer_Info.DATE_OF_BIRTH;
            PD_label2.Text = Buyer_Info.NID_NUMBER;
            PD_label3.Text = Buyer_Info.PASSPORT_NUMBER;
            PD_label4.Text = Buyer_Info.NATIONALITY;
            PD_label5.Text = Buyer_Info.STREET_ADDRESS;
            PD_label6.Text = Buyer_Info.CITY;

            AD_label1.Text = Buyer_Info.DESCRIPTION;
            AD_label2.Text = Buyer_Info.BANK_ACCOUNT_NUMBER;
           // gunaButton1.Visible = false;

        }

        private void PictureBoxBuyermain_Click(object sender, EventArgs e)
        {

        }

        private void ButtonBuyerPortalSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Search().Show();

        }

        private void ButtonBuyerPortalPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Post_Job().Show();

        }

        private void ButtonBuyerPortalManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();

        }

        private void ButtonBuyerPortalRecJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Recent_Job().Show();

        }

        private void ButtonBuyerPortalSubob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();

        }

        private void ButtonBuyerPortalPreJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Previous_Job().Show();

        }

        private void ButtonBuyerPortalCanJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Cancel_Job().Show();

        }

        private void ButtonBuyerPortalAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Account().Show();

        }

        private void ButtonBuyerPortalChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Messenger().Show();
        }

      
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void BuyerSignUp_ResetAll_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Edit_Profile().Show();
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gunaTextBox1.Text))
            {
                searchac = false;
                EnableButton();
            }
            else
            {

                searchac = true;
                EnableButton();
            }
        }

        public void EnableButton()
        {
            if (searchac)
            {
                gunaButton2.Enabled = true;
            }
            else {

                gunaButton2.Enabled = false;
            }

        }

        private void gunaTextBox1_Enter(object sender, EventArgs e)
        {
           
        }



        private void gunaButton2_Click(object sender, EventArgs e)
        {

            Boolean buyercheck = false;
            Boolean sellercheck = false;
            ///////////////////search

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", gunaTextBox1.Text);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    buyercheck = true;
                    while (sda.Read())
                    {


                        portal_search_name.Text = (sda["USER_NAME"].ToString());

                        EMAILSEARCH.Text = (sda["EMAIL"].ToString());
                        pictureBox3.Image = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));
                       
                        portalStatus.Text = (sda["STATUS"].ToString());
                        PortalStatusMessage.Text = (sda["STATUS_MESSAGE"].ToString());

                        portalPost.Text = (sda["RAW_POST"].ToString());


                    }

                }

                else
                {
                    panel9.Visible = false;

                }

                con.Close();

               if(buyercheck) 
                {
                    SqlConnection con1 = new SqlConnection(cs);
                    String query1 = "SELECT * FROM BUYER_TOTAL_RATING WHERE USER_NAME= @user;";
                    SqlCommand cmd1 = new SqlCommand(query1, con1);
                    cmd1.Parameters.AddWithValue("@user", gunaTextBox1.Text);

                    con1.Open();
                    SqlDataReader sda1 = cmd1.ExecuteReader();
                    if (sda1.HasRows == true)
                    {

                        while (sda1.Read())
                        {

                            portalRating.Text = (sda1["CURRENT_RATING"].ToString()) + "(" + (sda1["TOTAL_RATED_BY"].ToString()) + ")";
                            panel9.Visible = true;

                        }

                    }

                    else
                    {
                        panel9.Visible = false;

                    }

                    con.Close();
                }
            }

            if(!buyercheck)
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", gunaTextBox1.Text);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    sellercheck = true;
                    while (sda.Read())
                    {


                        portal_search_name.Text = (sda["USER_NAME"].ToString());

                        EMAILSEARCH.Text = (sda["EMAIL"].ToString());
                        pictureBox3.Image = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                        portalStatus.Text = (sda["STATUS"].ToString());
                        PortalStatusMessage.Text = (sda["STATUS_MESSAGE"].ToString());

                        portalPost.Text = (sda["RAW_POST"].ToString());


                    }

                }

                else
                {

                    panel9.Visible = false;
                }

                con.Close();

                if (sellercheck)
                {
                    SqlConnection con1 = new SqlConnection(cs);
                    String query1 = "SELECT * FROM SELLER_TOTAL_RATING WHERE USER_NAME= @user;";
                    SqlCommand cmd1 = new SqlCommand(query1, con1);
                    cmd1.Parameters.AddWithValue("@user", gunaTextBox1.Text);

                    con1.Open();
                    SqlDataReader sda1 = cmd1.ExecuteReader();
                    if (sda1.HasRows == true)
                    {

                        while (sda1.Read())
                        {

                            portalRating.Text = (sda1["CURRENT_RATING"].ToString()) + "(" + (sda1["TOTAL_RATED_BY"].ToString()) + ")";
                            panel9.Visible = true;
                        }

                    }

                    else
                    {
                        panel9.Visible = false ;

                    }

                    con.Close();
                }
            }


        }


        private void PictureBoxBuyerPortal_Click(object sender, EventArgs e)
        {
            
// this.Controls.Add(bup);
            bup.Visible = false;
            viewp++;

          //  MessageBox.Show(Convert.ToString(viewp));
            if (viewp % 2 ==0)
            {
                
                this.bup.Location = new System.Drawing.Point(980, 88);
                this.Controls.Add(bup);
                bup.Visible = true;
                bup.BringToFront();
                PictureBoxBuyerPortal.BringToFront();
                // bup.Show();
            }
            else {
                bup.Hide();
                bup.Visible = false;
                bup.SendToBack();
                this.Controls.Remove(bup);
                
                
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelJobPost_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonBuyerPortalJobPost_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelJobPost);
        }

        private void ButtonBuyerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PD_label1_Click(object sender, EventArgs e)
        {

        }
    }
}
