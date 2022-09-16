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
    public partial class Buyer_Cancel_Job : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        // ArrayList job = new ArrayList();

        Buyer_CancelJob_Panel[] bcp = new Buyer_CancelJob_Panel[50];
        int viewp = 1;
        Buyer_UserPortal bup = new Buyer_UserPortal();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void customizeSubMenu()
        {
            PanelJobPost.Visible = false;
            PanelWorkHouse.Visible = true;
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
        public Buyer_Cancel_Job()
        {
            InitializeComponent();
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

    

        private void Buyer_Cancel_Job_Load(object sender, EventArgs e)
        {


            {
                SqlConnection con = new SqlConnection(cs);
                String query = "SELECT * FROM JOB_INFO WHERE BUYER_NAME= @user AND JOB_STATUS=@jstatus;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", Buyer_Info.USER_NAME);
                cmd.Parameters.AddWithValue("@jstatus", "Progress");
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    int i = 0;
                    int x = 0, y = 0;
                    while (sda.Read())
                    {

                        byte[] image = ((byte[])(sda["JOB_IMAGE"]));
                        String bname = (sda["JOB_NAME"].ToString());
                        String bpost = (sda["JOB_ID"].ToString());
                        String bdet = (sda["JOB_DETAILS"].ToString());
                        String bprice = (sda["JOB_PRICE"].ToString());
                        String btime = (sda["JOB_TIME"].ToString());
                        String stat = (sda["JOB_STATUS"].ToString());
                        String sname = "";


                        SqlConnection con1 = new SqlConnection(cs);
                        String query1 = "SELECT * FROM PROGRESS_JOB WHERE JOB_ID=@id;";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@id",bpost);
                       
                        con1.Open();
                        SqlDataReader sda1 = cmd1.ExecuteReader();
                        if (sda1.HasRows == true)
                        {
                            
                            while (sda1.Read())
                            {
                                sname = (sda1["SELLER_NAME"].ToString());

                                bcp[i] = new Buyer_CancelJob_Panel(image, bname, bpost, bdet, bprice, btime, sname);

                                panel6.Controls.Add(bcp[i]);
                                bcp[i].Location = new System.Drawing.Point(x, y);
                                bcp[i].Visible = true;
                                bcp[i].BringToFront();

                                bcp[i].Show();

                                y += (bcp[i].Height + 10);
                            }
                            // MessageBox.Show(bjp[0].BPAYMENT);
                        }


                        else
                        {


                        }

                        con1.Close();

                       
                        i++;
                        //job.Add(bjp[0]);

                        /*  TOTAL_RATING = (sda["CURRENT_RATING"].ToString());
                          TOTAL_RATED_NUMBER = (sda["TOTAL_RATED_BY"].ToString());*/
                    }
                    // MessageBox.Show(bjp[0].BPAYMENT);
                }


                else
                {


                }

                con.Close();
            }





            customizeSubMenu();
            label6.Text = Buyer_Info.USER_NAME;
            label5.Text = Buyer_Info.RAW_POST;
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerPortalName.Text = "Welcome " + Buyer_Info.LAST_NAME + ", " + Buyer_Info.FIRST_NAME;
            gunaCirclePictureBox3.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
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
    }
}
