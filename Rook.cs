using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Rook : Piece
{
    int[,] moves = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

    public Rook(string team) : base(team, "Rook")
    {
        if (getTeam() == "White")
            textureURL = "/Texture/RookW.png";
        else
            textureURL = "/Texture/RookB.png";
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
        return 7;
    }
    public override int jumpAttack()
    {
        return 7;
    }

    public override Image getTexture()
    {
        return Texture;
    }
}
