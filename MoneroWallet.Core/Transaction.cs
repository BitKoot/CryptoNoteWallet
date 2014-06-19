using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneroWallet.Core
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string Availablity { get; set; }
        public string TransactionId { get; set; }

        public Transaction(decimal amount, bool spent, string transactionId)
        {
            Amount = amount;
            this.Availablity = spent ? "Unavailable" : "Available";
            TransactionId = transactionId;
        }
    }
}
