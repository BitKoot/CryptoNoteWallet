using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace CryptoNoteWallet.Core
{
    /// <summary>
    /// Wraps the simplewallet command line application. Sends command and interprets output.
    /// </summary>
    public class WalletWrapper : BaseWrapper
    {
        private List<Transaction> Transactions { get; set; }
        private bool IsNew { get; set; }

        public Timer RefreshTimer { get; set; }

        public EventHandler<EventArgs> ReadyToLogin;
        public EventHandler<WrapperEvent<string>> AddressReceived;
        public EventHandler<WrapperBalanceEvent> BalanceUpdated;
        public EventHandler<WrapperEvent<IList<Transaction>>> TransactionsFetched;
        public EventHandler<WrapperEvent<bool>> WalletReadyToSpent;

        public WalletWrapper(string walletPath, string exeFileName, bool isNew, int refreshInterval)
            : base(walletPath, exeFileName)
        {
            Transactions = new List<Transaction>();
            IsNew = isNew;

            RefreshTimer = new Timer(refreshInterval);
            RefreshTimer.Elapsed += (s, e) => Refresh();
        }

        /// <summary>
        /// Start wallet process and parse output.
        /// </summary>
        public async void Start()
        {
            if (!CanStart())
            {
                return;
            }

            Backup();

            HandleLines = true; 

            WrapperProcess = new Process();

            var processStartInfo = new ProcessStartInfo(ExecutablePath);
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.CreateNoWindow = true;

            if (IsNew)
            {
                processStartInfo.Arguments = "--generate-new-wallet=" + WalletPath;
            }
            else
            {
                processStartInfo.Arguments = "--wallet-file=" + WalletPath;
            }

            WrapperProcess.StartInfo = processStartInfo;
            WrapperProcess.Start();

            TaskFactory factory = new TaskFactory();
            await factory.StartNew(() => ReadNextLine(false));
            await factory.StartNew(() => ReadNextLine(true));
        }

        public override void Exit()
        {
            HandleLines = false;

            RefreshTimer.Stop();

            base.Exit();
        }

        /// <summary>
        /// Create a backup of selected wallet.
        /// </summary>
        public void Backup()
        {
            string walletName = Path.GetFileNameWithoutExtension(WalletPath);
            string walletDir = Path.GetDirectoryName(WalletPath);
            string backupDir = Path.Combine(walletDir, walletName + "_" + DateTime.Now.ToString("yyyyMMdd")); 

            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }

            foreach (var file in Directory.GetFiles(walletDir, walletName + "*"))
            {
                File.Copy(file, Path.Combine(backupDir, Path.GetFileName(file)), true);
            }
        }

        /// <summary>
        /// Login with given password.
        /// </summary>
        /// <param name="password"></param>
        public void Login(string password)
        {
            WriteLine(password);
        }

        /// <summary>
        /// Transfer amount coins to address using given amount of mixin to hide transaction.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="amount"></param>
        /// <param name="mixin"></param>
        /// <param name="paymentId"></param>
        public void Transfer(string address, decimal amount, int mixin, string paymentId)
        {
            if (string.IsNullOrWhiteSpace(paymentId))
            {
                WriteLine(string.Format(CultureInfo.InvariantCulture, "transfer {0} {1} {2}", mixin, address.Trim(), amount));
            }
            else
            {
                WriteLine(string.Format(CultureInfo.InvariantCulture, "transfer {0} {1} {2} {3}", mixin, address.Trim(), amount, paymentId));
            }            
        }

        /// <summary>
        /// Refresh blocks from daemon.
        /// </summary>
        public void Refresh()
        {
            WriteLine("refresh");
            WriteLine("incoming_transfers");
        }

        /// <summary>
        /// Get current balance.
        /// </summary>
        public void GetBalance()
        {
            WriteLine("balance");
        }

        /// <summary>
        /// Interpret the current wallet output and call relevant event listeners.
        /// </summary>
        /// <param name="line">Current line.</param>
        /// <param name="isError">Is the line read from StandardError?</param>
        protected override void HandleLine(string line, bool isError)
        {
            bool isFetchingTransactions = false;

            if (line.Contains("Opened wallet: "))
            {
                string address = line.Substring("Opened wallet: ".Length - 1);
                address = address.Trim();

                if (AddressReceived != null)
                {
                    AddressReceived.Invoke(this, new WrapperEvent<string>(address));
                }
            }
            else if (line.Contains("Generated new wallet: "))
            {
                string address = line.Substring("Generated new wallet: ".Length - 1);
                address = address.Trim();

                if (AddressReceived != null)
                {
                    AddressReceived.Invoke(this, new WrapperEvent<string>(address));
                }
            }
            else if (line.Contains("bitmonero wallet"))
            {
                if (ReadyToLogin != null)
                {
                    ReadyToLogin.Invoke(this, null);
                }
            }
            else if (line.Contains("Error: wrong address"))
            {
                SendError("Invalid send address.", false);

                SetWalletReadyToSpent(true);
            }
            else if (line.Contains("Error: wallet failed to connect"))
            {
                UpdateStatus(WalletStatus.Error, "Can not connect to daemon");
            }
            else if (line.Contains("Error: failed to load wallet: invalid password"))
            {
                SendError("Invalid password", true);
            }
            else if (line.Contains("Error: payment id has invalid format"))
            {
                SendError("The payment id has an incorrect format. It needs to be a 64 character string.", false);

                SetWalletReadyToSpent(true);
            }
            else if (line.Contains("Error: not enough money"))
            {
                SendError(line, false);

                SetWalletReadyToSpent(true);
            }
            else if (line.Contains("Money successfully sent"))
            {
                Match match = Regex.Match(line, "Money successfully sent, transaction <([0-9a-z]*)>");
                if (match.Success)
                {
                    SendInformation("Money successfully sent, transaction: " + match.Groups[1].Value);
                }

                SetWalletReadyToSpent(true);
            }
            else if (line.Contains("balance"))
            {
                Match match = Regex.Match(line, "balance: ([0-9\\.,]*), unlocked balance: ([0-9\\.,]*)");
                if (match.Success && BalanceUpdated != null)
                {
                    decimal total = decimal.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                    decimal unlocked = decimal.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                    BalanceUpdated.Invoke(this, new WrapperBalanceEvent(total, unlocked));
                }
            }
            else if (Regex.IsMatch(line, "amount[\\s]+spent"))
            {
                Transactions.Clear();
                isFetchingTransactions = true;
            }
            else if (Regex.IsMatch(line, "([0-9]+\\.[0-9]+)[\\s]*([TF])[\\s]*[0-9]+[\\s]*<([0-9a-z]+)>"))
            {
                var match = Regex.Match(line, "([0-9]+\\.[0-9]+)[\\s]*([TF])[\\s]*[0-9]+[\\s]*<([0-9a-z]+)>");
                decimal amount = decimal.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                bool spent = match.Groups[2].Value == "T";
                string transactionId = match.Groups[3].Value;

                var transaction = new Transaction(amount, spent, transactionId);
                Transactions.Add(transaction);

                isFetchingTransactions = true;
            }

            if (!isFetchingTransactions && TransactionsFetched != null)
            {
                TransactionsFetched.Invoke(this, new WrapperEvent<IList<Transaction>>(Transactions));
            }

            base.HandleLine(line, isError);
        }

        private void SetWalletReadyToSpent(bool readyToSpent)
        {
            if (WalletReadyToSpent != null)
            {
                WalletReadyToSpent.Invoke(this, new WrapperEvent<bool>(readyToSpent));
            }
        }
    }
}
