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
    public partial class LoginPrompt : Form
    {
        public bool ShouldLogin { get; set; }
        public string Password { get; set; }

        public LoginPrompt()
        {
            InitializeComponent();

            tbPassword.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            
            CenterToParent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void tbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            DialogResult = DialogResult.OK;
            Password = tbPassword.Text;

            Close();
        }
    }
}
