using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class Bishop : Piece
{
    int[,] moves = { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };

    public Bishop(string team) : base(team, "Bishop")
    {
        if (getTeam() == "White")
            textureURL = "/Texture/BishopW.png";
        else
            textureURL = "/Texture/BishopB.png";
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
