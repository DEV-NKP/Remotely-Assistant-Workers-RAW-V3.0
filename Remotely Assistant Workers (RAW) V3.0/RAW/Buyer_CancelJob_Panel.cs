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

  

    public partial class Buyer_CancelJob_Panel : UserControl
    {
        
        String cs = ConfigurationManager.ConnectionStrings["RAW"].ConnectionString;
        byte[] PIC;
        String BNAME = "";
        String BPOST = "";
        String BDESCRIP = "";
        String BPAYMENT = "";
        String BTIME = "";
        String SNAME = "";
        public Buyer_CancelJob_Panel(byte[] p, String bname, String bpost, String bdescrip, String bpayment, String btime, String sname)
        {
            InitializeComponent();
            PIC = p;
            SNAME = sname;
            BPOST = bpost;
            BDESCRIP = bdescrip;
            BPAYMENT = bpayment;
            BTIME = btime;
            BNAME = bname;
        }

        private void Buyer_CancelJob_Panel_Load(object sender, EventArgs e)
        {
            PictureBoxBuyerCancelJob.Image = GetPhoto(PIC);
            LabelBuyerName.Text = SNAME;
            label1.Text = "JobId: " + BPOST;
            TextboxBuyerCancelJobDescription.Text = BDESCRIP;
            LabelBuyerCancelJobPayment.Text = "Price: " + BPAYMENT + "$";
            LabelBuyerCancelJobDuration.Text = "Time: " + BTIME + " Day";
            LabelBuyerCancelJobSellername.Text = BNAME;
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void ButtonBuyerCancelJob_Click(object sender, EventArgs e)
        {
            String cancelreqby = Buyer_Info.USER_NAME;
            String cancelaccby = SNAME;
            String canceltime = new RAW_Function().dtime();


            SqlConnection con2 = new SqlConnection(cs);
            String query2 = "INSERT INTO CANCEL_JOB VALUES(@id, @crb, @cab, @ct, @crt);";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@id", BPOST);
            cmd2.Parameters.AddWithValue("@crb", cancelreqby);
            cmd2.Parameters.AddWithValue("@cab", cancelaccby);
            cmd2.Parameters.AddWithValue("@ct", canceltime);
            cmd2.Parameters.AddWithValue("@crt", canceltime);


            con2.Open();
            int a2 = cmd2.ExecuteNonQuery();

            if (a2 > 0)
            {

                SqlConnection con1 = new SqlConnection(cs);
                String query1 = "UPDATE JOB_INFO SET  JOB_STATUS =@jstatus WHERE JOB_ID=@jid;";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@jid", BPOST);
                cmd1.Parameters.AddWithValue("@jstatus", "Cancel");



                con1.Open();
                int a1 = cmd1.ExecuteNonQuery();

                if (a1 > 0)
                {

                    SqlConnection con = new SqlConnection(cs);
                    string query = "delete from PROGRESS_JOB where JOB_ID=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", BPOST);
                   
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Canceled !!!.");
                   ((Form)this.TopLevelControl).Hide();

                   new Buyer_Cancel_Job().Show();
                    }
                    else
                    {
                        MessageBox.Show("OOPS!! an error occure please try again.");
                        Application.Exit();
                    }
                    con.Close();
                   




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
                MessageBox.Show("OOPS!! ERROR. Try again.");
                Application.Exit();
            }
            con2.Close();


        }
    }
}
