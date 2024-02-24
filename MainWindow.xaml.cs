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

namespace Chess
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            createMap();
            Piece[] Pieces = new Piece[64];
            fillMap(Pieces);

        }

        private void fillMap(Piece[] Pieces)
        {
            Pieces[0] = new Rook("Black");
            Pieces[7] = new Rook("Black");
            Pieces[56] = new Rook("White");
            Pieces[63] = new Rook("White");
            Pieces[1] = new Knight("Black");
            Pieces[6] = new Knight("Black");
            Pieces[57] = new Knight("White");
            Pieces[62] = new Knight("White");
            Pieces[2] = new Bishop("Black");
            Pieces[5] = new Bishop("Black");
            Pieces[58] = new Bishop("White");
            Pieces[61] = new Bishop("White");
            Pieces[4] = new Queen("Black");
            Pieces[60] = new Queen("White");
            Pieces[3] = new King("Black");
            Pieces[59] = new King("White");
            for (int i = 8; i < 16; i++)
                Pieces[i] = new Pawn("Black");
            for (int i = 48; i < 56; i++)
                Pieces[i] = new Pawn("White");
            for (int i = 16; i < 48; i++)
                Pieces[i] = new EmptyPiece();
        }

        private void createMap()
        {
            int ID = 0;
            for (int j = 0; j <= 7; j++)
            {
                for (int k = 0; k <= 7; k++)
                {
                    Button BoardSpace = new Button();
                    bool evenRow = (ID / 8) % 2 == 0;
                    bool evenColumn = ID % 2 == 0;
                    if (evenRow == evenColumn)
                    {
                        BoardSpace.Background = Brushes.White;
                    }
                    else
                    {
                        BoardSpace.Background = Brushes.Black;
                    }
                    BoardSpace.Name = "Bababab" + ID;
                    BoardSpace.Content = "B" + ID;
                    BoardSpace.Click += Button_Click;
                    Grid.SetColumn(BoardSpace, k);
                    Grid.SetRow(BoardSpace, j);
                    SandBox.Children.Add(BoardSpace);
                    ID++;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Name);
        }
    }
}
