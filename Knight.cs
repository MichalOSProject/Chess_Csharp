using System;
using System.Collections;
using System.Windows;

public class Knight : Piece
{
    int[,] moves = { { -2, -1 }, { -2, 1 }, { 2, -1 }, { 2, 1 }, { -1, -2 }, { 1, -2 }, { -1, 2 }, { 1, 2 } };

    public Knight(string team) : base(team, "Knight")
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
        return true;
    }
}
