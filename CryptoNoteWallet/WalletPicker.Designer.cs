namespace CryptoNoteWallet
{
    partial class WalletPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletPicker));
            this.label1 = new System.Windows.Forms.Label();
            this.cbWallets = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblWalletPath = new System.Windows.Forms.Label();
            this.btnSelectWalletPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Open wallet:";
            // 
            // cbWallets
            // 
            this.cbWallets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWallets.Enabled = false;
            this.cbWallets.FormattingEnabled = true;
            this.cbWallets.Location = new System.Drawing.Point(106, 54);
            this.cbWallets.Name = "cbWallets";
            this.cbWallets.Size = new System.Drawing.Size(388, 22);
            this.cbWallets.TabIndex = 2;
            this.cbWallets.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbWallets_KeyUp);
            // 
            // btnOpen
            // 
            this.btnOpen.Enabled = false;
            this.btnOpen.Location = new System.Drawing.Point(15, 93);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(419, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(231, 93);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wallet path:";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select the path where your wallet is stored";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // lblWalletPath
            // 
            this.lblWalletPath.AutoEllipsis = true;
            this.lblWalletPath.Location = new System.Drawing.Point(106, 13);
            this.lblWalletPath.Name = "lblWalletPath";
            this.lblWalletPath.Size = new System.Drawing.Size(300, 14);
            this.lblWalletPath.TabIndex = 4;
            this.lblWalletPath.Text = "...";
            // 
            // btnSelectWalletPath
            // 
            this.btnSelectWalletPath.Location = new System.Drawing.Point(419, 9);
            this.btnSelectWalletPath.Name = "btnSelectWalletPath";
            this.btnSelectWalletPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectWalletPath.TabIndex = 6;
            this.btnSelectWalletPath.Text = "Browse";
            this.btnSelectWalletPath.UseVisualStyleBackColor = true;
            this.btnSelectWalletPath.Click += new System.EventHandler(this.btnSelectWalletPath_Click);
            // 
            // WalletPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 127);
            this.Controls.Add(this.btnSelectWalletPath);
            this.Controls.Add(this.lblWalletPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.cbWallets);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WalletPicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CryptoNote Wallet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbWallets;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label lblWalletPath;
        private System.Windows.Forms.Button btnSelectWalletPath;
    }
}