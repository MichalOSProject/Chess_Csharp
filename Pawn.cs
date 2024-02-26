using System;

public class Pawn : Piece
{
    public Pawn(string team) : base(team)
    {
        setTeam(team);
        setPieceType("Pawn");
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
