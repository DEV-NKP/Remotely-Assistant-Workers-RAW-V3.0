using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Buyer_Manage_Job_Details : Form
    {
        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        String BUYER_NAME = "";
        String JOB_ID = "";
        byte[] JOB_IMAGE;
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
            PanelJobPost.Visible = true;
            PanelWorkHouse.Visible = false;
        }
        private void HideSubMenu()
        {
            if (PanelJobPost.Visible == true)
                PanelJobPost.Visible = false;
            if (PanelWorkHouse.Visible == true)
                PanelWorkHouse.Visible = false;
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
        public Buyer_Manage_Job_Details()
        {
            InitializeComponent();
        }

        private void Buyer_Manage_Job_Details_Load(object sender, EventArgs e)
        {
            customizeSubMenu();

            TextBoxBuyerManageJobName.Text = Job_Info.JOB_NAME;
                TextBoxBuyerManageJobPrice.Text = Job_Info.JOB_PRICE;
            TextBoxBuyerManageJobSkills.Text = Job_Info.JOB_SKILLS;
            TextBoxBuyerManageJobDescription.Text = Job_Info.JOB_DETAILS;

            jobIDLabel.Text = Job_Info.JOB_ID;

            TextBoxBuyerManageJobDuration.Text = Job_Info.JOB_TIME;
            Picturebox_Img_ManageJob.Image= GetPhoto(Job_Info.JOB_IMAGE);

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();
        }

        private void Update_Manage_Job_Bttn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image (*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Picturebox_Img_ManageJob.Image = new Bitmap(ofd.FileName);


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

        private void TextBoxBuyerManageJobName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerManageJobName.Text))
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

        public void EnableButton()
        {

            if (jn && jp && js && jd && jt && ace)
            {
                ButtonBuyerPortalSubmit.Enabled = true;


            }
            else
            {
                ButtonBuyerPortalSubmit.Enabled = false;

            }
        }

        private void TextBoxBuyerManageJobPrice_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerManageJobPrice.Text))
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

        private void TextBoxBuyerManageJobSkills_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerManageJobSkills.Text))
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

        private void TextBoxBuyerManageJobDuration_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerManageJobDuration.Text))
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

        private void TextBoxBuyerManageJobDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBuyerManageJobDescription.Text))
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

        private void ButtonBuyerPortalReset_Click(object sender, EventArgs e)
        {
            CheckBoxTerm.Checked = false;
            TextBoxBuyerManageJobName.Text = "";
            TextBoxBuyerManageJobPrice.Text = "";
            TextBoxBuyerManageJobSkills.Text = "";
            TextBoxBuyerManageJobDescription.Text = "";
            TextBoxBuyerManageJobDuration.Text = "";
            Picturebox_Img_ManageJob.Image = Properties.Resources.Menu_gif;
            jn = jp = js = jd = jt = ace = false;
            EnableButton();
        }


        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            Picturebox_Img_ManageJob.Image.Save(ms, Picturebox_Img_ManageJob.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void ButtonBuyerPortalSubmit_Click(object sender, EventArgs e)
        {

            BUYER_NAME = Buyer_Info.USER_NAME;
            JOB_ID = jobIDLabel.Text;
            JOB_IMAGE = Savephoto();
            JOB_NAME = TextBoxBuyerManageJobName.Text;
            JOB_SKILLS = TextBoxBuyerManageJobSkills.Text;
            JOB_PRICE = TextBoxBuyerManageJobPrice.Text;
            JOB_TIME = TextBoxBuyerManageJobDuration.Text;
            JOB_DETAILS = TextBoxBuyerManageJobDescription.Text;
            JOB_STATUS = "ACTIVE";
            POST_TIME = new RAW_Function().dtime();

            SqlConnection con1 = new SqlConnection(cs);
            String query1 = "UPDATE JOB_INFO SET BUYER_NAME=@bname , JOB_IMAGE=@jimg, JOB_NAME=@jname, JOB_SKILLS=@jskill, JOB_PRICE=@jprice , JOB_TIME =@jtime, JOB_DETAILS =@jdetail, JOB_STATUS =@jstatus, POST_TIME =@jptime WHERE JOB_ID=@jid;";
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
                MessageBox.Show("Updated !!! Wait for seller responses.");
                this.Hide();
                new Buyer_Manage_Job().Show();
            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con1.Close();

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

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ButtonBuyerPortalJobPost_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelJobPost);

        }

        private void ButtonBuyerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

        }

        private void ButtonBuyerPortalSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Search().Show();
        }

        private void ButtonBuyerPortalPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Post_Job().Show();
        }

        private void ButtonBuyerPortalManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Manage_Job().Show();
        }

        private void ButtonBuyerPortalRecJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Recent_Job().Show();
        }

        private void ButtonBuyerPortalSubob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Submitted_Job().Show();
        }

        private void ButtonBuyerPortalPreJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Previous_Job().Show();
        }

        private void ButtonBuyerPortalCanJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Cancel_Job().Show();
        }

        private void ButtonBuyerPortalAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Account().Show();
        }

        private void ButtonBuyerPortalChat_Click(object sender, EventArgs e)
        {

            this.Hide();
            new Buyer_Messenger().Show();
        }

     

        private void ButtonBuyerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
