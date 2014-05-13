using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    public class WrapperStatusEvent : EventArgs
    {
        public WalletStatus Status { get; set; }
        public string Message { get; set; }

        public WrapperStatusEvent(WalletStatus status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
