using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IList<Card> _availableCards;
        private readonly CardFactory _cardFactory = new CardFactory();
        private readonly CardImageSelector _cardImageSelector = new CardImageSelector();

        public MainWindowViewModel()
        {
            this._availableCards = this._cardFactory.CreateCardSequence(7);
            this.Cards = new ObservableCollection<CardViewModel>(this.CreateRandomCards(15, this._availableCards));
        }

        public ObservableCollection<CardViewModel> Cards { get; }

        private List<CardViewModel> CreateRandomCards(int amount, IList<Card> availableCards)
        {
            return availableCards.PickRandom(amount).Select(card =>
                new CardViewModel(card, this._cardImageSelector.GetPackNotationResourceFileName(card))).ToList();
        }
    }
}