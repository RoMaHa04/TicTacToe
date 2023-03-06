using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Game _Game = new Game();
        private void PlayerClicSpace(object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            space.Content = _Game.CurentPlayer;


            var cordinates = space.Tag.ToString().Split(",");
            var xValue = int.Parse(cordinates[0]);
            var yValue = int.Parse(cordinates[1]);

            var buttonPosition = new Possition { x = xValue, y = yValue };
            _Game.UpdateBoard(buttonPosition, _Game.CurentPlayer);

            if (_Game.CheckPlayerWins())
            {
                WinSreen.Text = $"Player {_Game.CurentPlayer} Wins";
                WinSreen.Visibility = Visibility.Visible;
            }
            _Game.SetNexPlayer();
        }
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach( var c in Board.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Content = String.Empty;
                }
            }
            WinSreen.Visibility = Visibility.Collapsed;
        }
    }
}
