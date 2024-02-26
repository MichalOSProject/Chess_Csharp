using System;

public class EmptyPiece : Piece
{
    public EmptyPiece(string team = "0") : base(team)
    {
        setTeam(team);
        setPieceType("");
    }

    public new int[] move(int IDconvert)
    {
        int[] possibleMoves = { 1 };
        return possibleMoves;
    }

    public new void attack() { }

    public new Boolean jump()
    {
        return false;
    }

}
