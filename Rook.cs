using System;

public class Rook : Piece
{
    public Rook(string team) : base(team)
    {
        setTeam(team);
        setPieceType("Rook");
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
