using System;

public abstract class Piece
{
    string team = "Not Defined";
    string pieceType = "Not Defined";

    public Piece(string team)
    {
    }

    public int[] move(int IDconvert)
    {
        int[] possibleMoves = { 1 };
        return possibleMoves;
    }

    public void attack() { }

    public Boolean jump()
    {
        return false;
    }

    public void setTeam(string team)
    {
        this.team = team;
    }

    public string getTeam()
    {
        return team;
    }

    public void setPieceType(string pieceType)
    {
        this.pieceType = pieceType;
    }

    public string getPieceType()
    {
        return pieceType;
    }



}
