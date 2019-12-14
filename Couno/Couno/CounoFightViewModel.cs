using System.Collections.Generic;
using Couno.Engine;

namespace Couno
{
    public class CounoFightViewModel : ViewModelBase
    {
        private readonly ICounoFightEnvironment _fight =
            new CounoTestFight(new Character(200, new List<Item>()), new Character(86, new List<Item>()));

        public CounoFightViewModel()
        {
            this.Player = new FighterViewModel(this._fight, this._fight.Player);
            this.Enemy = new FighterViewModel(this._fight, this._fight.Enemy);
        }

        public FighterViewModel Player { get; }

        public FighterViewModel Enemy { get; }
    }
}