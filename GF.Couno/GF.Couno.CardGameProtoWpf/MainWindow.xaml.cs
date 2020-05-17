using System.Windows;

namespace GF.Couno.CardGameProtoWpf
{
    /// <summary>
    ///     Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        #region - Konstruktoren -

        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = _viewModel = new MainWindowViewModel();
            this.Loaded += HandleMainWindowLoaded;
        }

        private async void HandleMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.StartNewFight();
        }

        #endregion
    }
}