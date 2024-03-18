using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess
{
    public partial class Menu : Window
    {
        public Color bColor1 = Color.FromRgb(0, 0, 0);
        public Color bColor2 = Color.FromRgb(254, 254, 254);
        private Game gameWindow;
        private ColorPanel colorWindow;
        protected String team;
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
            Button bTeam = new Button();
            bTeam.Content = "";
            bTeam.Background = Brushes.Black;
            bTeam.Name = "sTeam";
            bTeam.Click += changeTeam;
            Grid.SetColumn(bTeam, 3);
            Grid.SetRow(bTeam, 1);
            GameMenu.Children.Add(bTeam);
            Button color1 = new Button();
            color1.Content = "1# Color";
            color1.Name = "bColor1";
            color1.Click += setColor;
            color1.Background = new SolidColorBrush(bColor1);
            Grid.SetColumn(color1, 3);
            Grid.SetRow(color1, 2);
            GameMenu.Children.Add(color1);
            Button color2 = new Button();
            color2.Content = "2# Color";
            color2.Name = "bColor2";
            color2.Click += setColor;
            color2.Background = new SolidColorBrush(bColor2);
            Grid.SetColumn(color2, 3);
            Grid.SetRow(color2, 3);
            GameMenu.Children.Add(color2);
        }

        private void setColor(object sender, RoutedEventArgs e)
        {
            if (colorWindow == null || !colorWindow.IsVisible)
            {
                if ((sender as Button).Name == "bColor1")
                    colorWindow = new ColorPanel(bColor1);
                else
                    colorWindow = new ColorPanel(bColor2);

                colorWindow.Closed += (s, args) =>
                {
                    if ((sender as Button).Name == "bColor1")
                        bColor1 = colorWindow.selectedColor;
                    else
                        bColor2 = colorWindow.selectedColor;
                    (sender as Button).Background = new SolidColorBrush(colorWindow.selectedColor);
                    colorWindow = null;
                };
                colorWindow.Show();

            }
            else
            {
                colorWindow.Activate();
            }

        }

        private void changeTeam(object sender, RoutedEventArgs e)
        {
            if (team == "White")
            {
                team = "Black";
                (sender as Button).Background = Brushes.Black;
            }
            else {
                team = "White";
                (sender as Button).Background = Brushes.White;
            }
        }
        private void newGame(object sender, RoutedEventArgs e)
        {
            if (gameWindow == null || !gameWindow.IsVisible)
            {
                gameWindow = new Game(bColor1, bColor2, team);
                Debug.WriteLine(bColor1.R);
                Debug.WriteLine(bColor1.G);
                Debug.WriteLine(bColor1.B);
                Debug.WriteLine(bColor2.R);
                Debug.WriteLine(bColor2.G);
                Debug.WriteLine(bColor2.B);
                this.Hide();
                gameWindow.Closed += (s, args) => { gameWindow = null; this.Show(); };
                gameWindow.Show();
            }
            else
            {
                gameWindow.Activate();
            }
        }
    }
}
/*
 * ToDO:
 * -włącz działanie teamów
 * -koniec gry
 * -poprawienie króla bo zabicie konia pionkiem nie jest uwzględniona
*/