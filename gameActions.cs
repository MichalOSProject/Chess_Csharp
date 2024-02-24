using System;
using System.Windows;

    public static class gameActions
    {
        public static void action(string ID, int stage)
        {
            if (stage == 0)
            {
                MessageBox.Show(getPiece(int.Parse(ID)).getPieceType());
                //MessageBox.Show(Pieces[)].getPieceType());
            }
            else
            {
                MessageBox.Show("XD");
                stage = 0;
            }
        }
    }
