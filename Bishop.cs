using System;
using System.Collections;
using System.Windows;

public class Bishop : Piece
{
    int[,] moves = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

    public Bishop(string team) : base(team, "Bishop")
    {
    }

    public override int[,] move()
    {
        return moves;
    }

    public override int[,] attack()
    {
        return moves;
    }

    public override Boolean specified()
    {
        return false;
    }
}
