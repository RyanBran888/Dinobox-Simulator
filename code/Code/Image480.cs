using Godot;
using System;

public partial class Image480 : CharacterBody2D
{
	private Vector2 velocity = new Vector2();
	private const int Speed = 200;
	private float vel;
	private float velx;
	public override void _Ready()
	{
		
	}
	public override void _PhysicsProcess(double delta)
	{
		velocity = Vector2.Zero;
		if(Input.IsKeyPressed(Key.W))
		{
			velocity.Y -= Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.S))
		{
			velocity.Y += Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.A))
		{
			velocity.X -= Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.D))
		{
			velocity.X += Speed * (float)delta;
		}
		velocity = velocity.Normalized() * Speed;
		Velocity = velocity;
		MoveAndSlide();
}
}
