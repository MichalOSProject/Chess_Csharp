using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess
{

    public partial class Game : Window
    {
        private int stage = 0;
        private Piece[] Pieces;
        private Button[,] BoardSpace;
        private int[,,] stats; //[ID,1-3,attacker]
        private int played;
        private int lastUsed;
        private int checkMateStatusW = 0;
        private int checkMateStatusB = 0;
        private Color bColor1;
        private Color bColor2;
        private String team;
        public Game(Color bColor1, Color bColor2, String team)
        {
            this.team = team;
            this.bColor1 = bColor1;
            this.bColor2 = bColor2;
            InitializeComponent();
            defineMap();
            createMap();
        }
        private void defineMap()
        {
            stats = new int[64, 3, 10];
            removeMovesMarks();
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
            assignDamage();
            removeMovesMarks();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            buttonAction((int)((Button)sender).Tag);
        }
        private void buttonAction(int ID)
        {
            this.played = ID;

            if (stage == 0 && allowedPlace(played))
            {
                gameActions.action(ref Pieces, ref stage, ref stats, played);
                repaint(ref BoardSpace, stats);
                lastUsed = played;
            }
            else if (stage == 1 && allowedPlace(played))
            {
                gameActions.action(ref Pieces, ref stage, ref stats, played);
                removeMovesMarks();
                assignDamage();
                repaint(ref BoardSpace, stats);
                if (played != lastUsed)
                {
                    if (team == "White")
                        team = "Black";
                    else
                        team = "White";
                    assignDamage();
                    check();
                }
            }
        }
        private Boolean allowedPlace(int ID)
        {
            if (stage == 1 && (stats[ID, 0, 0] == 1 || lastUsed == ID))
                return true;
            else if (stage == 0 && Pieces[ID].getTeam() == team)
                return true;
            else
                return false;
        }
        private void removeMovesMarks()
        {
            for (int i = 0; i < 64; i++)
            {
                stats[i, 0, 0] = 0;
            }

        }
        private void repaint(ref Button[,] BoardSpace, int[,,] stats)
        {
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
                    if (stats[ID, 0, 0] != 0)
                        BoardSpace[j, k].Background = Brushes.Gray;
                    if (played == ID && stage == 1)
                        BoardSpace[j, k].Background = Brushes.LightBlue;
                    ID++;
                }
            }
        }
        private void assignDamage()
        {

            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    stats[i, 1, j] = 100;
                    stats[i, 2, j] = 100;
                }
            }
            for (int i = 0; i < 64; i++)
                gameActions.assignMoves(i, ref stats, ref Pieces, 1);
        }
        private void check()
        {
            for (int i = 0; i < 64; i++)
            {
                if (Pieces[i].getPieceType() == "King")
                    if (Pieces[i].getTeam() == "White")
                    {
                        if (checkMateStatusW <= gameActions.checkMate(Pieces, stats, i) && checkMateStatusW == 1)
                        {
                            endgame("The Black Team Wins! The attack was not avoided");
                            break;
                        }
                        checkMateStatusW = gameActions.checkMate(Pieces, stats, i);
                        if (checkMateStatusW == 1)
                            MessageBox.Show("The King of the White Team is in Danger!");
                    }
                    else
                    {
                        if (checkMateStatusB <= gameActions.checkMate(Pieces, stats, i) && checkMateStatusB == 1)
                        {
                            endgame("The White Team Wins! The attack was not avoided");
                            break;
                        }
                        checkMateStatusB = gameActions.checkMate(Pieces, stats, i);
                        if (checkMateStatusB == 1)
                            MessageBox.Show("The King of the Black Team is in Danger!");
                    }
            }
            if (checkMateStatusB == 2 && checkMateStatusW == 2)
                endgame("Draw!");
            else if (checkMateStatusW == 2)
                endgame("The Black Team Wins!");
            else if (checkMateStatusB == 2)
                endgame("The White Team Wins!");
        }
        private void endgame(String text)
        {
            MessageBox.Show(text);
            this.Close();
        }
    }
}

