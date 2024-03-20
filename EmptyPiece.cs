using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class EmptyPiece : Piece
{
    int[,] moves = { { 0, 0 }, { 0, 0 } };
    public EmptyPiece(string team = "FF") : base(team, "")
    {
        moveJumps = 1;
        attackJumps = 1;
        setMoves(moves);

    }
}
