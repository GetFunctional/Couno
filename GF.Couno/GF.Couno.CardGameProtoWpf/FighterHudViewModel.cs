using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class FighterHudViewModel : ObservableObject
    {
        #region - Felder privat -

        private int _health;
        private ObservableCollection<CardViewModel> _cardsInHand;
        private readonly CardFactory _cardFactory = new CardFactory();
        private readonly CardImageSelector _cardImageSelector = new CardImageSelector();

        #endregion

        #region - Konstruktoren -

        public FighterHudViewModel(int health, string name)
        {
            this.Health = health;
            this.Name = name;
            this.CardDeck = new ObservableCollection<CardViewModel>(this.CreateRandomCards(15, this._cardFactory.CreateCardSequence(7)));
            this.CardsInHand = new ObservableCollection<CardViewModel>(this.CardDeck.Take(3));
        }

        #endregion

        #region - Methoden privat -

        private List<CardViewModel> CreateRandomCards(int amount, IList<Card> availableCards)
        {
            return availableCards.PickRandom(amount).Select(card =>
                new CardViewModel(card, this._cardImageSelector.GetPackNotationResourceFileName(card))).ToList();
        }

        #endregion

        #region - Properties oeffentlich -

        public ObservableCollection<CardViewModel> CardDeck { get; }

        public int Health
        {
            get => this._health;
            set => this.SetField(ref this._health, value);
        }

        public string Name { get; }

        public ObservableCollection<CardViewModel> CardsInHand
        {
            get => this._cardsInHand;
            set => this.SetField(ref this._cardsInHand, value);
        }

        #endregion
    }
}