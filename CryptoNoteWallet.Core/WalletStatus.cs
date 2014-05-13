using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    public enum WalletStatus
    {
        Ready,
        Error,
        SynchronizingBlockchain
    }
}
