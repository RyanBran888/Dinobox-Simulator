using Godot;
using System;

public partial class Credits : Node2D
{
	private RichTextLabel scores;
	private AudioStreamPlayer2D audio;
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		scores = GetNode<RichTextLabel>("RichTextLabel");
	}
	private void ButtonPressed2()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
	private void Fin2()
	{
		audio.Play();
	}
}
