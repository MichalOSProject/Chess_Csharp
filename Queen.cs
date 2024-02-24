using System;

public class Queen : Piece
{
	public Queen(string team) : base(team)
	{
		this.setTeam(team);
	}

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
