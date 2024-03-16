using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Knight : Piece
{
    int[,] moves = { { -2, -1 }, { -2, 1 }, { 2, -1 }, { 2, 1 }, { -1, -2 }, { 1, -2 }, { -1, 2 }, { 1, 2 } };

    public Knight(string team) : base(team, "Knight")
    {
        if (getTeam() == "White")
            textureURL = "/Texture/KnightW.png";
        else
            textureURL = "/Texture/KnightB.png";
        Texture = new Image
        {
            Source = new BitmapImage(new Uri(textureURL, UriKind.Relative)),
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };
    }

    public override int[,] move()
    {
        return moves;
    }

    public override int[,] attack()
    {
        return moves;
    }

    public override int jumpMove()
    {
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
