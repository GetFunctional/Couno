using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Couno.Engine;

namespace Couno
{
    public class TokenBoardViewModel : ViewModelBase
    {
        private readonly IResourceStreamlineElement _tokenBoard;
        private string _name;

        public TokenBoardViewModel(IResourceStreamlineElement tokenBoard)
        {
            this._tokenBoard = tokenBoard;
            this.Abilities = new ObservableCollection<AbilityTokenViewModel>(CreateAbilitiesFrom(tokenBoard.ExtractAbilities()));
            this.Name = tokenBoard.ToString();
        }

        public string Name
        {
            get { return this._name; }
            set { this.SetField(ref this._name,value); }
        }

        private IEnumerable<AbilityTokenViewModel> CreateAbilitiesFrom(IEnumerable<IAbilityToken> abilities)
        {
            return abilities.Select(x => new AbilityTokenViewModel(x));
        }

        public ObservableCollection<AbilityTokenViewModel> Abilities { get; }
    }
}