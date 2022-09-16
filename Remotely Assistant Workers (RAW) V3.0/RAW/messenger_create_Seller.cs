using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAW
{
    class messenger_create_Seller
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        String cs1 = ConfigurationManager.ConnectionStrings["RAW_MESSENGER"].ConnectionString;
        public static Seller_Messenger sm;

        public void setRecName(String sendName, String recName)
        {
            Boolean sissender = false;
            Boolean rissender = false;
            String tableName = "";


            SqlConnection con = new SqlConnection(cs);
            String query = "SELECT * FROM MESSENGER WHERE SENDER_NAME= @sname AND REC_NAME= @rname;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sname", sendName);
            cmd.Parameters.AddWithValue("@rname", recName);
            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {
                while (sda.Read())
                {

                    sissender = true;
                    tableName = (sda["TABLE_NAME"].ToString());
                }
            }
            con.Close();


            if (!sissender)
            {
                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "SELECT * FROM MESSENGER WHERE SENDER_NAME= @rname AND REC_NAME= @sname;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@sname", sendName);
                cmd1.Parameters.AddWithValue("@rname", recName);
                con1.Open();
                SqlDataReader sda1 = cmd1.ExecuteReader();
                if (sda1.HasRows == true)
                {
                    while (sda1.Read())
                    {

                        rissender = true;
                        tableName = (sda1["TABLE_NAME"].ToString());
                    }
                }
                con1.Close();

            }

            if (!sissender && !rissender)
            {
                String POST_TIME = new RAW_Function().dtime();
                Boolean hasTable = false;
                tableName = sendName + "_TO_" + recName;
                tableName = tableName.Replace(" ", "_");

                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "INSERT INTO MESSENGER VALUES(@sname,@rname,@tname,@time);";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@sname", sendName);
                cmd1.Parameters.AddWithValue("@rname", recName);
                cmd1.Parameters.AddWithValue("@tname", tableName);
                cmd1.Parameters.AddWithValue("@time", POST_TIME);



                con1.Open();
                int a = cmd1.ExecuteNonQuery();

                if (a > 0)
                {


                    SqlConnection connection = new SqlConnection(cs1);


                    connection.Open();

                    SqlCommand commandCT = new SqlCommand("SELECT name FROM sys.Tables", connection);
                    SqlDataReader reader = commandCT.ExecuteReader();
                    while (reader.Read())
                    {

                        if (reader["name"].ToString().Equals(tableName))
                        {
                            hasTable = true;
                        }
                    }
                    connection.Close();

                    if (!hasTable)
                    {
                        SqlConnection adcon = new SqlConnection(cs1);
                        String adQ = "CREATE TABLE " + tableName + " ( MSGID int NOT NULL IDENTITY(1,1), SENDER_NAME VARCHAR(100), REC_NAME VARCHAR(100), MESSAGE VARCHAR(1000),  TIME VARCHAR(200));";

                        SqlCommand adcmd = new SqlCommand(adQ, adcon);
                        adcon.Open();
                        adcmd.ExecuteReader();
                        adcon.Close();

                    }


                }
                else
                {

                }
                con1.Close();



            }


            if ((sissender || rissender) || (sissender && rissender))
            {



                sm.showUserRight(recName, tableName);




            }




        }

    }
}
