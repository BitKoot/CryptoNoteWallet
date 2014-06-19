using CryptoNoteWallet.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoNoteWallet
{
    public partial class LogWindow : Form
    {
        private const int LinesToShow = 50;

        private BindingList<LogLine> LogLines { get; set; }
        private BaseWrapper Wrapper { get; set; }

        private bool HideHandledLines
        {
            get { return chkHideHandledLines.Checked; }
        }

        public LogWindow(BindingList<LogLine> logLines, BaseWrapper wrapper)
        {
            InitializeComponent();

            LogLines = logLines;
            Wrapper = wrapper;

            UpdateLog();

            LogLines.ListChanged += LogChanged;
        }

        private void LogChanged(object sender, ListChangedEventArgs e)
        {
            AddLogLine(LogLines.ElementAt(e.NewIndex));
        }

        private void chkHideHandledLines_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLog();
        }

        /// <summary>
        /// Update the entire log shown at the moment.
        /// </summary>
        private void UpdateLog()
        {
            // Get 50 last log lines
            var filtered = LogLines
                .Where(l => !HideHandledLines || !l.IsHandled)
                .Select(l => l.Line)
                .Reverse()
                .Take(LinesToShow)
                .Reverse()
                .ToList();

            lbLogLines.Items.Clear();

            if (filtered.Count >= 1)
            {
                lbLogLines.Items.AddRange(filtered.ToArray());
            }
        }

        /// <summary>
        /// Add a new line to the already displayed log lines.
        /// </summary>
        /// <param name="line"></param>
        private void AddLogLine(LogLine line)
        {
            if (HideHandledLines && line.IsHandled)
            {
                return;
            }

            if (lbLogLines.Items.Count >= 50)
            {
                lbLogLines.Items.RemoveAt(0);
            }

            lbLogLines.Items.Add(line.Line);

            // Make sure the last item is visible
            lbLogLines.SelectedIndex = lbLogLines.Items.Count - 1;
            lbLogLines.ClearSelected();
        }

        /// <summary>
        /// Send a command to the wrapper.
        /// </summary>
        private void SendCommand()
        {
            Wrapper.WriteLine(tbCommand.Text);
            tbCommand.Text = string.Empty;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendCommand();
            }
        }

    }
}
