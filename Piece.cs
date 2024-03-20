using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

public abstract class Piece
{
    protected Boolean moved = false;
    protected String textureURL;
    protected Image Texture;
    protected int[,] moves;
    protected int moveJumps;
    protected int attackJumps;

    private string team = "Not Defined";
    private string pieceType = "Not Defined";

    public Piece(string team, string pieceType)
    {
        this.team = team;
        this.pieceType = pieceType;
        setTexture();
    }

    public Image getTexture()
    {
        return Texture;
    }

    public void setTexture()
    {
        if (getPieceType() != "Not Defined")
        {
            textureURL = "/Texture/" + getPieceType() + getTeam() + ".png";
            Texture = new Image
            {
                Source = new BitmapImage(new Uri(textureURL, UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
        }
    }

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
    public virtual int[,] move()
    {
        return moves;
    }

    public virtual int[,] attack()
    {
        return moves;
    }

    public virtual void setMoves(int[,] moves)
    {
        this.moves = moves;
    }

    public virtual void setAttack(int[,] moves)
    {
        this.moves = moves;
    }

    public virtual int jumpMove()
    {
        return moveJumps;
    }
    public virtual int jumpAttack()
    {
        return attackJumps;
    }
}
