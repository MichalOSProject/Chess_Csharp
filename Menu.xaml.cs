using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private Game gameWindow;
        public Menu()
        {
            InitializeComponent();
            Button runGame = new Button();
            runGame.Content = "Run Game";
            runGame.Name = "RG";
            runGame.Click += newGame;
            Grid.SetColumn(runGame, 3);
            Grid.SetRow(runGame, 8);
            GameMenu.Children.Add(runGame);
            Label lTeam = new Label();
            lTeam.Content = "Team: ";
            lTeam.Name = "lTeam";
            Grid.SetColumn(lTeam, 1);
            Grid.SetRow(lTeam, 1);
            GameMenu.Children.Add(lTeam);
            Label l1type = new Label();
            l1type.Content = "1'st Color: ";
            l1type.Name = "l1Color";
            Grid.SetColumn(l1type, 1);
            Grid.SetRow(l1type, 2);
            GameMenu.Children.Add(l1type);
            Label l2type = new Label();
            l2type.Content = "2'nd Color: ";
            l2type.Name = "l2Color";
            Grid.SetColumn(l2type, 1);
            Grid.SetRow(l2type, 3);
            GameMenu.Children.Add(l2type);
        }

        private void newGame (object sender, RoutedEventArgs e)
        {
            if (gameWindow == null || ! gameWindow.IsVisible)
            {
                gameWindow = new Game();
                gameWindow.Closed += (s, args) => { gameWindow = null; };
                gameWindow.Show();
            }
            else {
                gameWindow.Activate();
            }
        }
    }
}
