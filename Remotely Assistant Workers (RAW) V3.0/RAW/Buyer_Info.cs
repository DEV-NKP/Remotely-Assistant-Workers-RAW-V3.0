using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    class Buyer_Info
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;


       public static String EMAIL = "";
        public static String FULL_NAME = "";
        public static String FIRST_NAME = "";
        public static String LAST_NAME = "";
        public static String COUNTRY_CODE = "";
        public static String MOBILE_NUMBER = "";
        public static String GENDER = "";


        public static String DATE_OF_BIRTH = "";
        public static String BIRTH_DATE = "";
        public static String BIRTH_MONTH = "";
        public static String BIRTH_YEAR = "";
        public static String AGE = "";
        public static String NID_NUMBER = "";
        public static String PASSPORT_NUMBER = "";
        public static String COUNTRY = "";
        public static String NATIONALITY = "";
        public static String STREET_ADDRESS = "";
        public static String ADDRESS_LINE_2 = "";
        public static String CITY = "";
        public static String STATE = "";


        public static String USER_NAME = "";
        public static String PASSWORD = "";
        public static byte[] PROFILE_PICTURE;
        public static String PROMOTIONAL_EMAIL = "";
        public static String STATUS = "";
        public static String STATUS_MESSAGE = "";
        public static String RAW_POST = "";





        public static String BANK_ACCOUNT_NUMBER = "";
        public static String DESCRIPTION = "";
        public static String HAVE_SELLER = "";
        public static String SIGN_UP_TIME = "";
        public static String SIGN_UP_IP = "";

        public static String TOTAL_RATING = "";
        public static String TOTAL_RATED_NUMBER = "";

        public static String COMPANY_NAME = "";
        public static String COMPANY_TYPE = "";
        public static String COMPANY_DESIGNATION = "";
        public static String WORKERS_AMOUNT = "";
        public static String COMPANY_ADDRESS = "";
        public static String BUYER_REASON = "";

        public static String AMOUNT = "";


        public Buyer_Info()
        { }

        public Buyer_Info(String uname)
        {


            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_BASIC_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {
                        FULL_NAME = (sda["FULL_NAME"].ToString());
                        FIRST_NAME = (sda["FIRST_NAME"].ToString());
                        LAST_NAME = (sda["LAST_NAME"].ToString());
                        COUNTRY_CODE = (sda["COUNTRY_CODE"].ToString());
                        MOBILE_NUMBER = (sda["MOBILE_NUMBER"].ToString());
                        GENDER = (sda["GENDER"].ToString());

                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured1. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_PERSONAL_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {



                        DATE_OF_BIRTH = (sda["DATE_OF_BIRTH"].ToString());
                        BIRTH_DATE = (sda["BIRTH_DATE"].ToString());
                        BIRTH_MONTH = (sda["BIRTH_MONTH"].ToString());
                        BIRTH_YEAR = (sda["BIRTH_YEAR"].ToString());
                        AGE = (sda["AGE"].ToString());
                        NID_NUMBER = (sda["NID_NUMBER"].ToString());
                        PASSPORT_NUMBER = (sda["PASSPORT_NUMBER"].ToString());
                        COUNTRY = (sda["COUNTRY"].ToString());
                        NATIONALITY = (sda["NATIONALITY"].ToString());
                        STREET_ADDRESS = (sda["STREET_ADDRESS"].ToString());
                        ADDRESS_LINE_2 = (sda["ADDRESS_LINE_2"].ToString());
                        CITY = (sda["CITY"].ToString());
                        STATE = (sda["STATE"].ToString());

                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured2. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {


                        USER_NAME = (sda["USER_NAME"].ToString());
                        PASSWORD = (sda["PASSWORD"].ToString());
                        EMAIL = (sda["EMAIL"].ToString());
                        PROFILE_PICTURE = ((byte[])(sda["PROFILE_PICTURE"]));
                        PROMOTIONAL_EMAIL = (sda["PROMOTIONAL_EMAIL"].ToString());
                        STATUS = (sda["STATUS"].ToString());
                        STATUS_MESSAGE = (sda["STATUS_MESSAGE"].ToString());

                        RAW_POST = (sda["RAW_POST"].ToString());


                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured3. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_COMPANY_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {




                        COMPANY_NAME = (sda["COMPANY_NAME"].ToString());
                        COMPANY_TYPE = (sda["COMPANY_TYPE"].ToString());
                        COMPANY_DESIGNATION = (sda["COMPANY_DESIGNATION"].ToString());
                        WORKERS_AMOUNT = (sda["WORKERS_AMOUNT"].ToString());
                        COMPANY_ADDRESS = (sda["COMPANY_ADDRESS"].ToString());
                        BUYER_REASON = (sda["BUYER_REASON"].ToString());
                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured4. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_SIGNUP_ACCOUNT_DETAILS WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {


                        BANK_ACCOUNT_NUMBER = (sda["BANK_ACCOUNT_NUMBER"].ToString());
                        DESCRIPTION = (sda["DESCRIPTION"].ToString());
                        HAVE_SELLER = (sda["HAVE_SELLER"].ToString());
                        SIGN_UP_TIME = (sda["SIGN_UP_TIME"].ToString());
                        SIGN_UP_IP = (sda["SIGN_UP_IP"].ToString());

                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured5. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM BUYER_TOTAL_RATING WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {


                        TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                        TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());
                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured6. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }




            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM ACCOUNT WHERE USER_NAME= @user;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", uname);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {


                        AMOUNT = (sda["AMOUNT"].ToString());
                       
                    }

                }

                else
                {
                    MessageBox.Show("OOPS!!! Sorry. An error occured6. Please try again.");
                    Application.Exit();

                }

                con.Close();
            }
        }
    }
}
