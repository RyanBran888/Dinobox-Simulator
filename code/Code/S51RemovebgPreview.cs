using Godot;
using System;

public partial class S51RemovebgPreview : CharacterBody2D
{
	private bool left = true;
	private const int Speed = 13000;
	private Vector2 velocity = new Vector2();
	public delegate void CharacterCollided();
	public override void _Ready()
	{
		
	}
	private void OnBodyEntered1(Node body)
	{
		
		if(body is CharacterBody2D)
		{
			
		}
		if(body is AnimatableBody2D)
		{
			if(left == true)
			{
				left = false;
			}else
			{
				left = true;
			}
		}
	}
	private void OnBodyEntered2(Node body)
	{
		if(body is CharacterBody2D)
		{
		}
		if(body is AnimatableBody2D)
		{
			if(left == true)
			{
				left = false;
			}else
			{
				left = true;
			}
		}
	}
	private void OnBodyEntered3(Node body)
	{
		if(body is CharacterBody2D)
		{
		}
		if(body is AnimatableBody2D)
		{
			if(left == true)
			{
				left = false;
			}else
			{
				left = true;
			}
		}
	}
	private void OnBodyEntered4(Node body)
	{
		if(body is CharacterBody2D)
		{
		}
		if(body is AnimatableBody2D)
		{
			if(left == true)
			{
				left = false;
			}else
			{
				left = true;
			}
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		velocity.X = 0;
		if(left == true)
		{
			velocity.X -= Speed * (float)delta;
		}
		if(left == false)
		{
			velocity.X += Speed * (float)delta;
		}
		Velocity = velocity;
		MoveAndSlide();
}
}
