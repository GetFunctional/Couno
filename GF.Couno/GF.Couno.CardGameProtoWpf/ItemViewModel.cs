using System.Collections.Generic;
using System.Windows.Documents;

namespace GF.Couno.CardGameProtoWpf
{
    public class ItemViewModel : ObservableObject
    {
        public ItemViewModel(string itemName, string itemDescription, List<RequirementViewModel> requirements)
        {
            ItemName = itemName;
            ItemDescription = itemDescription;
            Requirements = requirements;
        }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public List<RequirementViewModel> Requirements { get; }
    }
}