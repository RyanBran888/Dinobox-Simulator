using Godot;
using System;
public partial class Node2d : Node2D
{
	private AudioStreamPlayer playAudio;
	private RichTextLabel label;
	public int betterPoints;
	public override void _Ready()
	{
		
			playAudio = GetNode<AudioStreamPlayer>("AudioStreamPlayer");	
			}
	//	postGameStart = GetNode<postGameStart>("res://postGameStart.tscn");

		//label.Text = "You Scored: " + postGameStart.points;
	public void OnFinished(){
		playAudio.Play();
	}
	public void OnButtonPressed(){
		GetTree().ChangeSceneToFile("res://Main.tscn");
	}
}
