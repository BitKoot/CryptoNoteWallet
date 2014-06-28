namespace MoneroWallet
{
    partial class LogWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogWindow));
            this.chkHideHandledLines = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.lbLogLines = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // chkHideHandledLines
            // 
            this.chkHideHandledLines.AutoSize = true;
            this.chkHideHandledLines.Checked = true;
            this.chkHideHandledLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideHandledLines.Location = new System.Drawing.Point(12, 12);
            this.chkHideHandledLines.Name = "chkHideHandledLines";
            this.chkHideHandledLines.Size = new System.Drawing.Size(111, 17);
            this.chkHideHandledLines.TabIndex = 0;
            this.chkHideHandledLines.Text = "hide handled lines";
            this.chkHideHandledLines.UseVisualStyleBackColor = true;
            this.chkHideHandledLines.CheckedChanged += new System.EventHandler(this.chkHideHandledLines_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(340, 310);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbCommand
            // 
            this.tbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCommand.Location = new System.Drawing.Point(13, 313);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(321, 20);
            this.tbCommand.TabIndex = 3;
            this.tbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommand_KeyDown);
            // 
            // lbLogLines
            // 
            this.lbLogLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLogLines.Location = new System.Drawing.Point(12, 34);
            this.lbLogLines.Name = "lbLogLines";
            this.lbLogLines.ScrollAlwaysVisible = true;
            this.lbLogLines.Size = new System.Drawing.Size(405, 264);
            this.lbLogLines.TabIndex = 4;
            // 
            // LogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 345);
            this.Controls.Add(this.lbLogLines);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chkHideHandledLines);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "LogWindow";
            this.ShowInTaskbar = false;
            this.Text = "Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHideHandledLines;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.ListBox lbLogLines;

    }
}