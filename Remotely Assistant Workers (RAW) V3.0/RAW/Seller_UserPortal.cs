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
    public partial class Seller_UserPortal : UserControl
    {
        //byte[] PIC;
        //String SSTATUS = "";
        //String SNAME = "";
        //String SPOST = "";
        //String SCOUNTRY = "";
        //String SDATE = "";
        //String SRATE = "";
        //String SDESCRIP = "";
        public Seller_UserPortal()
        {
            InitializeComponent();
        }
        //public Seller_UserPortal(byte[] p, String sstatus, String sname, String spost, String scountry, String sdate, String srate, String sdescrip)
        //{
        //    InitializeComponent();
        //    PIC = p;
        //    SSTATUS = sstatus;
        //    SNAME = sname;
        //    SPOST = spost;
        //    SCOUNTRY = scountry;
        //    SDATE = sdate;
        //    SRATE = srate;
        //    SDESCRIP = sdescrip;
        //}

        private void Seller_UserPortal_Load(object sender, EventArgs e)
        {
            PictureBoxSellerPortal.Image = GetPhoto(Seller_Info.PROFILE_PICTURE);
            ButtonSellerStatus.Text = Seller_Info.STATUS;
            LabelSellerName.Text = Seller_Info.USER_NAME;
            label2.Text = Seller_Info.RAW_POST;
            label4.Text = "Country: "+ Seller_Info.COUNTRY;

            string[] afterSplit = Seller_Info.SIGN_UP_TIME.Split(',');

            label3.Text = "Since: " + afterSplit[0];
            TextFieldSellerPortalBio.Text = Seller_Info.DESCRIPTION; ;
            LabelSellerPortalRating.Text = "Rating: " + Seller_Info.TOTAL_RATING + " out of 5";

        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonSellerPortalLogout_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Hide();
            new RAW_Function().RemoveRemember();
            new Landing_Page().Show();
        }
    }
}
