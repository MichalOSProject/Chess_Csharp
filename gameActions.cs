using System;

public static class gameActions
{
    static Piece lastPiece;
    static int lastId = 0;
    public static void action(ref Piece[] Pieces, ref int stage, ref int[,,] stats, int IDconvert)
    {
        if (stage == 0)
        {
            lastPiece = Pieces[IDconvert];
            lastId = IDconvert;
            assignMoves(IDconvert, ref stats, ref Pieces, 0);

            stage = 1;
        }
        else
        {
            if (IDconvert != lastId)
            {
                lastPiece.setMoved(true);
                Pieces[lastId] = new EmptyPiece();
                Pieces[IDconvert] = lastPiece;
            }
            stage = 0;

        }

    }
    public static void assignMoves(int IDconvert, ref int[,,] stats, ref Piece[] Pieces, int dmg)
    {
        int[,] moves = Pieces[IDconvert].move();
        int[,] attackMap = Pieces[IDconvert].attack();
        int Column = IDconvert % 8;
        int Row = (IDconvert - Column) / 8;
        Boolean breakLoop;
        int sensitive = 1;
        String pieceTeam = Pieces[IDconvert].getTeam();
        if (pieceTeam == "Black")
            sensitive = 2;


        for (int i = 0; i < moves.GetLength(0); i++)
        {
            for (int j = 0; j < Pieces[IDconvert].jumpMove();)
            {
                j++;
                int currentRow = Row + (moves[i, 1] * j);
                int currentColumn = Column + (moves[i, 0] * j);
                int currentIndex = (currentRow * 8) + currentColumn;
                if (inGame(currentColumn, currentRow))
                {
                    if (Pieces[currentIndex].getTeam() == "FF" && dmg == 0)
                    {
                        stats[currentIndex, 0, 0] = 1;
                    }
                    else
                    {
                        j = Pieces[IDconvert].jumpMove();
                    }
                }
                else
                {
                    j = Pieces[IDconvert].jumpMove();
                }
            }
        }

        for (int i = 0; i < attackMap.GetLength(0); i++)
        {
            breakLoop = false;
            for (int j = 0; j < Pieces[IDconvert].jumpAttack();)
            {
                j++;
                if (breakLoop)
                    break;
                int currentRow = Row + (attackMap[i, 1] * j);
                int currentColumn = Column + (attackMap[i, 0] * j);
                int currentIndex = (currentRow * 8) + currentColumn;
                if (inGame(currentColumn, currentRow))
                {
                    if (dmg == 0 && Pieces[currentIndex].getPieceType() != "King")
                    {
                        if (Pieces[currentIndex].getTeam() != pieceTeam && Pieces[currentIndex].getTeam() != "FF")
                            stats[currentIndex, 0, 0] = 1;
                    }

                    if (Pieces[currentIndex].getTeam() != "FF")
                        breakLoop = true;
                    if (Pieces[currentIndex].getTeam() != pieceTeam)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            if (stats[currentIndex, sensitive, x] == 100)
                            {
                                stats[currentIndex, sensitive, x] = IDconvert;
                                break;
                            }
                        }
                    }
                }
                else
                    break;
            }
        }
    }
    public static int checkMate(Piece[] Pieces, int[,,] stats, int ID)
    {
        int checkMateStatus = 0;
        int[,] attackMap = Pieces[ID].attack();
        int Column = ID % 8;
        int Row = (ID - Column) / 8;
        string kingsTeam = Pieces[ID].getTeam();
        int sensitive = 1; // 1-> sensitive for Black dmg 2->sensitive for White dmg
        int enemySensitive = 2;
        int killableSensitive = 0;

        if (kingsTeam == "White")
        {
            sensitive = 2;
            enemySensitive = 1;
        }
        if (stats[ID, sensitive, 0] != 100)
        {
            checkMateStatus = 1;
            for (int i = 0; i < 10; i++)
            {
                int attacker = stats[ID, sensitive, i];
                if (attacker == 100)
                    break;
                if (stats[attacker, enemySensitive, 0] == 100)
                    checkMateStatus = 2;
                else
                    killableSensitive++;
            }
            if (killableSensitive >= 2)
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
                    if (Pieces[currentIndex].getTeam() != kingsTeam && stats[currentIndex, sensitive, 0] == 100)
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

}