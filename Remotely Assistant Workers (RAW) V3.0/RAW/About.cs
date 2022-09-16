using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class About : Form
    {

        String link = "https://www.youtube.com/watch?v=AuJNB6E_LVY";
        public About()
        {
            InitializeComponent();
        }

        private void EXIT_BUTTON_Click(object sender, EventArgs e)
        {
            DialogResult yesno = MessageBox.Show("Do you really want to quit?", "Information", MessageBoxButtons.OKCancel);
            if (yesno == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void ABOUT_BUTTON_Click(object sender, EventArgs e)
        {
           // ABOUT_BUTTON.BorderColor = Color.FromArgb(53, 188, 191);
        }

        private void HOME_BUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
            new Landing_Page().Show();
        }

        private void CONTACT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
            new Contact().Show();
        }

        private void FEEDBACK_BUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
            new FeedBack().Show();
        }

        private void REPORT_BUTTON_Click(object sender, EventArgs e)
        {
            this.Close();
            new Repost_User().Show();
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradient2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void About_Load(object sender, EventArgs e)
        {
             webBrowser1.Navigate(link);
           // 464, 280

            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            // html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='600' height='300' frameborder='0' allowfullscreen></iframe>";
            html += "<iframe width='437' height='255' src='https://www.youtube.com/embed/5uFQtKGP4XI?controls=0' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";

            html += "</body></html>";





            this.webBrowser2.DocumentText = html;
        }

        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
