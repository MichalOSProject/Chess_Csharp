using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

public class EmptyPiece : Piece
{
    int[,] moves = { {0,0}, {0,0} };

    public EmptyPiece(string team = "FF") : base(team, "")
    {
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
        return null;
    }
}
