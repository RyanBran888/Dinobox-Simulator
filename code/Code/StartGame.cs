using Godot;
using System;

public partial class StartGame : Button
{
	private AudioStreamPlayer playAudio;
	
	public override void _Ready()
	{
		playAudio = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}
	public void OnFinished(){
		playAudio.Play();
	}
	public void _on_pressed()
	{
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
}
