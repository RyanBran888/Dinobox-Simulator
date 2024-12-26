using Godot;
using System;

public partial class Main : Node2D
{
	private AudioStreamPlayer playAudio;
	
	public override void _Ready()
	{
		playAudio = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}
	public void OnFinished(){
		playAudio.Play();
	}
	public void OnPressed()
	{
		GetTree().ChangeSceneToFile("res://maze_one.tscn");
	}
	public void OnPressed1()
	{
		GetTree().ChangeSceneToFile("res://maze_two.tscn");
	}
	public void OnButton3()
	{
		GetTree().ChangeSceneToFile("res://maze_three.tscn");
	//	GetTree().ChangeSceneToFile("res://TowerDef.tscn");
	}
	public void Button4()
	{
		GetTree().ChangeSceneToFile("res://maze_four.tscn");
	}
	public void Button5()
	{
		GetTree().ChangeSceneToFile("res://credits.tscn");
	}
}
