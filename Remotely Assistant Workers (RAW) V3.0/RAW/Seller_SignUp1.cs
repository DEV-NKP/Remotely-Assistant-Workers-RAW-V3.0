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
    public partial class Seller_SignUp1 : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;


        Boolean fna = false;
        Boolean lna = false;
        Boolean ema = false;
        Boolean con = false;
        Boolean mbl = false;
        //Boolean dob = false;
        Boolean gen = false;
        Boolean dp = true;
        public static String gender = "";
        public static String Fname = "";
        public static String Lname = "";
        public static String Email = "";
        public static String country = "";
        public static String mobile = "";

        public static byte[] picture;
        public static String dob = "";

        public Seller_SignUp1()
        {
            InitializeComponent();
            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void SellerSignUp_Firstname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Firstname.Text))
            {
                fna = false;
                EnableButton();
            }
            else
            {

                fna = true;
                EnableButton();
            }
        }

        private void SellerSignUp_Lastname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Lastname.Text))
            {
                lna = false;
                EnableButton();
            }
            else
            {

                lna = true;
                EnableButton();
            }
        }

        private void SellerSignUp_Email_TextChanged(object sender, EventArgs e)
        {
            RAW_Function rw = new RAW_Function();
            {
                if (string.IsNullOrEmpty(SellerSignUp_Email.Text))
                {
                    ema = false;
                    EnableButton();
                }
                else
                {

                    ema = true;
                    EnableButton();
                }
                if (!rw.IsValidEmail(SellerSignUp_Email.Text))
                {
                    ema = false;
                    labelE.Visible = true;
                    errorProvider1.SetError(this.SellerSignUp_Email, "Please enter a valid Email");

                    EnableButton();
                }
                else
                {

                    ema = true;
                    labelE.Visible = false;
                    errorProvider1.Clear();
                    EnableButton();
                }
            }
            SqlConnection con = new SqlConnection(cs);
            String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE EMAIL= @email;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", SellerSignUp_Email.Text);

            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {
                ema = false;
                EnableButton();
                label4.Text = "Email (This email has already registered)";
            }

            else
            {
                ema = true;
                EnableButton();
                label4.Text = "Email";
            }

            con.Close();
        }

        private void SellerSignUp_Country_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Country.Text))
            {
                con = false;
                EnableButton();
            }
            else
            {

                con = true;
                EnableButton();
            }
        }

        private void SellerSignUp_MobileNo_TextChanged(object sender, EventArgs e)
        {
            RAW_Function rw = new RAW_Function();
            if (string.IsNullOrEmpty(SellerSignUp_MobileNo.Text))
            {
                mbl = false;
                EnableButton();
            }
            else
            {

                mbl = true;
                EnableButton();
            }
            if (!rw.IsValidMobile(SellerSignUp_MobileNo.Text))
            {
                ema = false;
                labelM.Visible = true;
                errorProvider1.SetError(this.SellerSignUp_MobileNo, "Please enter a valid Mobile Number");
                EnableButton();
            }
            else
            {

                ema = true;
                labelM.Visible = false;
                errorProvider1.Clear();

                EnableButton();
            }
        }

        private void SellerSignUp_Profile_Picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image (*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gunaCirclePictureBox1.Image = new Bitmap(ofd.FileName);
                dp = true;
                EnableButton();
            }
        }

        private void SellerSignUp_male_radio_bttn_CheckedChanged(object sender, EventArgs e)
        {
            gen = true;
            gender = SellerSignUp_male_radio_bttn.Text;
            EnableButton();
        }

        private void SellerSignUp_female_radio_bttn_CheckedChanged(object sender, EventArgs e)
        {
            gen = true;
            gender = SellerSignUp_female_radio_bttn.Text;
            EnableButton();
        }

        private void SellerSignUp_other_radio_bttn_CheckedChanged(object sender, EventArgs e)
        {
            gen = true;
            gender = SellerSignUp_other_radio_bttn.Text;
            EnableButton();
        }

        private void SellerSignUp_ResetAll_Click(object sender, EventArgs e)
        {
            SellerSignUp_Firstname.Text = "";
            SellerSignUp_Lastname.Text = "";
            SellerSignUp_Email.Text = "";
            SellerSignUp_Country.Text = "";
            SellerSignUp_MobileNo.Text = "";
            SellerSignUpDOB.Value = DateTime.Now;
            SellerSignUp_female_radio_bttn.Checked = false;
            SellerSignUp_male_radio_bttn.Checked = false;
            SellerSignUp_other_radio_bttn.Checked = false;
             gunaCirclePictureBox1.Image = Properties.Resources.red_default1;
            //gunaCirclePictureBox1.Image = Image.FromFile("../Resources/profile_icon1.png"); 
            fna = lna = ema = con = mbl = gen = dp = false;
            EnableButton();
        }

        private void SellerSignUp_NextBttn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Please Fillup all information..");

            Fname = SellerSignUp_Firstname.Text;
            Lname = SellerSignUp_Lastname.Text;
            Email = SellerSignUp_Email.Text;
            country = SellerSignUp_Country.Text;
            mobile = SellerSignUp_MobileNo.Text;

            picture = Savephoto();
            dob = Convert.ToString(SellerSignUpDOB.Value);



            this.Hide();
            new Seller_SignUp2().Show();
            //  (GetPhoto(picture));
        }

        private void Seller_SignUp1_Load(object sender, EventArgs e)
        {
            SellerSignUpDOB.Value = DateTime.Now;
            labelE.Visible = false;
            labelM.Visible = false;
        }

        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            gunaCirclePictureBox1.Image.Save(ms, gunaCirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        public void EnableButton()
        {
            if (fna && lna && ema && con && mbl && gen && dp)
            {

                SellerSignUp_NextBttn.Enabled = true;
            }
            else
            {

                SellerSignUp_NextBttn.Enabled = false;
            }

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp_Menu().Show();
        }
    }
}
