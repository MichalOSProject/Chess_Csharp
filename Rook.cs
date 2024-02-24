using System;

public class Rook : Piece
{
	public Rook(string team) : base(team)
	{
		this.setTeam(team);
	}

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
