using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GF.Couno.CardGameProtoWpf
{
    public class ItemViewModel : ObservableObject
    {
        public ItemViewModel(string itemName, string itemDescription, List<RequirementViewModel> requirements,
            IList<IEffect> itemEffects, ICommand useItemCommand)
        {
            ItemName = itemName;
            ItemDescription = string.Join("|", itemEffects.Select(ie => ie.GetType().Name));
            Requirements = requirements;
            ItemEffects = itemEffects;
            UseItemCommand = useItemCommand;
        }

        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public List<RequirementViewModel> Requirements { get; }
        private IList<IEffect> ItemEffects { get; }
        public ICommand UseItemCommand { get; }
        public bool RequirementsAreSatisfied { get; set; }

        public IList<IEffect> GetEffects()
        {
            return ItemEffects;
        }
    }
}