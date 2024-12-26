using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	private Vector2 velocity = new Vector2();
	private const int Speed = 20000;
	private const int Gravity = 600;
	private const int JumpForce = 500;
	private bool isJumping = false;
	private float vel;
	private float velx;
	private bool started = false;
	public override void _Ready()
	{
	}
	public void OnBodyEntered12(Node body)
	{
		if(body is CharacterBody2D)
		{
		Position = new Vector2(631, 145);
		}
	}
	public void OnBodyEntered13(Node body)
	{
		if(body is CharacterBody2D)
		{
		Position = new Vector2(631, 145);
		}
	}
	public void OnBodyEntered14(Node body)
	{
		if(body is CharacterBody2D)
		{
		Position = new Vector2(631, 145);
		}
	}
	public void OnBodyEntered11(Node body)
	{
		if(body is CharacterBody2D)
		{
		Position = new Vector2(631, 145);
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		velocity.X = 0;
		if(Input.IsKeyPressed(Key.A))
		{
			velocity.X -= Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.D))
		{
			velocity.X += Speed * (float)delta;
		}
			velocity.Y += Gravity * (float)delta;
		if((Input.IsKeyPressed(Key.Space) && IsOnFloor()) || (Input.IsKeyPressed(Key.W) && IsOnFloor()))
		{
			velocity.Y -= JumpForce;
			isJumping = true;
			started = true;
		}
		Velocity = velocity;
		MoveAndSlide();
		if(IsOnFloor())
		{
			isJumping = false;
			velocity.Y = 0;
		}
}
}
