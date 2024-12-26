using Godot;
using System;

public partial class Img5523 : Sprite2D
{
	private AudioStreamPlayer audio;
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
	}
	private void OnBodyEntered(Node body)
	{
		if(body is CharacterBody2D)
		{
			GetTree().ChangeSceneToFile("res://platformer.tscn");
		}
	}
	public void Finished()
	{
		audio.Play();
	}
} 
