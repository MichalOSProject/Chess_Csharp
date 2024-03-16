using System;
using System.Windows.Controls;

public abstract class Piece
{
    protected Boolean moved = false;
    protected String textureURL;
    protected Image Texture;

    private string team = "Not Defined";
    private string pieceType = "Not Defined";

    public Piece(string team, string pieceType)
    {
        this.team = team;
        this.pieceType = pieceType;
    }

    public abstract int[,] move();

    public abstract int[,] attack();

    public abstract int jumpMove();

    public abstract int jumpAttack();

    public abstract Image getTexture();

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
