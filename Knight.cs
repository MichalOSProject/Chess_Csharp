﻿using System;

public class Knight : Piece
{
	public Knight(string team) : base(team)
	{
		this.setTeam(team);
	}

	public new void move() { }

    public new void attack() { }

	public new void jump() { }

}