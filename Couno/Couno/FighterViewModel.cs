using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Couno.Engine;
using Couno.Shared.Mvvm;

namespace Couno
{
    public class FighterViewModel : ViewModelBase
    {
        private readonly ICounoFightEnvironment _fight;
        private bool _itsMyTurn;
        private ObservableCollection<StreamlineViewModel> _streamlines;

        public FighterViewModel(ICounoFightEnvironment fight, Character me)
        {
            this._fight = fight;
            this.Me = me;
            this.Streamlines = new ObservableCollection<StreamlineViewModel>(CreateStreamlineViewModels(me.Engine));
            this._fight.ActiveCharacterChanged += this.FightOnActiveCharacterChanged;
            this.RefreshIsItMyTurn();
        }

        private IEnumerable<StreamlineViewModel> CreateStreamlineViewModels(CounoEngine engine)
        {
            var streamlines = engine.StreamlineGraph.Streamlines;

            return streamlines.Select(x => new StreamlineViewModel(x,new DelegateCommand<StreamlineViewModel>(ExecuteStreamline)));
        }

        private void ExecuteStreamline(StreamlineViewModel streamline)
        {
            this._fight.ExecuteStreamline(streamline.StreamLine, this.Me);
            streamline.CanExecute = false;

            if (this.Streamlines.All(x => !x.CanExecute))
            {
                this._fight.FinishTurn(this.Me);
            }
        }


        public Character Me { get; }

        public bool ItsMyTurn
        {
            get { return this._itsMyTurn; }
            set { this.SetField(ref this._itsMyTurn, value); }
        }

        public ObservableCollection<StreamlineViewModel> Streamlines
        {
            get { return this._streamlines; }
            set { this.SetField(ref this._streamlines, value); }
        }

        private void FightOnActiveCharacterChanged(object sender, ActiveCharacterChangedEventArgs e)
        {
            this.RefreshIsItMyTurn();
        }

        private void RefreshIsItMyTurn()
        {
            this.ItsMyTurn = this._fight.IsItMyTurn(this.Me);
            foreach (var streamlineViewModel in this.Streamlines)
            {
                streamlineViewModel.CanExecute = this._fight.IsItMyTurn(this.Me);
            }
        }

        //private void AddNode(object sender, RoutedEventArgs e)
        //{
        //    var lastAddedNode = this.Nodes.LastOrDefault();
        //    var damageAbility = this._abilityBuilder.CreateDamageAbility(6, lastAddedNode?.AbilityToken, null);
        //    var nodeViewModel = new AbilityTokenViewModel(damageAbility);
        //    this.Nodes.Add(nodeViewModel);
        //}


        //private void Evaluate(object sender, RoutedEventArgs e)
        //{
        //    var abilities = this.Nodes.FirstOrDefault(); // Root Node
        //    var abilityActionsQueue = new AbilityActionsQueue(abilities.AbilityToken);

        //    foreach (var abilityAction in abilityActionsQueue)
        //    {
        //        var targetSelectionRequired =
        //            this.Fight.GetTargetSelectionRequirementForAction(this.MyIdentity, abilityAction);
        //        var target = this.Fight.AutoSelectTargetForAction(this.MyIdentity, abilityAction);
        //        var log = this.Fight.ResolveAbility(this.MyIdentity, abilityAction, target);
        //    }

        //    this.Fight.FinishTurn(MyIdentity);
        //}


        //private void AddBlockNode(object sender, RoutedEventArgs e)
        //{
        //    var lastAddedNode = this.Nodes.LastOrDefault();
        //    var blockAbility = this._abilityBuilder.CreateBlockAbility(6, lastAddedNode?.AbilityToken, null);
        //    var nodeViewModel = new AbilityTokenViewModel(blockAbility);
        //    this.Nodes.Add(nodeViewModel);
        //}
    }
}