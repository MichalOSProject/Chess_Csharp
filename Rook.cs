using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Rook : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
    public Rook(string team) : base(team, "Rook")
    {
        moveJumps = 7;
        attackJumps = 7;
        setMoves(moves);

    }
}
