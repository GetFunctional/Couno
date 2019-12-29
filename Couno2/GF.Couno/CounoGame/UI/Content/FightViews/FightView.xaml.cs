using CounoGame.Shared.Mvvm.DataTemplates;

namespace CounoGame.UI.Content.FightViews
{
    /// <summary>
    ///     Interaction logic for FightView.xaml
    /// </summary>
    public partial class FightView : IViewFor<FightViewModel>
    {
        public FightView()
        {
            this.InitializeComponent();
        }
    }
}