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
    public partial class Buyer_Account : Form
    {
        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();

        Boolean depos = false;

        Boolean withdr = false;

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        public Buyer_Account()
        {
            new Buyer_Info(Buyer_Info.USER_NAME);
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void customizeSubMenu()
        {
            PanelJobPost.Visible = false;
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
        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Buyer_Account_Load(object sender, EventArgs e)
        {
            customizeSubMenu();

            label6.Text = Buyer_Info.USER_NAME;
            label5.Text = Buyer_Info.RAW_POST;
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            gunaCirclePictureBox3.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            BuyerBalance.Text = Buyer_Info.AMOUNT;
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ButtonBuyerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
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

        }

        private void ButtonBuyerPortalChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Messenger().Show();
        }

       
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

       

        private void ButtonBuyerAccDeposit_Click(object sender, EventArgs e)
        {
            ButtonBuyerAccDeposit.BaseColor1 = Color.MediumTurquoise;
            ButtonBuyerAccDeposit.BaseColor2 = Color.MediumTurquoise;
            ButtonBuyerAccWithdrw.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonBuyerAccWithdrw.BaseColor2 = Color.FromArgb(211, 32, 79);
            label4.Visible = true;
            NumUpdownBuyerAmount.Visible = true;
            depos = true;
            withdr = false;
        }

        private void ButtonBuyerAccWithdrw_Click(object sender, EventArgs e)
        {
            ButtonBuyerAccDeposit.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonBuyerAccDeposit.BaseColor2 = Color.FromArgb(211, 32, 79);
            ButtonBuyerAccWithdrw.BaseColor1 = Color.MediumTurquoise;
            ButtonBuyerAccWithdrw.BaseColor2 = Color.MediumTurquoise;
            label4.Visible = true;
            NumUpdownBuyerAmount.Visible = true;
            withdr = true;
            depos = false;
        }

        private void ButtonBuyerAccCancel_Click(object sender, EventArgs e)
        {
            ButtonBuyerAccDeposit.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonBuyerAccDeposit.BaseColor2 = Color.FromArgb(211, 32, 79);
            ButtonBuyerAccWithdrw.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonBuyerAccWithdrw.BaseColor2 = Color.FromArgb(211, 32, 79);
            label4.Visible = false;
            NumUpdownBuyerAmount.Visible = false;
            depos = withdr = false;


        }

        private void ButtonBuyerAccSubmit_Click(object sender, EventArgs e)
        {

            String AMOUNT = "";
            Boolean entry = false;
            if (depos || withdr)
            {


                if (depos)
                {
                     AMOUNT = Convert.ToString(Convert.ToDouble(Buyer_Info.AMOUNT)+ Convert.ToDouble(NumUpdownBuyerAmount.Value));
                    entry = true;
                 

                }

                if (withdr)
                {

                    if (Convert.ToDouble(NumUpdownBuyerAmount.Value) > Convert.ToDouble(Buyer_Info.AMOUNT))
                    {
                        MessageBox.Show("You have not enough money", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { 
                    
                       AMOUNT = Convert.ToString(Convert.ToDouble(Buyer_Info.AMOUNT) - Convert.ToDouble(NumUpdownBuyerAmount.Value));


                        entry = true;
                     
                    }
                  

                }
             
            }

            if (entry)
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "UPDATE ACCOUNT SET AMOUNT=@amoun where ACCOUNT_NO=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@amoun", AMOUNT);

                cmd.Parameters.AddWithValue("@id", Buyer_Info.BANK_ACCOUNT_NUMBER);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                     DialogResult ok = MessageBox.Show("Transaction Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                if (ok == DialogResult.OK)
                {
                    this.Hide();
                    new Buyer_Info(Buyer_Info.USER_NAME);
                    new Buyer_Account().Show();
                }
                else
                {
                    this.Hide();
                    new Buyer_Info(Buyer_Info.USER_NAME);
                    new Buyer_Account().Show();
                }
                  
                }
                else
                {
                    MessageBox.Show("OOPS!! an Error Ocured. Please Try Again.");
                    Application.Exit();
                }


              
            }





        }

        private void ButtonBuyerPortalJobPost_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelJobPost);

        }

        private void ButtonBuyerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

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

        private void gunaCirclePictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void NumUpdownBuyerAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BuyerBalance_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
