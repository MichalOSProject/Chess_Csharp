using System;
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
        public String team = "White";
        public Menu()
        {
            InitializeComponent();
            Button runGame = new Button();
            runGame.Content = "Run Game";
            runGame.Click += buttonGame;
            Grid.SetColumn(runGame, 3);
            Grid.SetRow(runGame, 8);
            GameMenu.Children.Add(runGame);
            Label lTeam = new Label();
            lTeam.Content = "Starts the game: ";
            Grid.SetColumn(lTeam, 1);
            Grid.SetRow(lTeam, 1);
            GameMenu.Children.Add(lTeam);
            Label l1type = new Label();
            l1type.Content = "1'st Color: ";
            Grid.SetColumn(l1type, 1);
            Grid.SetRow(l1type, 3);
            GameMenu.Children.Add(l1type);
            Label l2type = new Label();
            l2type.Content = "2'nd Color: ";
            Grid.SetColumn(l2type, 1);
            Grid.SetRow(l2type, 5);
            GameMenu.Children.Add(l2type);
            Button bTeam = new Button();
            bTeam.Content = "";
            bTeam.Background = Brushes.White;
            bTeam.Click += buttonTeam;
            Grid.SetColumn(bTeam, 3);
            Grid.SetRow(bTeam, 1);
            GameMenu.Children.Add(bTeam);
            Button color1 = new Button();
            color1.Content = "1# Color";
            color1.Name = "bColor1";
            color1.Click += buttonColor;
            color1.Background = new SolidColorBrush(bColor1);
            Grid.SetColumn(color1, 3);
            Grid.SetRow(color1, 3);
            GameMenu.Children.Add(color1);
            Button color2 = new Button();
            color2.Content = "2# Color";
            color2.Name = "bColor2";
            color2.Click += buttonColor;
            color2.Background = new SolidColorBrush(bColor2);
            Grid.SetColumn(color2, 3);
            Grid.SetRow(color2, 5);
            GameMenu.Children.Add(color2);
        }

        private void buttonColor(object sender, RoutedEventArgs e)
        {
            setColor(sender as Button);
        }

        private void buttonTeam(object sender, RoutedEventArgs e)
        {
            changeTeam(sender as Button);
        }

        private void buttonGame(object sender, RoutedEventArgs e)
        {
            newGame();
        }

        private void newGame()
        {
            if (gameWindow == null || !gameWindow.IsVisible)
            {
                gameWindow = new Game(bColor1, bColor2, team);
                this.Hide();
                gameWindow.Closed += (s, args) => { gameWindow = null; this.Show(); };
                gameWindow.Show();
            }
            else
            {
                gameWindow.Activate();
            }
        }
        private void setColor(Button bName)
        {
            if (colorWindow == null || !colorWindow.IsVisible)
            {
                if (bName.Name == "bColor1")
                    colorWindow = new ColorPanel(bColor1);
                else
                    colorWindow = new ColorPanel(bColor2);

                colorWindow.Closed += (s, args) =>
                {
                    if (bName.Name == "bColor1")
                        bColor1 = colorWindow.selectedColor;
                    else
                        bColor2 = colorWindow.selectedColor;
                    bName.Background = new SolidColorBrush(colorWindow.selectedColor);
                    colorWindow = null;
                };
                colorWindow.Show();

            }
            else
            {
                colorWindow.Activate();
            }

        }

        private void changeTeam(Button bName)
        {
            if (team == "White")
            {
                team = "Black";
                bName.Background = Brushes.Black;
            }
            else
            {
                team = "White";
                bName.Background = Brushes.White;
            }
        }
    }
}