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
    public partial class Buyer_UserPortal : UserControl
    {
        /*
        byte[] PIC;
     public  static String BSTATUS = "";
        public static String BNAME = "";
        public static String BPOST = "";
        public static String BCOUNTRY = "";
        public static String BDATE = "";
        public static String BRATE = "";
        public static String BDESCRIP = "";
        */
        public Buyer_UserPortal()
        {
            InitializeComponent();
          
        }
        /*
        public void setvalue(byte[] p, String bstatus, String bname, String bpost, String bcountry, String bdate, String brate, String bdescrip)
        {
           
            PIC = p;
            BSTATUS = bstatus;
            BNAME = bname;
            BPOST = bpost;
            BCOUNTRY = bcountry;
            BDATE = bdate;
            BRATE = brate;
            BDESCRIP = bdescrip;
        }
        */
        private void Buyer_UserPortal_Load(object sender, EventArgs e)
        {
            PictureBoxBuyerPortal.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            ButtonBuyerStatus.Text = Buyer_Info.STATUS;
            LabelBuyerName.Text = Buyer_Info.USER_NAME;
            label2.Text = Buyer_Info.RAW_POST;
            label4.Text = "Country: "+ Buyer_Info.COUNTRY;

            
            string[] afterSplit = Buyer_Info.SIGN_UP_TIME.Split(',');

            label3.Text = "Since: "+ afterSplit[0];
            TextFieldBuyerPortalBio.Text = Buyer_Info.DESCRIPTION;
            LabelBuyerPortalRating.Text = "Rating: "+ Buyer_Info.TOTAL_RATING + " out of 5";
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void PictureBoxBuyerPortal_Click(object sender, EventArgs e)
        {

        }

        private void ButtonBuyerPortalLogout_Click(object sender, EventArgs e)
        {
            ((Form)this.TopLevelControl).Hide();
            new RAW_Function().RemoveRemember();
            new Landing_Page().Show();
        }
    }
}
