using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace RAW
{
    public partial class Buyer_Post_Job : Form
    {
        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        String BUYER_NAME = "";
       String JOB_ID = "";
        byte[] JOB_IMAGE ;
        String JOB_NAME = "";
        String JOB_SKILLS = "";
        String JOB_PRICE = "";
        String JOB_TIME = "";
        String JOB_DETAILS = "";
        String JOB_STATUS = "";
        String POST_TIME = "";

        Boolean jn = false;
        Boolean jp = false;
        Boolean js = false;
        Boolean jd = false;
        Boolean jt = false;

        Boolean ace = false;

        private void customizeSubMenu()
        {
            jobpost.Visible = true;
            workhouse.Visible = false;
        }
        private void HideSubMenu()
        {
            if (jobpost.Visible == true)
                jobpost.Visible = false;
            if (workhouse.Visible == true)
                workhouse.Visible = false;
        }
        private void ShowSubMenu(Panel submenu)
        {
            if (submenu.Visible == true)
            {
                submenu.Visible = false;
            }
            else
            {
                HideSubMenu();
                submenu.Visible = true;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Buyer_Post_Job()
        {
            InitializeComponent();
        }

        private void gunaControlBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Buyer_Post_Job_Load(object sender, EventArgs e)
        {
            customizeSubMenu();

            label6.Text = Buyer_Info.USER_NAME;
            label5.Text = Buyer_Info.RAW_POST;
            gunaGradientButton2.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            gunaCirclePictureBox3.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);

            jobIDLabel.Text  = "RAC-" + RandomString(12);


        }
        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void BuyerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }

        private void BuyerPortalSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Search().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void BuyerPortalManageJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();
        }

        private void BuyerPortalRecent_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Recent_Job().Show();
        }

        private void BuyerPortalSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();
        }

        private void BuyerPortalPrevious_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Previous_Job().Show();
        }

        private void BuyerPortalcancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Cancel_Job().Show();
        }

        private void BuyerPortalAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Account().Show();
        }

        private void BuyerPortalMessenger_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Messenger().Show();
        }

       
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void TextBoxBuyerPostJobName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerPostJobName.Text))
            {
                jn = false;
                EnableButton();
            }
            else
            {

                jn = true;
                EnableButton();
            }
        }

        private void TextBoxBuyerPostJobPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerPostJobPrice.Text))
            {
                jp = false;
                EnableButton();
            }
            else
            {

                jp = true;
                EnableButton();
            }
        }

        private void TextBoxBuyerPostJobDuration_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerPostJobDuration.Text))
            {
                jt = false;
                EnableButton();
            }
            else
            {

                jt = true;
                EnableButton();
            }
        }

        private void TextBoxBuyerPostJobSkills_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerPostJobSkills.Text))
            {
                js = false;
                EnableButton();
            }
            else
            {

                js = true;
                EnableButton();
            }
        }

        private void TextBoxBuyerPostJobDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerPostJobDescription.Text))
            {
                jd = false;
                EnableButton();
            }
            else
            {

                jd = true;
                EnableButton();
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image (*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Picturebox_Img_Job.Image = new Bitmap(ofd.FileName);
               
               
            }
        }

        private void CheckBoxTerm_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBoxTerm.Checked)
            {
                ace = true;

                EnableButton();
            }
            else
            {
                ace = false;
                EnableButton();
            }
        }

        public void EnableButton()
        {

            if (jn && jp && js && jd && jt && ace)
            {
                gunaAdvenceButton9.Enabled = true;


            }
            else {
                gunaAdvenceButton9.Enabled = false;

            }
        }


        private void ButtonBuyerPortalReset_Click(object sender, EventArgs e)
        {
            CheckBoxTerm.Checked = false;
            TextBoxBuyerPostJobName.Text ="";
            TextBoxBuyerPostJobPrice.Text = "";
            TextBoxBuyerPostJobSkills.Text = "";
            TextBoxBuyerPostJobDescription.Text = "";
            TextBoxBuyerPostJobDuration.Text = "";
            Picturebox_Img_Job.Image = Properties.Resources.Menu_gif;
            jn = jp = js = jd = jt = ace = false;
            EnableButton();

        }

        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            Picturebox_Img_Job.Image.Save(ms, Picturebox_Img_Job.Image.RawFormat);
            return ms.GetBuffer();
        }
        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {

             BUYER_NAME = Buyer_Info.USER_NAME;
             JOB_ID = jobIDLabel.Text;
             JOB_IMAGE = Savephoto();
             JOB_NAME = TextBoxBuyerPostJobName.Text;
             JOB_SKILLS = TextBoxBuyerPostJobSkills.Text;
             JOB_PRICE = TextBoxBuyerPostJobPrice.Text;
             JOB_TIME = TextBoxBuyerPostJobDuration.Text;
             JOB_DETAILS = TextBoxBuyerPostJobDescription.Text;
             JOB_STATUS = "ACTIVE";
             POST_TIME = new RAW_Function().dtime();

            SqlConnection con1 = new SqlConnection(cs);
            String query1 = "INSERT INTO JOB_INFO VALUES(@bname,@jid,@jimg,@jname,@jskill,@jprice,@jtime,@jdetail,@jstatus,@jptime);";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.Parameters.AddWithValue("@bname", BUYER_NAME);
            cmd1.Parameters.AddWithValue("@jid", JOB_ID);
            cmd1.Parameters.AddWithValue("@jimg", JOB_IMAGE);
            cmd1.Parameters.AddWithValue("@jname", JOB_NAME);
            cmd1.Parameters.AddWithValue("@jskill", JOB_SKILLS);
            cmd1.Parameters.AddWithValue("@jprice", JOB_PRICE);
            cmd1.Parameters.AddWithValue("@jtime", JOB_TIME);
            cmd1.Parameters.AddWithValue("@jdetail", JOB_DETAILS);
            cmd1.Parameters.AddWithValue("@jstatus", JOB_STATUS);
            cmd1.Parameters.AddWithValue("@jptime", POST_TIME);


            con1.Open();
            int a = cmd1.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Posted !!! Wait for seller responses.");
                this.Hide();
                new Buyer_Profile().Show();
            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con1.Close();



        }

        private void Picturebox_Img_Job_Click(object sender, EventArgs e)
        {

        }

        private void BuyerPortalJobPost_Click(object sender, EventArgs e)
        {
            ShowSubMenu(jobpost);

        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            ShowSubMenu(workhouse);

        }

        private void PictureBoxBuyerPortal_Click(object sender, EventArgs e)
        {
            // this.Controls.Add(bup);
            bup.Visible = false;
            viewp++;

            //  MessageBox.Show(Convert.ToString(viewp));
            if (viewp % 2 == 0)
            {

                this.bup.Location = new System.Drawing.Point(980, 88);
                this.Controls.Add(bup);
                bup.Visible = true;
                bup.BringToFront();
                PictureBoxBuyerPortal.BringToFront();
                // bup.Show();
            }
            else
            {
                bup.Hide();
                bup.Visible = false;
                bup.SendToBack();
                this.Controls.Remove(bup);


            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
