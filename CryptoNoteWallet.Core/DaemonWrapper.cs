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
    /// Wraps the daemon command line application. Sends command and interprets output.
    /// </summary>
    public class DaemonWrapper : BaseWrapper
    {
        private string WalletPath { get; set; }
        private string ExeFileName { get; set; }

        public DaemonWrapper(string walletPath, string exeFileName)
        {
            HandleLines = true;
            WalletPath = walletPath;
            ExeFileName = exeFileName;
        }

        public async void Start()
        {
            myProcess = new Process();

            var myProcessStartInfo = new ProcessStartInfo(
                System.IO.Path.Combine(System.IO.Path.GetDirectoryName(WalletPath), ExeFileName));

            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.RedirectStandardInput = true;
            myProcessStartInfo.CreateNoWindow = true;
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();

            TaskFactory factory = new TaskFactory();
            await factory.StartNew(this.ReadNextLine);
        }
    }
}
