using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Queen : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
    public Queen(string team) : base(team, "Queen")
    {
        moveJumps = 7;
        attackJumps = 7;
        setMoves(moves);
        
    }
}
