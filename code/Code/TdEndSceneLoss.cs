using Godot;
using System;

public partial class TdEndSceneLoss : Node2D
{
	private RichTextLabel scores;
	private AudioStreamPlayer2D audio;
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		scores = GetNode<RichTextLabel>("RichTextLabel");
		scores.Text = "\n Nice Try! \n \n You made it to round: " + GameManager.TDround +  "\n \n You scored: " + GameManager.TDpoints;
	}
	private void ButtonPress2()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
	private void Fin2()
	{
		audio.Play();
	}
}
