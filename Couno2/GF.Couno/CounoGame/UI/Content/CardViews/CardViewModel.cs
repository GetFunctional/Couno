using CounoGame.Shared.Mvvm.ViewModels;

namespace CounoGame.UI.Content.CardViews
{
    public class CardViewModel : ViewModelBase
    {
        public CardViewModel()
        {
            this.Name = "Test";
        }


        public string Name { get; set; }


    }
}