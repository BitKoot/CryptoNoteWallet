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
        public DaemonWrapper(string walletPath, string exeFileName)
            : base(walletPath, exeFileName)
        {
        }

        public async void Start()
        {
            if (!CanStart())
            {
                return;
            }

            WrapperProcess = new Process();

            var myProcessStartInfo = new ProcessStartInfo(ExecutablePath);
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.RedirectStandardInput = true;
            myProcessStartInfo.CreateNoWindow = true;
            WrapperProcess.StartInfo = myProcessStartInfo;
            WrapperProcess.Start();

            TaskFactory factory = new TaskFactory();
            await factory.StartNew(this.ReadNextLine);
        }
    }
}
