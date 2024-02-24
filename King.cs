using System;

public class King : Piece
{
	public King(string team) : base(team)
	{
		this.setTeam(team);
	}

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
