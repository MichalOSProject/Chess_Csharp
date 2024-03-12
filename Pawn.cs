using System;
using System.Collections;
using System.Windows.Input;

public class Pawn : Piece
{
    int[,] movesB = { { 0, 1 } };
    int[,] movesW = { { 0, -1 } };
    int[,] movesFB = { { 0, 1 }, { 0, 2 } };
    int[,] movesFW = { { 0, -1 }, { 0, -2 } };

    int[,] attackMapB = { { 1, 1 }, { -1, 1 } };
    int[,] attackMapW = { { 1, -1 }, { -1, -1 } };
    public Pawn(string team) : base(team, "Pawn")
    {
    }

    public override int[,] move()
    {
        if (getTeam() == "White")
        {
            if (!moved)
            {
                return movesFW;
            }
            else
            {
                return movesW;
            }
        }
        else
        {
            if (!moved)
            {
                return movesFB;
            }
            else
            {
                return movesB;
            }
        }

    }

    public override int[,] attack()
    {
        if (getTeam() == "White")
        {
            return attackMapW;
        }
        else
        {
            return attackMapB;
        }
    }

    public override Boolean specified()
    {
        return true;
    }
}
