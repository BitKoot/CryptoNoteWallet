using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneroWallet.Core
{
    public class MinerWrapper : BaseWrapper
    {
        private string PoolAddress { get; set; }
        private string PoolLogin { get; set; }
        private string PoolPassword { get; set; }
        private int Count { get; set; }

        public IList<Process> Processes { get; set; }
        public bool IsMinig { get; set; }

        public MinerWrapper(string walletPath, string exeFileName)
            : base(walletPath, exeFileName)
        {
            Processes = new List<Process>();
        }

        public void Start(string poolAddress, string poolLogin, string poolPassword, int count, bool showWindows)
        {
            PoolAddress = poolAddress;
            PoolLogin = poolLogin;
            PoolPassword = poolPassword;
            Count = count;

            if (IsMinig || !CanStart())
            {
                return;
            }

            IsMinig = true;

            for (int i = 0; i < Count; i++)
            {
                var process = new Process();

                var processStartInfo = new ProcessStartInfo(ExecutablePath);

                if (!showWindows)
                {
                    processStartInfo.UseShellExecute = false;
                    processStartInfo.RedirectStandardOutput = true;
                    processStartInfo.RedirectStandardInput = true;
                    processStartInfo.RedirectStandardError = true;
                }

                processStartInfo.CreateNoWindow = !showWindows;
                processStartInfo.Arguments = string.Format("--pool-addr \"{0}\" --login \"{1}\" --pass \"{2}\"", PoolAddress, PoolLogin, PoolPassword);
                process.StartInfo = processStartInfo;

                Processes.Add(process);
            }

            foreach (var p in Processes)
            {
                p.Start();
            }
        }

        public override void Exit()
        {
            if (!IsMinig)
            {
                return;
            }

            foreach (var process in Processes.Where(p => !p.HasExited))
            {
                process.Kill();
            }

            Processes.Clear();

            IsMinig = false;
        }
    }
}
