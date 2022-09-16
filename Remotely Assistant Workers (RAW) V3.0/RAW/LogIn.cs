using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class LogIn : Form

    { 
          String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        String POST = "";
        String EMAIL = "";
        String USERNAME = "";
        String PASSWORD = "";
        String REMEMBER = "NO";


        Boolean ps = false;
        Boolean un = false;
        Boolean pas = false;
        Boolean ace = false;
        public LogIn()
        {



            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label10.Parent = pictureBox1;
            label10.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Landing_Page().Show();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            textpass.UseSystemPasswordChar = true;
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            gunaGradientButton1.BorderColor =  Color.FromArgb(21, 196, 149);
            gunaGradientButton2.BorderColor = Color.Black;

            gunaElipsePanel1.Visible = true;

            POST = "BUYER";
            ps = true;
            EnableButton();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            gunaGradientButton2.BorderColor = Color.FromArgb(21, 196, 149);
            gunaGradientButton1.BorderColor = Color.Black;
            gunaElipsePanel1.Visible = true;
            POST = "SELLER";
            ps = true;
            EnableButton();
        }

        public void EnableButton()
        {

            if (ace && un && pas && ps)
            {
                LOGINBUT.Enabled = true;
            }
            else {

                LOGINBUT.Enabled = false;
            }
        
        }

        private void LOGINBUT_Click(object sender, EventArgs e)
        {
            USERNAME = textemail.Text;
            PASSWORD = textpass.Text;
            String LOGTIME = new RAW_Function().time();
            String LOGIP = "N/A";

            Boolean buyerflag = false;
            Boolean sellerflag = false;

            if (POST.Equals("BUYER"))
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE  PASSWORD= @password AND USER_NAME= @user OR EMAIL=@user ;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", USERNAME);
                cmd.Parameters.AddWithValue("@password", PASSWORD);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                   buyerflag = true;
                    while (sda.Read())
                    {
                        USERNAME = (sda["USER_NAME"].ToString());
                        PASSWORD = (sda["PASSWORD"].ToString());
                      EMAIL = (sda["EMAIL"].ToString());
                        
                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. This user can't register in our database.");

                }

                con.Close();
            }

            if (POST.Equals("SELLER"))
            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE PASSWORD= @password AND USER_NAME= @user OR EMAIL=@user  ;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", USERNAME);
                cmd.Parameters.AddWithValue("@password", PASSWORD);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    sellerflag = true;
                    while (sda.Read())
                    {
                        USERNAME = (sda["USER_NAME"].ToString());
                        PASSWORD = (sda["PASSWORD"].ToString());
                        EMAIL = (sda["EMAIL"].ToString());

                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. This user can't register in our database.");

                }

                con.Close();
            }

            if (buyerflag)
            {
                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "INSERT INTO BUYER_LOGIN VALUES(@user,@email,@pass,@rem,@logt,@logip,@post);";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@user", USERNAME);
                cmd1.Parameters.AddWithValue("@email", EMAIL);
                cmd1.Parameters.AddWithValue("@pass", PASSWORD);
                cmd1.Parameters.AddWithValue("@rem", REMEMBER);
                cmd1.Parameters.AddWithValue("@logt", LOGTIME);
                cmd1.Parameters.AddWithValue("@logip", LOGIP);
                cmd1.Parameters.AddWithValue("@post", POST);

                con1.Open();
                int a = cmd1.ExecuteNonQuery();

                if (a > 0)
                {

                    if (CheckBoxTerm.Checked)
                    { new RAW_Function().CreateRemember(USERNAME, PASSWORD, POST); }

                    this.Hide();
                    new Buyer_Info(USERNAME);
                    new Buyer_Profile().Show();
                }
                else
                {
                    MessageBox.Show("OOPS!! ERROR. Try again.");
                    Application.Exit();
                }
                con1.Close();

            }

            if (sellerflag)
            {
                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "INSERT INTO SELLER_LOGIN VALUES(@user,@email,@pass,@rem,@logt,@logip,@post);";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@user", USERNAME);
                cmd1.Parameters.AddWithValue("@email", EMAIL);
                cmd1.Parameters.AddWithValue("@pass", PASSWORD);
                cmd1.Parameters.AddWithValue("@rem", REMEMBER);
                cmd1.Parameters.AddWithValue("@logt", LOGTIME);
                cmd1.Parameters.AddWithValue("@logip", LOGIP);
                cmd1.Parameters.AddWithValue("@post", POST);

                con1.Open();
                int a = cmd1.ExecuteNonQuery();

                if (a > 0)
                {
                    if (CheckBoxTerm.Checked)
                    {

                        new RAW_Function().CreateRemember(USERNAME, PASSWORD, POST);
                    }
                    this.Hide();
                    new Seller_Info(USERNAME);
                    new Seller_Profile().Show();
                }
                else
                {
                    MessageBox.Show("OOPS!! ERROR. Try again.");
                    Application.Exit();
                }
                con1.Close();

            }

        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textemail.Text))
            {
                un = false;
                EnableButton();
            }
            else
            {

                un = true;
                EnableButton();
            }
        }

        private void textpass_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textpass.Text))
            {
                pas = false;
                EnableButton();
            }
            else
            {

                pas = true;
                EnableButton();
            }
        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (gunaCheckBox1.Checked)
            { ace = true;

                EnableButton();
            }
            else { ace = false;
                EnableButton();
            }
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp_Menu().Show();
        }

        private void CheckBoxTerm_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxTerm.Checked)
            {  REMEMBER = "YES";}
            else { REMEMBER = "NO";}
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (show.Checked)
            {
                textpass.UseSystemPasswordChar = false;
            }
            else
            {
                textpass.UseSystemPasswordChar = true;
            }
        }

        private void gunaElipsePanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
