using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class CardViewModel
    {
        #region - Konstruktoren -

        public CardViewModel(Card card, string fileName)
        {
            this.Card = card;
            this.FileName = fileName;
            this.Name = card.ToString();
        }

        #endregion

        #region - Methoden oeffentlich -

        public override string ToString() => this.Name;

        #endregion

        #region - Properties oeffentlich -

        public Card Card { get; }

        public string Name { get; }

        public string FileName { get; }

        #endregion
    }
}