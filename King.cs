using System;

public class King : Piece
{
	public King(string team) : base(team)
	{
		setTeam(team);
        setPieceType("King");
    }

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
