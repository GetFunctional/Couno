using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Input;
using Couno.Engine;
using Couno.Shared.Mvvm;

namespace Couno
{
    public class TokenBoardViewModel : ResourceStreamlineElementViewModel
    {
        private readonly TokenBoard _tokenBoard;
        private string _name;

        public TokenBoardViewModel(TokenBoard tokenBoard)
        {
            this._tokenBoard = tokenBoard;
            this.Abilities = new ObservableCollection<AbilityTokenViewModel>(CreateAbilitiesFrom(tokenBoard.ExtractAbilities()));
            this.Name = tokenBoard.ToString();
            this.ConfigureBoardCommand = new DelegateCommand<object>(ConfigureBoard);
        }

        private void ConfigureBoard(object obj)
        {
            var configureViewModel = new ConfigureBoardViewModel(this._tokenBoard);
            var dialog = new ConfigureBoardView()
                {DataContext = configureViewModel};

            dialog.ShowDialog();
            var currentConfiguration = configureViewModel.Abilities.Select(x => x.AbilityToken);
            this._tokenBoard.ReplaceAbilities(currentConfiguration);
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

        public ICommand ConfigureBoardCommand { get; private set; }
    }
}