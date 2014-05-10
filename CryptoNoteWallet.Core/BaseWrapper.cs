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
        protected Process myProcess = new Process();

        public EventHandler<WrapperEvent<string>> OutputReceived;

        protected bool HandleLines { get; set; }

        protected virtual void HandleLine(string line)
        {
            if (OutputReceived != null)
            {
                OutputReceived.Invoke(this, new WrapperEvent<string>(line));
            }
        }

        /// <summary>
        /// Stop the running process.
        /// </summary>
        public void Exit()
        {
            HandleLines = false;

            if (!myProcess.HasExited)
            {
                WriteLine("exit");

                myProcess.WaitForExit(60000);

                if (!myProcess.HasExited)
                {
                    myProcess.Kill();
                    myProcess.WaitForExit();
                }

                myProcess.Close();
            }
        }

        /// <summary>
        /// Write a line to the standard input.
        /// </summary>
        /// <param name="line"></param>
        protected async void WriteLine(string line)
        {
            await myProcess.StandardInput.WriteLineAsync(line);
        }

        /// <summary>
        /// Read the next line from standard output.
        /// </summary>
        protected async void ReadNextLine()
        {
            if (HandleLines)
            {
                StreamReader myStreamReader = myProcess.StandardOutput;

                var task = myStreamReader.ReadLineAsync();
                this.HandleLine(await task);

                ReadNextLine();
            }
        }
    }
}
