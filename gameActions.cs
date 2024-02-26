using System;
using System.Windows;
using System.Diagnostics;

public static class gameActions
{
    //public static int[] possibleMoves;

    public static void action(Piece[] Pieces, string ID, ref int stage)
    {

        int IDconvert = int.Parse(ID);
        string test2 = "";
        if (stage == 0)
        {
            int test = Pieces[IDconvert].move(IDconvert);
            foreach (int i in test)
            {
                test2 = test2 + i.ToString();
            }
            MessageBox.Show(test2);
            stage = 1;
        }
        else
        {
            MessageBox.Show("Wybrano, teraz ruch");
            stage = 0;
        }
    }
}
