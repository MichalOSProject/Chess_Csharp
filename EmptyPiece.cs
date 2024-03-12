using System;

public class EmptyPiece : Piece
{
    int[,] moves = { {0,0}, {0,0} };

    public EmptyPiece(string team = "FF") : base(team, "")
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
