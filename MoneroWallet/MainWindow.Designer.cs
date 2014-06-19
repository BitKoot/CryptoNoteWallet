namespace MoneroWallet
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblConnections = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWalletLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDaemonLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnStartPoolMining = new System.Windows.Forms.Button();
            this.chkShowPoolMinerWindows = new System.Windows.Forms.CheckBox();
            this.tbPoolMinerThreads = new System.Windows.Forms.NumericUpDown();
            this.tbPoolPassword = new System.Windows.Forms.TextBox();
            this.tbPoolLogin = new System.Windows.Forms.TextBox();
            this.lbMiningPools = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnStartSoloMining = new System.Windows.Forms.Button();
            this.tbSoloMinerThreads = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgTransactions = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbSendMixin = new System.Windows.Forms.NumericUpDown();
            this.tbSendAmount = new System.Windows.Forms.NumericUpDown();
            this.tbPaymentId = new System.Windows.Forms.TextBox();
            this.tbSendAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAddress = new System.Windows.Forms.TextBox();
            this.btnCopyAddress = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUnconfirmed = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPoolMinerThreads)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoloMinerThreads)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSendMixin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSendAmount)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblStatus,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.lblConnections});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(608, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 17);
            this.lblStatus.Text = "Initializing";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(352, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel3.Text = "Connections:";
            // 
            // lblConnections
            // 
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(61, 17);
            this.lblConnections.Text = "Initializing";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.logsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWalletLogToolStripMenuItem,
            this.showDaemonLogToolStripMenuItem});
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logsToolStripMenuItem.Text = "Logs";
            // 
            // showWalletLogToolStripMenuItem
            // 
            this.showWalletLogToolStripMenuItem.Name = "showWalletLogToolStripMenuItem";
            this.showWalletLogToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.showWalletLogToolStripMenuItem.Text = "Show wallet log";
            this.showWalletLogToolStripMenuItem.Click += new System.EventHandler(this.showWalletLogToolStripMenuItem_Click);
            // 
            // showDaemonLogToolStripMenuItem
            // 
            this.showDaemonLogToolStripMenuItem.Name = "showDaemonLogToolStripMenuItem";
            this.showDaemonLogToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.showDaemonLogToolStripMenuItem.Text = "Show daemon log";
            this.showDaemonLogToolStripMenuItem.Click += new System.EventHandler(this.showDaemonLogToolStripMenuItem_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnStartPoolMining);
            this.tabPage5.Controls.Add(this.chkShowPoolMinerWindows);
            this.tabPage5.Controls.Add(this.tbPoolMinerThreads);
            this.tabPage5.Controls.Add(this.tbPoolPassword);
            this.tabPage5.Controls.Add(this.tbPoolLogin);
            this.tabPage5.Controls.Add(this.lbMiningPools);
            this.tabPage5.Controls.Add(this.label8);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(600, 291);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Pool Mining";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnStartPoolMining
            // 
            this.btnStartPoolMining.Location = new System.Drawing.Point(439, 168);
            this.btnStartPoolMining.Name = "btnStartPoolMining";
            this.btnStartPoolMining.Size = new System.Drawing.Size(153, 27);
            this.btnStartPoolMining.TabIndex = 5;
            this.btnStartPoolMining.Text = "Start mining";
            this.btnStartPoolMining.UseVisualStyleBackColor = true;
            this.btnStartPoolMining.Click += new System.EventHandler(this.btnStartPoolMiningClick);
            // 
            // chkShowPoolMinerWindows
            // 
            this.chkShowPoolMinerWindows.AutoSize = true;
            this.chkShowPoolMinerWindows.Location = new System.Drawing.Point(265, 143);
            this.chkShowPoolMinerWindows.Name = "chkShowPoolMinerWindows";
            this.chkShowPoolMinerWindows.Size = new System.Drawing.Size(15, 14);
            this.chkShowPoolMinerWindows.TabIndex = 4;
            this.chkShowPoolMinerWindows.UseVisualStyleBackColor = true;
            // 
            // tbPoolMinerThreads
            // 
            this.tbPoolMinerThreads.Location = new System.Drawing.Point(265, 109);
            this.tbPoolMinerThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbPoolMinerThreads.Name = "tbPoolMinerThreads";
            this.tbPoolMinerThreads.Size = new System.Drawing.Size(45, 23);
            this.tbPoolMinerThreads.TabIndex = 3;
            this.tbPoolMinerThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbPoolPassword
            // 
            this.tbPoolPassword.Location = new System.Drawing.Point(265, 80);
            this.tbPoolPassword.Name = "tbPoolPassword";
            this.tbPoolPassword.Size = new System.Drawing.Size(327, 23);
            this.tbPoolPassword.TabIndex = 2;
            // 
            // tbPoolLogin
            // 
            this.tbPoolLogin.Location = new System.Drawing.Point(265, 50);
            this.tbPoolLogin.Name = "tbPoolLogin";
            this.tbPoolLogin.Size = new System.Drawing.Size(327, 23);
            this.tbPoolLogin.TabIndex = 2;
            // 
            // lbMiningPools
            // 
            this.lbMiningPools.FormattingEnabled = true;
            this.lbMiningPools.Location = new System.Drawing.Point(265, 18);
            this.lbMiningPools.Name = "lbMiningPools";
            this.lbMiningPools.Size = new System.Drawing.Size(327, 24);
            this.lbMiningPools.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Show miner windows:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Number of threads:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pool password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pool login (your address):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pool address (including portnumber):";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnStartSoloMining);
            this.tabPage4.Controls.Add(this.tbSoloMinerThreads);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(600, 291);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Solo Mining";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnStartSoloMining
            // 
            this.btnStartSoloMining.Location = new System.Drawing.Point(430, 53);
            this.btnStartSoloMining.Name = "btnStartSoloMining";
            this.btnStartSoloMining.Size = new System.Drawing.Size(162, 28);
            this.btnStartSoloMining.TabIndex = 6;
            this.btnStartSoloMining.Text = "Start mining";
            this.btnStartSoloMining.UseVisualStyleBackColor = true;
            this.btnStartSoloMining.Click += new System.EventHandler(this.btnStartSoloMiningClick);
            // 
            // tbSoloMinerThreads
            // 
            this.tbSoloMinerThreads.Location = new System.Drawing.Point(150, 18);
            this.tbSoloMinerThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbSoloMinerThreads.Name = "tbSoloMinerThreads";
            this.tbSoloMinerThreads.Size = new System.Drawing.Size(45, 23);
            this.tbSoloMinerThreads.TabIndex = 5;
            this.tbSoloMinerThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Number of threads:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgTransactions);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(600, 291);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transactions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgTransactions
            // 
            this.dgTransactions.AllowUserToAddRows = false;
            this.dgTransactions.AllowUserToDeleteRows = false;
            this.dgTransactions.AllowUserToOrderColumns = true;
            this.dgTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTransactions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgTransactions.CausesValidation = false;
            this.dgTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTransactions.Location = new System.Drawing.Point(3, 3);
            this.dgTransactions.Name = "dgTransactions";
            this.dgTransactions.ReadOnly = true;
            this.dgTransactions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgTransactions.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.dgTransactions.ShowCellErrors = false;
            this.dgTransactions.ShowEditingIcon = false;
            this.dgTransactions.ShowRowErrors = false;
            this.dgTransactions.Size = new System.Drawing.Size(594, 285);
            this.dgTransactions.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSend);
            this.tabPage2.Controls.Add(this.tbSendMixin);
            this.tabPage2.Controls.Add(this.tbSendAmount);
            this.tabPage2.Controls.Add(this.tbPaymentId);
            this.tabPage2.Controls.Add(this.tbSendAddress);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transfer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(516, 141);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.SendClick);
            // 
            // tbSendMixin
            // 
            this.tbSendMixin.Location = new System.Drawing.Point(160, 80);
            this.tbSendMixin.Name = "tbSendMixin";
            this.tbSendMixin.Size = new System.Drawing.Size(120, 23);
            this.tbSendMixin.TabIndex = 2;
            // 
            // tbSendAmount
            // 
            this.tbSendAmount.DecimalPlaces = 8;
            this.tbSendAmount.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tbSendAmount.Location = new System.Drawing.Point(160, 52);
            this.tbSendAmount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.tbSendAmount.Name = "tbSendAmount";
            this.tbSendAmount.Size = new System.Drawing.Size(120, 23);
            this.tbSendAmount.TabIndex = 2;
            // 
            // tbPaymentId
            // 
            this.tbPaymentId.Location = new System.Drawing.Point(160, 111);
            this.tbPaymentId.Name = "tbPaymentId";
            this.tbPaymentId.Size = new System.Drawing.Size(432, 23);
            this.tbPaymentId.TabIndex = 1;
            // 
            // tbSendAddress
            // 
            this.tbSendAddress.Location = new System.Drawing.Point(160, 19);
            this.tbSendAddress.Name = "tbSendAddress";
            this.tbSendAddress.Size = new System.Drawing.Size(432, 23);
            this.tbSendAddress.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Payment id:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Mixin count:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Amount:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Destination address:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblAddress);
            this.tabPage1.Controls.Add(this.btnCopyAddress);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblUnconfirmed);
            this.tabPage1.Controls.Add(this.lblBalance);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(600, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Wallet";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.SystemColors.Window;
            this.lblAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblAddress.Enabled = false;
            this.lblAddress.Location = new System.Drawing.Point(367, 31);
            this.lblAddress.Multiline = true;
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.ReadOnly = true;
            this.lblAddress.Size = new System.Drawing.Size(225, 95);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Initializing";
            // 
            // btnCopyAddress
            // 
            this.btnCopyAddress.Location = new System.Drawing.Point(298, 51);
            this.btnCopyAddress.Name = "btnCopyAddress";
            this.btnCopyAddress.Size = new System.Drawing.Size(63, 23);
            this.btnCopyAddress.TabIndex = 5;
            this.btnCopyAddress.Text = "Copy";
            this.btnCopyAddress.UseVisualStyleBackColor = true;
            this.btnCopyAddress.Click += new System.EventHandler(this.btnCopyAddressClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Address:";
            // 
            // lblUnconfirmed
            // 
            this.lblUnconfirmed.AutoSize = true;
            this.lblUnconfirmed.Location = new System.Drawing.Point(112, 54);
            this.lblUnconfirmed.Name = "lblUnconfirmed";
            this.lblUnconfirmed.Size = new System.Drawing.Size(50, 16);
            this.lblUnconfirmed.TabIndex = 1;
            this.lblUnconfirmed.Text = "X XMR";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(112, 31);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(50, 16);
            this.lblBalance.TabIndex = 1;
            this.lblBalance.Text = "X XMR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unconfirmed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Balance:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 366);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainWindow";
            this.Text = "Monero Wallet";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPoolMinerThreads)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoloMinerThreads)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTransactions)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSendMixin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSendAmount)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblConnections;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWalletLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDaemonLogToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnStartPoolMining;
        private System.Windows.Forms.CheckBox chkShowPoolMinerWindows;
        private System.Windows.Forms.NumericUpDown tbPoolMinerThreads;
        private System.Windows.Forms.TextBox tbPoolPassword;
        private System.Windows.Forms.TextBox tbPoolLogin;
        private System.Windows.Forms.ComboBox lbMiningPools;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnStartSoloMining;
        private System.Windows.Forms.NumericUpDown tbSoloMinerThreads;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgTransactions;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.NumericUpDown tbSendMixin;
        private System.Windows.Forms.NumericUpDown tbSendAmount;
        private System.Windows.Forms.TextBox tbPaymentId;
        private System.Windows.Forms.TextBox tbSendAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox lblAddress;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUnconfirmed;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

