using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GF.Couno.FightSystem;
using GF.Couno.FightSystem.Entities;

namespace GF.Couno.CardGameProtoWpf
{
    public class MainWindowViewModel : ObservableObject
    {
        #region - Konstruktoren -

        public MainWindowViewModel()
        {
            this.FightProgress = new FightProgressViewModel();
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

            this.FightProgress.RegisterFighters(Player, Enemy);
            this.FightProgress.ApplyFightData(_currentFight);
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