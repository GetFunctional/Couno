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
        private readonly ICounoFightEnvironment _fight = new CounoTestFight(new Player(), new Enemy());
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;

            this.Player.Fight = this._fight;
            this.Player.MyIdentity = this._fight.Player;

            this.Enemy.Fight = this._fight;
            this.Enemy.MyIdentity = this._fight.Enemy;

        }
    }
}