using Godot;
using System;

public partial class endloss : Node2D
{
	private RichTextLabel scores;
	private AudioStreamPlayer2D audio;
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		scores = GetNode<RichTextLabel>("RichTextLabel");
		scores.Text = "\n You did it!  Congrats on winning Tower Defence! \n \n You made it to round: 50 " + "\n \n You scored: " + GameManager.TDpoints;
	}
	private void ButtonPress()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
	private void Fin()
	{
		audio.Play();
	}
}
