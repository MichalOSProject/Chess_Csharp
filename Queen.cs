using System;

public class Queen : Piece
{
    public Queen(string team) : base(team)
    {
        setTeam(team);
        setPieceType("Queen");
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
