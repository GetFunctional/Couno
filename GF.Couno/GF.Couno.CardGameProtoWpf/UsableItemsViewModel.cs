using System.Collections.Generic;
using System.Windows.Documents;

namespace GF.Couno.CardGameProtoWpf
{
    public class UsableItemsViewModel : ObservableObject
    {
        public UsableItemsViewModel(List<ItemViewModel> fighterItems)
        {
            FighterItems = fighterItems;
        }

        public List<ItemViewModel> FighterItems { get; set; }
    }
}