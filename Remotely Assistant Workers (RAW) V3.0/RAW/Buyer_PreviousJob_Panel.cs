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
    public partial class Buyer_PreviousJob_Panel : UserControl
    {
        byte[] PIC;
        String BNAME = "";
        String BPOST = "";
        String BLINK = "";
        String BPAYMENT = "";
        String BTIME = "";
        String SNAME = "";
        public Buyer_PreviousJob_Panel(byte[] p, String bname, String bpost, String blink, String bpayment, String btime, String sname)
        {
            InitializeComponent();
            PIC = p;
            SNAME = sname;
            BPOST = bpost;
            BLINK = blink;
            BPAYMENT = bpayment;
            BTIME = btime;
            BNAME = bname;
        }

        private void Buyer_PreviousJob_Panel_Load(object sender, EventArgs e)
        {

            PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
            LabelBuyerSubJobName.Text = SNAME;
            label1.Text = "JobId: " + BPOST;
            LabelLinkBuyerSubmitJob.Text = BLINK;
            LabelBuyerSubJobPayment.Text = "Price: " + BPAYMENT + "$";
            LabelBuyerSubJobDuration.Text = "Time: " + BTIME + " Day";
            LabelBuyerSubJobSellername.Text = BNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
    }
}
