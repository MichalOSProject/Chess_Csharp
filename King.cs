using System;

public class King : Piece
{
    public King(string team) : base(team)
    {
        setTeam(team);
        setPieceType("King");
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
