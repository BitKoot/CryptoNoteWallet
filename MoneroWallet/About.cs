using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneroWallet
{
    public partial class About : Form
    {
        public About(string simpleWalletVersion, long blockHeight)
        {
            InitializeComponent();

            tbLicense.Select(0, 0);
            
            lblMoneroWalletVersion.Text = string.Format(
                "v{0}.{1}.{2}",
                Assembly.GetEntryAssembly().GetName().Version.Major,
                Assembly.GetEntryAssembly().GetName().Version.Minor,
                Assembly.GetEntryAssembly().GetName().Version.Build);
            lblSimpleWalletVersion.Text = string.Format("v{0}", simpleWalletVersion);
            lblBlockHeight.Text = blockHeight.ToString();
        }
    }
}
