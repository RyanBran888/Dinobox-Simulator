using Godot;
using System;

public partial class Img5515720 : Sprite2D
{
	private void OnBodyEntered(Node body)
	{
		if(body is CharacterBody2D)
		{
			GetTree().ChangeSceneToFile("res://postGameStart.tscn");
		}
	}
} 
