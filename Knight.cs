using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Knight : Piece
{
    int[,] moves = { { -2, -1 }, { -2, 1 }, { 2, -1 }, { 2, 1 }, { -1, -2 }, { 1, -2 }, { -1, 2 }, { 1, 2 } };
    public Knight(string team) : base(team, "Knight")
    {
        moveJumps = 1;
        attackJumps = 1;
        setMoves(moves);

    }
}
