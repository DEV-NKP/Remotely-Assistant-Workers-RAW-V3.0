using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Applicant_User_Control : UserControl
    {

        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;

        public byte[] PIC;
        public String BNAME = "";
        public String BPOST = "";
        public String BDESCRIP = "";
        public String BPAYMENT = "";
        public String BTIME = "";
        public String APPTIME = "";
        public String ID = "";

        public Applicant_User_Control()
        {
            InitializeComponent();
        }

        public Applicant_User_Control(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String apptime, String id)
        {
            InitializeComponent();
            PIC = p;
            BNAME = bname;
            BPOST = bpost;
            BDESCRIP = bdescrip;
            BPAYMENT =  bpayment;
            BTIME = btime;
            APPTIME = apptime;
            ID = id;
        }


        private void Applicant_User_Control_Load(object sender, EventArgs e)
        {
            PictureBoxBuyerManageJob.Image = GetPhoto(PIC);
            LabelBuyerName.Text = BNAME;
            LabelBuyerPost.Text = "Rating:  "+BPOST;
            DescribeApplicant.Text = BDESCRIP;
            ApplicantPrice.Text = "Price: " + BPAYMENT + "$";
            ApplicantTime.Text = "Time: " + BTIME + " Day";

           

            ApplyingTime.Text = APPTIME;
            JobId.Text = "JobId: " + ID;
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonBuyerManageJob_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from APPLY_JOB where JOB_ID=@id and SELLER_NAME=@sname";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@sname", BNAME);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                ((Form)this.TopLevelControl).Hide();
               
                new View_Applicant(ID).Show();
            }
            else
            {
                MessageBox.Show("OOPS!! an error occure please try again.");
                Application.Exit();
            }
        }

        private void ButtonBuyerViewJob_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from APPLY_JOB where JOB_ID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@sname", BNAME);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {

                String selleracctime = new RAW_Function().dtime();
                String endtime = new RAW_Function().addDate(Convert.ToInt32(BTIME));
                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "INSERT INTO PROGRESS_JOB VALUES(@jobid,@bname,@sname,@sactime,@jend,@subtime,@workacctime);";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@jobid", ID);
                cmd1.Parameters.AddWithValue("@bname", Buyer_Info.USER_NAME);
                cmd1.Parameters.AddWithValue("@sname", BNAME);
                cmd1.Parameters.AddWithValue("@sactime", selleracctime);
                cmd1.Parameters.AddWithValue("@jend", endtime);
                cmd1.Parameters.AddWithValue("@subtime", "N/A");
                cmd1.Parameters.AddWithValue("@workacctime", "N/A");
           


                con1.Open();
                int a1 = cmd1.ExecuteNonQuery();

                if (a1 > 0)
                {

                    SqlConnection con2 = new SqlConnection(cs);
                    String query2 = "UPDATE JOB_INFO SET  JOB_STATUS =@jstatus WHERE JOB_ID=@jid;";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@jid", ID);
                    cmd2.Parameters.AddWithValue("@jstatus", "Progress");
                    


                    con2.Open();
                    int a2 = cmd2.ExecuteNonQuery();

                    if (a2 > 0)
                    {
                        MessageBox.Show("Accepted !!! Wait for seller submission.");
                        ((Form)this.TopLevelControl).Hide();

                        new Buyer_Manage_Job().Show();
                    }
                    else
                    {
                        MessageBox.Show("OOPS!! ERROR. Try again.");
                        Application.Exit();
                    }
                    con2.Close();




                
                }
                else
                {
                    MessageBox.Show("OOPS!! ERROR. Try again.");
                    Application.Exit();
                }
                con1.Close();

            }
            else
            {
                MessageBox.Show("OOPS!! an error occure please try again.");
                Application.Exit();
            }
            con.Close();
       





        }

        private void DescribeApplicant_Click(object sender, EventArgs e)
        {

        }
    }
}
