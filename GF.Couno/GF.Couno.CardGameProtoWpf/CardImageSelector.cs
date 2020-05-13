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
            this._cardImageSourceLocationPackNotation = cardImageSourceLocationPackNotation;
        }

        public string GetPackNotationResourceFileName(Card card)
        {
            var resourceFileName = $"{this._cardImageSourceLocationPackNotation}{card}.png";
            return resourceFileName;
        }
    }
}