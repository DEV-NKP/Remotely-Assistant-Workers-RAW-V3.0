using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class SellerSearchPanel : UserControl
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        public byte[] PIC;
        public String BNAME = "";
        public String BPOST = "";
        public String BDESCRIP = "";
        public String BPAYMENT = "";
        public String BTIME = "";
        public String APPNUM = "";
        public String status = "";
        public byte[] BPIC;
        public String BNAME1 = "";
        public String BRATING = "";
        public SellerSearchPanel(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String bappnum, String stat, byte[] bp, String bname1, String brating)
        {
            InitializeComponent();
            PIC = p;
            BNAME = bname;
            BPOST = bpost;
            BDESCRIP = bdescrip;
            BPAYMENT = bpayment;
            BTIME = btime;
            APPNUM = bappnum;
            status = stat;
            BPIC = bp;
            BNAME1 = bname1;
            BRATING = brating;
        }

        private void SellerSearchPanel_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM APPLY_JOB WHERE JOB_ID=@bid AND SELLER_NAME=@seller;";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@bid", BPOST);
            cmd.Parameters.AddWithValue("@seller", Seller_Info.USER_NAME);
            con.Open();
            SqlDataReader sda = cmd.ExecuteReader();
            if (sda.HasRows == true)
            {
                PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
                LabelBuyerName.Text = BNAME;
                label1.Text = "JobId: " + BPOST;
                TextboxBuyerManageJobDescription.Text = BDESCRIP;
                LabelsellerPayment.Text = "Price: " + BPAYMENT + "$";
                LabelSellerManageJobDuration.Text = "Time: " + BTIME + " Day";
                LabelBuyerManageJobApp.Text = APPNUM;
                jstatus.Text = status;
                BuyerPicture.Image = GetPhoto(BPIC);
                Bnamelab.Text = BNAME1;
                Brating.Text = "Rating: " + BRATING;
                ButtonSellerViewJob.Visible = false;

            }
            else
            {
                PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
                LabelBuyerName.Text = BNAME;
                label1.Text = "JobId: " + BPOST;
                TextboxBuyerManageJobDescription.Text = BDESCRIP;
                LabelsellerPayment.Text = "Price: " + BPAYMENT + "$";
                LabelSellerManageJobDuration.Text = "Time: " + BTIME + " Day";
                LabelBuyerManageJobApp.Text = APPNUM;
                jstatus.Text = status;
                BuyerPicture.Image = GetPhoto(BPIC);
                Bnamelab.Text = BNAME1;
                Brating.Text = "Rating: " + BRATING;
            }
            con.Close();

            
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonSellerViewJob_Click(object sender, EventArgs e)
        {
           // String Sellermsg = "N/A";
            String apptime = new RAW_Function().dtime();

            SqlConnection con2 = new SqlConnection(cs);
            String query2 = "INSERT INTO APPLY_JOB VALUES(@id, @bname, @sname, @apptime,@status, @cmnt);";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@id", BPOST);
            cmd2.Parameters.AddWithValue("@bname", BNAME1);
            cmd2.Parameters.AddWithValue("@sname", Seller_Info.USER_NAME);
            cmd2.Parameters.AddWithValue("@status", "Active");
            cmd2.Parameters.AddWithValue("@apptime", apptime);
            cmd2.Parameters.AddWithValue("@cmnt", "N/A");


            con2.Open();
            int a2 = cmd2.ExecuteNonQuery();

            if (a2 > 0)
            {
                MessageBox.Show("HURRAY!!! Application Sent. Wait for buyer response.");
                ButtonSellerViewJob.Visible = false;
            }
            else
            {
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con2.Close();

        }
    }

    internal class sqlconnection
    {
    }
}
