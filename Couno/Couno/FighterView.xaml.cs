using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Couno.Engine;

namespace Couno
{
    /// <summary>
    /// Interaction logic for FighterView.xaml
    /// </summary>
    public partial class FighterView : UserControl
    {
        public FighterView()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Nodes = new ObservableCollection<AbilityTokenViewModel>();
        }

        private readonly AbilityBuilder _abilityBuilder = new AbilityBuilder();
        private readonly IAbilityActionQueueResolver _actionQueueResolver = new AbilityActionQueueResolver();

        public ICounoFightEnvironment Fight { get; set; }

        public ITarget MyIdentity { get; set; }

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
                    this._actionQueueResolver.GetTargetSelectionRequirement(abilityAction, this.Fight);

                var target = this._actionQueueResolver.AutoSelectTarget(abilityAction, this.Fight);

                var log = _actionQueueResolver.Resolve(abilityAction, this.Fight,target);

                //this.OutputConsole.Text += $"{Environment.NewLine}{log.LogMessage}";
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
