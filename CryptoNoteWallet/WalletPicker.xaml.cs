using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CryptoNoteWallet
{
    /// <summary>
    /// Interaction logic for WalletPicker.xaml
    /// </summary>
    public partial class WalletPicker : Window
    {
        private string walletPath;
        private List<FileInfo> existingWallets;

        public WalletPicker()
        {
            InitializeComponent();

            walletPath = ConfigurationManager.AppSettings.Get("WalletPath");
            if (string.IsNullOrWhiteSpace(walletPath))
            {
                walletPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            }

            string extensions = ConfigurationManager.AppSettings.Get("WalletExtensions") ?? "wallet";

            var dir = new DirectoryInfo(walletPath);
            existingWallets = new List<FileInfo>();

            foreach (var extension in extensions.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries))
            {
                existingWallets.AddRange(dir.GetFiles("*." + extension));
            }

            cbWallets.DisplayMemberPath = "Name";
            cbWallets.SelectedValuePath = "FullName";
            cbWallets.ItemsSource = existingWallets;

            if (cbWallets.Items.Count > 0)
            {
                cbWallets.SelectedIndex = 0;
                cbWallets.IsEnabled = true;
                btnOpen.IsEnabled = true;
            }

            cbWallets.Focus();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Open existing wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenMain((string)cbWallets.SelectedValue, false);
        }

        /// <summary>
        /// Show dialog for new wallet name. Open new wallet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            var createForm = new CreateWallet(existingWallets);
            createForm.Height = Height;
            createForm.Owner = this;

            if (createForm.ShowDialog() == true)
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
            if (e.Key == Key.Enter)
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

            mw.ShowDialog();

            Close();
        }
    }
}
