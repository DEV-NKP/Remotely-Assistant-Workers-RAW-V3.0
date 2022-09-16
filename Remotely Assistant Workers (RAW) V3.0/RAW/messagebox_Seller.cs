using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class messagebox_Seller : UserControl
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        String cs1 = ConfigurationManager.ConnectionStrings["RAW_MESSENGER"].ConnectionString;

        static Image images;
        static Image imager;

        msg_right[] msr = new msg_right[5000];
        msg_left[] msl = new msg_left[5000];

        String tableName = "";
        String recName = "";

        public messagebox_Seller()
        {
            InitializeComponent();
        }
        public messagebox_Seller(String rname, String tname)
        {
            InitializeComponent();
            this.tableName = tname;
            this.recName = rname;
            msgLoad();
        }

        public void msgLoad()
        {
            msgpan.Controls.Clear();



            SqlConnection con14 = new SqlConnection(cs);
            String query14 = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= '" + Seller_Info.USER_NAME + "';";
            SqlCommand cmd14 = new SqlCommand(query14, con14);
            // cmd.Parameters.AddWithValue("@user", searchbox.Text);

            con14.Open();
            SqlDataReader sda14 = cmd14.ExecuteReader();
            if (sda14.HasRows == true)
            {

                while (sda14.Read())
                {



                    images = GetPhoto(((byte[])(sda14["PROFILE_PICTURE"])));


                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con14.Close();

            SqlConnection con13 = new SqlConnection(cs);
            String query13 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE  USER_NAME= '" + Seller_Info.USER_NAME + "';";
            SqlCommand cmd13 = new SqlCommand(query13, con13);


            con13.Open();
            SqlDataReader sda13 = cmd13.ExecuteReader();
            if (sda13.HasRows == true)
            {

                while (sda13.Read())
                {



                    images = GetPhoto(((byte[])(sda13["PROFILE_PICTURE"])));


                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con13.Close();


            SqlConnection con12 = new SqlConnection(cs);
            String query12 = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= '" + recName + "';";
            SqlCommand cmd12 = new SqlCommand(query12, con12);
            // cmd.Parameters.AddWithValue("@user", searchbox.Text);

            con12.Open();
            SqlDataReader sda12 = cmd12.ExecuteReader();
            if (sda12.HasRows == true)
            {

                while (sda12.Read())
                {



                    imager = GetPhoto(((byte[])(sda12["PROFILE_PICTURE"])));


                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con12.Close();

            SqlConnection con11 = new SqlConnection(cs);
            String query11 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE  USER_NAME= '" + recName + "';";
            SqlCommand cmd11 = new SqlCommand(query11, con11);


            con11.Open();
            SqlDataReader sda11 = cmd11.ExecuteReader();
            if (sda11.HasRows == true)
            {

                while (sda11.Read())
                {



                    imager = GetPhoto(((byte[])(sda11["PROFILE_PICTURE"])));


                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con11.Close();





            // Application.Exit();
            int contacts = 0;
            int y1 = 0;



            ///////////////////search


            SqlConnection con = new SqlConnection(cs1);
            String query = "SELECT * FROM " + tableName + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            // cmd.Parameters.AddWithValue("@user", searchbox.Text);

            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {

                while (sda.Read())
                {

                    if ((sda["SENDER_NAME"].ToString()) == Seller_Info.USER_NAME)
                    {
                        msr[contacts] = new msg_right((sda["MESSAGE"].ToString()), images);
                        msgpan.Controls.Add(msr[contacts]);


                        msr[contacts].Location = new System.Drawing.Point(280, y1);
                        msr[contacts].Visible = true;
                        msr[contacts].BringToFront();

                        msr[contacts].Show();

                        y1 += (msr[contacts].Height + 1);

                        contacts++;

                    }
                    else
                    {
                        msl[contacts] = new msg_left((sda["MESSAGE"].ToString()), imager);
                        msgpan.Controls.Add(msl[contacts]);


                        msl[contacts].Location = new System.Drawing.Point(0, y1);
                        msl[contacts].Visible = true;
                        msl[contacts].BringToFront();

                        msl[contacts].Show();

                        y1 += (msl[contacts].Height + 1);

                        contacts++;
                    }



                    /* String unames = (sda["USER_NAME"].ToString());
                     String fnames = (sda["FULL_NAME"].ToString());
                     Image images = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                     ms[contacts] = new messageUserSearch(unames, fnames, images);
                     contactcont.Controls.Add(ms[contacts]);


                     ms[contacts].Location = new System.Drawing.Point(x, y);
                     ms[contacts].Visible = true;
                     ms[contacts].BringToFront();

                     ms[contacts].Show();

                     y += (ms[contacts].Height + 1);

                     contacts++;*/
                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con.Close();

            msgpan.VerticalScroll.Value = msgpan.VerticalScroll.Maximum;
        }




        private void msgpan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void send_Click(object sender, EventArgs e)
        {

        }

        private void send_MouseClick(object sender, MouseEventArgs e)
        {
            String POST_TIME = new RAW_Function().dtime();

            SqlConnection con1 = new SqlConnection(cs1);
            String query1 = "INSERT INTO " + tableName + " VALUES(@sname,@rname,@msg,@time);";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@sname", Seller_Info.USER_NAME);
            cmd1.Parameters.AddWithValue("@rname", recName);
            cmd1.Parameters.AddWithValue("@msg", msgType.Text);
            cmd1.Parameters.AddWithValue("@time", POST_TIME);



            con1.Open();
            int a = cmd1.ExecuteNonQuery();

            if (a > 0)
            {


                msgType.Text = "";
                msgLoad();

            }
            else
            {
                msgType.Text = msgType.Text;
            }
            con1.Close();


        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
    }
}
