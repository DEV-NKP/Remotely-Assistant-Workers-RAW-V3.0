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
    public partial class Buyer_RecentJob_Panel : UserControl
    {

        byte[] PIC;
        String BNAME = "";
        String BPOST = "";
        String BSTATUS = "";
        String BACCTIME = "";
        String BENDTIME = "";
     //   String BMINUTE = "";
        String BPAYMENT = "";
        String BTIME = "";
        String SNAME = "";
        public Buyer_RecentJob_Panel(byte[] p, String bname, String bprice, String btime, String bpost, String status, String sname, String acctime, String endtime)
        {

            InitializeComponent();
            PIC = p;
            BNAME = bname;
            BPOST = bpost;
            BSTATUS = status;
            BACCTIME = acctime;
            BENDTIME = endtime;
            BPAYMENT = bprice;
            BTIME = btime;
            SNAME = sname;
        }
        public void timecalculate()
        { 
            
        }
        private void Buyer_RecentJob_Panel_Load(object sender, EventArgs e)
        {
            
           // MessageBox.Show(BENDTIME);
            timer1.Start();
            RAW_Function rf = new RAW_Function();
            string time = rf.FutureCounter(BENDTIME);
       
            string[] countTime = time.Split(',');
          

                PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
                LabelBuyerRecentJobName.Text = BNAME;
            JobId.Text = "JobId: " + BPOST;
            LabelSecond.Text = countTime[3];
            LabelDay.Text = countTime[0];
            LabelMinute.Text = countTime[2];
            LabelHour.Text = countTime[1];
            LabelBuyerRecentJobPayment.Text = "Price: " + BPAYMENT + "$";
            LabelBuyerRecentJobDuration.Text = "Time: " + BTIME + " Day";
            LabelRecentJobSellerName.Text = SNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RAW_Function rf = new RAW_Function();
            string time = rf.FutureCounter(BENDTIME);
            string[] countTime = time.Split(',');
            LabelSecond.Text = countTime[3];
            LabelDay.Text = countTime[0];
            LabelMinute.Text = countTime[2];
            LabelHour.Text = countTime[1];
        }
    }
}
