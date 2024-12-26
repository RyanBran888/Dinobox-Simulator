using Godot;
using System;

public partial class Box : Sprite2D
{
	private Button button;
	private AudioStreamPlayer audio;
	public void OnEnter(Node body)
	{
		button.Visible = true;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		button = GetNode<Button>("../Dino/Camera2D/Button");
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnButtonDown()
	{
		GetTree().ChangeSceneToFile("res://EndPlatform.tscn");
	}
	private void finish()
	{
		audio.Play();
	}
}
