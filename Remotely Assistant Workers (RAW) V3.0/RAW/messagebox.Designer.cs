
namespace RAW
{
    partial class messagebox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(messagebox));
            this.panel9 = new System.Windows.Forms.Panel();
            this.send = new Guna.UI.WinForms.GunaAdvenceButton();
            this.attachFile = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.msgType = new Guna.UI.WinForms.GunaTextBox();
            this.msgpan = new System.Windows.Forms.Panel();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attachFile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.send);
            this.panel9.Controls.Add(this.attachFile);
            this.panel9.Controls.Add(this.msgType);
            this.panel9.Controls.Add(this.msgpan);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(640, 579);
            this.panel9.TabIndex = 170;
            // 
            // send
            // 
            this.send.AnimationHoverSpeed = 0.07F;
            this.send.AnimationSpeed = 0.03F;
            this.send.BackColor = System.Drawing.Color.Transparent;
            this.send.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.send.BorderColor = System.Drawing.Color.Black;
            this.send.CheckedBaseColor = System.Drawing.Color.Gray;
            this.send.CheckedBorderColor = System.Drawing.Color.Black;
            this.send.CheckedForeColor = System.Drawing.Color.White;
            this.send.CheckedImage = ((System.Drawing.Image)(resources.GetObject("send.CheckedImage")));
            this.send.CheckedLineColor = System.Drawing.Color.DimGray;
            this.send.DialogResult = System.Windows.Forms.DialogResult.None;
            this.send.FocusedColor = System.Drawing.Color.Empty;
            this.send.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send.ForeColor = System.Drawing.Color.White;
            this.send.Image = ((System.Drawing.Image)(resources.GetObject("send.Image")));
            this.send.ImageSize = new System.Drawing.Size(20, 20);
            this.send.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.send.Location = new System.Drawing.Point(511, 514);
            this.send.Name = "send";
            this.send.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.send.OnHoverBorderColor = System.Drawing.Color.LightSteelBlue;
            this.send.OnHoverForeColor = System.Drawing.Color.White;
            this.send.OnHoverImage = null;
            this.send.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.send.OnPressedColor = System.Drawing.Color.Black;
            this.send.Radius = 15;
            this.send.Size = new System.Drawing.Size(105, 42);
            this.send.TabIndex = 174;
            this.send.Text = "Send";
            this.send.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.send.TextOffsetX = 50;
            this.send.Click += new System.EventHandler(this.send_Click);
            this.send.MouseClick += new System.Windows.Forms.MouseEventHandler(this.send_MouseClick);
            // 
            // attachFile
            // 
            this.attachFile.BaseColor = System.Drawing.Color.White;
            this.attachFile.Image = ((System.Drawing.Image)(resources.GetObject("attachFile.Image")));
            this.attachFile.Location = new System.Drawing.Point(19, 516);
            this.attachFile.Name = "attachFile";
            this.attachFile.Size = new System.Drawing.Size(50, 35);
            this.attachFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.attachFile.TabIndex = 18;
            this.attachFile.TabStop = false;
            this.attachFile.UseTransfarantBackground = false;
            // 
            // msgType
            // 
            this.msgType.BackColor = System.Drawing.Color.Transparent;
            this.msgType.BaseColor = System.Drawing.SystemColors.WindowText;
            this.msgType.BorderColor = System.Drawing.Color.Silver;
            this.msgType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.msgType.FocusedBaseColor = System.Drawing.Color.White;
            this.msgType.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.msgType.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.msgType.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgType.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.msgType.Location = new System.Drawing.Point(83, 515);
            this.msgType.Multiline = true;
            this.msgType.Name = "msgType";
            this.msgType.PasswordChar = '\0';
            this.msgType.Radius = 15;
            this.msgType.SelectedText = "";
            this.msgType.Size = new System.Drawing.Size(412, 44);
            this.msgType.TabIndex = 13;
            this.msgType.TextChanged += new System.EventHandler(this.msgType_TextChanged);
            // 
            // msgpan
            // 
            this.msgpan.AutoScroll = true;
            this.msgpan.Location = new System.Drawing.Point(0, 0);
            this.msgpan.Name = "msgpan";
            this.msgpan.Size = new System.Drawing.Size(640, 493);
            this.msgpan.TabIndex = 173;
            this.msgpan.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.msgpan_ControlAdded);
            this.msgpan.Paint += new System.Windows.Forms.PaintEventHandler(this.msgpan_Paint);
            // 
            // messagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel9);
            this.Name = "messagebox";
            this.Size = new System.Drawing.Size(640, 579);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attachFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private Guna.UI.WinForms.GunaCirclePictureBox attachFile;
        private Guna.UI.WinForms.GunaTextBox msgType;
        private Guna.UI.WinForms.GunaAdvenceButton send;
        private System.Windows.Forms.Panel msgpan;
    }
}
