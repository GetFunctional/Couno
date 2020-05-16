using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace GF.Couno.CardGameProtoWpf
{
    public class UsableItemsViewModel : ObservableObject
    {
        public UsableItemsViewModel(List<ItemViewModel> fighterItems)
        {
            FighterItems = new ObservableCollection<ItemViewModel>(fighterItems);
        }

        public ObservableCollection<ItemViewModel> FighterItems { get; set; }
    }
}