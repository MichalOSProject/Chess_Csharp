using System;

public class Knight : Piece
{
    public Knight(string team) : base(team)
    {
        setTeam(team);
        setPieceType("Knight");
    }

    public new int[] move(int IDconvert)
    {
        int[,] moves = { { -2, -1 }, { -2, 1 }, { 1, 2 }, { 1, -2 }, { -1, -2 }, { -1, 2 }, { -2, -1 }, { -2, 1 } };
        int[] possibleMoves = new int[8];
        int Count = 0;
        int Column = IDconvert % 8;
        int Row = (IDconvert - Column) / 8;
        for (int i = 0; i <= moves.GetLength(0); i++)
        {
            if (Row + moves[i, 0] <= 7 && Row + moves[i, 0] >= 0 && Column + moves[i, 1] <= 7 && Column + moves[i, 1] >= 0)
            {
                possibleMoves[Count] = ((Column + moves[i, 1]) * 8) + (Row + moves[i, 0]);
                Count++;
            }

        }
        return possibleMoves;
    }

    public new void attack()
    {

    }

    public new Boolean jump()
    {
        return true;
    }
}
