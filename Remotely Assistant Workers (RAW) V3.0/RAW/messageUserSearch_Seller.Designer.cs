
namespace RAW
{
    partial class messageUserSearch_Seller
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
            this.recFName = new System.Windows.Forms.Label();
            this.image = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(13)))), ((int)(((byte)(25)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.recName);
            this.panel2.Controls.Add(this.recFName);
            this.panel2.Controls.Add(this.image);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 65);
            this.panel2.TabIndex = 7;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // recName
            // 
            this.recName.AutoSize = true;
            this.recName.Font = new System.Drawing.Font("Baskerville Old Face", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recName.ForeColor = System.Drawing.Color.Gray;
            this.recName.Location = new System.Drawing.Point(70, 40);
            this.recName.Name = "recName";
            this.recName.Size = new System.Drawing.Size(68, 14);
            this.recName.TabIndex = 3;
            this.recName.Text = "User Name";
            // 
            // recFName
            // 
            this.recFName.AutoSize = true;
            this.recFName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recFName.ForeColor = System.Drawing.Color.White;
            this.recFName.Location = new System.Drawing.Point(66, 13);
            this.recFName.Name = "recFName";
            this.recFName.Size = new System.Drawing.Size(100, 22);
            this.recFName.TabIndex = 3;
            this.recFName.Text = "Full Name";
            // 
            // image
            // 
            this.image.BaseColor = System.Drawing.Color.White;
            this.image.Image = global::RAW.Properties.Resources.red_default1;
            this.image.Location = new System.Drawing.Point(12, 7);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(50, 50);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            this.image.UseTransfarantBackground = false;
            // 
            // messageUserSearch_Seller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "messageUserSearch_Seller";
            this.Size = new System.Drawing.Size(340, 65);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label recName;
        private System.Windows.Forms.Label recFName;
        private Guna.UI.WinForms.GunaCirclePictureBox image;
    }
}
