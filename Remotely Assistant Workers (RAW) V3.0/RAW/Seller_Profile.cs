using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace RAW
{
    public partial class Seller_Profile : Form
    {
        Boolean searchac = false;

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_Profile()
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



        private void Seller_Profile_Load(object sender, EventArgs e)
        {
            customizeSubMenu();
            SellerName.Text = Seller_Info.USER_NAME;
            label3.Text = Seller_Info.RAW_POST;
            SellerPortalStatus.Text = Seller_Info.STATUS;
            LabelSellerPortalName.Text = "Welcome " + Seller_Info.LAST_NAME + ", " + Seller_Info.FIRST_NAME;
            PictureBoxSellermain.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            PictureBoxSelPortal.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);

            PictureBox_Seller_Profile.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            label9.Text = Seller_Info.USER_NAME;
            label2.Text = "Email: " + Seller_Info.EMAIL;
            label1.Text = "Country: " + Seller_Info.COUNTRY;
            label6.Text = "Status: " + Seller_Info.STATUS_MESSAGE;
            label5.Text = Seller_Info.TOTAL_RATING;

            PD_label1.Text = Seller_Info.DATE_OF_BIRTH;
            PD_label2.Text = Seller_Info.NID_NUMBER;
            PD_label3.Text = Seller_Info.PASSPORT_NUMBER;
            PD_label4.Text = Seller_Info.NATIONALITY;
            PD_label5.Text = Seller_Info.STREET_ADDRESS;
            PD_label6.Text = Seller_Info.CITY;

            AD_label1.Text = Seller_Info.DESCRIPTION;
            AD_label2.Text = Seller_Info.BANK_ACCOUNT_NUMBER;

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        private void ButtonSellerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

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
            sup.Visible = false;
            viewp++;

            //  MessageBox.Show(Convert.ToString(viewp));
            if (viewp % 2 == 0)
            {

                this.sup.Location = new System.Drawing.Point(980, 88);
                this.Controls.Add(sup);
                sup.Visible = true;
                sup.BringToFront();
                PictureBoxSelPortal.BringToFront();
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

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Boolean buyercheck = false;
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

                if (buyercheck)
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

            if (!buyercheck)
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
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

                if (buyercheck)
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
                        panel9.Visible = false;

                    }

                    con.Close();
                }
            }

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
            else
            {

                gunaButton2.Enabled = false;
            }

        }

        private void Button_Edit_Profile_Seller_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Edit_Profile().Show();
        }
    }
}
