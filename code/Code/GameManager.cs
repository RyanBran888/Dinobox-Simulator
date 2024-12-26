using Godot;
using System;

public partial class GameManager : Node2D
{
	public static int TDstamps { get; set; } = 600;
	public static int TDround { get; set; } = 1;
	public static int TDpoints { get; set; } = 0;
	public static int TDlives { get; set; } = 100;
	public RichTextLabel stampLabel;
	public RichTextLabel roundLabel;
	public RichTextLabel livesLabel;
	public RichTextLabel pointsLabel;
	private Panel panel;
	private AudioStreamPlayer2D audio;
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		panel = GetNode<Panel>("Panel");
		panel.Visible = false;
		stampLabel = GetNode<RichTextLabel>("RichTextLabel");
		roundLabel = GetNode<RichTextLabel>("RichTextLabel2");
		livesLabel = GetNode<RichTextLabel>("RichTextLabel3");
		pointsLabel = GetNode<RichTextLabel>("RichTextLabel4");
	}
	public override void _Process(double delta)
	{
		stampLabel.Text = ("Stamps: " + TDstamps);
		roundLabel.Text = ("Round: " + TDround);
		livesLabel.Text = ("Lives: " + TDlives);
		pointsLabel.Text = ("Points: " + TDpoints);
		if(TDlives <= 0)
		{
			GetTree().ChangeSceneToFile("res://td_end_scene_loss.tscn");
		}
		if(TDround == 51)
		{
			GetTree().ChangeSceneToFile("res://tdendscenewin.tcsn");
		}
	}
	private void PressOpen()
	{
		panel.Visible = true;
	}
	private void PressClose()
	{
		panel.Visible = false;
	}
	private void Fin()
	{
		audio.Play();
	}
}
