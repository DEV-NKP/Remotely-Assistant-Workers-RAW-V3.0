
namespace RAW
{
    partial class messenger_name_right
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.recName = new System.Windows.Forms.Label();
            this.image = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(13)))), ((int)(((byte)(25)))));
            this.panel2.Controls.Add(this.recName);
            this.panel2.Controls.Add(this.image);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 65);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // recName
            // 
            this.recName.AutoSize = true;
            this.recName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recName.ForeColor = System.Drawing.Color.White;
            this.recName.Location = new System.Drawing.Point(91, 22);
            this.recName.Name = "recName";
            this.recName.Size = new System.Drawing.Size(100, 22);
            this.recName.TabIndex = 3;
            this.recName.Text = "Full Name";
            // 
            // image
            // 
            this.image.BaseColor = System.Drawing.Color.White;
            this.image.Image = global::RAW.Properties.Resources.red_default1;
            this.image.Location = new System.Drawing.Point(29, 8);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(50, 50);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            this.image.UseTransfarantBackground = false;
            // 
            // messenger_name_right
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "messenger_name_right";
            this.Size = new System.Drawing.Size(340, 65);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label recName;
        private Guna.UI.WinForms.GunaCirclePictureBox image;
    }
}
