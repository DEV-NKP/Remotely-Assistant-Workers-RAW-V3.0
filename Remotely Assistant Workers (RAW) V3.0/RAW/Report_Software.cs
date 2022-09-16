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
    public partial class Report_Software : Form
    {


        String FULL_NAME = "";
        String EMAIL = "";

        String REPORT_SECTION = "";


        String SUSPECT_NAME = "";
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
        Boolean prb = false;
        Boolean sprb = false;


        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Report_Software()
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

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
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

        private void ButtonReportUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Repost_User().Show();
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

        private void TextboxReportSoftName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxReportSoftName.Text))
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

        private void TextboxReportSoftEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxReportSoftEmail.Text))
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

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton1.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton2.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton3.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton4.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton5.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton6.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton7.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton8.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton9.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton10.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton11.Text;
            prb = true;
            EnableButton();
        }

        private void gunaRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            PROBLEM_TYPE = gunaRadioButton12.Text;
            prb = true;
            EnableButton();
        }

        private void TextboxReportSoftProblem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxReportSoftProblem.Text))
            {
                sprb = false;
                EnableButton();
            }
            else
            {

                sprb = true;
                EnableButton();
            }
        }

        private void TextboxReportSoftComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonReportAccReset_Click(object sender, EventArgs e)
        {
            gunaRadioButton1.Checked = false;
                gunaRadioButton2.Checked = false;
            gunaRadioButton3.Checked = false;

            gunaRadioButton4.Checked = false;
            gunaRadioButton5.Checked = false;
            gunaRadioButton6.Checked = false;
            gunaRadioButton7.Checked = false;
            gunaRadioButton8.Checked = false;
            gunaRadioButton9.Checked = false;
            gunaRadioButton10.Checked = false;
            gunaRadioButton11.Checked = false;
            gunaRadioButton12.Checked = false;

            TextboxReportSoftComment.Text = "";
            TextboxReportSoftName.Text = "";
            TextboxReportSoftEmail.Text = "";
            TextboxReportSoftProblem.Text = "";

            nm = em = prb = sprb = false;
            EnableButton();

        }

        private void ButtonReportAccSubmit_Click(object sender, EventArgs e)
        {
            FULL_NAME = TextboxReportSoftName.Text;
            EMAIL = TextboxReportSoftEmail.Text;

            REPORT_SECTION = "SOFTWARE";


            SUSPECT_NAME = "N/A";
            BANK_ACCOUNT_NO = "N/A";
            SUB_PROBLEM_TYPE = TextboxReportSoftProblem.Text;
            ADDITIONAL_COMMENT = TextboxReportSoftComment.Text;
            SENDING_TIME = new RAW_Function().time();
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

        public void EnableButton()
        {
            if (nm && em  && prb && sprb)
            {

                ButtonReportAccSubmit.Enabled = true;
            }

            else
            {

                ButtonReportAccSubmit.Enabled = false;
            }

        }
    }
}
