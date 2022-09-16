using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAW
{
    public partial class Starting_Page : Form
    {
        public Starting_Page()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void LandingClose()
        {

            this.Close();
            new Landing_Page().Show();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 5;//5
            if (panel3.Width >= 700)
            {
                timer1.Stop();
                this.Hide();
                if (new RAW_Function().CheckRemember())
                {


                }
                else
                {
                    new Landing_Page().Show();
                }
            }

            if (panel3.Width <= 200)
            {
                label1.Text = "   Processing...   ";//100
            }
            if (panel3.Width <= 350 && panel3.Width > 200)
            {
                label1.Text = "   Connecting...   ";//200
            }
            if (panel3.Width <= 500 && panel3.Width > 350)
            {
                label1.Text = "  Almost Ready...  ";//300
            }
            if (panel3.Width <= 650 && panel3.Width > 500)
            {
                label1.Text = "Ready to Launch... ";//450
            }
            if (panel3.Width > 650)
            {
                label1.Text = "    Launching...   ";//last
            }
            else
            {

            }
        }

      
        public void randomText()
        {
            string[] names = { "Tips: You can easily report someone from the report option", "Tips: Give us feedback to serve you more.", "Tips: For any enquiry contact us at any time.", "Tips: Want to know more about RAW? Visit our ABOUT section" };
            Random r = new Random();

            int index = r.Next(names.Length);
            label2.Text = names[index];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Starting_Page_Load(object sender, EventArgs e)
        {
            timer1.Start();
            new RAW_Function().checkMe();
            randomText();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
