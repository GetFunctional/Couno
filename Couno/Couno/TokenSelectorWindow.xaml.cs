using System;
using System.Collections.Generic;
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

namespace Couno
{
    /// <summary>
    /// Interaction logic for TokenSelectorWindow.xaml
    /// </summary>
    public partial class TokenSelectorWindow : Window
    {
        public TokenSelectorWindow()
        {
            InitializeComponent();
        }

        private void ConfirmClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
