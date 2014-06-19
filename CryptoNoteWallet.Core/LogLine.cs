using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNoteWallet.Core
{
    public class LogLine
    {
        public string Line { get; set; }
        public bool IsHandled { get; set; }

        public LogLine(string line, bool isHandled)
        {
            Line = line;
            IsHandled = isHandled;
        }
    }
}
