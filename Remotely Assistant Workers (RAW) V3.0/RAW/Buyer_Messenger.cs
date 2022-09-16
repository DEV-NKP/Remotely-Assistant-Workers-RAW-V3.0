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
    

    public partial class Buyer_Messenger : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();


        messageUserSearch[] ms = new messageUserSearch[500];
        messenger_name_right[] mr = new messenger_name_right[1];


        private void customizeSubMenu()
        {
            JobPanel.Visible = false;
            WorkPanel.Visible = false;
        }
        private void HideSubMenu()
        {
            if (JobPanel.Visible == true)
                JobPanel.Visible = false;
            if (WorkPanel.Visible == true)
                WorkPanel.Visible = false;
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
        public Buyer_Messenger()
        {
            InitializeComponent();
        }
        String recName = "";
        String tableName= "";
    /*    public Buyer_Messenger(String rec_Name, String tableName)
        {
            this.recName = recName;
            this.tableName = tableName;
            showUserRight( rec_Name,  tableName);
        }*/


        public void showUserRight(String rec_Name, String tableName)
        {
            this.recName = recName;
            this.tableName = tableName;

            mr[0] = new messenger_name_right(rec_Name);
            this.namecont.Controls.Add(mr[0]);

            mr[0].Location = new System.Drawing.Point(0,0);
            mr[0].Visible = true;
            mr[0].BringToFront();

            mr[0].Show();


            messagebox mb = new messagebox(rec_Name,tableName);
            this.inboxcont.Controls.Add(mb);

            mb.Location = new System.Drawing.Point(0, 0);
            mb.Visible = true;
            mb.BringToFront();

            mb.Show();

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

        private void Button_Buyer_Search_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Search().Show();
        }

        private void Button_Buyer_Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }

        private void Button_Buyer_PostJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Post_Job().Show();
        }

        private void Button_Buyer_ManageJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();
        }

        private void Button_Buyer_RecentJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Recent_Job().Show();
        }

        private void Button_Buyer_SubmittedJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();
        }

        private void Button_Buyer_PreviousJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Previous_Job().Show();
        }

        private void Button_Buyer_CancelJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Cancel_Job().Show();
        }

        private void Button_Buyer_Account_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Account().Show();
        }

      
        private void Button_Buyer_Messenger_Click(object sender, EventArgs e)
        {

        }

        private void Buyer_Messenger_Load(object sender, EventArgs e)
        {
            customizeSubMenu();
             messenger_create.bm = this;

            label6.Text = Buyer_Info.USER_NAME;
            label5.Text = Buyer_Info.RAW_POST;
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            gunaCirclePictureBox3.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);

            /* own1.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
             own2.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
             own3.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);

             label10.Text = Buyer_Info.USER_NAME;
             label17.Text = Buyer_Info.EMAIL;*/

            contactcont.Controls.Clear();
            

                // Application.Exit();
                int contacts = 0;
                int x = 0, y = 0;
            ///////////////////search

            SqlConnection con11 = new SqlConnection(cs);
            String query11 = "SELECT * FROM MESSENGER WHERE SENDER_NAME = '" + Buyer_Info.USER_NAME + "';";
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

                            ms[contacts] = new messageUserSearch(unames, fnames, images);
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

                            ms[contacts] = new messageUserSearch(unames, fnames, images);
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
                String query12 = "SELECT * FROM MESSENGER WHERE REC_NAME = '" + Buyer_Info.USER_NAME + "' AND SENDER_NAME != '" + Buyer_Info.USER_NAME + "';";
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

                                ms[contacts] = new messageUserSearch(unames, fnames, images);
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

                                ms[contacts] = new messageUserSearch(unames, fnames, images);
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            ShowSubMenu(WorkPanel);
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            ShowSubMenu(JobPanel);
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

        private void search_MouseClick(object sender, MouseEventArgs e)
        {

          

            

        }

        private void search_Click(object sender, EventArgs e)
        {
           
            

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            contactcont.Controls.Clear();
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

                        ms[contacts] = new messageUserSearch(unames, fnames, images);
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

                        ms[contacts] = new messageUserSearch(unames, fnames, images);
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

        private void searchbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           // Application.Exit();
        }

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
           // Application.Exit();
        }

        private void searchbox_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void contactcont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void namecont_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inboxcont_Paint(object sender, PaintEventArgs e)
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

                        ms[contacts] = new messageUserSearch(unames, fnames, images);
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

                        ms[contacts] = new messageUserSearch(unames, fnames, images);
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

        private void gunaCirclePictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
