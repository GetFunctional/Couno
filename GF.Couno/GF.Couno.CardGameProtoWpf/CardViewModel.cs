using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class CardViewModel
    {
        public CardViewModel(Card card, string fileName)
        {
            this.Card = card;
            this.FileName = fileName;
            this.Name = card.ToString();
        }

        public Card Card { get; }

        public string Name { get; }

        public string FileName { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}