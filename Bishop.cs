using System;

public class Bishop : Piece
{
	public Bishop(string team) : base(team)
	{
		setTeam(team);
        setPieceType("Bishop");
    }

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
