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
    public partial class Seller_SignUp2 : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Boolean una = false;
        Boolean pas = false;
        Boolean veri = false;
        Boolean des = false;
        Boolean skil = false;

        static String EMAIL = "";
        String FULL_NAME = "";
        static String FIRST_NAME = "";
        static String LAST_NAME = "";
        String COUNTRY_CODE = "";
        static String MOBILE_NUMBER = "";
        static String GENDER = "";


        static String DATE_OF_BIRTH = "";
        String BIRTH_DATE = "";
        String BIRTH_MONTH = "";
        String BIRTH_YEAR = "";
        String AGE = "";
        String NID_NUMBER = "";
        String PASSPORT_NUMBER = "";
        static String COUNTRY = "";
        String NATIONALITY = "";
        String STREET_ADDRESS = "";
        String ADDRESS_LINE_2 = "";
        String CITY = "";
        String STATE = "";


        String USER_NAME = "";
        String PASSWORD = "";
        byte[] PROFILE_PICTURE;
        String PROMOTIONAL_EMAIL = "";
        String STATUS = "";
        String STATUS_MESSAGE = "";
        String RAW_POST = "";



        String BASIC_SKILLS = "";
        String OTHER_SKILLS = "";
        String EXPERT_ON = "";
        String DEMO_PROJECTS = "";

        String BANK_ACCOUNT_NUMBER = "";
        String DESCRIPTION = "";
        String HAVE_BUYER = "";
        String SIGN_UP_TIME = "";
        String SIGN_UP_IP = "";

        String TOTAL_RATING = "";
        String TOTAL_RATED_NUMBER = "";


        String otp = "";

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Seller_SignUp2()
        {
            InitializeComponent();

            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;

        }

        private void SellerSignUp_Username_TextChanged(object sender, EventArgs e)
        {
            {
                Boolean buyern = false;
                if (string.IsNullOrEmpty(SellerSignUp_Username.Text))
                {
                    una = false;
                    EnableButton();
                }
                else
                {


                    {
                        SqlConnection con = new SqlConnection(cs);
                        String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", SellerSignUp_Username.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {
                            una = false;
                            EnableButton();
                            label9.Text = "Username (This Username has already taken)";
                        }

                        else
                        {
                            buyern = true;
                            /* una = true;
                             EnableButton();
                             label9.Text = "Username";*/
                        }

                        con.Close();
                    }
                    if (buyern)
                    {
                        SqlConnection con = new SqlConnection(cs);
                        String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@user", SellerSignUp_Username.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {
                            una = false;
                            EnableButton();
                            label9.Text = "Username (This Username has already taken)";
                        }

                        else
                        {

                            una = true;
                            EnableButton();
                            label9.Text = "Username";
                        }

                        con.Close();
                    }



                }
            }
        }

        private void SellerSignUp_Password_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Password.Text))
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

        private void SellerSignUp_Verification_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Verification.Text))
            {
                veri = false;
                EnableButton();
            }
            else
            {

                veri = true;
                EnableButton();
            }
        }

        private void SellerSignUp_SendMailBttn_Click(object sender, EventArgs e)
        {
            SellerSignUp_Verification.Enabled = true;
            USER_NAME = SellerSignUp_Username.Text;
            PASSWORD = SellerSignUp_Password.Text;
            RAW_Function rf = new RAW_Function();
            otp = RandomString(6);
            rf.MailSender("system.confirmation.validity@gmail.com", "RAW - Verification", EMAIL, FIRST_NAME, "cezsxtphsghceajb", "Verification of RAW Account", "<h3>Dear " + LAST_NAME + ",</h3> <br> Your verification code is: " + otp + " <br> <br><br><br>Enter this code in RAW software to activate your Seller account.<br>Your User Name: " + USER_NAME + "<br><br>Once your account is activated, you will be able to login to your RAW portal. <br><br> If this wasn't you:<br> keep calm we will not register your account without this confirmation code. <br><br><br> Do not reply here. <br><br><br> If you have any questions, send us an email( raw.helpdesk@gmail.com ). <br><br><br> Thanks, <br> RAW <br><br><br><br><br>All rights reserved @Team RAW. ");
        }

        private void SellerSignUp_VerifyBttn_Click(object sender, EventArgs e)
        {
            if (SellerSignUp_Verification.Text.Equals(otp))
            {
                label10.Text = "Verification Success";
                SellerSignUp_SendMailBttn.Enabled = false;
                SellerSignUp_VerifyBttn.Enabled = false;
                SellerSignUp_Verification.Enabled = false;
            }
        }

        private void SellerSignUp_Description_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Description.Text))
            {
                des = false;
                EnableButton();
            }
            else
            {

                des = true;
                EnableButton();
            }
        }

        private void SellerSignUp_Skills_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SellerSignUp_Skills.Text))
            {
                skil = false;
                EnableButton();
            }
            else
            {

                skil = true;
                EnableButton();
            }
        }

        private void SellerSignUp_BackBttn_Click(object sender, EventArgs e)
        {
            SellerSignUp_Username.Text = "";
            SellerSignUp_Password.Text = "";
            SellerSignUp_Verification.Text = "";
            SellerSignUp_Description.Text = "";
            SellerSignUp_Skills.Text = "";



            
            SellerSignUp_SendMailBttn.Enabled = true;
            SellerSignUp_VerifyBttn.Enabled = false;
            label10.Text = "";
            una = pas = veri = des = veri = una = pas = false;
            EnableButton();
        }

        private void SellerSignUp_SignUpBttn_Click(object sender, EventArgs e)
        {
            FULL_NAME = FIRST_NAME + " " + LAST_NAME;

            COUNTRY_CODE = "N/A";
            BIRTH_DATE = ".";
            BIRTH_MONTH = ".";
            BIRTH_YEAR = ".";
            AGE = ".";


            NID_NUMBER = "N/A";
            PASSPORT_NUMBER = "N/A";

            NATIONALITY = "N/A";
            STREET_ADDRESS = "N/A";
            ADDRESS_LINE_2 = "N/A";
            CITY = "N/A";
            STATE = "N/A";

            PROMOTIONAL_EMAIL = "N/A";
            STATUS = "Active";
            STATUS_MESSAGE = "I am available.";
            RAW_POST = "Seller";



            BASIC_SKILLS = SellerSignUp_Skills.Text;
            OTHER_SKILLS = "N/A";
            EXPERT_ON = "N/A";
            DEMO_PROJECTS = "N/A";

            BANK_ACCOUNT_NUMBER = label6.Text;
            DESCRIPTION = SellerSignUp_Description.Text;
            HAVE_BUYER = "N/A";

            RAW_Function rf = new RAW_Function();

            SIGN_UP_TIME = rf.time();
            SIGN_UP_IP = "N/A";

            TOTAL_RATING = "0.00";
            TOTAL_RATED_NUMBER = "0";

            String AMOUNT = "0";


            SqlConnection con2 = new SqlConnection(cs);
            String query2 = "INSERT INTO SELLER_SIGNUP_BASIC_DETAILS VALUES(@user, @email, @fullname, @firstname, @lastname, @countrycode, @mobile, @gender);";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@user", USER_NAME);
            cmd2.Parameters.AddWithValue("@email", EMAIL);
            cmd2.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd2.Parameters.AddWithValue("@firstname", FIRST_NAME);
            cmd2.Parameters.AddWithValue("@lastname", LAST_NAME);
            cmd2.Parameters.AddWithValue("@countrycode", COUNTRY_CODE);
            cmd2.Parameters.AddWithValue("@mobile", MOBILE_NUMBER);
            cmd2.Parameters.AddWithValue("@gender", GENDER);


            con2.Open();
            int a2 = cmd2.ExecuteNonQuery();

            if (a2 > 0)
            {

            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con2.Close();


            SqlConnection con3 = new SqlConnection(cs);
            String query3 = "INSERT INTO SELLER_SIGNUP_PERSONAL_DETAILS VALUES(@user, @email, @fullname, @dob, @birthdate, @birthmonth, @birthyear, @age,@nid,@passport,@country,@nationality,@street,@address2,@city,@state);";
            SqlCommand cmd3 = new SqlCommand(query3, con3);
            cmd3.Parameters.AddWithValue("@user", USER_NAME);
            cmd3.Parameters.AddWithValue("@email", EMAIL);
            cmd3.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd3.Parameters.AddWithValue("@dob", DATE_OF_BIRTH);
            cmd3.Parameters.AddWithValue("@birthdate", BIRTH_DATE);
            cmd3.Parameters.AddWithValue("@birthmonth", BIRTH_MONTH);
            cmd3.Parameters.AddWithValue("@birthyear", BIRTH_YEAR);
            cmd3.Parameters.AddWithValue("@age", AGE);
            cmd3.Parameters.AddWithValue("@nid", NID_NUMBER);
            cmd3.Parameters.AddWithValue("@passport", PASSPORT_NUMBER);
            cmd3.Parameters.AddWithValue("@country", COUNTRY);
            cmd3.Parameters.AddWithValue("@nationality", NATIONALITY);
            cmd3.Parameters.AddWithValue("@street", STREET_ADDRESS);
            cmd3.Parameters.AddWithValue("@address2", ADDRESS_LINE_2);
            cmd3.Parameters.AddWithValue("@city", CITY);
            cmd3.Parameters.AddWithValue("@state", STATE);



            con3.Open();
            int a3 = cmd3.ExecuteNonQuery();

            if (a3 > 0)
            {

            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con3.Close();

            SqlConnection con4 = new SqlConnection(cs);
            String query4 = "INSERT INTO SELLER_SIGNUP_USER_DETAILS VALUES(@user, @email, @fullname, @pass, @profilepic, @promoemail, @status, @statusmsg,@rawpost);";
            SqlCommand cmd4 = new SqlCommand(query4, con4);
            cmd4.Parameters.AddWithValue("@user", USER_NAME);
            cmd4.Parameters.AddWithValue("@email", EMAIL);
            cmd4.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd4.Parameters.AddWithValue("@pass", PASSWORD);
            cmd4.Parameters.AddWithValue("@profilepic", Seller_SignUp1.picture);
            cmd4.Parameters.AddWithValue("@promoemail", PROMOTIONAL_EMAIL);
            cmd4.Parameters.AddWithValue("@status", STATUS);
            cmd4.Parameters.AddWithValue("@statusmsg", STATUS_MESSAGE);
            cmd4.Parameters.AddWithValue("@rawpost", RAW_POST);
            con4.Open();
            int a4 = cmd4.ExecuteNonQuery();

            if (a4 > 0)
            {

            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con4.Close();

            SqlConnection con5 = new SqlConnection(cs);
            String query5 = "INSERT INTO SELLER_SIGNUP_USER_SKILLS VALUES(@user, @email, @fullname, @basicskills, @otherskills, @experton, @demo);";
            SqlCommand cmd5 = new SqlCommand(query5, con5);
            cmd5.Parameters.AddWithValue("@user", USER_NAME);
            cmd5.Parameters.AddWithValue("@email", EMAIL);
            cmd5.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd5.Parameters.AddWithValue("@basicskills", BASIC_SKILLS);
            cmd5.Parameters.AddWithValue("@otherskills", OTHER_SKILLS);
            cmd5.Parameters.AddWithValue("@experton", EXPERT_ON);
            cmd5.Parameters.AddWithValue("@demo", DEMO_PROJECTS);
            con5.Open();
            int a5 = cmd5.ExecuteNonQuery();

            if (a5 > 0)
            {

            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con5.Close();

            SqlConnection con6 = new SqlConnection(cs);
            String query6 = "INSERT INTO SELLER_SIGNUP_ACCOUNT_DETAILS VALUES(@user, @email, @fullname, @accno, @description, @haveseller, @signuptime, @signupip);";
            SqlCommand cmd6 = new SqlCommand(query6, con6);
            cmd6.Parameters.AddWithValue("@user", USER_NAME);
            cmd6.Parameters.AddWithValue("@email", EMAIL);
            cmd6.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd6.Parameters.AddWithValue("@accno", BANK_ACCOUNT_NUMBER);
            cmd6.Parameters.AddWithValue("@description", DESCRIPTION);
            cmd6.Parameters.AddWithValue("@haveseller", HAVE_BUYER);
            cmd6.Parameters.AddWithValue("@signuptime", SIGN_UP_TIME);
            cmd6.Parameters.AddWithValue("@signupip", SIGN_UP_IP);
            con6.Open();
            int a6 = cmd6.ExecuteNonQuery();

            if (a6 > 0)
            {

            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con6.Close();

            SqlConnection con7 = new SqlConnection(cs);
            String query7 = "INSERT INTO SELLER_TOTAL_RATING VALUES(@user, @email, @fullname, @currentrate, @totalrate);";
            SqlCommand cmd7 = new SqlCommand(query7, con7);
            cmd7.Parameters.AddWithValue("@user", USER_NAME);
            cmd7.Parameters.AddWithValue("@email", EMAIL);
            cmd7.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd7.Parameters.AddWithValue("@currentrate", TOTAL_RATING);
            cmd7.Parameters.AddWithValue("@totalrate", TOTAL_RATED_NUMBER);
            con7.Open();
            int a7 = cmd7.ExecuteNonQuery();

            if (a7 > 0)
            {
              
            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con7.Close();

            SqlConnection con8 = new SqlConnection(cs);
            String query8 = "INSERT INTO ACCOUNT VALUES(@user,@acno, @amount);";
            SqlCommand cmd8 = new SqlCommand(query8, con8);
            cmd8.Parameters.AddWithValue("@user", USER_NAME);
            cmd8.Parameters.AddWithValue("@acno", BANK_ACCOUNT_NUMBER);
            cmd8.Parameters.AddWithValue("@amount", AMOUNT);

            con8.Open();
            int a8 = cmd8.ExecuteNonQuery();

            if (a8 > 0)
            {


            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con8.Close();




            DialogResult ok = MessageBox.Show("SignUp Successful", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (ok == DialogResult.OK)
            {
                this.Hide();
                new SignUp_Successfull().Show();
            }
            else
            {
                this.Hide();
                new SignUp_Successfull().Show();
            }


        }

        private void Seller_SignUp2_Load(object sender, EventArgs e)
        {
            SellerSignUp_Password.UseSystemPasswordChar = true;
            label6.Text = "RAC-" + RandomString(10);

            FIRST_NAME = Seller_SignUp1.Fname;
            LAST_NAME = Seller_SignUp1.Lname;
            EMAIL = Seller_SignUp1.Email;
            COUNTRY = Seller_SignUp1.country;
            MOBILE_NUMBER = Seller_SignUp1.mobile;
            PROFILE_PICTURE = Seller_SignUp1.picture;
            DATE_OF_BIRTH = Seller_SignUp1.dob;
            GENDER = Seller_SignUp1.gender;

        }


        public void EnableButton()
        {


            if (una && pas)
            {
                SellerSignUp_SendMailBttn.Enabled = true;

                if (veri)
                {
                    SellerSignUp_VerifyBttn.Enabled = true;

                    if (skil && des && veri && una && pas)
                    {

                        SellerSignUp_SignUpBttn.Enabled = true;
                    }
                    else
                    {

                        SellerSignUp_SignUpBttn.Enabled = false;
                    }
                }
                else
                {
                    SellerSignUp_VerifyBttn.Enabled = false;

                }
            }
            else
            {

                SellerSignUp_SendMailBttn.Enabled = false;
            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp_Menu().Show();
        }

        private void CheckBoxTerm_CheckedChanged(object sender, EventArgs e)
        {
            bool status = CheckBoxTerm.Checked;

            switch (status)
            {
                case true:
                    SellerSignUp_Password.UseSystemPasswordChar = false;
                    break;
                default:
                    SellerSignUp_Password.UseSystemPasswordChar = true;
                    break;
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
