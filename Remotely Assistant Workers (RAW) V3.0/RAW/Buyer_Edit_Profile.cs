using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Buyer_Edit_Profile : Form
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);



        String FULL_NAME = "";
         String FIRST_NAME = "";
         String LAST_NAME = "";
          
          String MOBILE_NUMBER = "";
          String GENDER = "";

          String DATE_OF_BIRTH = "";

          String COUNTRY = "";
          String NATIONALITY = "";
          String STREET_ADDRESS = "";
          String ADDRESS_LINE_2 = "";
          String CITY = "";
          String STATE = "";
  
          byte[] PROFILE_PICTURE;

          String STATUS = "";
          String STATUS_MESSAGE = "";
      
          String DESCRIPTION = "";
      //    String HAVE_SELLER = "";
          

          String COMPANY_NAME = "";
          String COMPANY_TYPE = "";
        String HAVE_BUYER = "";





        Boolean fn = false;
        Boolean ln = false;
        Boolean con = false;
        Boolean nat = false;
        Boolean mob = false;
       Boolean add1 = false;
       Boolean add2 = false;
        Boolean str = false;
        Boolean cit = false;
        Boolean sta = false;
        Boolean cn = false;
        Boolean ct = false;
        Boolean des = false;
        Boolean sma = false;
        Boolean gen = false;
        Boolean stat = false;

        public Buyer_Edit_Profile()
        {
            InitializeComponent();
        }

        private void BuyerSignUp_Next_Click(object sender, EventArgs e)
        {

            LAST_NAME = EditProfileLastName.Text;
             FIRST_NAME = EditProfileFirstName.Text;

            DATE_OF_BIRTH = Convert.ToString(EditProfileDOB.Value);


            FULL_NAME = FIRST_NAME + " " + LAST_NAME;
            String USER_NAME = Buyer_Info.USER_NAME;

            PROFILE_PICTURE = Savephoto();
            COUNTRY = EditProfileCountry.Text;
            MOBILE_NUMBER = EditProfileMobile.Text;

            NATIONALITY = EditProfileNationality.Text;
            STREET_ADDRESS = EditProfileStreet.Text;
            ADDRESS_LINE_2 = EditProfileAddressLine2.Text;
            CITY = EditProfileCity.Text;
            STATE = EditProfileState.Text;

            
            STATUS_MESSAGE = EditProfileStatusMessage.Text;


            COMPANY_NAME = EditProfileCompanyName.Text;
            COMPANY_TYPE = EditProfileCompanyType.Text;


            DESCRIPTION = EditProfileDescription.Text;

            if (EditProfileHaveSeller.Checked)
            { 
            HAVE_BUYER = "YES";
            
            }
            if (!EditProfileHaveSeller.Checked)
            {
                HAVE_BUYER = "NO";

            }

            RAW_Function rf = new RAW_Function();


            SqlConnection con2 = new SqlConnection(cs);
            String query2 = "UPDATE BUYER_SIGNUP_BASIC_DETAILS SET FULL_NAME=@fullname ,  FIRST_NAME=@firstname,  LAST_NAME=@lastname,  MOBILE_NUMBER=@mobile,  GENDER=@gender WHERE USER_NAME=@user;";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            
            cmd2.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd2.Parameters.AddWithValue("@firstname", FIRST_NAME);
            cmd2.Parameters.AddWithValue("@lastname", LAST_NAME);
            cmd2.Parameters.AddWithValue("@user", USER_NAME);
            cmd2.Parameters.AddWithValue("@mobile", MOBILE_NUMBER);
            cmd2.Parameters.AddWithValue("@gender", GENDER);

            con2.Open();
            int a2 = cmd2.ExecuteNonQuery();

            if (a2 > 0)
            {


            }
            else
            {
                MessageBox.Show("OOPS!! ERROR5. Try again.");
                Application.Exit();
            }
            con2.Close();


            SqlConnection con3 = new SqlConnection(cs);
            String query3 = "UPDATE BUYER_SIGNUP_PERSONAL_DETAILS SET FULL_NAME=@fullname ,  DATE_OF_BIRTH=@dob,  COUNTRY=@country,  NATIONALITY=@nationality,  STREET_ADDRESS=@street,  ADDRESS_LINE_2=@address2,  CITY=@city,  STATE=@state WHERE USER_NAME=@user;";

            SqlCommand cmd3 = new SqlCommand(query3, con3);
        
            cmd3.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd3.Parameters.AddWithValue("@dob", DATE_OF_BIRTH);
            cmd3.Parameters.AddWithValue("@user", USER_NAME);
            cmd3.Parameters.AddWithValue("@country", COUNTRY);
            cmd3.Parameters.AddWithValue("@nationality", NATIONALITY);
            cmd3.Parameters.AddWithValue("@street", STREET_ADDRESS);
            cmd3.Parameters.AddWithValue("@address2", ADDRESS_LINE_2);
            cmd3.Parameters.AddWithValue("@city", CITY);
            cmd3.Parameters.AddWithValue("@state", STATE);

            con3.Open();
            int a3 = cmd3.ExecuteNonQuery();

            if (a3 > 0)
            {


            }
            else
            {
                MessageBox.Show("OOPS!! ERROR4. Try again.");
                Application.Exit();
            }
            con3.Close();



            SqlConnection con4 = new SqlConnection(cs);
            String query4 = "UPDATE BUYER_SIGNUP_USER_DETAILS SET FULL_NAME=@fullname ,  PROFILE_PICTURE=@profilepic,  STATUS=@status,  STATUS_MESSAGE=@statusmsg WHERE USER_NAME=@user;";

            SqlCommand cmd4 = new SqlCommand(query4, con4);
            cmd4.Parameters.AddWithValue("@user", USER_NAME);
            
            cmd4.Parameters.AddWithValue("@fullname", FULL_NAME);
            
            cmd4.Parameters.AddWithValue("@profilepic", PROFILE_PICTURE);
            
            cmd4.Parameters.AddWithValue("@status", STATUS);
            cmd4.Parameters.AddWithValue("@statusmsg", STATUS_MESSAGE);
          
            con4.Open();
            int a4 = cmd4.ExecuteNonQuery();

            if (a4 > 0)
            {


            }
            else
            {
                MessageBox.Show("OOPS!! ERROR3. Try again.");
                Application.Exit();
            }
            con4.Close();



            SqlConnection con5 = new SqlConnection(cs);

            String query5 = "UPDATE BUYER_SIGNUP_COMPANY_DETAILS SET FULL_NAME=@fullname ,  COMPANY_NAME=@companyname,  COMPANY_TYPE=@companytype WHERE USER_NAME=@user;";


            SqlCommand cmd5 = new SqlCommand(query5, con5);
            cmd5.Parameters.AddWithValue("@user", USER_NAME);

            cmd5.Parameters.AddWithValue("@fullname", FULL_NAME);
            cmd5.Parameters.AddWithValue("@companyname", COMPANY_NAME);
            cmd5.Parameters.AddWithValue("@companytype", COMPANY_TYPE);

            con5.Open();
            int a5 = cmd5.ExecuteNonQuery();

            if (a5 > 0)
            {


            }
            else
            {
                MessageBox.Show("OOPS!! ERROR2. Try again.");
                Application.Exit();
            }
            con5.Close();

            SqlConnection con6 = new SqlConnection(cs);

            String query6 = "UPDATE BUYER_SIGNUP_ACCOUNT_DETAILS SET FULL_NAME=@fullname ,  DESCRIPTION=@description,  HAVE_SELLER=@haveseller WHERE USER_NAME=@user;";

            SqlCommand cmd6 = new SqlCommand(query6, con6);
            cmd6.Parameters.AddWithValue("@user", USER_NAME);
            
            cmd6.Parameters.AddWithValue("@fullname", FULL_NAME);
           
            cmd6.Parameters.AddWithValue("@description", DESCRIPTION);
            cmd6.Parameters.AddWithValue("@haveseller", HAVE_BUYER);
            
            con6.Open();
            int a6 = cmd6.ExecuteNonQuery();

            if (a6 > 0)
            {


            }
            else
            {
                MessageBox.Show("OOPS!! ERROR1. Try again.");
                Application.Exit();
            }
            con6.Close();




            DialogResult ok = MessageBox.Show("Update Successful", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);



            if (ok == DialogResult.OK)
            {
                this.Hide();
                new Buyer_Info(USER_NAME);
                new Buyer_Profile().Show();
            }
            else
            {
                this.Hide();
                new Buyer_Info(USER_NAME);
                new Buyer_Profile().Show();
            }






        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void EnableButton()
        {

            if (fn && ln && con && nat && mob  && str && cit && sta && cn && ct && des && sma && gen && stat)
            {

                EditProfileSubmit.Enabled = true;


            }

            else {

                EditProfileSubmit.Enabled = false;
            }

        }


        private void EditProfileAddressLine2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileAddressLine2.Text))
            {
                add2 = false;
                EnableButton();
            }
            else
            {

                add2 = true;
                EnableButton();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void EditProfileFirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileFirstName.Text))
            {
                fn = false;
                EnableButton();
            }
            else
            {

                fn = true;
                EnableButton();
            }


        }

        private void EditProfileLastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileLastName.Text))
            {
                ln = false;
                EnableButton();
            }
            else
            {

                ln = true;
                EnableButton();
            }
        }

        private void EditProfileCountry_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileCountry.Text))
            {
                con = false;
                EnableButton();
            }
            else
            {

                con= true;
                EnableButton();
            }
        }

        private void EditProfileNationality_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileNationality.Text))
            {
                nat = false;
                EnableButton();
            }
            else
            {

                nat = true;
                EnableButton();
            }
        }

        private void EditProfileMobile_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileMobile.Text))
            {
                mob = false;
                EnableButton();
            }
            else
            {

                mob = true;
                EnableButton();
            }

            RAW_Function rw = new RAW_Function();

            if (!rw.IsValidMobile(EditProfileMobile.Text))
            {
                mob = false;
                labelM.Visible = true;
                errorProvider1.SetError(this.EditProfileMobile, "Please enter a valid Mobile Number");
                EnableButton();
            }
            else
            {

                mob = true;
                labelM.Visible = false;
                errorProvider1.Clear();

                EnableButton();
            }
        }

 

        private void EditProfileStreet_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileStreet.Text))
            {
                str = false;
                EnableButton();
            }
            else
            {

                str = true;
                EnableButton();
            }
        }

        private void EditProfileCity_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileCity.Text))
            {
                cit = false;
                EnableButton();
            }
            else
            {

                cit = true;
                EnableButton();
            }
        }

        private void EditProfileState_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileState.Text))
            {
                sta = false;
                EnableButton();
            }
            else
            {

                sta = true;
                EnableButton();
            }
        }

        private void EditProfileCompanyName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileCompanyName.Text))
            {
                cn = false;
                EnableButton();
            }
            else
            {

                cn = true;
                EnableButton();
            }
        }

        private void EditProfileCompanyType_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileCompanyType.Text))
            {
                ct = false;
                EnableButton();
            }
            else
            {

                ct = true;
                EnableButton();
            }
        }

        private void EditProfileDescription_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileDescription.Text))
            {
                des = false;
                EnableButton();
            }
            else
            {

                des = true;
                EnableButton();
            }
        }

        private void EditProfileStatusMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EditProfileStatusMessage.Text))
            {
                sma= false;
                EnableButton();
            }
            else
            {

                sma = true;
                EnableButton();
            }
        }

        private void EditProfileMale_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = EditProfileMale.Text;
            gen = true;
        }

        private void EditProfileFemale_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = EditProfileFemale.Text;
            gen = true;
        }

        private void EditProfileOther_CheckedChanged(object sender, EventArgs e)
        {
            GENDER = EditProfileOther.Text;
            gen = true;
        }

        private void EditProfileActive_CheckedChanged(object sender, EventArgs e)
        {
            STATUS = EditProfileActive.Text;
            stat = true;
        }

        private void EditProfileBusy_CheckedChanged(object sender, EventArgs e)
        {
            STATUS = EditProfileBusy.Text;
            stat = true;
        }

        private void EditProfileOffline_CheckedChanged(object sender, EventArgs e)
        {
            STATUS = EditProfileOffline.Text;
            stat = true;
        }

        private void EditProfileResetAll_Click(object sender, EventArgs e)
        {

            fn = ln = con = nat = mob = str = cit = sta = cn = ct = des = sma = gen = stat = false;
            EditProfileAddressLine2.Text = "";
            EditProfileFirstName.Text = "";

                EditProfileLastName.Text = "";
            EditProfileCountry.Text = "";
            EditProfileNationality.Text = "";
            EditProfileMobile.Text = "";
           // EditProfileAddressLine.Text = "";
            EditProfileStreet.Text = "";
            EditProfileCity.Text = "";
            EditProfileState.Text = "";
            EditProfileCompanyName.Text = "";
            EditProfileCompanyType.Text = "";
            EditProfileDescription.Text = "";
            EditProfileStatusMessage.Text = "";
            EditProfileMale.Checked = false;
            EditProfileFemale.Checked = false;
            EditProfileOther.Checked = false;
            EditProfileActive.Checked = false;
            EditProfileBusy.Checked = false;
            EditProfileOffline.Checked = false;
            EditProfileHaveSeller.Checked = false;

            BuyerEditProfilePictureBox.Image = Properties.Resources.red_default1;
            EditProfileDOB.Value = DateTime.Now;

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BuyerSignUp_Profile_Picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "All Image (*) | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                BuyerEditProfilePictureBox.Image = new Bitmap(ofd.FileName);
              
            }
        }

        private byte[] Savephoto()
        {
            MemoryStream ms = new MemoryStream();
            BuyerEditProfilePictureBox.Image.Save(ms, BuyerEditProfilePictureBox.Image.RawFormat);
            return ms.GetBuffer();
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void BuyerEdit_Profile_Load(object sender, EventArgs e)
        {


            fn = ln = con = nat = mob = str = cit = sta = cn = ct = des = sma = gen = stat = true;
            EditProfileAddressLine2.Text = Buyer_Info.ADDRESS_LINE_2;
            EditProfileFirstName.Text = Buyer_Info.FIRST_NAME;

            EditProfileLastName.Text = Buyer_Info.LAST_NAME;
            EditProfileCountry.Text = Buyer_Info.COUNTRY;
            EditProfileNationality.Text = Buyer_Info.NATIONALITY;
            EditProfileMobile.Text = Buyer_Info.MOBILE_NUMBER;
            
            EditProfileStreet.Text = Buyer_Info.STREET_ADDRESS;
            EditProfileCity.Text = Buyer_Info.CITY;
            EditProfileState.Text = Buyer_Info.STATE;
            EditProfileCompanyName.Text = Buyer_Info.COMPANY_NAME;
            EditProfileCompanyType.Text = Buyer_Info.COMPANY_TYPE;
            EditProfileDescription.Text = Buyer_Info.DESCRIPTION;
            EditProfileStatusMessage.Text = Buyer_Info.STATUS_MESSAGE;
          //  EditProfileDOB.Value = Convert.ToDateTime(Buyer_Info.DATE_OF_BIRTH);

            if (Buyer_Info.GENDER.Equals("Male"))
            {
                EditProfileMale.Checked = true;
            }

            if (Buyer_Info.GENDER.Equals("Female"))
            {
                EditProfileFemale.Checked = true;
            }

            if (Buyer_Info.GENDER.Equals("Other"))
            {
                EditProfileOther.Checked = true;
            }


            if (Buyer_Info.STATUS.Equals("Active"))
            {
                EditProfileActive.Checked = true;
            }
            if (Buyer_Info.STATUS.Equals("Busy"))
            {
                EditProfileBusy.Checked = true;
            }
            if (Buyer_Info.STATUS.Equals("Offline"))
            {
                EditProfileOffline.Checked = true;
            }



            if (Buyer_Info.HAVE_SELLER.Equals("YES"))
            { 
            EditProfileHaveSeller.Checked = true;
            }
            

            BuyerEditProfilePictureBox.Image = GetPhoto(Buyer_Info.PROFILE_PICTURE);
            //EditProfileDOB.Value = DateTime.Now;
        }

        private void CancelButt_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Buyer_Profile().Show();
        }

        private void gunaPictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
