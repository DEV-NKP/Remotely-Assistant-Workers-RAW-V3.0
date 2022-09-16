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



    public partial class messenger_name_right : UserControl
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        public messenger_name_right()
        {
            InitializeComponent();
        }

        public messenger_name_right(String unamer)
        {
            InitializeComponent();

           
            

            SqlConnection con = new SqlConnection(cs);
            String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME ='"+unamer+"' ;";
            SqlCommand cmd = new SqlCommand(query, con);
            // cmd.Parameters.AddWithValue("@user", searchbox.Text);

            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {

                while (sda.Read())
                {


                   
                    recName.Text = (sda["FULL_NAME"].ToString());
                     image.Image = GetPhoto(((byte[])(sda["PROFILE_PICTURE"])));

                 
                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con.Close();

            SqlConnection con1 = new SqlConnection(cs);
            String query1 = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME ='" + unamer+"';";
            SqlCommand cmd1 = new SqlCommand(query1, con1);


            con1.Open();
            SqlDataReader sda1 = cmd1.ExecuteReader();
            if (sda1.HasRows == true)
            {

                while (sda1.Read())
                {


                    recName.Text = (sda1["FULL_NAME"].ToString());
                    image.Image = GetPhoto(((byte[])(sda1["PROFILE_PICTURE"])));


                }

            }

            else
            {
                // panel9.Visible = false;

            }

            con1.Close();



        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
