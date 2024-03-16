using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Diagnostics;

public class Pawn : Piece
{
    int[,] movesB = { { 0, 1 } };
    int[,] movesW = { { 0, -1 } };

    int[,] attackMapB = { { 1, 1 }, { -1, 1 } };
    int[,] attackMapW = { { 1, -1 }, { -1, -1 } };

    int specifiedCount = 2;
    public Pawn(string team) : base(team, "Pawn")
    {
        if (getTeam() == "White")
            textureURL = "/Texture/PawnW.png";
        else
            textureURL = "/Texture/PawnB.png";
        Texture = new Image
        {
            Source = new BitmapImage(new Uri(textureURL, UriKind.Relative)),
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };
    }

    public override int[,] move()
    {
        if (getTeam() == "White")
        {
                return movesW;
        }
        else
        {
                return movesB;
        }

    }

    public override int[,] attack()
    {
        if (getTeam() == "White")
        {
            return attackMapW;
        }
        else
        {
            return attackMapB;
        }
    }

    public override int jumpMove()
    {
        if (!moved)
            return 2;
        else
            return 1;
    }
    public override int jumpAttack()
    {
        return 1;
    }

    public override Image getTexture()
    {
        return Texture;
    }
}
