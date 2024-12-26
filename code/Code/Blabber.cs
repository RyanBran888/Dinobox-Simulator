using Godot;
using System;

public partial class Blabber : Sprite2D
{
	private int speed = 2;
	public override void _Ready()
	{
		this.AddToGroup("Baddies");
	}
	public override void _Process(double delta)
	{
		if(IsInGroup("Baddies"))
		{
//			GD.Print("NATALIE NAAAAAAAAN");
		}
		//GD.Print("ahahahaha");
		if(Position.X < 325 && Position.Y < 405)
		{
		Position = new Vector2(Position.X + speed, Position.Y);
		}else if(Position.Y < 425 && Position.X < 750)
		{
			Position = new Vector2(Position.X, Position.Y + speed);
		}else if(Position.X < 770)
		{
			Position = new Vector2(Position.X + speed, Position.Y);
		}else if(Position.Y > 115)
		{
			Position = new Vector2(Position.X , Position.Y - speed);
		}else if(Position.X < 965)
		{
			Position = new Vector2(Position.X + speed, Position.Y);
		}else
		{
			GameManager.TDlives -= 1;
			QueueFree();
			
		}
	}

}
