using Godot;
using System;

public partial class EndPlatform : Node2D
{
	private AudioStreamPlayer audio;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
	}
	public void OnPressed()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void e()
	{
		audio.Play();
	}
}
