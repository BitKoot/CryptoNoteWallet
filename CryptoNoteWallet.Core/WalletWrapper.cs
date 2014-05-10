using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    /// <summary>
    /// Wraps the simplewallet command line application. Sends command and interprets output.
    /// </summary>
    public class WalletWrapper : BaseWrapper
    {
        private string WalletPath { get; set; }
        private string ExeFileName { get; set; }
        private bool IsNew { get; set; }

        public EventHandler<EventArgs> ReadyToLogin;
        public EventHandler<WrapperEvent<string>> StatusChanged;
        public EventHandler<WrapperEvent<string>> AddressReceived;
        public EventHandler<WrapperErrorEvent> Error;
        public EventHandler<WrapperEvent<string>> Information;
        public EventHandler<WrapperBalanceEvent> BalanceUpdated;

        public WalletWrapper(string walletPath, string exeFileName, bool isNew)
        {
            WalletPath = walletPath;
            ExeFileName = exeFileName;
            IsNew = isNew;
        }

        /// <summary>
        /// Start wallet process and parse output.
        /// </summary>
        public async void Start()
        {
            Backup();

            HandleLines = true;

            myProcess = new Process();

            var myProcessStartInfo = new ProcessStartInfo(
                System.IO.Path.Combine(System.IO.Path.GetDirectoryName(WalletPath), ExeFileName));

            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.RedirectStandardInput = true;
            myProcessStartInfo.CreateNoWindow = true;

            if (IsNew)
            {
                myProcessStartInfo.Arguments = "--generate-new-wallet=" + WalletPath;
            }
            else
            {
                myProcessStartInfo.Arguments = "--wallet-file=" + WalletPath;
            }

            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();

            TaskFactory factory = new TaskFactory();
            await factory.StartNew(this.ReadNextLine);
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
        public void Transfer(string address, decimal amount, int mixin)
        {
            WriteLine(string.Format(CultureInfo.InvariantCulture, "transfer {0} {1} {2}", mixin, address.Trim(), amount));
        }

        /// <summary>
        /// Refresh blocks from daemon.
        /// </summary>
        public void Refresh()
        {
            WriteLine("refresh");
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
        protected override void HandleLine(string line)
        {
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
            }
            else if (line.Contains("Error: refresh failed: daemon is busy"))
            {
                UpdateStatus("Retrieving blockchain");
            }
            else if (line.Contains("Error: wallet failed to connect"))
            {
                UpdateStatus("Can not connect to daemon");
            }
            else if (line.Contains("Error: failed to load wallet: invalid password"))
            {
                SendError("Invalid password", true);
            }
            else if (line.Contains("Error: not enough money"))
            {
                SendError(line, false);
            }
            else if (line.Contains("Refresh done"))
            {
                UpdateStatus("Ready");
            }
            else if (line.Contains("Money successfully sent"))
            {
                Match match = Regex.Match(line, "Money successfully sent, transaction <([0-9a-z]*)>");
                if (match.Success)
                {
                    SendInformation("Money successfully sent, transaction: " + match.Groups[1].Value);
                }
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

            base.HandleLine(line);
        }

        private void UpdateStatus(string status)
        {
            if (StatusChanged != null)
            {
                StatusChanged.Invoke(this, new WrapperEvent<string>(status));
            }
        }

        private void SendError(string message, bool shouldExit)
        {
            if (Error != null)
            {
                Error.Invoke(this, new WrapperErrorEvent(message, shouldExit));
            }
        }

        private void SendInformation(string message)
        {
            if (Information != null)
            {
                Information.Invoke(this, new WrapperEvent<string>(message));
            }
        }
    }
}
