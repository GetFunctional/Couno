using CounoGame.Shared.Mvvm.ViewModels;
using CounoGame.UI.Content.FightViews;

namespace CounoGame.UI.Content
{
    public class ShellViewModel : ViewModelBase
    {
        public FightViewModel FightViewModel { get; }

        public ShellViewModel(FightViewModel fightViewModel)
        {
            this.FightViewModel = fightViewModel;
        }
    }
}