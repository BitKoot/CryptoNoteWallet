using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoNoteWallet.Gui
{
    public partial class WalletPicker : Form
    {
        private string walletPath;
        private List<FileInfo> existingWallets;

        public WalletPicker()
        {
            InitializeComponent();

            walletPath = ConfigurationManager.AppSettings.Get("WalletPath");
            if (string.IsNullOrWhiteSpace(walletPath) || !Directory.Exists(walletPath))
            {
                walletPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            }

            string extensions = ConfigurationManager.AppSettings.Get("WalletExtensions") ?? "wallet";

            var dir = new DirectoryInfo(walletPath);
            existingWallets = new List<FileInfo>();

            foreach (var extension in extensions.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                existingWallets.AddRange(dir.GetFiles("*." + extension));
            }

            cbWallets.DisplayMember = "Name";
            cbWallets.ValueMember = "FullName";
            cbWallets.DataSource = existingWallets;

            if (cbWallets.Items.Count > 0)
            {
                cbWallets.SelectedIndex = 0;
                cbWallets.Enabled = true;
                btnOpen.Enabled = true;
            }

            cbWallets.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Open existing wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenMain((string)cbWallets.SelectedValue, false);
        }

        /// <summary>
        /// Show dialog for new wallet name. Open new wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            var createForm = new CreateWallet(existingWallets);
            createForm.Height = Height;
            createForm.Owner = this;

            if (createForm.ShowDialog() == DialogResult.OK)
            {
                string fullWalletPath = System.IO.Path.Combine(walletPath, createForm.WalletName + ".bin");
                OpenMain(fullWalletPath, true);
            }
        }

        /// <summary>
        /// Open existing wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbWallets_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenMain((string)cbWallets.SelectedValue, false);
            }
        }

        /// <summary>
        /// Open main wallet window.
        /// </summary>
        /// <param name="walletPath"></param>
        /// <param name="isNew"></param>
        private void OpenMain(string walletPath, bool isNew)
        {
            var mw = new MainWindow(walletPath, isNew);

            Hide();

            try
            {
                mw.ShowDialog();
            }
            catch (InvalidOperationException)
            {
                // Catch exception when main window is closed before being opened.
            }

            Close();
        }
    }
}
