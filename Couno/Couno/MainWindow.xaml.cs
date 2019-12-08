using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Couno.Engine;

namespace Couno
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AbilityBuilder _abilityBuilder = new AbilityBuilder();
        private readonly AbilityEvaluator _abilityEvaluator = new AbilityEvaluator();
        private readonly ICounoFightEnvironment _fight = new CounoTestFight(new Player(), new Enemy());
        private readonly IAbilityActionQueueResolver _actionQueueResolver = new AbilityActionQueueResolver();
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.Nodes = new ObservableCollection<AbilityTokenViewModel>();
        }

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
                    this._actionQueueResolver.GetTargetSelectionRequirement(abilityAction, this._fight);

                var target = this._actionQueueResolver.AutoSelectTarget(abilityAction, this._fight);

                var log = _actionQueueResolver.Resolve(abilityAction, this._fight,target);

                this.OutputConsole.Text += $"{Environment.NewLine}{log.LogMessage}";
            }
        }
    }
}