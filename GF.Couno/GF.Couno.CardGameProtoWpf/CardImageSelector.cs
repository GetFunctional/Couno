using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    internal class CardImageSelector
    {
        private readonly string _cardImageSourceLocationPackNotation;

        public CardImageSelector() : this("pack://application:,,,/SolitaireGames;component/Resources/Images/Cards/")
        {
        }

        public CardImageSelector(string cardImageSourceLocationPackNotation)
        {
            _cardImageSourceLocationPackNotation = cardImageSourceLocationPackNotation;
        }

        public string GetPackNotationResourceFileName(Card card)
        {
            var resourceFileName = $"{_cardImageSourceLocationPackNotation}{card.ToString()}.png";
            return resourceFileName;
        }
    }
}