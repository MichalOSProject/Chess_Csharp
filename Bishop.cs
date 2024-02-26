using System;

public class Bishop : Piece
{
    public Bishop(string team) : base(team)
    {
        setTeam(team);
        setPieceType("Bishop");
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
