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
    public partial class Seller_RecentJob_Panel : UserControl
    {
        byte[] PIC;
        String SNAME = "";
        String SPOST = "";
       // String SDAY = "";
      //  String SHOUR = "";
      //  String SMINUTE = "";
      //  String SSECOND = "";
        String SPAYMENT = "";
        String STIME = "";
        String BNAME = "";
        String ETIME = "";
        public Seller_RecentJob_Panel(byte[] p, String sname, String spost, String etime, String spayment, String stime, String bname)
        {
            InitializeComponent();
            PIC = p;
            SNAME = sname;
            SPOST = spost;
          
            SPAYMENT = spayment;
            STIME = stime;
            BNAME = bname;
            ETIME = etime;
        }

        private void LabelSellerDay_Click(object sender, EventArgs e)
        {

        }

        private void Seller_RecentJob_Panel_Load(object sender, EventArgs e)
        {
            timer1.Start();
            RAW_Function rf = new RAW_Function();
            string time = rf.FutureCounter(ETIME);
            string[] countTime = time.Split(',');

            PictureBoxSellerRecentJob.Image = GetPhoto(PIC);
            LabelSellerRecentJobName.Text = SNAME;
            label1.Text = "JobId: " + SPOST;
            LabelSellerSecond.Text = countTime[3];
            LabelDaySeller.Text = countTime[0];
            LabelSellerMinute.Text = countTime[2];
            LabelSellerHour.Text = countTime[1];
            LabelSellerRecentJobPayment.Text = "Price: " + SPAYMENT + "$";
            LabelSellerRecentJobDuration.Text = "Time: " + STIME + " Day";
            LabelSellerRecentJobBuyerName.Text = BNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RAW_Function rf = new RAW_Function();
            string time = rf.FutureCounter(ETIME);
            string[] countTime = time.Split(',');
            LabelSellerSecond.Text = countTime[3];
            LabelDaySeller.Text = countTime[0];
            LabelSellerMinute.Text = countTime[2];
            LabelSellerHour.Text = countTime[1];
        }

        private void ButtonSellerViewJob_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Hide();
            new Job_Info(SPOST);
            new Seller_Submit_page().Show();
        }
    }
}
