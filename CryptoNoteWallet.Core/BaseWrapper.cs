using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    /// <summary>
    /// Base class for wrappers around command line programs.
    /// </summary>
    public abstract class BaseWrapper
    {
        protected string WalletPath { get; set; }
        protected string ExeFileName { get; set; }
        protected Process WrapperProcess { get; set; }
        protected bool HandleLines { get; set; }

        public EventHandler<WrapperEvent<string>> OutputReceived;
        public EventHandler<WrapperErrorEvent> Error;
        public EventHandler<WrapperEvent<string>> Information;

        protected string ExecutablePath
        {
            get
            {
                return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(WalletPath), ExeFileName);
            }
        }

        public BaseWrapper(string walletPath, string exeFileName)
        {
            HandleLines = true;
            WalletPath = walletPath;
            ExeFileName = exeFileName;
        }

        /// <summary>
        /// Stop the running process.
        /// </summary>
        public void Exit()
        {
            HandleLines = false;

            if (WrapperProcess != null && !WrapperProcess.HasExited)
            {
                WriteLine("exit");

                WrapperProcess.WaitForExit(60000);

                if (!WrapperProcess.HasExited)
                {
                    WrapperProcess.Kill();
                    WrapperProcess.WaitForExit();
                }

                WrapperProcess.Close();
            }
        }

        /// <summary>
        /// Check if we can find the executable to start.
        /// </summary>
        /// <returns></returns>
        protected bool CanStart()
        {
            if (!File.Exists(ExecutablePath))
            {
                SendError(
                    string.Format(
                        "The {0} executable for the daemon could not be found. You should put CryptoNote Wallet in the same directory as the {0} executable.",
                        ExeFileName),
                    true);
                return false;
            }

            return true;
        }

        protected void SendError(string message, bool shouldExit)
        {
            if (Error != null)
            {
                Error.Invoke(this, new WrapperErrorEvent(message, shouldExit));
            }
        }

        protected void SendInformation(string message)
        {
            if (Information != null)
            {
                Information.Invoke(this, new WrapperEvent<string>(message));
            }
        }

        protected virtual void HandleLine(string line)
        {
            if (OutputReceived != null)
            {
                OutputReceived.Invoke(this, new WrapperEvent<string>(line));
            }
        }

        /// <summary>
        /// Write a line to the standard input.
        /// </summary>
        /// <param name="line"></param>
        protected async void WriteLine(string line)
        {
            await WrapperProcess.StandardInput.WriteLineAsync(line);
        }

        /// <summary>
        /// Read the next line from standard output.
        /// </summary>
        protected async void ReadNextLine()
        {
            if (HandleLines)
            {
                StreamReader myStreamReader = WrapperProcess.StandardOutput;

                var task = myStreamReader.ReadLineAsync();
                this.HandleLine(await task);

                ReadNextLine();
            }
        }
    }
}
