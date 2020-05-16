using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class RequirementViewModel : ObservableObject
    {
        public ValueRestriction ValueRestriction { get; set; }
        
        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public CardType RequiredType { get; set; }
    }
}