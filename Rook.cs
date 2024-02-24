using System;

public class Rook : Piece
{
	public Rook(string team) : base(team)
	{
		setTeam(team);
		setPieceType("Rook");
	}

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
