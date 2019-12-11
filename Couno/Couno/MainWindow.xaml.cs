using System;
using System.Collections.Generic;
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
        private readonly ICounoFightEnvironment _fight = new CounoTestFight(new Character(200, new List<Item>()), new Character(160, new List<Item>()));
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;

            this.Player.InitializeFight(_fight, _fight.Player);
            this.Enemy.InitializeFight(_fight, _fight.Enemy);
        }
    }
}