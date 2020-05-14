using System.Collections.Generic;

namespace GF.Couno.CardGameProtoWpf
{
    public class FightProgressViewModel : ObservableObject
    {
        #region - Felder privat -

        private FighterHudViewModel _currentFighter;
        private int _turn;

        #endregion

        #region - Konstruktoren -

        public FightProgressViewModel(IEnumerable<FighterHudViewModel> fighters)
        {
            this.FighterOrder = new List<FighterHudViewModel>(fighters.Shuffle());
            this.PlayerTurnQueue = new Queue<FighterHudViewModel>(this.FighterOrder);
            this.NextTurn();
        }

        #endregion

        #region - Methoden oeffentlich -

        public void EndTurn()
        {
            this.NextTurn();
        }

        private void NextTurn()
        {
            if (this.PlayerTurnQueue.IsEmpty())
            {
                this.Turn += 1;
                this.PlayerTurnQueue = new Queue<FighterHudViewModel>(this.FighterOrder);
            }

            var nextPlayer = this.PlayerTurnQueue.Dequeue();
            this.CurrentFighter = nextPlayer;
        }

        #endregion

        #region - Properties oeffentlich -

        public List<FighterHudViewModel> FighterOrder { get; }

        public Queue<FighterHudViewModel> PlayerTurnQueue { get; set; }

        public FighterHudViewModel CurrentFighter
        {
            get => this._currentFighter;
            set => this.SetField(ref this._currentFighter, value);
        }

        public int Turn
        {
            get => this._turn;
            set => this.SetField(ref this._turn, value);
        }

        #endregion
    }
}