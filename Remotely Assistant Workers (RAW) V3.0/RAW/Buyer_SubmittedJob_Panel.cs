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
    public partial class Buyer_SubmittedJob_Panel : UserControl
    {
        byte[] PIC;
        String BNAME = "";
        String BPOST = "";
        String BDESCRIP = "";
        String BPAYMENT = "";
        String BTIME = "";
        String SNAME = "";
        String SLINK = "";
        public Buyer_SubmittedJob_Panel(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String sname, String slink)
        {
            InitializeComponent();
            PIC = p;
            SNAME = sname;
            BPOST = bpost;
            BDESCRIP = bdescrip;
            BPAYMENT = bpayment;
            BTIME = btime;
            BNAME = bname;
            SLINK = slink;
        }

        private void Buyer_SubmittedJob_Panel_Load(object sender, EventArgs e)
        {
            PictureBoxBuyerSubJob.Image = GetPhoto(PIC);
            LabelBuyerName.Text = SNAME;
            label1.Text = "JobId: " + BPOST;
            TextboxBuyerSubJobDescription.Text = BDESCRIP;
            LabelBuyerSubJobPayment.Text = "Price: " + BPAYMENT + "$";
            LabelBuyerSubJobDuration.Text = "Time: " + BTIME + " Day";
            LabelBuyerCancelSubSellername.Text = BNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonBuyerSubJob_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Hide();
            new Job_Info(BPOST);
            new Buyer_Payment(SLINK,SNAME).Show();
        }
    }
}
