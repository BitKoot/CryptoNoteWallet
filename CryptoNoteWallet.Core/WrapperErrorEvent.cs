using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    public class WrapperErrorEvent : EventArgs
    {
        public string Message { get; set; }
        public bool ShouldExit { get; set; }

        public WrapperErrorEvent(string message, bool shouldExit)
        {
            Message = message;
            ShouldExit = shouldExit;
        }
    }
}
