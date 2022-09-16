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
    class Job_Info
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        public static String BUYER_NAME = "";
        public static String JOB_ID = "";
        public static byte[] JOB_IMAGE;
        public static String JOB_NAME = "";
        public static String JOB_SKILLS = "";
        public static String JOB_PRICE = "";
        public static String JOB_TIME = "";
        public static String JOB_DETAILS = "";
        public static String JOB_STATUS = "";
        public static String POST_TIME = "";



        public static String SELLER_NAME = "";
        public static String SELLER_ACCEPT_TIME = "";
        public static String JOB_ENDING_TIME = "";
        public static String SUBMISSION_TIME = "";
        public static String WORK_ACCEPT_TIME = "";





        public static String CANCEL_REQUESTED_BY = "";
        public static String CANCEL_ACCEPT_BY = "";
        public static String CANCELATION_TIME = "";
        public static String CANCEL_REQUEST_TIME = "";
       





        
        public static String TRANSACTION_ID = "";


        public static String SUBMITTED_LINK = "";
        public static String BUYER_COMMENT = "";










        public Job_Info()
        { }

        public Job_Info(String jid)
        {

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM JOB_INFO WHERE JOB_ID= @id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", jid);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {
                      


        BUYER_NAME = (sda["BUYER_NAME"].ToString());
                        JOB_ID = (sda["JOB_ID"].ToString());
                        JOB_IMAGE = ((byte[])(sda["JOB_IMAGE"]));

                        JOB_NAME = (sda["JOB_NAME"].ToString());
                        JOB_SKILLS = (sda["JOB_SKILLS"].ToString());
                        JOB_PRICE = (sda["JOB_PRICE"].ToString());
                        JOB_TIME = (sda["JOB_TIME"].ToString());
                        JOB_DETAILS = (sda["JOB_DETAILS"].ToString());
                        JOB_STATUS = (sda["JOB_STATUS"].ToString());
                        POST_TIME = (sda["POST_TIME"].ToString());


                    }

                }

                else
                {
                   

                }

                con.Close();
            }


            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM PROGRESS_JOB WHERE JOB_ID= @id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", jid);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {
                      


                        SELLER_NAME = (sda["SELLER_NAME"].ToString());
                        SELLER_ACCEPT_TIME = (sda["SELLER_ACCEPT_TIME"].ToString());


                        JOB_ENDING_TIME = (sda["JOB_ENDING_TIME"].ToString());
                        SUBMISSION_TIME = (sda["SUBMISSION_TIME"].ToString());
                        WORK_ACCEPT_TIME = (sda["WORK_ACCEPT_TIME"].ToString());
                      

                    }

                }

                else
                {
                    

                }

                con.Close();
            }



            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM CANCEL_JOB WHERE JOB_ID= @id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", jid);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {
                        SELLER_NAME = (sda["SELLER_NAME"].ToString());
                        CANCEL_REQUESTED_BY = (sda["CANCEL_REQUESTED_BY"].ToString());
                        CANCEL_ACCEPT_BY = (sda["CANCEL_ACCEPT_BY"].ToString());


                        CANCELATION_TIME = (sda["CANCELATION_TIME"].ToString());
                        CANCEL_REQUEST_TIME = (sda["CANCEL_REQUEST_TIME"].ToString());
                        


                    }

                }

                else
                {


                }

                con.Close();
            }

            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM SUBMITTED_JOB WHERE JOB_ID= @id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", jid);

                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {

                    while (sda.Read())
                    {
                        SELLER_NAME = (sda["SELLER_NAME"].ToString());
                        TRANSACTION_ID = (sda["TRANSACTION_ID"].ToString());
                        SUBMITTED_LINK = (sda["SUBMITTED_LINK"].ToString());


                        BUYER_COMMENT = (sda["BUYER_COMMENT"].ToString());
                       



                    }

                }

                else
                {


                }

                con.Close();
            }














        }








    }
}
