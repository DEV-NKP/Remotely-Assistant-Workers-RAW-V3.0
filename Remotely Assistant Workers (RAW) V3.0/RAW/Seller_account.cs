using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RAW
{
    public partial class Seller_account : Form
    {
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        Boolean depos = false;

        Boolean withdr = false;


        int viewp = 1;
        Seller_UserPortal sup = new Seller_UserPortal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public Seller_account()
        {
            new Seller_Info(Seller_Info.USER_NAME);
            InitializeComponent();
        }

        private void customizeSubMenu()
        {
            PanelWorkHouse.Visible = false;
        }
        private void HideSubMenu()
        {

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

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ButtonSellerPortalWork_Click(object sender, EventArgs e)
        {
            ShowSubMenu(PanelWorkHouse);

        }

        private void Seller_account_Load(object sender, EventArgs e)
        {
            customizeSubMenu();
            SellerName.Text = Seller_Info.USER_NAME;
            label3.Text = Seller_Info.RAW_POST;
            SellerPortalStatus.Text = Seller_Info.STATUS;
            LabelSellerPortalName.Text = "Welcome " + Seller_Info.LAST_NAME + ", " + Seller_Info.FIRST_NAME;
            PictureBoxSellermain.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            PictureBoxSellerPortal.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            BuyerBalance.Text = Seller_Info.AMOUNT;

        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonSellerPortalProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Profile().Show();
        }

        private void ButtonSellerPortalSearch_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Search().Show();
        }

        private void ButtonSellerPortalJobPost_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Job_Directory().Show();
        }

        private void ButtonSellerPortalRecJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Recent_Job().Show();
        }

        private void ButtonSellerPortalSubob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Submitted_Job().Show();
        }

        private void ButtonSellerPortalPreJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Previous_Job().Show();
        }

        private void ButtonSellerPortalCanJob_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Cancel_Job().Show();
        }

        private void ButtonSellerPortalChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Seller_Messenger().Show();
        }

      

        private void PictureBoxSellerPortal_Click(object sender, EventArgs e)
        {
            sup.Visible = false;
            viewp++;

            //  MessageBox.Show(Convert.ToString(viewp));
            if (viewp % 2 == 0)
            {

                this.sup.Location = new System.Drawing.Point(980, 88);
                this.Controls.Add(sup);
                sup.Visible = true;
                sup.BringToFront();
                PictureBoxSellerPortal.BringToFront();
                // bup.Show();
            }
            else
            {
                sup.Hide();
                sup.Visible = false;
                sup.SendToBack();
                this.Controls.Remove(sup);


            }
        }

        private void PictureBoxSellermain_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSellerAccDeposit_Click(object sender, EventArgs e)
        {
            ButtonSellerAccDeposit.BaseColor1 = Color.MediumTurquoise;
            ButtonSellerAccDeposit.BaseColor2 = Color.MediumTurquoise;
            ButtonSellerAccWithdrw.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonSellerAccWithdrw.BaseColor2 = Color.FromArgb(211, 32, 79);
            label4.Visible = true;
            NumUpdownSellerAmount.Visible = true;
            depos = true;
            withdr = false;

        }

        private void ButtonSellerAccWithdrw_Click(object sender, EventArgs e)
        {
            ButtonSellerAccDeposit.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonSellerAccDeposit.BaseColor2 = Color.FromArgb(211, 32, 79);
            ButtonSellerAccWithdrw.BaseColor1 = Color.PaleTurquoise;
            ButtonSellerAccWithdrw.BaseColor2 = Color.PaleTurquoise;
            label4.Visible = true;
            NumUpdownSellerAmount.Visible = true;
            withdr = true;
            depos = false;
        }

        private void ButtonSellerAccCancel_Click(object sender, EventArgs e)
        {
            ButtonSellerAccDeposit.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonSellerAccDeposit.BaseColor2 = Color.FromArgb(211, 32, 79);
            ButtonSellerAccWithdrw.BaseColor1 = Color.FromArgb(211, 32, 79);
            ButtonSellerAccWithdrw.BaseColor2 = Color.FromArgb(211, 32, 79);
            label4.Visible = false;
            NumUpdownSellerAmount.Visible = false;
            depos = withdr = false;


        }

        private void NumUpdownSellerAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ButtonSellerAccSubmit_Click(object sender, EventArgs e)
        {
            String AMOUNT = "";
            Boolean entry = false;
            if (depos || withdr)
            {
                if (depos)
                {
                    AMOUNT = Convert.ToString(Convert.ToDouble(Seller_Info.AMOUNT) + Convert.ToDouble(NumUpdownSellerAmount.Value));
                    entry = true;
                }

                if (withdr)
                {
                    if (Convert.ToDouble(NumUpdownSellerAmount.Value) > Convert.ToDouble(Seller_Info.AMOUNT))
                    {
                        MessageBox.Show("You have not enough money", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        AMOUNT = Convert.ToString(Convert.ToDouble(Seller_Info.AMOUNT) - Convert.ToDouble(NumUpdownSellerAmount.Value));
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
                cmd.Parameters.AddWithValue("@id", Seller_Info.BANK_ACCOUNT_NUMBER);
                con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    DialogResult ok = MessageBox.Show("Transaction Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ok == DialogResult.OK)
                    {
                        this.Hide();
                        new Seller_Info(Seller_Info.USER_NAME);
                        new Seller_account().Show();
                    }
                    else
                    {
                        this.Hide();
                        new Seller_Info(Seller_Info.USER_NAME);
                        new Seller_account().Show();
                    }
                }
                else
                {
                    MessageBox.Show("OOPS!! an Error Ocured. Please Try Again.");
                    Application.Exit();
                }
            }

        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
