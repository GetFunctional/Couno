using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class FightProgressViewModel : ObservableObject
    {
        #region - Konstruktoren -

        public FightProgressViewModel(IEnumerable<FighterHudViewModel> fighters)
        {
            FighterOrder = new List<FighterHudViewModel>(fighters.Shuffle());
            PlayerTurnQueue = new Queue<FighterHudViewModel>(FighterOrder);
            this._useItemCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand<ItemViewModel>(UseItem);
            NextTurn();
        }

        #endregion

        #region - Felder privat -

        private FighterHudViewModel _currentFighter;
        private int _turn;
        private UsableItemsViewModel _currentPlayerItems;

        #endregion

        #region - Methoden oeffentlich -

        public void EndTurn()
        {
            NextTurn();
        }

        public void UseItem(ItemViewModel item)
        {
            var itemEffects = item.GetEffects();
            foreach (var itemEffect in itemEffects)
            {
                this.ApplyItemEffect(itemEffect);
            }

            this.CurrentPlayerItems.FighterItems.Remove(item);
        }

        private void ApplyItemEffect(IEffect itemEffect)
        {
            // Use internal closed Mediator for that?!
            switch (itemEffect)
            {
                case DealDamage dmg:
                    var enemies = FighterOrder.Except(this.CurrentFighter.Yield()).ToList();
                    enemies.ForEach(fighter => fighter.Health -= dmg.AmountDamage);
                    break;
            }

            if (PlayerTurnQueue.Any(x => x.Health <= 0))
            {
                MessageBox.Show("Game over");
                Application.Current.Shutdown(0);
            }
        }

        private void NextTurn()
        {
            if (PlayerTurnQueue.IsEmpty())
            {
                Turn += 1;
                PlayerTurnQueue = new Queue<FighterHudViewModel>(FighterOrder);
            }

            var nextPlayer = PlayerTurnQueue.Dequeue();
            CurrentFighter = nextPlayer;
            CurrentPlayerItems = new UsableItemsViewModel(new List<ItemViewModel> { BuildSword() });
        }

        private readonly ICommand _useItemCommand;

        private ItemViewModel BuildSword()
        {
            var reqs = new List<RequirementViewModel>
                {new RequirementViewModel {MaxValue = 6, MinValue = 2, ValueRestriction = ValueRestriction.Range}};
            return new ItemViewModel("Schwert", "Schlägt zu", reqs, new List<IEffect>() { new DealDamage(6) },_useItemCommand );
        }

        #endregion

        #region - Properties oeffentlich -

        public List<FighterHudViewModel> FighterOrder { get; }

        public Queue<FighterHudViewModel> PlayerTurnQueue { get; set; }

        public FighterHudViewModel CurrentFighter
        {
            get => _currentFighter;
            set => SetField(ref _currentFighter, value);
        }

        public int Turn
        {
            get => _turn;
            set => SetField(ref _turn, value);
        }

        public UsableItemsViewModel CurrentPlayerItems
        {
            get => _currentPlayerItems;
            set => SetField(ref _currentPlayerItems, value);
        }

        #endregion
    }
}