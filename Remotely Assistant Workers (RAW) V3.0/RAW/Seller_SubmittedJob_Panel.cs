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
    public partial class Seller_SubmittedJob_Panel : UserControl
    {
        byte[] PIC;
        String SNAME = "";
        String SPOST = "";
        String SDESCRIP = "";
        String SPAYMENT = "";
        String STIME = "";
        String BNAME = "";
        public Seller_SubmittedJob_Panel(byte[] p, String sname, String spost, String sdescrip, String spayment, String stime, String bname)
        {
            InitializeComponent();
            PIC = p;
            SNAME = sname;
            SPOST = spost;
            SDESCRIP = sdescrip;
            SPAYMENT = spayment;
            STIME = stime;
            BNAME = bname;
        }

        private void Seller_SubmittedJob_Panel_Load(object sender, EventArgs e)
        {
            PictureBoxSellerSubJob.Image = GetPhoto(PIC);
            LabelSellerName.Text = SNAME;
            label1.Text = "JobId: " + SPOST;
            TextboxSellerSubJobDescription.Text = SDESCRIP;
            LabelSellerSubJobPayment.Text = "Price: " + SPAYMENT + "$";
            LabelSellerSubJobDuration.Text = "Time: " + STIME + " Day";
            LabelSellerSubJobBuyername.Text = BNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
    }
}
