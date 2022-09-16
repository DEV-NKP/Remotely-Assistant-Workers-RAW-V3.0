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
    public partial class Seller_Messenger : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();

        messageUserSearch_Seller[] ms = new messageUserSearch_Seller[500];
        messenger_name_right[] mr = new messenger_name_right[1];


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_Messenger()
        {
            InitializeComponent();
        }
        String recName = "";
        String tableName = "";
        public void showUserRight(String rec_Name, String tableName)
        {
            this.recName = recName;
            this.tableName = tableName;

            mr[0] = new messenger_name_right(rec_Name);
            this.namecont.Controls.Add(mr[0]);

            mr[0].Location = new System.Drawing.Point(0, 0);
            mr[0].Visible = true;
            mr[0].BringToFront();

            mr[0].Show();


            messagebox_Seller mb = new messagebox_Seller(rec_Name, tableName);
            this.inboxcont.Controls.Add(mb);

            mb.Location = new System.Drawing.Point(0, 0);
            mb.Visible = true;
            mb.BringToFront();

            mb.Show();

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

        private void ButtonSellerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

        }

        private void Seller_Messenger_Load(object sender, EventArgs e)
        {
            messenger_create_Seller.sm = this;
            customizeSubMenu();

            SellerName.Text = Seller_Info.USER_NAME;
            label3.Text = Seller_Info.RAW_POST;
            SellerPortalStatus.Text = Seller_Info.STATUS;
            LabelSellerPortalName.Text = "Welcome " + Seller_Info.LAST_NAME + ", " + Seller_Info.FIRST_NAME;
            PictureBoxSellermain.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            PictureBoxSellerPortal.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            /*

            own1.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            own2.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            own3.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            own4.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);

            label10.Text = Seller_Info.USER_NAME;
            */

            contactcont.Controls.Clear();


            // Application.Exit();
            int contacts = 0;
            int x = 0, y = 0;
            ///////////////////search

            SqlConnection con11 = new SqlConnection(cs);
            String query11 = "SELECT * FROM MESSENGER WHERE SENDER_NAME = '" + Seller_Info.USER_NAME + "';";
            SqlCommand cmd11 = new SqlCommand(query11, con11);
            // cmd.Parameters.AddWithValue("@user", searchbox.Text);

            con11.Open();
            SqlDataReader sda11 = cmd11.ExecuteReader();
            if (sda11.HasRows == true)
            {

                while (sda11.Read())
                {


                    SqlConnection con = new SqlConnection(cs);
                    String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda11["REC_NAME"].ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                    con.Open();
                    SqlDataReader sda = cmd.ExecuteReader();
                    if (sda.HasRows == true)
                    {

                        while (sda.Read())
                        {


                            String unames = (sda["USER_NAME"].ToString());
                            String fnames = (sda["FULL_NAME"].ToString());
                            Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                            ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                            contactcont.Controls.Add(ms[contacts]);
                            ms[contacts].Location = new System.Drawing.Point(x, y);
                            ms[contacts].Visible = true;
                            ms[contacts].BringToFront();

                            ms[contacts].Show();

                            y += (ms[contacts].Height + 1);

                            contacts++;
                        }

                    }

                    else
                    {
                        // panel9.Visible = false;

                    }

                    con.Close();

                    SqlConnection con1 = new SqlConnection(cs);
                    String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda11["REC_NAME"].ToString() + "';";
                    SqlCommand cmd1 = new SqlCommand(query1, con1);


                    con1.Open();
                    SqlDataReader sda1 = cmd1.ExecuteReader();
                    if (sda1.HasRows == true)
                    {

                        while (sda1.Read())
                        {


                            String unames = (sda1["USER_NAME"].ToString());
                            String fnames = (sda1["FULL_NAME"].ToString());
                            Image images = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));

                            ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                            contactcont.Controls.Add(ms[contacts]);

                            ms[contacts].Location = new System.Drawing.Point(x, y);
                            ms[contacts].Visible = true;
                            ms[contacts].BringToFront();

                            ms[contacts].Show();

                            y += (ms[contacts].Height + 1);
                            contacts++;
                        }

                    }

                    else
                    {
                        // panel9.Visible = false;

                    }

                    con1.Close();



                }

            }

            else
            { }
            con11.Close();
            SqlConnection con12 = new SqlConnection(cs);
                String query12 = "SELECT * FROM MESSENGER WHERE REC_NAME = '" + Seller_Info.USER_NAME + "' AND SENDER_NAME != '" + Seller_Info.USER_NAME + "';";
                SqlCommand cmd12 = new SqlCommand(query12, con12);
                // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                con12.Open();
                SqlDataReader sda12 = cmd12.ExecuteReader();
                if (sda12.HasRows == true)
                {

                    while (sda12.Read())
                    {


                        SqlConnection con = new SqlConnection(cs);
                        String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda12["SENDER_NAME"].ToString() + "';";
                        SqlCommand cmd = new SqlCommand(query, con);
                        // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {

                            while (sda.Read())
                            {


                                String unames = (sda["USER_NAME"].ToString());
                                String fnames = (sda["FULL_NAME"].ToString());
                                Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                                ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                                contactcont.Controls.Add(ms[contacts]);
                                ms[contacts].Location = new System.Drawing.Point(x, y);
                                ms[contacts].Visible = true;
                                ms[contacts].BringToFront();

                                ms[contacts].Show();

                                y += (ms[contacts].Height + 1);

                                contacts++;
                            }

                        }

                        else
                        {
                            // panel9.Visible = false;

                        }

                        con.Close();

                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda12["SENDER_NAME"].ToString() + "';";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);


                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {


                                String unames = (sda1["USER_NAME"].ToString());
                                String fnames = (sda1["FULL_NAME"].ToString());
                                Image images = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));

                                ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                                contactcont.Controls.Add(ms[contacts]);

                                ms[contacts].Location = new System.Drawing.Point(x, y);
                                ms[contacts].Visible = true;
                                ms[contacts].BringToFront();

                                ms[contacts].Show();

                                y += (ms[contacts].Height + 1);
                                contacts++;
                            }

                        }

                        else
                        {
                            // panel9.Visible = false;

                        }

                        con1.Close();



                    }

                }

                else
                {
                    // panel9.Visible = false;

                }

                con12.Close();


            

         

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

     

        private void gunaControlBox2_Click(object sender, EventArgs e)
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

        private void inboxcont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
           

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            contactcont.Controls.Clear();
            if((searchbox.Text == "") || (searchbox.Text == " "))
            {

              


                // Application.Exit();
                int contacts = 0;
                int x = 0, y = 0;
                ///////////////////search

                SqlConnection con11 = new SqlConnection(cs);
                String query11 = "SELECT * FROM MESSENGER WHERE SENDER_NAME = '" + Seller_Info.USER_NAME + "';";
                SqlCommand cmd11 = new SqlCommand(query11, con11);
                // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                con11.Open();
                SqlDataReader sda11 = cmd11.ExecuteReader();
                if (sda11.HasRows == true)
                {

                    while (sda11.Read())
                    {


                        SqlConnection con = new SqlConnection(cs);
                        String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda11["REC_NAME"].ToString() + "';";
                        SqlCommand cmd = new SqlCommand(query, con);
                        // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {

                            while (sda.Read())
                            {


                                String unames = (sda["USER_NAME"].ToString());
                                String fnames = (sda["FULL_NAME"].ToString());
                                Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                                ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                                contactcont.Controls.Add(ms[contacts]);
                                ms[contacts].Location = new System.Drawing.Point(x, y);
                                ms[contacts].Visible = true;
                                ms[contacts].BringToFront();

                                ms[contacts].Show();

                                y += (ms[contacts].Height + 1);

                                contacts++;
                            }

                        }

                        else
                        {
                            // panel9.Visible = false;

                        }

                        con.Close();

                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda11["REC_NAME"].ToString() + "';";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);


                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {


                                String unames = (sda1["USER_NAME"].ToString());
                                String fnames = (sda1["FULL_NAME"].ToString());
                                Image images = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));

                                ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                                contactcont.Controls.Add(ms[contacts]);

                                ms[contacts].Location = new System.Drawing.Point(x, y);
                                ms[contacts].Visible = true;
                                ms[contacts].BringToFront();

                                ms[contacts].Show();

                                y += (ms[contacts].Height + 1);
                                contacts++;
                            }

                        }

                        else
                        {
                            // panel9.Visible = false;

                        }

                        con1.Close();



                    }

                }

                else
                { }
                con11.Close();
                SqlConnection con12 = new SqlConnection(cs);
                String query12 = "SELECT * FROM MESSENGER WHERE REC_NAME = '" + Seller_Info.USER_NAME + "' AND SENDER_NAME != '" + Seller_Info.USER_NAME + "';";
                SqlCommand cmd12 = new SqlCommand(query12, con12);
                // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                con12.Open();
                SqlDataReader sda12 = cmd12.ExecuteReader();
                if (sda12.HasRows == true)
                {

                    while (sda12.Read())
                    {


                        SqlConnection con = new SqlConnection(cs);
                        String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda12["SENDER_NAME"].ToString() + "';";
                        SqlCommand cmd = new SqlCommand(query, con);
                        // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {

                            while (sda.Read())
                            {


                                String unames = (sda["USER_NAME"].ToString());
                                String fnames = (sda["FULL_NAME"].ToString());
                                Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                                ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                                contactcont.Controls.Add(ms[contacts]);
                                ms[contacts].Location = new System.Drawing.Point(x, y);
                                ms[contacts].Visible = true;
                                ms[contacts].BringToFront();

                                ms[contacts].Show();

                                y += (ms[contacts].Height + 1);

                                contacts++;
                            }

                        }

                        else
                        {
                            // panel9.Visible = false;

                        }

                        con.Close();

                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME = '" + sda12["SENDER_NAME"].ToString() + "';";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);


                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {

                            while (sda1.Read())
                            {


                                String unames = (sda1["USER_NAME"].ToString());
                                String fnames = (sda1["FULL_NAME"].ToString());
                                Image images = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));

                                ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                                contactcont.Controls.Add(ms[contacts]);

                                ms[contacts].Location = new System.Drawing.Point(x, y);
                                ms[contacts].Visible = true;
                                ms[contacts].BringToFront();

                                ms[contacts].Show();

                                y += (ms[contacts].Height + 1);
                                contacts++;
                            }

                        }

                        else
                        {
                            // panel9.Visible = false;

                        }

                        con1.Close();



                    }

                }

                else
                {
                    // panel9.Visible = false;

                }

                con12.Close();

            }

            if (!(searchbox.Text == "") && !(searchbox.Text == " "))
            {

                // Application.Exit();
                int contacts = 0;
                int x = 0, y = 0;
                ///////////////////search


                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE FULL_NAME LIKE '%" + searchbox.Text + "%';";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {


                        String unames = (sda["USER_NAME"].ToString());
                        String fnames = (sda["FULL_NAME"].ToString());
                        Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                        ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                        contactcont.Controls.Add(ms[contacts]);


                        ms[contacts].Location = new System.Drawing.Point(x, y);
                        ms[contacts].Visible = true;
                        ms[contacts].BringToFront();

                        ms[contacts].Show();

                        y += (ms[contacts].Height + 1);

                        contacts++;
                    }

                }

                else
                {
                    // panel9.Visible = false;

                }

                con.Close();

                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE FULL_NAME LIKE '%" + searchbox.Text + "%';";
                SqlCommand cmd1 = new SqlCommand(query1, con1);


                con1.Open();
                SqlDataReader sda1 = cmd1.ExecuteReader();
                if (sda1.HasRows == true)
                {

                    while (sda1.Read())
                    {


                        String unames = (sda1["USER_NAME"].ToString());
                        String fnames = (sda1["FULL_NAME"].ToString());
                        Image images = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));

                        ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                        contactcont.Controls.Add(ms[contacts]);

                        ms[contacts].Location = new System.Drawing.Point(x, y);
                        ms[contacts].Visible = true;
                        ms[contacts].BringToFront();

                        ms[contacts].Show();

                        y += (ms[contacts].Height + 1);
                        contacts++;
                    }

                }

                else
                {
                    // panel9.Visible = false;

                }

                con1.Close();
            }
        }

        private void contactcont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_Click_1(object sender, EventArgs e)
        {
            contactcont.Controls.Clear();
            if (!String.IsNullOrEmpty(searchbox.Text))
            {

                // Application.Exit();
                int contacts = 0;
                int x = 0, y = 0;
                ///////////////////search


                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE FULL_NAME LIKE '%" + searchbox.Text + "%';";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@user", searchbox.Text);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {


                        String unames = (sda["USER_NAME"].ToString());
                        String fnames = (sda["FULL_NAME"].ToString());
                        Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                        ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                        contactcont.Controls.Add(ms[contacts]);
                        ms[contacts].Location = new System.Drawing.Point(x, y);
                        ms[contacts].Visible = true;
                        ms[contacts].BringToFront();

                        ms[contacts].Show();

                        y += (ms[contacts].Height + 1);

                        contacts++;
                    }

                }

                else
                {
                    // panel9.Visible = false;

                }

                con.Close();

                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE FULL_NAME LIKE '%" + searchbox.Text + "%';";
                SqlCommand cmd1 = new SqlCommand(query1, con1);


                con1.Open();
                SqlDataReader sda1 = cmd1.ExecuteReader();
                if (sda1.HasRows == true)
                {

                    while (sda1.Read())
                    {


                        String unames = (sda1["USER_NAME"].ToString());
                        String fnames = (sda1["FULL_NAME"].ToString());
                        Image images = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));

                        ms[contacts] = new messageUserSearch_Seller(unames, fnames, images);
                        contactcont.Controls.Add(ms[contacts]);

                        ms[contacts].Location = new System.Drawing.Point(x, y);
                        ms[contacts].Visible = true;
                        ms[contacts].BringToFront();

                        ms[contacts].Show();

                        y += (ms[contacts].Height + 1);
                        contacts++;
                    }

                }

                else
                {
                    // panel9.Visible = false;

                }

                con1.Close();
            }
        }
    }
}
