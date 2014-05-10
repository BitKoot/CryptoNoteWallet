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
    /// Interaction logic for CreateWallet.xaml
    /// </summary>
    public partial class CreateWallet : Window
    {
        public string WalletName
        {
            get
            {
                return tbName.Text.Replace(' ', '_');
            }
        }

        private IList<FileInfo> ExisingWallets { get; set; }

        public CreateWallet(IList<FileInfo> existingWallets)
        {
            InitializeComponent();

            ExisingWallets = existingWallets;

            tbName.Focus();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                if (ExisingWallets.Any(ew => System.IO.Path.GetFileNameWithoutExtension(ew.FullName).Equals(tbName.Text, StringComparison.InvariantCultureIgnoreCase)))
                {
                    MessageBox.Show("The wallet name you entered already exists.", "Duplicate name", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
