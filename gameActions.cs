using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Controls;
using System.Data.Common;
using System.Windows.Input;
using System.Collections;

public static class gameActions
{
    static Piece buffPiece;
    static int buffId = 0;
    public static void action(ref Piece[] Pieces, string ID, ref int stage, ref int[,] stats)
    {

        int IDconvert = int.Parse(ID);

        if (stage == 0)
        {
            buffPiece = Pieces[IDconvert];
            buffId = IDconvert;
            assignMoves(IDconvert, ref stats, ref Pieces, 0);

            stage = 1;
        }
        else
        {
            if (IDconvert != buffId)
            {
                buffPiece.setMoved(true);
                Pieces[buffId] = new EmptyPiece();
                Pieces[IDconvert] = buffPiece;
            }
            stage = 0;

        }

    }
    public static int checkMate(Piece[] Pieces, int[,] stats, int ID)
    {
        int checkMateStatus = 0;
        int[,] attackMap = Pieces[ID].attack();
        int Column = ID % 8;
        int Row = (ID - Column) / 8;
        string kingsTeam = Pieces[ID].getTeam();
        int sensitive = 1; // 1-> sensitive for Black dmg 2->sensitive for Black dmg
        Boolean endangered = false;
        Boolean possibleMoves = true;

        Debug.WriteLine("Jestem krolem ID: " + ID + ", Koloru: " + Pieces[ID].getTeam());
        if (kingsTeam == "White")
            sensitive = 2;

        if (stats[ID, sensitive] != 0)
        {
            checkMateStatus = 2;
        }
        if (checkMateStatus != 0)
        {
            for (int i = 0; i < attackMap.GetLength(0); i++)
            {
                int currentRow = Row + attackMap[i, 1];
                int currentColumn = Column + attackMap[i, 0];
                int currentIndex = (currentRow * 8) + currentColumn;
                if (inGame(currentColumn, currentRow))
                {
                    if (Pieces[currentIndex].getTeam() != kingsTeam && stats[currentIndex, sensitive] == 0)//i tutaj warunek na znalezienie kolegi :P)
                        checkMateStatus = 1;
                }
            }
        }
        return checkMateStatus;
    }
    private static bool inGame(int Column, int Row)
    {
        if (Column >= 0 && Row >= 0 && Column <= 7 && Row <= 7)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static void assignMoves(int IDconvert, ref int[,] stats, ref Piece[] Pieces, int dmg)
    {
        int[,] moves = Pieces[IDconvert].move();
        int[,] attackMap = Pieces[IDconvert].attack();
        int Column = IDconvert % 8;
        int Row = (IDconvert - Column) / 8;


        for (int i = 0; i < moves.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int currentRow = Row + (moves[i, 1] * j);
                int currentColumn = Column + (moves[i, 0] * j);
                int currentIndex = (currentRow * 8) + currentColumn;
                if (inGame(currentColumn, currentRow))
                {
                    if (Pieces[currentIndex].getTeam() == "FF" && dmg == 0)
                    {
                        stats[currentIndex, 0] = 1;
                    }
                    else
                    {
                        j = 8;
                    }
                }
                else
                {
                    j = 8;
                }
                if (Pieces[IDconvert].specified())
                    j = 8;
            }
        }

        for (int i = 0; i < attackMap.GetLength(0); i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int currentRow = Row + (attackMap[i, 1] * j);
                int currentColumn = Column + (attackMap[i, 0] * j);
                int currentIndex = (currentRow * 8) + currentColumn;
                if (inGame(currentColumn, currentRow))
                {
                    if (Pieces[currentIndex].getTeam() != "FF")
                    {
                        if (dmg == 0 && Pieces[currentIndex].getTeam() != Pieces[IDconvert].getTeam() && Pieces[currentIndex].getPieceType() != "King")
                            stats[currentIndex, 0] = 1;
                        if (Pieces[IDconvert].getTeam() == "White")
                        {
                            stats[currentIndex, 1] += dmg;
                        }
                        else
                        {
                            stats[currentIndex, 2] += dmg;
                        }
                        break;
                    }
                }
                else
                    break;
                if (Pieces[IDconvert].specified())
                    break;
            }
        }
    }
}


/*
 * Do zrobienia:
 * zaprojektowanie tur
 * 
 */