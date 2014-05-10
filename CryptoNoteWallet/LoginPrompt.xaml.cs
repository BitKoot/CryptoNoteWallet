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
    /// Interaction logic for LoginPrompt.xaml
    /// </summary>
    public partial class LoginPrompt : Window
    {
        public bool ShouldLogin { get; set; }
        public string Password { get; set; }

        public LoginPrompt(Window parent)
        {
            Owner = parent;

            InitializeComponent();

            tbPassword.Focus();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void tbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void Login()
        {
            DialogResult = true;
            Password = tbPassword.Password;

            Close();
        }
    }
}
