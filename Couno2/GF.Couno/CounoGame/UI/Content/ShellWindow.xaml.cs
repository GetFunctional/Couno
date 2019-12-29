using System.Windows;

namespace CounoGame.UI.Content
{
    /// <summary>
    ///     Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow
    {
        public ShellWindow(ShellViewModel shellViewModel)
        {
            this.InitializeComponent();
            this.DataContext = shellViewModel;
        }
    }
}