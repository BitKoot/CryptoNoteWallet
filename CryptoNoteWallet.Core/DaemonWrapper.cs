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
    /// Wraps the daemon command line application. Sends command and interprets output.
    /// </summary>
    public class DaemonWrapper : BaseWrapper
    {
        private Timer PingTimer { get; set; }

        public DaemonWrapper(string walletPath, string exeFileName, int pingInterval)
            : base(walletPath, exeFileName)
        {
            PingTimer = new Timer(pingInterval);
            PingTimer.Elapsed += (s, e) => Ping();
        }

        public async void Start()
        {
            if (!CanStart())
            {
                return;
            }

            WrapperProcess = new Process();

            var processStartInfo = new ProcessStartInfo(ExecutablePath);
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.CreateNoWindow = true;
            WrapperProcess.StartInfo = processStartInfo;
            WrapperProcess.Start();

            await Task.Factory.StartNew(() => ReadNextLine(false));
            await Task.Factory.StartNew(() => ReadNextLine(true));

            PingTimer.Start();
        }

        public override void Exit()
        {
            PingTimer.Stop();

            base.Exit();
        }

        /// <summary>
        /// Keep the daemon output up to date by entering a newline.
        /// </summary>
        public void Ping()
        {
            WriteLine(Environment.NewLine);
        }
    }
}
