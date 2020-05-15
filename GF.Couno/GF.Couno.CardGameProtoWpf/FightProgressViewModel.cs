using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class FightProgressViewModel : ObservableObject
    {
        #region - Felder privat -

        private FighterHudViewModel _currentFighter;
        private int _turn;
        private UsableItemsViewModel _currentPlayerItems;

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
            this.CurrentPlayerItems = new UsableItemsViewModel(new List<ItemViewModel>() { BuildSword() });
        }

        private ItemViewModel BuildSword()
        {
            var reqs = new List<RequirementViewModel>()
                {new RequirementViewModel() {MaxValue = 6, MinValue = 2, ValueRestriction = ValueRestriction.Range}};
            return new ItemViewModel("Schwert", "Schlägt zu", reqs);
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

        public UsableItemsViewModel CurrentPlayerItems
        {
            get => _currentPlayerItems;
            set => this.SetField(ref this._currentPlayerItems, value);
        }

        #endregion
    }
}