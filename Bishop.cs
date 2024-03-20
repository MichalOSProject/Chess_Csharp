using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Bishop : Piece
{
    int[,] moves = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
    public Bishop(string team) : base(team, "Bishop")
    {
        moveJumps = 7;
        attackJumps = 7;
        setMoves(moves);

    }
}
