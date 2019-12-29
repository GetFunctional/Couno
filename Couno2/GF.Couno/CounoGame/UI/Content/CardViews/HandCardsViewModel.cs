using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using CounoGame.Shared.Mvvm.ViewModels;

namespace CounoGame.UI.Content.CardViews
{
    public class HandCardsViewModel : ViewModelBase
    {
        public HandCardsViewModel()
        {
            this.HandCards = new ObservableCollection<CardViewModel>();
            this.HandCards.Add(new CardViewModel());
        }


        public ObservableCollection<CardViewModel> HandCards { get; set; }


    }
}