namespace MoneroWallet
{
    partial class About
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMoneroWalletVersion = new System.Windows.Forms.Label();
            this.lblSimpleWalletVersion = new System.Windows.Forms.Label();
            this.lblBlockHeight = new System.Windows.Forms.Label();
            this.tbLicense = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monero Wallet version:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SimpleWallet version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Current block:";
            // 
            // lblMoneroWalletVersion
            // 
            this.lblMoneroWalletVersion.AutoSize = true;
            this.lblMoneroWalletVersion.Location = new System.Drawing.Point(361, 13);
            this.lblMoneroWalletVersion.Name = "lblMoneroWalletVersion";
            this.lblMoneroWalletVersion.Size = new System.Drawing.Size(16, 13);
            this.lblMoneroWalletVersion.TabIndex = 4;
            this.lblMoneroWalletVersion.Text = "...";
            // 
            // lblSimpleWalletVersion
            // 
            this.lblSimpleWalletVersion.AutoSize = true;
            this.lblSimpleWalletVersion.Location = new System.Drawing.Point(361, 55);
            this.lblSimpleWalletVersion.Name = "lblSimpleWalletVersion";
            this.lblSimpleWalletVersion.Size = new System.Drawing.Size(16, 13);
            this.lblSimpleWalletVersion.TabIndex = 4;
            this.lblSimpleWalletVersion.Text = "...";
            // 
            // lblBlockHeight
            // 
            this.lblBlockHeight.AutoSize = true;
            this.lblBlockHeight.Location = new System.Drawing.Point(361, 100);
            this.lblBlockHeight.Name = "lblBlockHeight";
            this.lblBlockHeight.Size = new System.Drawing.Size(16, 13);
            this.lblBlockHeight.TabIndex = 4;
            this.lblBlockHeight.Text = "...";
            // 
            // tbLicense
            // 
            this.tbLicense.Location = new System.Drawing.Point(13, 133);
            this.tbLicense.Multiline = true;
            this.tbLicense.Name = "tbLicense";
            this.tbLicense.ReadOnly = true;
            this.tbLicense.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLicense.Size = new System.Drawing.Size(399, 101);
            this.tbLicense.TabIndex = 5;
            this.tbLicense.Text = resources.GetString("tbLicense.Text");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 100);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::MoneroWallet.Properties.Resources.monero_large;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 243);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbLicense);
            this.Controls.Add(this.lblBlockHeight);
            this.Controls.Add(this.lblSimpleWalletVersion);
            this.Controls.Add(this.lblMoneroWalletVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMoneroWalletVersion;
        private System.Windows.Forms.Label lblSimpleWalletVersion;
        private System.Windows.Forms.Label lblBlockHeight;
        private System.Windows.Forms.TextBox tbLicense;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}