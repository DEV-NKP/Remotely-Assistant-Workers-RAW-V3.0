using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
   
    public partial class Buyer_ManageJob_Panel : UserControl
    {
        public byte[] PIC;
        public String BNAME = "";
        public String BPOST = "";
        public String BDESCRIP = "";
        public String BPAYMENT = "";
        public String BTIME = "";
        public String APPNUM = "";
        public String status = "";
        public Buyer_ManageJob_Panel()
        { InitializeComponent(); }
        public Buyer_ManageJob_Panel(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String bappnum, String stat)
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
        }

        private void Buyer_ManageJob_Panel_Load(object sender, EventArgs e)
        {
            PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
            LabelBuyerName.Text = BNAME;
            label1.Text = "JobId: " + BPOST;
            TextboxBuyerManageJobDescription.Text = BDESCRIP;
            LabelBuyerManageJobPayment.Text = "Price: " + BPAYMENT + "$";
            LabelBuyerManageJobDuration.Text = "Time: " + BTIME + " Day";
            LabelBuyerManageJobApp.Text = APPNUM;
            jstatus.Text = status;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonBuyerManageJob_Click(object sender, EventArgs e)
        {
            new Job_Info(BPOST);
            ((Form)this.TopLevelControl).Hide();
            new Buyer_Manage_Job_Details().Show();
        }

        private void ButtonBuyerViewJob_Click(object sender, EventArgs e)
        {
            new Job_Info(BPOST);
            ((Form)this.TopLevelControl).Hide();
            new View_Applicant(BPOST).Show();
        }

        private void TextboxBuyerManageJobDescription_Click(object sender, EventArgs e)
        {

        }
    }
}
