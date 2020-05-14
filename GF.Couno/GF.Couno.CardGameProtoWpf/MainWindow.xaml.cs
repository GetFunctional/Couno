using System.Windows;

namespace GF.Couno.CardGameProtoWpf
{
    /// <summary>
    ///     Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region - Konstruktoren -

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        #endregion
    }
}