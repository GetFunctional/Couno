using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class CardViewModel
    {
        public CardViewModel(Card card, string fileName)
        {
            Card = card;
            FileName = fileName;
            this.Name = card.ToString();
        }

        public Card Card { get; }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }

        public string FileName { get; }
    }
}