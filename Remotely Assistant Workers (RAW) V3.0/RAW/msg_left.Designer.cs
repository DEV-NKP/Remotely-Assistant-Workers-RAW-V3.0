
namespace RAW
{
    partial class msg_left
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msg = new Guna.UI.WinForms.GunaElipsePanel();
            this.msgl = new System.Windows.Forms.Label();
            this.image = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.msg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.BackColor = System.Drawing.Color.Transparent;
            this.msg.BaseColor = System.Drawing.Color.LightSkyBlue;
            this.msg.Controls.Add(this.msgl);
            this.msg.Location = new System.Drawing.Point(61, 10);
            this.msg.Name = "msg";
            this.msg.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.msg.Radius = 10;
            this.msg.Size = new System.Drawing.Size(158, 37);
            this.msg.TabIndex = 21;
            // 
            // msgl
            // 
            this.msgl.AutoSize = true;
            this.msgl.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.msgl.Location = new System.Drawing.Point(10, 7);
            this.msgl.MaximumSize = new System.Drawing.Size(140, 0);
            this.msgl.Name = "msgl";
            this.msgl.Size = new System.Drawing.Size(41, 20);
            this.msgl.TabIndex = 171;
            this.msgl.Text = "Hello";
            // 
            // image
            // 
            this.image.BaseColor = System.Drawing.Color.White;
            this.image.Image = global::RAW.Properties.Resources.red_default1;
            this.image.Location = new System.Drawing.Point(3, 2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(50, 50);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 20;
            this.image.TabStop = false;
            this.image.UseTransfarantBackground = false;
            // 
            // msg_left
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.msg);
            this.Controls.Add(this.image);
            this.Name = "msg_left";
            this.Size = new System.Drawing.Size(352, 55);
            this.Load += new System.EventHandler(this.msg_left_Load);
            this.msg.ResumeLayout(false);
            this.msg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipsePanel msg;
        private System.Windows.Forms.Label msgl;
        private Guna.UI.WinForms.GunaCirclePictureBox image;
    }
}
