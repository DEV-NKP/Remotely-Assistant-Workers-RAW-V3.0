using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    class RAW_Function
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        public String time()
        {

            var y = DateTime.Now;
            return (y.ToString("dd/MM/yyyy") + "," + y.ToString("HH-mm-s") + "|" + TimeZone.CurrentTimeZone.StandardName);

        }

        public String dtime()
        {

            //  var y = DateTime.Now;

            var y = DateTime.Now;
            return (y.ToString());
            // return (y.ToString("dd/MM/yyyy") + "," + y.ToString("HH-mm-s") + "|" + TimeZone.CurrentTimeZone.StandardName);


        }

        public String addDate(int x)
        {

            //  var y = DateTime.Now;

            var y = DateTime.Now.AddDays(x);
            return (y.ToString());
            // return (y.ToString("dd/MM/yyyy") + "," + y.ToString("HH-mm-s") + "|" + TimeZone.CurrentTimeZone.StandardName);


        }

        public String addDateWP(String pdate, int x)
        {

            //  var y = DateTime.Now;
            DateTime prev = Convert.ToDateTime(pdate);
            var y = prev.AddDays(x);
            return (y.ToString());
            // return (y.ToString("dd/MM/yyyy") + "," + y.ToString("HH-mm-s") + "|" + TimeZone.CurrentTimeZone.StandardName);


        }

        public String PastCounter(String a)
        {

            DateTime now = DateTime.Now;
            // DateTime then = DateTime.Now.AddDays(-7);

            DateTime then = Convert.ToDateTime(a);
            TimeSpan ts = now.Subtract(then);
           // return (ts.Days + " Days, " + ts.Hours + " Hours, " + ts.Minutes + " Minutes, " + ts.Seconds + " Seconds, " + ts.Milliseconds + " Milliseconds");
            return (ts.Days + "," + ts.Hours + "," + ts.Minutes + "," + ts.Seconds);


        }
        public String FutureCounter(String a)
        {

            DateTime now = DateTime.Now;
            // DateTime then = DateTime.Now.AddDays(-7);

            DateTime then = Convert.ToDateTime(a);
            TimeSpan ts = then.Subtract(now);

           // return (ts.Days + " Days, " + ts.Hours + " Hours, " + ts.Minutes + " Minutes, " + ts.Seconds + " Seconds, " + ts.Milliseconds + " Milliseconds");
            return (ts.Days + "," + ts.Hours + "," + ts.Minutes + "," + ts.Seconds);


        }


        public void MailSender(String Femail, String Fname, String Temail, String Tname, String pass, String sub, String htmltext)
        {

            var fromAddress = new MailAddress(Femail, Fname);
            var toAddress = new MailAddress(Temail, Tname);
            string fromPassword = pass;
            string subject = sub;
            string body = htmltext;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {

                smtp.Send(message);
            }


        }


        

        public void checkMe()
        {

            Boolean bsbd = false;
            Boolean ssbd = false;
            Boolean bspd = false;
            Boolean sspd = false;
            Boolean bsud = false;
            Boolean ssud = false;
            Boolean bscd = false;
            Boolean ssus = false;
            Boolean bsad = false;
            Boolean ssad = false;
            Boolean btr = false;
            Boolean str = false;
            Boolean fd = false;
            Boolean rp = false;
            Boolean ct = false;
            Boolean ad = false;
            Boolean bl = false;
            Boolean sl = false;
            Boolean bprp = false;
            Boolean sprp = false;
            Boolean ji = false;
            Boolean cj = false;
            Boolean pj = false;
            Boolean sj = false;
            Boolean ac = false;

            Boolean apj = false;
            Boolean msg = false;

            SqlConnection connection = new SqlConnection(cs);


            connection.Open();

            SqlCommand commandCT = new SqlCommand("SELECT name FROM sys.Tables", connection);
            SqlDataReader reader = commandCT.ExecuteReader();
            while (reader.Read())
            {

                if (reader["name"].ToString().Equals("BUYER_SIGNUP_BASIC_DETAILS"))
                {
                    bsbd = true;
                }
                if (reader["name"].ToString().Equals("BUYER_SIGNUP_PERSONAL_DETAILS"))
                {
                    bspd = true;

                }
                if (reader["name"].ToString().Equals("BUYER_SIGNUP_USER_DETAILS"))
                {
                    bsud = true;
                }
                if (reader["name"].ToString().Equals("BUYER_SIGNUP_COMPANY_DETAILS"))
                {
                    bscd = true;
                }
                if (reader["name"].ToString().Equals("BUYER_SIGNUP_ACCOUNT_DETAILS"))
                {
                    bsad = true;
                }
                if (reader["name"].ToString().Equals("SELLER_SIGNUP_BASIC_DETAILS"))
                {
                    ssbd = true;
                }
                if (reader["name"].ToString().Equals("SELLER_SIGNUP_PERSONAL_DETAILS"))
                {
                    sspd = true;
                }
                if (reader["name"].ToString().Equals("SELLER_SIGNUP_USER_DETAILS"))
                {
                    ssud = true;
                }
                if (reader["name"].ToString().Equals("SELLER_SIGNUP_USER_SKILLS"))
                {
                    ssus = true;
                }
                if (reader["name"].ToString().Equals("SELLER_SIGNUP_ACCOUNT_DETAILS"))
                {
                    ssad = true;
                }
                if (reader["name"].ToString().Equals("FEEDBACK"))
                {
                    fd = true;
                }
                if (reader["name"].ToString().Equals("REPORT"))
                {
                    rp = true;
                }
                if (reader["name"].ToString().Equals("CONTACT"))
                {
                    ct = true;
                }
                if (reader["name"].ToString().Equals("BUYER_TOTAL_RATING"))
                {
                    btr = true;
                }
                if (reader["name"].ToString().Equals("SELLER_TOTAL_RATING"))
                {
                    str = true;
                }
                if (reader["name"].ToString().Equals("ADMIN"))
                {
                    ad = true;
                }
                if (reader["name"].ToString().Equals("BUYER_LOGIN"))
                {
                    bl = true;
                }
                if (reader["name"].ToString().Equals("SELLER_LOGIN"))
                {
                    sl = true;
                }
                if (reader["name"].ToString().Equals("BUYER_PRP_DETAILS"))
                {
                    bprp = true;
                }
                if (reader["name"].ToString().Equals("SELLER_PRP_DETAILS"))
                {
                    sprp = true;
                }

                if (reader["name"].ToString().Equals("JOB_INFO"))
                {
                    ji = true;
                }
                if (reader["name"].ToString().Equals("PROGRESS_JOB"))
                {
                    pj = true;
                }
                if (reader["name"].ToString().Equals("CANCEL_JOB"))
                {
                    cj = true;
                }
                if (reader["name"].ToString().Equals("SUBMITTED_JOB"))
                {
                    sj = true;
                }
                if (reader["name"].ToString().Equals("ACCOUNT"))
                {
                    ac = true;
                }
                if (reader["name"].ToString().Equals("APPLY_JOB"))
                {
                    apj = true;
                }
                if (reader["name"].ToString().Equals("MESSENGER"))
                {
                    msg = true;
                }

            }
            connection.Close();


            if (!ad)
            {
                SqlConnection adcon = new SqlConnection(cs);
                String adQ = "CREATE TABLE ADMIN (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), PASSWORD VARCHAR(50), REMEMBER_ME VARCHAR(20), RESET_TIME VARCHAR(200), RESET_IP VARCHAR(200));";

                SqlCommand adcmd = new SqlCommand(adQ, adcon);
                adcon.Open();
                adcmd.ExecuteReader();
                adcon.Close();

            }

            if (!bsbd)
            {
                SqlConnection bsbdcon = new SqlConnection(cs);
                String bsbdQ = "CREATE TABLE BUYER_SIGNUP_BASIC_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), FIRST_NAME VARCHAR(60), LAST_NAME VARCHAR(40), COUNTRY_CODE VARCHAR(50), MOBILE_NUMBER VARCHAR(30), GENDER VARCHAR(8));";
                SqlCommand bsbdcmd = new SqlCommand(bsbdQ, bsbdcon);
                bsbdcon.Open();
                bsbdcmd.ExecuteReader();
                bsbdcon.Close();


            }

            if (!ssbd)
            {
                SqlConnection ssbdcon = new SqlConnection(cs);
                String ssbdQ = "CREATE TABLE SELLER_SIGNUP_BASIC_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), FIRST_NAME VARCHAR(60), LAST_NAME VARCHAR(40), COUNTRY_CODE VARCHAR(50), MOBILE_NUMBER VARCHAR(30), GENDER VARCHAR(8));";
                SqlCommand ssbdcmd = new SqlCommand(ssbdQ, ssbdcon);
                ssbdcon.Open();
                ssbdcmd.ExecuteReader();
                ssbdcon.Close();


            }

            if (!bspd)
            {
                SqlConnection bspdcon = new SqlConnection(cs);
                String bspdQ = "CREATE TABLE BUYER_SIGNUP_PERSONAL_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), DATE_OF_BIRTH VARCHAR(100), BIRTH_DATE VARCHAR(25), BIRTH_MONTH VARCHAR(25), BIRTH_YEAR VARCHAR(25), AGE VARCHAR(50), NID_NUMBER VARCHAR(25), PASSPORT_NUMBER VARCHAR(25), COUNTRY VARCHAR(30), NATIONALITY VARCHAR(50), STREET_ADDRESS VARCHAR(200), ADDRESS_LINE_2 VARCHAR(200), CITY VARCHAR(80), STATE VARCHAR(50));";
                SqlCommand bspdcmd = new SqlCommand(bspdQ, bspdcon);
                bspdcon.Open();
                bspdcmd.ExecuteReader();
                bspdcon.Close();


            }


            if (!sspd)
            {
                SqlConnection sspdcon = new SqlConnection(cs);
                String sspdQ = "CREATE TABLE SELLER_SIGNUP_PERSONAL_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), DATE_OF_BIRTH VARCHAR(100), BIRTH_DATE VARCHAR(25), BIRTH_MONTH VARCHAR(25), BIRTH_YEAR VARCHAR(25), AGE VARCHAR(50), NID_NUMBER VARCHAR(25), PASSPORT_NUMBER VARCHAR(25), COUNTRY VARCHAR(30), NATIONALITY VARCHAR(50), STREET_ADDRESS VARCHAR(200), ADDRESS_LINE_2 VARCHAR(200), CITY VARCHAR(80), STATE VARCHAR(50));";
                SqlCommand sspdcmd = new SqlCommand(sspdQ, sspdcon);
                sspdcon.Open();
                sspdcmd.ExecuteReader();
                sspdcon.Close();
            }

            if (!bsud)
            {
                SqlConnection bsudcon = new SqlConnection(cs);
                String bsudQ = "CREATE TABLE BUYER_SIGNUP_USER_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), PASSWORD VARCHAR(16), PROFILE_PICTURE IMAGE, PROMOTIONAL_EMAIL VARCHAR(10), STATUS VARCHAR(20), STATUS_MESSAGE VARCHAR(120),  RAW_POST VARCHAR(20));";
                SqlCommand bsudcmd = new SqlCommand(bsudQ, bsudcon);
                bsudcon.Open();
                bsudcmd.ExecuteReader();
                bsudcon.Close();
            }

            if (!ssud)
            {
                SqlConnection ssudcon = new SqlConnection(cs);
                String ssudQ = "CREATE TABLE SELLER_SIGNUP_USER_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), PASSWORD VARCHAR(16), PROFILE_PICTURE IMAGE, PROMOTIONAL_EMAIL VARCHAR(10), STATUS VARCHAR(20), STATUS_MESSAGE VARCHAR(120), RAW_POST VARCHAR(20));";
                SqlCommand ssudcmd = new SqlCommand(ssudQ, ssudcon);
                ssudcon.Open();
                ssudcmd.ExecuteReader();
                ssudcon.Close();
            }

            if (!bscd)
            {
                SqlConnection bscdcon = new SqlConnection(cs);
                String bscdQ = "CREATE TABLE BUYER_SIGNUP_COMPANY_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), COMPANY_NAME VARCHAR(100), COMPANY_TYPE VARCHAR(20), COMPANY_DESIGNATION VARCHAR(20), WORKERS_AMOUNT VARCHAR(10), COMPANY_ADDRESS VARCHAR(200) , BUYER_REASON VARCHAR(300));";
                SqlCommand bscdcmd = new SqlCommand(bscdQ, bscdcon);
                bscdcon.Open();
                bscdcmd.ExecuteReader();
                bscdcon.Close();
            }

            if (!ssus)
            {
                SqlConnection ssuscon = new SqlConnection(cs);
                String ssusQ = "CREATE TABLE SELLER_SIGNUP_USER_SKILLS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), BASIC_SKILLS VARCHAR(1000), OTHER_SKILLS VARCHAR(1000), EXPERT_ON VARCHAR(1000), DEMO_PROJECTS VARCHAR(1000));";
                SqlCommand ssuscmd = new SqlCommand(ssusQ, ssuscon);
                ssuscon.Open();
                ssuscmd.ExecuteReader();
                ssuscon.Close();
            }

            if (!bsad)
            {
                SqlConnection bsadcon = new SqlConnection(cs);
                String bsadQ = "CREATE TABLE BUYER_SIGNUP_ACCOUNT_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), BANK_ACCOUNT_NUMBER VARCHAR(25), DESCRIPTION VARCHAR(500), HAVE_SELLER VARCHAR(10), SIGN_UP_TIME VARCHAR(200), SIGN_UP_IP VARCHAR(100));";
                SqlCommand bsadcmd = new SqlCommand(bsadQ, bsadcon);
                bsadcon.Open();
                bsadcmd.ExecuteReader();
                bsadcon.Close();
            }

            if (!ssad)
            {
                SqlConnection ssadcon = new SqlConnection(cs);
                String ssadQ = "CREATE TABLE SELLER_SIGNUP_ACCOUNT_DETAILS (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), BANK_ACCOUNT_NUMBER VARCHAR(25), DESCRIPTION VARCHAR(500), HAVE_BUYER VARCHAR(10), SIGN_UP_TIME VARCHAR(200), SIGN_UP_IP VARCHAR(100));";
                SqlCommand ssadcmd = new SqlCommand(ssadQ, ssadcon);
                ssadcon.Open();
                ssadcmd.ExecuteReader();
                ssadcon.Close();
            }


            if (!btr)
            {
                SqlConnection btrcon = new SqlConnection(cs);
                String btrQ = "CREATE TABLE BUYER_TOTAL_RATING (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), CURRENT_RATING VARCHAR(25), TOTAL_RATED_BY VARCHAR(25));";
                SqlCommand btrcmd = new SqlCommand(btrQ, btrcon);
                btrcon.Open();
                btrcmd.ExecuteReader();
                btrcon.Close();
            }

            if (!str)
            {
                SqlConnection strcon = new SqlConnection(cs);
                String strQ = "CREATE TABLE SELLER_TOTAL_RATING (USER_NAME VARCHAR(100) PRIMARY KEY, EMAIL VARCHAR(100), FULL_NAME VARCHAR(100), CURRENT_RATING VARCHAR(25), TOTAL_RATED_BY VARCHAR(25));";
                SqlCommand strcmd = new SqlCommand(strQ, strcon);
                strcon.Open();
                strcmd.ExecuteReader();
                strcon.Close();
            }


            if (!fd)
            {
                SqlConnection fdcon = new SqlConnection(cs);
                String fdQ = "CREATE TABLE FEEDBACK (FULL_NAME VARCHAR(100) , EMAIL VARCHAR(100) PRIMARY KEY, MOBILE_NUMBER VARCHAR(50), SATISFACTION_RATE VARCHAR(50), COMMENTS VARCHAR(3000), RAW_POST VARCHAR(50), SENDING_TIME VARCHAR(200), SENDING_IP VARCHAR(200));";
                SqlCommand fdcmd = new SqlCommand(fdQ, fdcon);
                fdcon.Open();
                fdcmd.ExecuteReader();
                fdcon.Close();
            }


            if (!rp)
            {
                SqlConnection rpcon = new SqlConnection(cs);

                String rpQ = "CREATE TABLE REPORT (FULL_NAME VARCHAR(100) , EMAIL VARCHAR(100), REPORT_SECTION VARCHAR(50), SUSPECT_NAME VARCHAR(100), BANK_ACCOUNT_NO VARCHAR(50), PROBLEM_TYPE VARCHAR(200), SUB_PROBLEM_TYPE VARCHAR(200), ADDITIONAL_COMMENT VARCHAR(500), SENDING_TIME VARCHAR(200) , SENDING_IP VARCHAR(200), REPORT_CONDITION VARCHAR(50), INVESTIGATION_TIME VARCHAR(200), WARNING_TIME VARCHAR(200), CLOSING_TIME VARCHAR(200), HANDLER_EMAIL VARCHAR(100) , SOLUTION VARCHAR(500), USER_SATISFACTION VARCHAR(50));";
                SqlCommand rpcmd = new SqlCommand(rpQ, rpcon);
                rpcon.Open();
                rpcmd.ExecuteReader();
                rpcon.Close();
            }


            if (!ct)
            {
                SqlConnection ctcon = new SqlConnection(cs);
                String ctQ = "CREATE TABLE CONTACT (FULL_NAME VARCHAR(100) , EMAIL VARCHAR(100), MOBILE_NUMBER VARCHAR(50), COMMUNICATION_METHOD VARCHAR(50), MESSAGE VARCHAR(3000), RAW_POST VARCHAR(50), SENDING_TIME VARCHAR(500),SENDING_IP VARCHAR(200), CONTACT_CONDITION VARCHAR(50));";
                SqlCommand ctcmd = new SqlCommand(ctQ, ctcon);
                ctcon.Open();
                ctcmd.ExecuteReader();
                ctcon.Close();
            }

            if (!bl)
            {
                SqlConnection blcon = new SqlConnection(cs);
                String blQ = "CREATE TABLE BUYER_LOGIN (USER_NAME VARCHAR(100) , EMAIL VARCHAR(100), PASSWORD VARCHAR(20), REMEMBER_ME VARCHAR(20), LOGIN_TIME VARCHAR(200), LOGIN_IP VARCHAR(200), RAW_POST VARCHAR(50));";
                SqlCommand blcmd = new SqlCommand(blQ, blcon);
                blcon.Open();
                blcmd.ExecuteReader();
                blcon.Close();
            }
            if (!sl)
            {
                SqlConnection slcon = new SqlConnection(cs);
                String slQ = "CREATE TABLE SELLER_LOGIN (USER_NAME VARCHAR(100) , EMAIL VARCHAR(100), PASSWORD VARCHAR(20), REMEMBER_ME VARCHAR(20), LOGIN_TIME VARCHAR(200), LOGIN_IP VARCHAR(200), RAW_POST VARCHAR(50));";
                SqlCommand slcmd = new SqlCommand(slQ, slcon);
                slcon.Open();
                slcmd.ExecuteReader();
                slcon.Close();
            }

            if (!bprp)
            {
                SqlConnection bprpcon = new SqlConnection(cs);
                String bprpQ = "CREATE TABLE BUYER_PRP_DETAILS (USER_NAME VARCHAR(100) , EMAIL VARCHAR(100), OLD_PASSWORD VARCHAR(20), NEW_PASSWORD VARCHAR(20), PRP_TIME VARCHAR(200), PRP_IP VARCHAR(200), RAW_POST VARCHAR(50));";
                SqlCommand bprpcmd = new SqlCommand(bprpQ, bprpcon);
                bprpcon.Open();
                bprpcmd.ExecuteReader();
                bprpcon.Close();
            }

            if (!sprp)
            {
                SqlConnection sprpcon = new SqlConnection(cs);
                String sprpQ = "CREATE TABLE SELLER_PRP_DETAILS (USER_NAME VARCHAR(100) , EMAIL VARCHAR(100), OLD_PASSWORD VARCHAR(20), NEW_PASSWORD VARCHAR(20), PRP_TIME VARCHAR(200), PRP_IP VARCHAR(200), RAW_POST VARCHAR(50));";
                SqlCommand sprpcmd = new SqlCommand(sprpQ, sprpcon);
                sprpcon.Open();
                sprpcmd.ExecuteReader();
                sprpcon.Close();
            }

            if (!ji)
            {
                SqlConnection jicon = new SqlConnection(cs);
                String jiQ = "CREATE TABLE JOB_INFO (BUYER_NAME VARCHAR(100) , JOB_ID VARCHAR(50), JOB_IMAGE IMAGE, JOB_NAME VARCHAR(100), JOB_SKILLS VARCHAR(100), JOB_PRICE VARCHAR(10), JOB_TIME VARCHAR(200), JOB_DETAILS VARCHAR(500), JOB_STATUS VARCHAR(20), POST_TIME VARCHAR(200));";              
                SqlCommand jicmd = new SqlCommand(jiQ, jicon);
                jicon.Open();
                jicmd.ExecuteReader();
                jicon.Close();
            }

            if (!pj)
            {
                SqlConnection pjcon = new SqlConnection(cs);
                String pjQ = "CREATE TABLE PROGRESS_JOB (JOB_ID VARCHAR(50) , BUYER_NAME VARCHAR(100), SELLER_NAME VARCHAR(100), SELLER_ACCEPT_TIME VARCHAR(200), JOB_ENDING_TIME VARCHAR(200), SUBMISSION_TIME VARCHAR(200), WORK_ACCEPT_TIME VARCHAR(200));";            
                SqlCommand pjcmd = new SqlCommand(pjQ, pjcon);
                pjcon.Open();
                pjcmd.ExecuteReader();
                pjcon.Close();
            }

            if (!cj)
            {
                SqlConnection cjcon = new SqlConnection(cs);
                String cjQ = "CREATE TABLE CANCEL_JOB (JOB_ID VARCHAR(50) , CANCEL_REQUESTED_BY VARCHAR(100), CANCEL_ACCEPT_BY VARCHAR(100), CANCELATION_TIME VARCHAR(200), CANCEL_REQUEST_TIME VARCHAR(200));";           
                SqlCommand cjcmd = new SqlCommand(cjQ, cjcon);
                cjcon.Open();
                cjcmd.ExecuteReader();
                cjcon.Close();
            }

            if (!sj)
            {
                SqlConnection sjcon = new SqlConnection(cs);
                String sjQ = "CREATE TABLE SUBMITTED_JOB (JOB_ID VARCHAR(50) , SUBMISSION_TIME VARCHAR(200), TRANSACTION_ID VARCHAR(50), SELLER_NAME VARCHAR(100), BUYER_NAME VARCHAR(100), SUBMITTED_LINK VARCHAR(200), BUYER_COMMENT VARCHAR(500));";      
                SqlCommand sjcmd = new SqlCommand(sjQ, sjcon);
                sjcon.Open();
                sjcmd.ExecuteReader();
                sjcon.Close();
            }

            if (!ac)
            {
                SqlConnection accon = new SqlConnection(cs);
                String acQ = "CREATE TABLE ACCOUNT (USER_NAME VARCHAR(100) , ACCOUNT_NO VARCHAR(50), AMOUNT VARCHAR(50));";
                SqlCommand accmd = new SqlCommand(acQ, accon);
                accon.Open();
                accmd.ExecuteReader();
                accon.Close();
            }
            if (!apj)
            {
                SqlConnection apjcon = new SqlConnection(cs);
                String apjQ = "CREATE TABLE APPLY_JOB (JOB_ID VARCHAR(50) , BUYER_NAME VARCHAR(100), SELLER_NAME VARCHAR(100), APPLY_TIME VARCHAR(200), JOB_STATUS VARCHAR(20), SELLER_COMMENT VARCHAR(20));";
                SqlCommand apjcmd = new SqlCommand(apjQ, apjcon);
                apjcon.Open();
                apjcmd.ExecuteReader();
                apjcon.Close();
            }

            if (!msg)
            {
                SqlConnection msgcon = new SqlConnection(cs);
                String msgQ = "CREATE TABLE MESSENGER ( SENDER_NAME VARCHAR(100), REC_NAME VARCHAR(100), TABLE_NAME VARCHAR(200),  CREATE_TIME VARCHAR(200));";
                SqlCommand msgcmd = new SqlCommand(msgQ, msgcon);
                msgcon.Open();
                msgcmd.ExecuteReader();
                msgcon.Close();
            }

        }




        public void CreateRemember(String USERNAME, String PASSWORD, String POST)
        {

            string root = @"C:\Users\Public\.RAW";
            //string subdir = @"C:\Temp\Mahesh";
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            //File and path you want to create and write to
            string fileName = root + @"\Temp.txt";
            //Check if the file exists
            if (!File.Exists(fileName))
            {
                // Create the file and use streamWriter to write text to it.
                //If the file existence is not check, this will overwrite said file.
                //Use the using block so the file can close and vairable disposed correctly
                using (StreamWriter writer = File.CreateText(fileName))
                {
                    writer.WriteLine(POST);
                    writer.WriteLine(USERNAME);
                    writer.WriteLine(PASSWORD);

                }
            }




        }

        public void RemoveRemember()
        {
            string fileName = @"C:\Users\Public\.RAW\Temp.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

        }


        public Boolean CheckRemember()
        {

            string fileName = @"C:\Users\Public\.RAW\Temp.txt";
            if (File.Exists(fileName))
            {
                string[] lines = System.IO.File.ReadAllLines(fileName);
                string USERNAME = lines[1];
                string PASSWORD = lines[2];
                string POST = lines[0];


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


                        new Buyer_Info(USERNAME);
                        new Buyer_Profile().Show();
                        return true;



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


                        new Seller_Info(USERNAME);
                        new Seller_Profile().Show();
                        return true;
                    }

                    else
                    {
                        MessageBox.Show("OOPS!!! Sorry. This user can't register in our database.");

                    }

                    con.Close();
                }

                return false;
            }
            else { return false; }
        }



        public  bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public  bool IsValidMobile(string email)
        {
            String numberRegex = "^(\\+\\d{1,3}( )?)?((\\(\\d{1,3}\\))|\\d{1,3})[- .]?\\d{3,4}[- .]?\\d{4}$";
            var regex = new Regex(numberRegex, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }


    }
}
