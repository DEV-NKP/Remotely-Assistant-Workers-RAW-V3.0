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
    public partial class Seller_PreviousJob_Panel : UserControl
    {
        byte[] PIC;
        String SNAME = "";
        String SPOST = "";
        String SLINK = "";
        String SPAYMENT = "";
        String STIME = "";
        String BNAME = "";
        public Seller_PreviousJob_Panel(byte[] p, String sname, String spost, String slink, String spayment, String stime, String bname)
        {
            InitializeComponent();
            PIC = p;
            SNAME = sname;
            SPOST = spost;
            SLINK = slink;
            SPAYMENT = spayment;
            STIME = stime;
            BNAME = bname;
        }

        private void Seller_PreviousJob_Panel_Load(object sender, EventArgs e)
        {
            PictureBoxSellerPreJob.Image = GetPhoto(PIC);
            LabelSellerPreJobName.Text = SNAME;
            label1.Text = "JobId: " + SPOST;
            LabelLinkSellerSubmitJob.Text = SLINK;
            LabelSellerPreJobPayment.Text = "Price: " + SPAYMENT + "$";
            LabelSellerPreJobDuration.Text = "Time: " + STIME + " Day";
            LabelSellerPreJobBuyerName.Text = BNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }
    }
}
