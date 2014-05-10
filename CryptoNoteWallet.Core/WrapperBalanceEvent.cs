using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    public class WrapperBalanceEvent : EventArgs
    {
        public decimal Total { get; set; }
        public decimal Unlocked { get; set; }

        public WrapperBalanceEvent(decimal total, decimal unlocked)
        {
            Total = total;
            Unlocked = unlocked;
        }
    }
}
