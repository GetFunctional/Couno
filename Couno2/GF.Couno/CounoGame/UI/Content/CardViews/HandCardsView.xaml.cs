using CounoGame.Shared.Mvvm.DataTemplates;

namespace CounoGame.UI.Content.CardViews
{
    /// <summary>
    ///     Interaction logic for HandCardsView.xaml
    /// </summary>
    public partial class HandCardsView : IViewFor<HandCardsViewModel>
    {
        public HandCardsView()
        {
            this.InitializeComponent();
        }
    }
}