using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GF.Couno.FightSystem;

namespace GF.Couno.CardGameProtoWpf
{
    public class MainWindowViewModel : ObservableObject
    {
        #region - Konstruktoren -

        public MainWindowViewModel()
        {
            EndTurnCommand = new RelayCommand(() => FightProgress.EndTurn());
        }

        private readonly FightEngine _fightEngine = FightEngine.CreateFightRuntime();
        private FightInfoResult _currentFight;
        private FighterHudViewModel _enemy;
        private FighterHudViewModel _player;

        internal async Task StartNewFight()
        {
            _currentFight = await _fightEngine.FightMediator.StartFightAsync(new FighterId());

            Player = new FighterHudViewModel(_currentFight.PlayerFighterInfo);
            Enemy = new FighterHudViewModel(_currentFight.EnemyFighterInfo);
        }

        #endregion

        #region - Properties oeffentlich -

        public FighterHudViewModel Enemy
        {
            get => _enemy;
            set => this.SetField(ref _enemy, value);
        }

        public FighterHudViewModel Player
        {
            get => _player;
            set => this.SetField(ref _player, value);
        }

        public FightProgressViewModel FightProgress { get; }

        public ICommand EndTurnCommand { get; }

        #endregion
    }
}