using System.Collections.Generic;
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
        private readonly IAbilityActionQueueResolver _actionQueueResolver = new AbilityActionQueueResolver();

        public FighterView()
        {
            InitializeComponent();
            DataContext = this;
            Nodes = new ObservableCollection<AbilityTokenViewModel>();
        }

        public ICounoFightEnvironment Fight { get; set; }

        public ITarget MyIdentity { get; set; }

        public ObservableCollection<AbilityTokenViewModel> Nodes { get; }

        private void AddNode(object sender, RoutedEventArgs e)
        {
            var lastAddedNode = Nodes.LastOrDefault();
            var damageAbility = _abilityBuilder.CreateDamageAbility(6, lastAddedNode?.AbilityToken, null);
            var nodeViewModel = new AbilityTokenViewModel(damageAbility);
            Nodes.Add(nodeViewModel);
        }

        private void Evaluate(object sender, RoutedEventArgs e)
        {
            var abilities = Nodes.FirstOrDefault(); // Root Node
            var abilityActionsQueue = new AbilityActionsQueue(abilities.AbilityToken);

            foreach (var abilityAction in abilityActionsQueue)
            {
                var targetSelectionRequired =
                    _actionQueueResolver.GetTargetSelectionRequirement(abilityAction, Fight);

                var target =
                    _actionQueueResolver.AutoSelectTarget(abilityAction, MyIdentity, MyEnemies(MyIdentity));

                var log = _actionQueueResolver.Resolve(abilityAction, MyIdentity, target);

                //this.OutputConsole.Text += $"{Environment.NewLine}{log.LogMessage}";
            }
        }

        internal IList<ITarget> MyEnemies(ITarget me)
        {
            if (me == Fight.Enemy) return new List<ITarget> {Fight.Player};

            return new List<ITarget> {Fight.Enemy};
        }

        private void AddBlockNode(object sender, RoutedEventArgs e)
        {
            var lastAddedNode = Nodes.LastOrDefault();
            var blockAbility = _abilityBuilder.CreateBlockAbility(6, lastAddedNode?.AbilityToken, null);
            var nodeViewModel = new AbilityTokenViewModel(blockAbility);
            Nodes.Add(nodeViewModel);
        }
    }
}