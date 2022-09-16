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
    public partial class FeedBack : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Boolean cmnt = false;
         Boolean nm = false;
         Boolean emid = false;
         Boolean fed = false;
        String feedrating = "", feedcomment = "", feedname = "", feedemail = "", feednumber = "", SENDING_IP = "", RAW_POST = "";


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public FeedBack()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ABOUT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new About().Show();
        }

        private void HOME_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Landing_Page().Show();
        }

        private void CONTACT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Contact().Show();
        }

        private void FEEDBACK_BUTTON_Click(object sender, EventArgs e)
        {

        }

        private void REPORT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Repost_User().Show();
        }

      

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fed = true;
            feedrating = "Excellent";
            EnableButton();
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fed = true;
            feedrating = "Good";
            EnableButton();
        }

        private void gunaRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            fed = true;
            feedrating = "Neutral";
            EnableButton();
        }

        private void gunaRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            fed = true;
            feedrating = "Poor";
            EnableButton();
        }

        private void gunaRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fed = true;
            feedrating = "Very Poor";
            EnableButton();
        }

        private void TextboxFeedComment_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxFeedComment.Text))
            {
                cmnt = false;
                EnableButton();
            }
            else
            {

                cmnt = true;
                EnableButton();
            }
        }

        private void TextboxFeedName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxFeedName.Text))
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

        private void TextboxFeedPhone_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextboxFeedEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextboxFeedEmail.Text))
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

        public void EnableButton()
        {
            if (cmnt && nm && emid && fed)
            {
                ButtonReportAccSubmit.Enabled = true;

            }
            else {
                ButtonReportAccSubmit.Enabled = false;
            }
        
        }

        private void ButtonReportAccReset_Click(object sender, EventArgs e)
        {
            TextboxFeedPhone.Text = "";
            TextboxFeedEmail.Text = "";
                TextboxFeedName.Text = "";
            TextboxFeedComment.Text = "";

            gunaRadioButton1.Checked = false;
            gunaRadioButton2.Checked = false;
            gunaRadioButton3.Checked = false;
            gunaRadioButton4.Checked = false;
            gunaRadioButton5.Checked = false;
            cmnt = nm = emid = fed = false;
            EnableButton();


        }

        private void ButtonReportAccSubmit_Click(object sender, EventArgs e)
        {

            feedcomment = TextboxFeedComment.Text;
            feedname = TextboxFeedName.Text;
            feedemail = TextboxFeedEmail.Text;
            { 
            if (string.IsNullOrEmpty(TextboxFeedPhone.Text))
            {
                feednumber = "N/A";
            }
            else {
                feednumber = TextboxFeedPhone.Text;
            }
        }
            SENDING_IP = "N/A";
            RAW_POST = "USER";
            String SENDING_TIME = new RAW_Function().time();

            SqlConnection con1 = new SqlConnection(cs);
            String query1 = "INSERT INTO FEEDBACK VALUES(@name,@email,@mbl,@rate,@msg,@post,@sendt,@sendip);";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@name", feedname);
            cmd1.Parameters.AddWithValue("@email", feedemail);
            cmd1.Parameters.AddWithValue("@mbl", feednumber);
            cmd1.Parameters.AddWithValue("@rate", feedrating);
            cmd1.Parameters.AddWithValue("@msg", feedcomment);
            cmd1.Parameters.AddWithValue("@post", RAW_POST);
            cmd1.Parameters.AddWithValue("@sendt", SENDING_TIME);
            cmd1.Parameters.AddWithValue("@sendip", SENDING_IP);
           

            con1.Open();
            int a = cmd1.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("THANK YOU!!! Your Feedback send.");
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
