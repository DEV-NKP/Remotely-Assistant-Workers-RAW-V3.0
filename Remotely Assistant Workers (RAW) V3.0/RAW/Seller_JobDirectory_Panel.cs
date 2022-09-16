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
    public partial class Seller_JobDirectory_Panel : UserControl
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
        public Seller_JobDirectory_Panel()
        {
            InitializeComponent();
        }

        public Seller_JobDirectory_Panel(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String bappnum, String stat, byte[] bp, String bname1, String brating)
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
        private void Seller_JobDirectory_Panel_Load(object sender, EventArgs e)
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
            Brating.Text = BRATING;
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonSellerViewJob_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from APPLY_JOB where JOB_ID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", BPOST);
            
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                ((Form)this.TopLevelControl).Hide();

                new Seller_Job_Directory().Show();
            }
            else
            {
                MessageBox.Show("OOPS!! an error occure please try again.");
                Application.Exit();
            }
        }
    }
}
