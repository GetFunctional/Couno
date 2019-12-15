using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Couno.Engine;
using Couno.Shared.Mvvm;

namespace Couno
{
    public class TokenSelectorViewModel : ViewModelBase
    {
        private readonly TokenFactory _tokenFactory = new TokenFactory();
        private AbilityTokenViewModel _selectedToken;


        public TokenSelectorViewModel()
        {
            this.AvailableAbilityTokens =
                new ObservableCollection<AbilityTokenViewModel>(
                    this.CreateViewModelsFrom(this._tokenFactory.GetAllAvailableTokens()));
        }


        public ObservableCollection<AbilityTokenViewModel> AvailableAbilityTokens { get; }

        public AbilityTokenViewModel SelectedToken
        {
            get { return this._selectedToken; }
            set { this.SetField(ref this._selectedToken, value); }
        }


        private IEnumerable<AbilityTokenViewModel> CreateViewModelsFrom(IList<IAbilityToken> getAllAvailableTokens)
        {
            return getAllAvailableTokens.Select(x => new AbilityTokenViewModel(x)).ToList();
        }
    }
}