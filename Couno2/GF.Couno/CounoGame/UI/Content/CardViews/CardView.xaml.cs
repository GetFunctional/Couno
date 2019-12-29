using CounoGame.Shared.Mvvm.DataTemplates;

namespace CounoGame.UI.Content.CardViews
{
    /// <summary>
    ///     Interaction logic for CardView.xaml
    /// </summary>
    public partial class CardView : IViewFor<CardViewModel>
    {
        public CardView()
        {
            this.InitializeComponent();
        }
    }
}