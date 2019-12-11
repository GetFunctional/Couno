using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Couno.Engine;

namespace Couno
{
    /// <summary>
    ///     Interaction logic for FighterView.xaml
    /// </summary>
    public partial class FighterView : UserControl, INotifyPropertyChanged
    {
        private readonly AbilityBuilder _abilityBuilder = new AbilityBuilder();
        private bool _itsMyTurn;

        public FighterView()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.Nodes = new ObservableCollection<AbilityTokenViewModel>();
        }

        public void InitializeFight(ICounoFightEnvironment fight, Character myIdentity)
        {
            this.Fight = fight;
            this.MyIdentity = myIdentity;
            this.ItsMyTurn = Fight.IsItMyTurn(myIdentity);
            this.Fight.ActiveCharacterChanged += FightOnActiveCharacterChanged;
        }

        private void FightOnActiveCharacterChanged(object sender, ActiveCharacterChangedEventArgs e)
        {
            this.ItsMyTurn = Fight.IsItMyTurn(this.MyIdentity);
        }

        public ICounoFightEnvironment Fight { get; private set; }

        public Character MyIdentity { get; private set; }

        public ObservableCollection<AbilityTokenViewModel> Nodes { get; }

        public bool ItsMyTurn
        {
            get => _itsMyTurn;
            set
            {
                _itsMyTurn = value;
                RaisePropertyChanged();
            }
        }

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

            this.Fight.FinishTurn(MyIdentity);
        }


        private void AddBlockNode(object sender, RoutedEventArgs e)
        {
            var lastAddedNode = this.Nodes.LastOrDefault();
            var blockAbility = this._abilityBuilder.CreateBlockAbility(6, lastAddedNode?.AbilityToken, null);
            var nodeViewModel = new AbilityTokenViewModel(blockAbility);
            this.Nodes.Add(nodeViewModel);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}