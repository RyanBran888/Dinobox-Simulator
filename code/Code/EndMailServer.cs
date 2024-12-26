using Godot;
using System;

public partial class EndMailServer : Node2D
{
	private AudioStreamPlayer audio;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnDown()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
	private void r()
	{
		audio.Play();
	}
}
