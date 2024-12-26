using Godot;
using System;

public partial class roar : CharacterBody2D
{
	private Vector2 velocity = new Vector2();
	private const int Speed = 400;
	private float vel;
	private float velx;
	private AudioStreamPlayer audio;
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
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
	
	public void OnEnte(Node body)
	{
		GetTree().ChangeSceneToFile("res://TowerDef.tscn");
	}
	private void fin()
	{
		audio.Play();
	}
}
