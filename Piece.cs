using System;
using System.Windows;
using System.Collections;
using System.Diagnostics;

public abstract class Piece
{
    protected Boolean moved = false;

    private string team = "Not Defined";
    private string pieceType = "Not Defined";

    public Piece(string team, string pieceType)
    {
        this.team = team;
        this.pieceType = pieceType;
    }

    public abstract int[,] move();

    public abstract int[,] attack();

    public abstract Boolean specified();

    public void setMoved(Boolean moved)
    {
        this.moved = moved;
    }

    public string getTeam()
    {
        return team;
    }

    public string getPieceType()
    {
        return pieceType;
    }



}
