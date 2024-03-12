using System;
using System.Collections;

public class Rook : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

    public Rook(string team) : base(team, "Rook")
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
