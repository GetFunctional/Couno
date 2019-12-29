using CounoGame.Shared.Mvvm.ViewModels;
using CounoGame.UI.Content.CardViews;

namespace CounoGame.UI.Content.FightViews
{
    public class FightViewModel : ViewModelBase
    {
        public FightViewModel(HandCardsViewModel handCardsViewModel)
        {
            this.HandCardsViewModel = handCardsViewModel;
        }

        public HandCardsViewModel HandCardsViewModel { get;  }
    }
}