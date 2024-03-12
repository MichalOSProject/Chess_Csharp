using System;
using System.Collections;

public class Queen : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

    public Queen(string team) : base(team, "Queen")
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
