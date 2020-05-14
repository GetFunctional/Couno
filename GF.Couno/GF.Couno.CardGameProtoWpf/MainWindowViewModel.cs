using System.Collections.ObjectModel;

namespace GF.Couno.CardGameProtoWpf
{
    public class MainWindowViewModel : ObservableObject
    {
        #region - Konstruktoren -

        public MainWindowViewModel()
        {
            this.Player = new FighterHudViewModel(30,  "Player");
            this.Enemy = new FighterHudViewModel(30, "AI");
            this.FightProgress = new FightProgressViewModel(new[]{this.Player, this.Enemy});
        }

        #endregion

        #region - Properties oeffentlich -

        public FighterHudViewModel Enemy { get; set; }

        public FighterHudViewModel Player { get; set; }

        public FightProgressViewModel FightProgress { get; }

        #endregion
    }
}