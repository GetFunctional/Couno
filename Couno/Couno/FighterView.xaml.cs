using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Couno.Engine;

namespace Couno
{
    /// <summary>
    ///     Interaction logic for FighterView.xaml
    /// </summary>
    public partial class FighterView : UserControl
    {
        private readonly AbilityBuilder _abilityBuilder = new AbilityBuilder();

        public FighterView()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.Nodes = new ObservableCollection<AbilityTokenViewModel>();
        }

        public ICounoFightEnvironment Fight { get; set; }

        public Character MyIdentity { get; set; }

        public ObservableCollection<AbilityTokenViewModel> Nodes { get; }

        private void AddNode(object sender, RoutedEventArgs e)
        {
            var lastAddedNode = this.Nodes.LastOrDefault();
            var damageAbility = this._abilityBuilder.CreateDamageAbility(6, lastAddedNode?.AbilityToken, null);
            var nodeViewModel = new AbilityTokenViewModel(damageAbility);
            this.Nodes.Add(nodeViewModel);
        }


        private void Evaluate(object sender, RoutedEventArgs e)
        {
            var abilities = this.Nodes.FirstOrDefault(); // Root Node
            var abilityActionsQueue = new AbilityActionsQueue(abilities.AbilityToken);

            foreach (var abilityAction in abilityActionsQueue)
            {
                var targetSelectionRequired =
                    this.Fight.GetTargetSelectionRequirementForAction(this.MyIdentity, abilityAction);
                var target = this.Fight.AutoSelectTargetForAction(this.MyIdentity, abilityAction);
                var log = this.Fight.ResolveAbility(this.MyIdentity, abilityAction, target);
            }
        }


        private void AddBlockNode(object sender, RoutedEventArgs e)
        {
            var lastAddedNode = this.Nodes.LastOrDefault();
            var blockAbility = this._abilityBuilder.CreateBlockAbility(6, lastAddedNode?.AbilityToken, null);
            var nodeViewModel = new AbilityTokenViewModel(blockAbility);
            this.Nodes.Add(nodeViewModel);
        }
    }
}