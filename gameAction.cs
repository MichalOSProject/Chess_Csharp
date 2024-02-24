using System;
using System.Windows;

public static class gameAction
{
    public static void whoami(string ID, Piece[] Pieces)
    {
        MessageBox.Show(Pieces[int.Parse(ID)].getPieceType());
    }
}
