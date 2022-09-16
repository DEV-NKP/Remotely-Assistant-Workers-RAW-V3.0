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
    public partial class BuyerSearch_Panel : UserControl
    {
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
        public BuyerSearch_Panel()
        {
            InitializeComponent();
        }

        public BuyerSearch_Panel(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String bappnum, String stat, byte[] bp, String bname1,String brating )
        {
            InitializeComponent();
            PIC = p;
            BNAME = bname;
            BPOST = bpost;
            BDESCRIP = bdescrip;
            BPAYMENT =  bpayment ;
            BTIME = btime;
            APPNUM = bappnum;
            status = stat;
            BPIC = bp;
            BNAME1 = bname1;
            BRATING = brating;


        }


        private void BuyerSearch_Panel_Load(object sender, EventArgs e)
        {
            PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
            LabelBuyerName.Text = BNAME;
            label1.Text = "JobId: " + BPOST;
            TextboxBuyerManageJobDescription.Text = BDESCRIP;
            LabelBuyerManageJobPayment.Text = "Price: " + BPAYMENT + "$";
            LabelBuyerManageJobDuration.Text = "Time: " + BTIME + " Day";

            LabelBuyerManageJobApp.Text = APPNUM;
            jstatus.Text = status;
           BuyerPicture.Image=GetPhoto(BPIC);
         
            Bnamelab.Text = BNAME1;
            Brating.Text = BRATING;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }


    }
}
