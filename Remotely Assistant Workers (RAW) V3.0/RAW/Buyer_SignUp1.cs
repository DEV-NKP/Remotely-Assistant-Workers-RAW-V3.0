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
    public partial class Buyer_SignUp1 : Form
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


        public Buyer_SignUp1()
        {
            InitializeComponent();

            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;
        }

        private void BuyerSignUp_Firstname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuyerSignUp_Firstname.Text))
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

        private void BuyerSignUp_Lastname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuyerSignUp_Lastname.Text))
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

        private void BuyerSignUp_Email_TextChanged(object sender, EventArgs e)
        {
            RAW_Function rw = new RAW_Function();

            {
                if (string.IsNullOrEmpty(BuyerSignUp_Email.Text))
                {
                    ema = false;
                    EnableButton();
                }
                else
                {

                    ema = true;
                    EnableButton();
                }

                if (!rw.IsValidEmail(BuyerSignUp_Email.Text))
                {
                    ema = false; 
                    labelE.Visible = true;
                    errorProvider1.SetError(this.BuyerSignUp_Email, "Please enter a valid Email");

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
            String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE EMAIL= @email;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", BuyerSignUp_Email.Text);

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

        private void BuyerSignUp_Country_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuyerSignUp_Country.Text))
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

        private void BuyerSignUp_MobileNo_TextChanged(object sender, EventArgs e)
        {
            RAW_Function rw = new RAW_Function();
            if (string.IsNullOrEmpty(BuyerSignUp_MobileNo.Text))
            {
                mbl = false;
                EnableButton();
            }
            else
            {

                mbl = true;
                EnableButton();
            }
            if (!rw.IsValidMobile(BuyerSignUp_MobileNo.Text))
            {
                ema = false;
                labelM.Visible = true;
                errorProvider1.SetError(this.BuyerSignUp_MobileNo,"Please enter a valid Mobile Number");
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

        private void BuyerSignUp_Profile_Picture_Click(object sender, EventArgs e)
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

        private void BuyerSignUp_male_radio_bttn_CheckedChanged(object sender, EventArgs e)
        {
            gen = true;
            gender = BuyerSignUp_male_radio_bttn.Text;
            EnableButton();
        }

        private void BuyerSignUp_female_radio_bttn_CheckedChanged(object sender, EventArgs e)
        {
            gen = true;
            gender = BuyerSignUp_female_radio_bttn.Text;
            EnableButton();
        }

        private void BuyerSignUp_other_radio_bttn_CheckedChanged(object sender, EventArgs e)
        {
            gen = true;
            gender = BuyerSignUp_other_radio_bttn.Text;
            EnableButton();
        }

        private void BuyerSignUp_ResetAll_Click(object sender, EventArgs e)
        {
            BuyerSignUp_Firstname.Text = "";
            BuyerSignUp_Lastname.Text = "";
            BuyerSignUp_Email.Text = "";
            BuyerSignUp_Country.Text = "";
            BuyerSignUp_MobileNo.Text = "";
            BuyerSignUpDOB.Value = DateTime.Now;
            BuyerSignUp_female_radio_bttn.Checked = false;
            BuyerSignUp_male_radio_bttn.Checked = false;
            BuyerSignUp_other_radio_bttn.Checked = false;
             gunaCirclePictureBox1.Image = Properties.Resources.red_default1;
            //gunaCirclePictureBox1.Image = Image.FromFile("../Resources/profile_icon1.png"); 
            fna = lna = ema = con = mbl = gen = dp = false;
            EnableButton();
        }

        private void BuyerSignUp_Next_Click(object sender, EventArgs e)
        {
            Fname = BuyerSignUp_Firstname.Text;
            Lname = BuyerSignUp_Lastname.Text;
            Email = BuyerSignUp_Email.Text;
            country = BuyerSignUp_Country.Text;
            mobile = BuyerSignUp_MobileNo.Text;

            picture = Savephoto();
            dob = Convert.ToString(BuyerSignUpDOB.Value);

            this.Hide();
            new Buyer_SignUp2().Show();

          //  Buyer_SignUp_Page_3 ssp3 = new Buyer_SignUp_Page_3();
            //ssp3.setValue();
            //this.SendToBack();
            //  (GetPhoto(picture));
        }

        private void Buyer_SignUp1_Load(object sender, EventArgs e)
        {
            BuyerSignUpDOB.Value = DateTime.Now;
            labelE.Visible = false;
            labelM.Visible = false;
        }


        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            gunaCirclePictureBox1.Image.Save(ms, gunaCirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


        public void EnableButton()
        {
            if (fna && lna && ema && con && mbl && gen && dp)
            {

                BuyerSignUp_Next.Enabled = true;
            }
            else
            {

                BuyerSignUp_Next.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp_Menu().Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
