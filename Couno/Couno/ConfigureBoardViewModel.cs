using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Couno.Engine;
using Couno.Shared.Mvvm;

namespace Couno
{
    internal class ConfigureBoardViewModel : ViewModelBase
    {
        private readonly IResourceStreamlineElement _tokenBoard;

        public ConfigureBoardViewModel(IResourceStreamlineElement tokenBoard)
        {
            this._tokenBoard = tokenBoard;
            this.Abilities =
                new ObservableCollection<AbilityTokenViewModel>(
                    this.CreateAbilitiesFrom(tokenBoard.ExtractAbilities()));
            this.AddTokenCommand = new DelegateCommand<object>(this.SelectAndAddToken);
        }

        private void SelectAndAddToken(object obj)
        {
            var selectorViewModel = new TokenSelectorViewModel();
            var selectorDialog = new TokenSelectorWindow()
            {
                DataContext =selectorViewModel
            };

            selectorDialog.ShowDialog();
            var selectedToken = selectorViewModel.SelectedToken;
            if (selectedToken != null)
            {
                this.Abilities.Add(selectedToken);
            }
        }

        public ObservableCollection<AbilityTokenViewModel> Abilities { get; }

        public ICommand AddTokenCommand { get; }

        private IEnumerable<AbilityTokenViewModel> CreateAbilitiesFrom(IEnumerable<IAbilityToken> abilities)
        {
            return abilities.Select(x => new AbilityTokenViewModel(x));
        }
    }
}