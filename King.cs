using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class King : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 }, { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

    public King(string team) : base(team, "King")
    {
        if (getTeam() == "White")
            textureURL = "/Texture/KingW.png";
        else
            textureURL = "/Texture/KingB.png";
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
