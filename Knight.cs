using System;

public class Knight : Piece
{
	public Knight(string team) : base(team)
	{
		setTeam(team);
        setPieceType("Knight");
    }

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
