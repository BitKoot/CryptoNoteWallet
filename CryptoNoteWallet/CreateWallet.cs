using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneroWallet
{
    public partial class CreateWallet : Form
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                if (ExisingWallets.Any(ew => System.IO.Path.GetFileNameWithoutExtension(ew.FullName).Equals(tbName.Text, StringComparison.InvariantCultureIgnoreCase)))
                {
                    MessageBox.Show("The wallet name you entered already exists.", "Duplicate name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
