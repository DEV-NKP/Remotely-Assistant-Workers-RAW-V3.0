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
    public partial class Buyer_SignUp2 : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Boolean una = false;
        Boolean pas = false;
        Boolean veri = false;
        Boolean des = false;
    //    Boolean skil = false;

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

        String COMPANY_NAME = "";
        String COMPANY_TYPE = "";
        String COMPANY_DESIGNATION = "";
        String WORKERS_AMOUNT = "";
        String COMPANY_ADDRESS = "";
        String BUYER_REASON = "";

      //  String BASIC_SKILLS = "";
       // String OTHER_SKILLS = "";
      //  String EXPERT_ON = "";
      //  String DEMO_PROJECTS = "";

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


        public Buyer_SignUp2()
        {
            InitializeComponent();

            pictureBox3.Parent = pictureBox1;
            pictureBox3.BackColor = Color.Transparent;

            
        }

        private void BuyerSignUp_Username_TextChanged(object sender, EventArgs e)
        {

            {
                Boolean buyern = false;
                if (string.IsNullOrEmpty(BuyerSignUp_Username.Text))
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
                        cmd.Parameters.AddWithValue("@user", BuyerSignUp_Username.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {
                            una = false;
                            EnableButton();
                            label8.Text = "Username (This Username has already taken)";
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
                        cmd.Parameters.AddWithValue("@user", BuyerSignUp_Username.Text);

                        con.Open();
                        SqlDataReader sda = cmd.ExecuteReader();
                        if (sda.HasRows == true)
                        {
                            una = false;
                            EnableButton();
                            label8.Text = "Username (This Username has already taken)";
                        }

                        else
                        {

                            una = true;
                            EnableButton();
                            label8.Text = "Username";
                        }

                        con.Close();
                    }



                }
            }
        }



        private void BuyerSignUp_Verification_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuyerSignUp_Verification.Text))
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void BuyerSignUp_Description_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuyerSignUp_Description.Text))
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

        private void BuyerSignUp_SendMailBttn_Click(object sender, EventArgs e)
        {
            BuyerSignUp_Verification.Enabled = true;
            USER_NAME = BuyerSignUp_Username.Text;
            PASSWORD = BuyerSignUp_Password.Text;
            RAW_Function rf = new RAW_Function();
            otp = RandomString(6);
            rf.MailSender("system.confirmation.validity@gmail.com", "RAW - Verification", EMAIL, FIRST_NAME, "cezsxtphsghceajb", "Verification of RAW Account", "<h3>Dear " + LAST_NAME + ",</h3> <br> Your verification code is: " + otp + " <br> <br><br><br>Enter this code in RAW software to activate your Buyer account.<br>Your User Name: " + USER_NAME + "<br><br>Once your account is activated, you will be able to login to your RAW portal. <br><br> If this wasn't you:<br> keep calm we will not register your account without this confirmation code. <br><br><br> Do not reply here. <br><br><br> If you have any questions, send us an email( raw.helpdesk@gmail.com ). <br><br><br> Thanks, <br> RAW <br><br><br><br><br>All rights reserved @Team RAW. ");

        }

        private void BuyerSignUp_SignUpBttn_Click(object sender, EventArgs e)
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
            RAW_POST = "Buyer";


            COMPANY_NAME = "N/A";
            COMPANY_TYPE = "N/A";
            COMPANY_DESIGNATION = "N/A";
            WORKERS_AMOUNT = "N/A";
            COMPANY_ADDRESS = "N/A";
            BUYER_REASON = "N/A";

            String AMOUNT = "0";
            /*BASIC_SKILLS = SellerSignUp_Skills.Text;
            OTHER_SKILLS = "N/A";
            EXPERT_ON = "N/A";
            DEMO_PROJECTS = "N/A";*/

            BANK_ACCOUNT_NUMBER = label6.Text;
            DESCRIPTION = BuyerSignUp_Description.Text;
            HAVE_BUYER = "N/A";

            RAW_Function rf = new RAW_Function();

            SIGN_UP_TIME = rf.time();
            SIGN_UP_IP = "N/A";

            TOTAL_RATING = "0.00";
            TOTAL_RATED_NUMBER = "0";

            SqlConnection con2 = new SqlConnection(cs);
            String query2 = "INSERT INTO BUYER_SIGNUP_BASIC_DETAILS VALUES(@user, @email, @fullname, @firstname, @lastname, @countrycode, @mobile, @gender);";
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
            String query3 = "INSERT INTO BUYER_SIGNUP_PERSONAL_DETAILS VALUES(@user, @email, @fullname, @dob, @birthdate, @birthmonth, @birthyear, @age,@nid,@passport,@country,@nationality,@street,@address2,@city,@state);";
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
            String query4 = "INSERT INTO BUYER_SIGNUP_USER_DETAILS VALUES(@user, @email, @fullname, @pass, @profilepic, @promoemail, @status, @statusmsg,@rawpost);";
            SqlCommand cmd4 = new SqlCommand(query4, con4);
            cmd4.Parameters.AddWithValue("@user", USER_NAME);
            cmd4.Parameters.AddWithValue("@email", EMAIL);
            cmd4.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd4.Parameters.AddWithValue("@pass", PASSWORD);
            cmd4.Parameters.AddWithValue("@profilepic", Buyer_SignUp1.picture);
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
            String query5 = "INSERT INTO BUYER_SIGNUP_COMPANY_DETAILS VALUES(@user, @email, @fullname, @companyname, @companytype, @companydesig, @workersamount, @companyadd, @buyerreason);";
            SqlCommand cmd5 = new SqlCommand(query5, con5);
            cmd5.Parameters.AddWithValue("@user", USER_NAME);
            cmd5.Parameters.AddWithValue("@email", EMAIL);
            cmd5.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd5.Parameters.AddWithValue("@companyname", COMPANY_NAME);
            cmd5.Parameters.AddWithValue("@companytype", COMPANY_TYPE);
            cmd5.Parameters.AddWithValue("@companydesig", COMPANY_DESIGNATION);
            cmd5.Parameters.AddWithValue("@workersamount", WORKERS_AMOUNT);
            cmd5.Parameters.AddWithValue("@companyadd", COMPANY_ADDRESS);
            cmd5.Parameters.AddWithValue("@buyerreason", BUYER_REASON);
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
            String query6 = "INSERT INTO BUYER_SIGNUP_ACCOUNT_DETAILS VALUES(@user, @email, @fullname, @accno, @description, @haveseller, @signuptime, @signupip);";
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
            String query7 = "INSERT INTO BUYER_TOTAL_RATING VALUES(@user, @email, @fullname, @currentrate, @totalrate);";
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

        private void Buyer_SignUp2_Load(object sender, EventArgs e)
        {
            BuyerSignUp_Password.UseSystemPasswordChar = true;


            label6.Text = "RAC-" + RandomString(10);

           // BuyerSignUp_Password.UseSystemPasswordChar = true;
            FIRST_NAME = Buyer_SignUp1.Fname;
            LAST_NAME = Buyer_SignUp1.Lname;
            EMAIL = Buyer_SignUp1.Email;
            COUNTRY = Buyer_SignUp1.country;
            MOBILE_NUMBER = Buyer_SignUp1.mobile;
            PROFILE_PICTURE = Buyer_SignUp1.picture;
            DATE_OF_BIRTH = Buyer_SignUp1.dob;
            GENDER = Buyer_SignUp1.gender;

        }


        public void EnableButton()
        {
            if (una && pas)
            {
                BuyerSignUp_SendMailBttn.Enabled = true;

                if (veri)
                {
                    BuyerSignUp_VerifyBttn.Enabled = true;

                    if (des && veri && una && pas)
                    {
                        BuyerSignUp_SignUpBttn.Enabled = true;
                    }
                    else
                    {
                        BuyerSignUp_SignUpBttn.Enabled = false;
                    }
                }
                else
                {
                    BuyerSignUp_VerifyBttn.Enabled = false;
                }
            }
            else
            {
                BuyerSignUp_SendMailBttn.Enabled = false;
            }
        }

        private void BuyerSignUp_VerifyBttn_Click(object sender, EventArgs e)
        {
            if (BuyerSignUp_Verification.Text.Equals(otp))
            {
                verification_success.Text = "Verification Success";
                BuyerSignUp_SendMailBttn.Enabled = false;
                BuyerSignUp_VerifyBttn.Enabled = false;
                BuyerSignUp_Verification.Enabled = false;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignUp_Menu().Show();
        }

        private void Buyer_SignUp_ResetALL_Click(object sender, EventArgs e)
        {
            BuyerSignUp_Username.Text = "";
            BuyerSignUp_Password.Text = "";
            BuyerSignUp_Verification.Text = "";
            BuyerSignUp_Description.Text = "";
            BuyerSignUp_SendMailBttn.Enabled = true;
            BuyerSignUp_VerifyBttn.Enabled = false;
            verification_success.Text = "";
            una = pas = veri = des = veri = una = pas = false;
            EnableButton();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckBoxTerm_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CheckBoxTerm.Checked)
            {
                BuyerSignUp_Password.UseSystemPasswordChar = false;
            }
            else
            {
                BuyerSignUp_Password.UseSystemPasswordChar = true;
            }
        }

        private void BuyerSignUp_PasswordChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BuyerSignUp_Password.Text))
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
    }
}
