using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IList<Card> _availableCards;
        private readonly CardImageSelector _cardImageSelector = new CardImageSelector();
        private readonly CardFactory cardFactory = new CardFactory();

        public MainWindowViewModel()
        {
            _availableCards = cardFactory.CreateCardSequence(7);
            Cards = new ObservableCollection<CardViewModel>(CreateRandomCards(15, _availableCards));
        }

        public ObservableCollection<CardViewModel> Cards { get; }

        private List<CardViewModel> CreateRandomCards(int amount, IList<Card> availableCards)
        {
            return availableCards.PickRandom(amount).Select(card =>
                new CardViewModel(card, _cardImageSelector.GetPackNotationResourceFileName(card))).ToList();
        }
    }
}