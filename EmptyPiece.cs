using System;

public class EmptyPiece : Piece
{
	public EmptyPiece(string team = "0") : base(team)
	{
		setTeam(team);
        setPieceType("");
    }

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}
