using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    internal class CardImageSelector
    {
        #region - Felder privat -

        private readonly string _cardImageSourceLocationPackNotation;

        #endregion

        #region - Konstruktoren -

        public CardImageSelector() : this("pack://application:,,,/SolitaireGames;component/Resources/Images/Cards/")
        {
        }

        public CardImageSelector(string cardImageSourceLocationPackNotation) => this._cardImageSourceLocationPackNotation = cardImageSourceLocationPackNotation;

        #endregion

        #region - Methoden oeffentlich -

        public string GetPackNotationResourceFileName(Card card)
        {
            var resourceFileName = $"{this._cardImageSourceLocationPackNotation}{card}.png";
            return resourceFileName;
        }

        #endregion
    }
}