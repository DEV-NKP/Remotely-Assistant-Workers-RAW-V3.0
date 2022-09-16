using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Repost_User : Form
    {
        String FULL_NAME = "";
String EMAIL="";

String REPORT_SECTION="";


String SUSPECT_NAME="";
String BANK_ACCOUNT_NO = "N/A";
        String PROBLEM_TYPE = "";
String SUB_PROBLEM_TYPE = "";
        String ADDITIONAL_COMMENT = "";
        String SENDING_TIME = "";
        String SENDING_IP = "N/A";
        String REPORT_CONDITION = "PENDING";
        String INVESTIGATION_TIME = "N/A";
        String WARNING_TIME = "N/A";
        String CLOSING_TIME = "N/A";
        String HANDLER_EMAIL = "N/A";
        String SOLUTION = "N/A";
        String USER_SATISFACTION = "N/A";


        Boolean nm = false;
        Boolean em = false;
        Boolean snm = false;
        Boolean prb = false;
        Boolean sprb = false;
        

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Repost_User()
        {
            InitializeComponent();
        }

        private void EXIT_BUTTON_Click(object sender, EventArgs e)
        {
            DialogResult yesno = MessageBox.Show("Do you really want to quit?", "Information", MessageBoxButtons.OKCancel);
            if (yesno == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {

            }
        }


        private void ButtonReportUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Repost_User().Show();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void gunaControlBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HOME_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Landing_Page().Show();
        }

        private void ABOUT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new About().Show();
        }

        private void CONTACT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Contact().Show();
        }

        private void FEEDBACK_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FeedBack().Show();
        }

        private void REPORT_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void ButtonReportSoft_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Report_Software().Show();
        }

        private void ButtonReportAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Report_Account().Show();
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Hide();
            PretendSubProblem.Show();

            PROBLEM_TYPE = gunaRadioButton1.Text;

            prb = true;
            EnableButton();
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Hide();

            PROBLEM_TYPE = gunaRadioButton2.Text;
            SUB_PROBLEM_TYPE = "N/A";
            prb = true;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Hide();

            PROBLEM_TYPE = gunaRadioButton3.Text;
            SUB_PROBLEM_TYPE = "N/A";
            prb = true;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Hide();
            PROBLEM_TYPE = gunaRadioButton4.Text;
            SUB_PROBLEM_TYPE = "N/A";
            prb = true;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Hide();

            PROBLEM_TYPE = gunaRadioButton5.Text;
            SUB_PROBLEM_TYPE = "N/A";
            prb = true;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Hide();

            PROBLEM_TYPE = gunaRadioButton6.Text;
            SUB_PROBLEM_TYPE = "N/A";
            prb = true;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            SomethingElseSubProblem.Hide();
            WantHelpSubProblem.Show();

            PROBLEM_TYPE = gunaRadioButton7.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            PretendSubProblem.Hide();
            WantHelpSubProblem.Hide();
            SomethingElseSubProblem.Show();

            PROBLEM_TYPE = gunaRadioButton8.Text;
            prb = true;
            EnableButton();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TextboxReportUserName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxReportUserName.Text))
            {
                nm = false;
                EnableButton();
            }
            else
            {

                nm = true;
                EnableButton();
            }
        }

        private void TextboxReportUserEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxReportUserEmail.Text))
            {
                em = false;
                EnableButton();
            }
            else
            {

                em = true;
                EnableButton();
            }
        }

        private void TextboxReportUserSusName_TextChanged(object sender, EventArgs e)
        {

            Boolean buyern = false;
            if (string.IsNullOrEmpty(TextboxReportUserSusName.Text))
            {
                snm = false;
                EnableButton();
            }
            else
            {


                {
                    SqlConnection con = new SqlConnection(cs);
                    String query = "SELECT * FROM SELLER_SIGNUP_USER_DETAILS WHERE USER_NAME= @user;";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", TextboxReportUserSusName.Text);

                    con.Open();
                    SqlDataReader sda = cmd.ExecuteReader();
                    if (sda.HasRows == true)
                    {
                        snm = true;
                        EnableButton();
                        gunaLabel4.Text = "Enter Suspect's User-Name";
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
                    cmd.Parameters.AddWithValue("@user", TextboxReportUserSusName.Text);

                    con.Open();
                    SqlDataReader sda = cmd.ExecuteReader();
                    if (sda.HasRows == true)
                    {
                        snm = true;
                        EnableButton();
                        gunaLabel4.Text = "Enter Suspect's User-Name";
                    }

                    else
                    {

                        snm = false;
                        EnableButton();
                        gunaLabel4.Text = "Enter Suspect's User-Name (This Username is not registered)";
                    }

                    con.Close();
                }



            }
        
    }

        private void TextboxReportUserComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton12.Text;
           
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton11.Text;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton10.Text;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton9.Text;
            sprb = true;
            EnableButton();
        }

        private void WantHelpSubProblem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaRadioButton20_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton20.Text;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton19_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton19.Text;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton18_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton18.Text;
            sprb = true;
            EnableButton();
        }

        private void gunaRadioButton17_CheckedChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = gunaRadioButton17.Text;
            sprb = true;
            EnableButton();
        }

        private void TextboxReportUserProblem_TextChanged(object sender, EventArgs e)
        {
            SUB_PROBLEM_TYPE = TextboxReportUserProblem.Text;
            sprb = true;
            EnableButton();
        }

        public void EnableButton()
        {
            if (nm && em && snm && prb && sprb)
            {

                ButtonReportAccSubmit.Enabled = true;
            }

            else {

                ButtonReportAccSubmit.Enabled = false;
            }

        }


        private void ButtonReportAccReset_Click(object sender, EventArgs e)
        {
            gunaRadioButton12.Checked = false;
            gunaRadioButton11.Checked = false;
            gunaRadioButton10.Checked = false;
            gunaRadioButton9.Checked = false;
            gunaRadioButton20.Checked = false;
            gunaRadioButton19.Checked = false;
            gunaRadioButton18.Checked = false;
            gunaRadioButton17.Checked = false;
                TextboxReportUserProblem.Text = "";


            gunaRadioButton1.Checked = false;
            gunaRadioButton2.Checked = false;
            gunaRadioButton3.Checked = false;
            gunaRadioButton4.Checked = false;
            gunaRadioButton5.Checked = false;
            gunaRadioButton6.Checked = false;
            gunaRadioButton7.Checked = false;
            gunaRadioButton8.Checked = false;
            TextboxReportUserName.Text = "";
            TextboxReportUserEmail.Text = "";
            TextboxReportUserSusName.Text = "";
            TextboxReportUserComment.Text = "";

            nm = em = snm = prb = sprb = false;
            EnableButton();

        }

        private void ButtonReportAccSubmit_Click(object sender, EventArgs e)
        {

             FULL_NAME = TextboxReportUserName.Text;
             EMAIL = TextboxReportUserEmail.Text;

             REPORT_SECTION = "USER";


            SUSPECT_NAME = TextboxReportUserSusName.Text;
             BANK_ACCOUNT_NO = "N/A";
             
             ADDITIONAL_COMMENT = TextboxReportUserComment.Text;
            SENDING_TIME = new RAW_Function().time() ;
             SENDING_IP = "N/A";
             REPORT_CONDITION = "PENDING";
             INVESTIGATION_TIME = "N/A";
             WARNING_TIME = "N/A";
             CLOSING_TIME = "N/A";
             HANDLER_EMAIL = "N/A";
             SOLUTION = "N/A";
             USER_SATISFACTION = "N/A";


            SqlConnection con1 = new SqlConnection(cs);
            String query1 = "INSERT INTO REPORT VALUES(@name,@email,@rsec,@sus,@bac,@pbl,@spbl,@cmt,@stime,@sip,@rcon,@intime,@watime,@clotime,@hemail,@sol,@sat);";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@name", FULL_NAME);
            cmd1.Parameters.AddWithValue("@email", EMAIL);
            cmd1.Parameters.AddWithValue("@rsec", REPORT_SECTION);
            cmd1.Parameters.AddWithValue("@sus", SUSPECT_NAME);
            cmd1.Parameters.AddWithValue("@bac", BANK_ACCOUNT_NO);
            cmd1.Parameters.AddWithValue("@pbl", PROBLEM_TYPE);
            cmd1.Parameters.AddWithValue("@spbl", SUB_PROBLEM_TYPE);
            cmd1.Parameters.AddWithValue("@cmt", ADDITIONAL_COMMENT);
            cmd1.Parameters.AddWithValue("@stime", SENDING_TIME);
            cmd1.Parameters.AddWithValue("@sip", SENDING_IP);
            cmd1.Parameters.AddWithValue("@rcon", REPORT_CONDITION);
            cmd1.Parameters.AddWithValue("@intime", INVESTIGATION_TIME);
            cmd1.Parameters.AddWithValue("@watime", WARNING_TIME);
            cmd1.Parameters.AddWithValue("@clotime", CLOSING_TIME);
            cmd1.Parameters.AddWithValue("@hemail", HANDLER_EMAIL);
            cmd1.Parameters.AddWithValue("@sol", SOLUTION);
            cmd1.Parameters.AddWithValue("@sat", USER_SATISFACTION);
            con1.Open();
            int a = cmd1.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("THANK YOU!!! Your Report send. Wait for admin response.");
                this.Hide();
                new Landing_Page().Show();
            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con1.Close();



        }
    }
}
