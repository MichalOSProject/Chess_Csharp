using System;

public abstract class Piece
{
    string team = "Not Defined";
    string pieceType = "Not Defined";

    public Piece(string team)
    {
    }

    public void move() { }

    public void attack() { }

    public void jump() { }

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
