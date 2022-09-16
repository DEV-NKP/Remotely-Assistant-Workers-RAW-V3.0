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
   
    public partial class Contact : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
         Boolean msg = false;
         Boolean nm = false;
         Boolean emid = false;
         Boolean phn = false;
         Boolean radio = false;

        String FULL_NAME = "";
        String EMAIL = "";
        String MOBILE_NUMBER = "";
        String COMMUNICATION_METHOD = "";
        String MESSAGE = "";
        String RAW_POSITION = "";
        String SENDING_TIME = "";
        String SENDING_IP = "";
        String CONTACT_CONDITION = "";


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Contact()
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

        private void CONTACT_BUTTON_Click(object sender, EventArgs e)
        {

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

        private void FEEDBACK_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FeedBack().Show();
        }

        private void REPORT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Repost_User().Show();
        }

        private void TextboxContactName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxContactName.Text))
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

        private void TextboxContactEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxContactEmail.Text))
            {
                emid = false;
                EnableButton();
            }
            else
            {

                emid = true;
                EnableButton();
            }
        }

        private void TextboxContactPhone_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxContactPhone.Text))
            {
                phn = false;
                EnableButton();
            }
            else
            {

                phn = true;
                EnableButton();
            }
        }

        private void TextboxContactMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxContactMessage.Text))
            {
                msg = false;
                EnableButton();
            }
            else
            {

                msg = true;
                EnableButton();
            }
        }


        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radio = true;
            COMMUNICATION_METHOD = "EMAIL";
            EnableButton();
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radio = true;
            COMMUNICATION_METHOD = "PHONE";
            EnableButton();
        }

        public void EnableButton()
        {
            if (msg && nm && emid && phn && radio)
            {
                ButtonReportAccSubmit.Enabled = true;

            }

            else {
                ButtonReportAccSubmit.Enabled = false;
            }
        }

        private void ButtonReportAccReset_Click(object sender, EventArgs e)
        {
            TextboxContactName.Text = "";
                TextboxContactEmail.Text = "";
            TextboxContactPhone.Text = "";
            TextboxContactMessage.Text = "";

            gunaRadioButton1.Checked = false;
            gunaRadioButton2.Checked = false;

            msg = nm = emid = phn = radio = false;
            EnableButton();
        }

        private void ButtonReportAccSubmit_Click(object sender, EventArgs e)
        {
             FULL_NAME = TextboxContactName.Text;
             EMAIL = TextboxContactEmail.Text;
             MOBILE_NUMBER = TextboxContactPhone.Text;
            
             MESSAGE = TextboxContactMessage.Text;
             RAW_POSITION = "USER";
             SENDING_TIME = new RAW_Function().time();
             SENDING_IP = "N/A";
             CONTACT_CONDITION = "PENDING";

            SqlConnection con1 = new SqlConnection(cs);
            String query1 = "INSERT INTO CONTACT VALUES(@name,@email,@mbl,@method,@msg,@post,@sendt,@sendip,@con);";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@name", FULL_NAME);
            cmd1.Parameters.AddWithValue("@email", EMAIL);
            cmd1.Parameters.AddWithValue("@mbl", MOBILE_NUMBER);
            cmd1.Parameters.AddWithValue("@method", COMMUNICATION_METHOD);
            cmd1.Parameters.AddWithValue("@msg", MESSAGE);
            cmd1.Parameters.AddWithValue("@post", RAW_POSITION);
            cmd1.Parameters.AddWithValue("@sendt", SENDING_TIME);
            cmd1.Parameters.AddWithValue("@sendip", SENDING_IP);
            cmd1.Parameters.AddWithValue("@con", CONTACT_CONDITION);

            con1.Open();
            int a = cmd1.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Send!!! Your contact Information was send. Wait for admin response.");
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
