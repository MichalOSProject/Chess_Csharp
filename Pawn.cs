using System;

public class Pawn : Piece
{
	public Pawn(string team) : base(team)
	{
		setTeam(team);
        setPieceType("Pawn");
    }

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
