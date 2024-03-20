using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class King : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
    public King(string team) : base(team, "King")
    {
        moveJumps = 1;
        attackJumps = 1;
        setMoves(moves);

    }
}
