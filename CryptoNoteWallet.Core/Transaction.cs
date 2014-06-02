using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string TransactionId { get; set; }

        public Transaction(decimal amount, bool spent, string transactionId)
        {
            Amount = amount;
            this.Type = spent ? "Send" : "Received";
            TransactionId = transactionId;
        }
    }
}
