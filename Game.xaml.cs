using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess
{

    public partial class Game : Window
    {
        private int stage = 0;
        private Piece[] Pieces;
        private Button[,] BoardSpace;
        private int[,] stats;
        private int lastUsed;
        private int checkMateStatusW = 0;
        private int checkMateStatusB = 0;
        private Color bColor1;
        private Color bColor2;
        public Game(Color bColor1, Color bColor2)
        {
            this.bColor1 = bColor1;
            this.bColor2 = bColor2;
            Debug.WriteLine(this.bColor1.R);
            Debug.WriteLine(this.bColor1.G);
            Debug.WriteLine(this.bColor1.B);
            Debug.WriteLine(this.bColor2.R);
            Debug.WriteLine(this.bColor2.G);
            Debug.WriteLine(this.bColor2.B);
            InitializeComponent();
            defineMap();
            createMap();
        }

        private void defineMap()
        {
            stats = new int[64, 3];
            clearMoves();
            Pieces = new Piece[64];
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
            setMoves();
            clearMoves();
        }

        private void setMoves()
        {
            for (int i = 0; i < 64; i++)
            {
                stats[i, 1] = 0;
                stats[i, 2] = 0;
            }
            for (int i = 0; i < 64; i++)
                gameActions.assignMoves(i, ref stats, ref Pieces, 1);
        }
        private void clearMoves()
        {
            for (int i = 0; i < 64; i++)
            {
                stats[i, 0] = 0;
            }
        }
        private void createMap()
        {
            int ID = 0;
            BoardSpace = new Button[8, 8];
            for (int j = 0; j <= 7; j++)
            {
                for (int k = 0; k <= 7; k++)
                {
                    BoardSpace[j, k] = new Button();
                    bool evenRow = (ID / 8) % 2 == 0;
                    bool evenColumn = ID % 2 == 0;
                    if (evenRow == evenColumn)
                    {
                        BoardSpace[j, k].Background = new SolidColorBrush(bColor1);
                    }
                    else
                    {
                        BoardSpace[j, k].Background = new SolidColorBrush(bColor2);
                    }
                    BoardSpace[j, k].Tag = new int();
                    BoardSpace[j, k].Tag = ID;
                    BoardSpace[j, k].Content = Pieces[ID].getTexture();
                    BoardSpace[j, k].Click += Button_Click;
                    BoardSpace[j, k].FontWeight = FontWeights.Bold;
                    if (Pieces[ID].getTeam() == "White")
                        BoardSpace[j, k].Foreground = Brushes.Yellow;
                    if (Pieces[ID].getTeam() == "Black")
                        BoardSpace[j, k].Foreground = Brushes.Purple;
                    Grid.SetColumn(BoardSpace[j, k], k);
                    Grid.SetRow(BoardSpace[j, k], j);
                    SandBox.Children.Add(BoardSpace[j, k]);
                    ID++;

                }
            }
        }
        private void repaint(ref Button[,] BoardSpace, int[,] stats)
        {
            setMoves();
            int ID = 0;
            for (int j = 0; j <= 7; j++)
            {
                for (int k = 0; k <= 7; k++)
                {
                    bool evenRow = (ID / 8) % 2 == 0;
                    bool evenColumn = ID % 2 == 0;
                    BoardSpace[j, k].Content = Pieces[ID].getTexture();
                    if (evenRow == evenColumn)
                    {
                        BoardSpace[j, k].Background = new SolidColorBrush(bColor1);
                    }
                    else
                    {
                        BoardSpace[j, k].Background = new SolidColorBrush(bColor2);
                    }
                    if (Pieces[ID].getTeam() == "White")
                        BoardSpace[j, k].Foreground = Brushes.Yellow;
                    if (Pieces[ID].getTeam() == "Black")
                        BoardSpace[j, k].Foreground = Brushes.Purple;
                    if (stats[ID, 0] != 0)
                        BoardSpace[j, k].Background = Brushes.Gray;
                    ID++;
                }
            }
        }

        private Boolean allowedPlace(int ID)
        {
            if (stats[ID, 0] != 0 || stage == 0 || lastUsed == ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void endgame()
        {
            for (int i = 0; i < 64; i++)
            {
                if (Pieces[i].getPieceType() == "King")
                    if (Pieces[i].getTeam() == "White")
                        checkMateStatusW = gameActions.checkMate(Pieces, stats, i);
                    else
                        checkMateStatusB = gameActions.checkMate(Pieces, stats, i);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (allowedPlace(int.Parse((sender as Button).Tag.ToString())))
            {
                if (stage == 1)
                    clearMoves();
                gameActions.action(ref Pieces, (sender as Button).Tag.ToString(), ref stage, ref stats);
                repaint(ref BoardSpace, stats);
                lastUsed = int.Parse((sender as Button).Tag.ToString());
            }



            //test
            for (int i = 0; i < 64; i++)
            {
                Debug.WriteLine("ID: " + i + ", White: " + stats[i, 1] + ", Black: " + stats[i, 2]);
            }
            endgame();
            Debug.WriteLine("Status szachmat dla W: " + checkMateStatusW);
            Debug.WriteLine("Status szachmat dla B: " + checkMateStatusB);

        }
    }
}

