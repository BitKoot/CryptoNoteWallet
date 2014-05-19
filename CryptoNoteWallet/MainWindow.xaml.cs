using CryptoNoteWallet.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace CryptoNoteWallet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void SetTextDelegate(string text);

        private DaemonWrapper Daemon { get; set; }
        private WalletWrapper Wallet { get; set; }
        private MinerWrapper MinerManager { get; set; }

        private List<string> DaemonLogLines { get; set; }
        private List<string> WalletLogLines { get; set; }

        private bool WalletHasBeenReady { get; set; }

        public MainWindow(string path, bool isNew)
        {
            InitializeComponent();

            Title = string.Format(
                "{0} v{1}.{2}.{3}",
                Title,
                Assembly.GetEntryAssembly().GetName().Version.Major, 
                Assembly.GetEntryAssembly().GetName().Version.Minor,
                Assembly.GetEntryAssembly().GetName().Version.Build);

            tbMinerThreads.Value = Environment.ProcessorCount;
            FillMiningPools();

            int refreshInterval = int.Parse(ConfigurationManager.AppSettings["WalletRefreshInterval"]);
            int pingInterval = int.Parse(ConfigurationManager.AppSettings["DaemonPingInterval"]);
            int connectionCountInterval = int.Parse(ConfigurationManager.AppSettings["DaemonConnectionCountInterval"]);
            
            string daemonClientExe = ConfigurationManager.AppSettings["DaemonFileName"];
            string walletClientExe = ConfigurationManager.AppSettings["WalletClientFileName"];
            string minerExe = ConfigurationManager.AppSettings["MinerFileName"];

            // Initialize and start daemon.
            Daemon = new DaemonWrapper(path, daemonClientExe, pingInterval, connectionCountInterval);
            DaemonLogLines = new List<string>();
            Daemon.OutputReceived += new EventHandler<WrapperEvent<string>>((s, e) => DispatchEvent(() => AddLogText(e.Data, DaemonLogLines, tbDaemonOutput, svDaemonOutput)));
            Daemon.StatusChanged += new EventHandler<WrapperStatusEvent>((s, e) => DispatchEvent(() => SetStatus(e.Status, e.Message)));
            Daemon.ConnectionsCounted += new EventHandler<WrapperEvent<int>>((s, e) => DispatchEvent(() => SetConnectionCount(e.Data)));
            Daemon.Start();

            // Initialize and start wallet client.
            Wallet = new WalletWrapper(path, walletClientExe, isNew, refreshInterval);
            WalletLogLines = new List<string>();
            Wallet.ReadyToLogin += new EventHandler<EventArgs>((s, e) => DispatchEvent(() => ShowLogin()));
            Wallet.StatusChanged += new EventHandler<WrapperStatusEvent>((s, e) => DispatchEvent(() => SetStatus(e.Status, e.Message)));
            Wallet.AddressReceived += new EventHandler<WrapperEvent<string>>((s, e) => DispatchEvent(() => SetAddress(e.Data)));
            Wallet.OutputReceived += new EventHandler<WrapperEvent<string>>((s, e) => DispatchEvent(() => AddLogText(e.Data, WalletLogLines, tbWalletClientOutput, svWalletClientOutput)));
            Wallet.BalanceUpdated += new EventHandler<WrapperBalanceEvent>((s, e) => DispatchEvent(() => SetBalance(e.Total, e.Unlocked)));
            Wallet.Error += new EventHandler<WrapperErrorEvent>((s, e) => DispatchEvent(() => ShowError(e.Message, e.ShouldExit)));
            Wallet.Information += new EventHandler<WrapperEvent<string>>((s, e) => DispatchEvent(() => ShowInformation(e.Data)));
            Wallet.TransactionsFetched += new EventHandler<WrapperEvent<IList<Transaction>>>((s, e) => DispatchEvent(() => RefreshTransactions(e.Data)));
            Wallet.Start();

            MinerManager = new MinerWrapper(path, minerExe);
        }

        /// <summary>
        /// Populate dropdown with mining pools.
        /// </summary>
        private void FillMiningPools()
        {
            var pools = ConfigurationManager.AppSettings["MiningPoolAddresses"]
                .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            lbMiningPools.ItemsSource = pools;

            if (lbMiningPools.Items.Count > 0)
            {
                lbMiningPools.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Safely dispatch an event to an action handler.
        /// </summary>
        /// <param name="handler"></param>
        private void DispatchEvent(Action handler)
        {
            if (!Dispatcher.HasShutdownStarted)
            {
                Dispatcher.Invoke(handler);
            }
        }

        /// <summary>
        /// Show general error message.
        /// </summary>
        /// <param name="message"></param>
        private void ShowError(string message, bool shouldExit)
        {
            System.Windows.MessageBox.Show(this, message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            if (shouldExit)
            {
                Close();   
            }
        }

        /// <summary>
        /// Show general information message.
        /// </summary>
        /// <param name="message"></param>
        private void ShowInformation(string message)
        {
            System.Windows.MessageBox.Show(this, message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Transfer coins.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text)
                || !tbSendAmount.Value.HasValue
                || !tbSendMixin.Value.HasValue)
            {
                System.Windows.MessageBox.Show("You need to enter an address, an amount and a mixin count.", "Input error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string address = tbSendAddress.Text;
                decimal amount = tbSendAmount.Value.Value;
                int mixin = tbSendMixin.Value.Value;

                Wallet.Transfer(address, amount, mixin);
            }
        }

        /// <summary>
        /// Show login window. Login to wallet when login is entered. If users cancels, close application.
        /// </summary>
        private void ShowLogin()
        {
            var loginPrompt = new LoginPrompt(this);
            if (loginPrompt.ShowDialog() == true)
            {
                Wallet.Login(loginPrompt.Password);
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Sets the balance.
        /// </summary>
        /// <param name="total"></param>
        /// <param name="unlocked"></param>
        private void SetBalance(decimal total, decimal unlocked)
        {
            lblBalance.Content = string.Format("{0} MRO", unlocked);
            lblUnconfirmed.Content = string.Format("{0} MRO", total);
        }

        /// <summary>
        /// Refresh the list of transactions.
        /// </summary>
        /// <param name="transactions"></param>
        private void RefreshTransactions(IList<Transaction> transactions)
        {
            dgTransactions.ItemsSource = transactions;
        }

        /// <summary>
        /// Set status in status bar.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        private void SetStatus(WalletStatus status, string message)
        {
            WalletHasBeenReady = WalletHasBeenReady || status == WalletStatus.Ready;

            // Once the daemon has synced, ignore any synchronisation events.
            if (WalletHasBeenReady && status == WalletStatus.SynchronizingBlockchain)
            {
                return;
            }

            tbStatus.Text = message;
            btnSend.IsEnabled = status == WalletStatus.Ready;
        }

        /// <summary>
        /// Set the connection count in status bar.
        /// </summary>
        /// <param name="connectionCount"></param>
        private void SetConnectionCount(int connectionCount)
        {
            tbConnections.Text = string.Format("Connections: {0} peers", connectionCount);
        }

        /// <summary>
        /// Update current wallet address.
        /// </summary>
        /// <param name="address"></param>
        private void SetAddress(string address)
        {
            tbAddress.Text = address;
            btnCopyAddress.IsEnabled = true;
            
            tbPoolLogin.Text = address;
        }

        /// <summary>
        /// Update wallet log.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="logLines"></param>
        /// <param name="textBox"></param>
        /// <param name="scrollViewer"></param>
        private void AddLogText(string text, IList<string> logLines, TextBox textBox, ScrollViewer scrollViewer)
        {
            while (logLines.Count >= 50)
            {
                logLines.RemoveAt(0);
            }

            logLines.Add(text);

            if (logLines.Count == 1)
            {
                textBox.Text = logLines.First();
            }
            else
            {
                textBox.Text = logLines.Aggregate((l1, l2) => l1 + Environment.NewLine + l2);
                textBox.AppendText(Environment.NewLine); // Hack: make sure scroll to bottom works
                scrollViewer.ScrollToBottom();
            }
        }

        /// <summary>
        /// When the form closes, make sure the wallet stops refreshing and all work is saved.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Cursor = Cursors.Wait;
            SetStatus(WalletStatus.Ready, "Waiting for daemon to exit...");

            MinerManager.Exit();
            Wallet.Exit();
            Daemon.Exit();

            base.OnClosing(e);
        }

        private void btnCopyAddressClick(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(tbAddress.Text);
        }

        /// <summary>
        /// Start miners.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartClick(object sender, RoutedEventArgs e)
        {
            if (MinerManager.IsMinig)
            {
                // Stop
                MinerManager.Exit();

                btnStart.Content = "Start mining";
            }
            else
            {
                // Start            
                if (lbMiningPools.SelectedValue != null
                    && !string.IsNullOrEmpty(tbPoolLogin.Text)
                    && !string.IsNullOrEmpty(tbPoolPassword.Text)
                    && tbMinerThreads.Value.HasValue)
                {
                    MinerManager.Start(
                        lbMiningPools.SelectedValue.ToString(), 
                        tbPoolLogin.Text, 
                        tbPoolPassword.Text, 
                        tbMinerThreads.Value.Value,
                        chkShowWindows.IsChecked.GetValueOrDefault());

                    btnStart.Content = string.Format("Stop miners ({0})", MinerManager.Processes.Count);
                }
            }
        }
    }
}
