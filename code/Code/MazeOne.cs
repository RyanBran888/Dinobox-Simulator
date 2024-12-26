using Godot;
using System;

public partial class MazeOne : Node2D
{
	private AudioStreamPlayer AudioPlayer;
	//walls AHHHH
	private Node2D MazeWall1;
	private Node2D MazeWall2;
	private Node2D MazeWall3;
	private Node2D MazeWall4;
	private Node2D MazeWall5;
	private Node2D MazeWall6;
	private Node2D MazeWall7;
	private Node2D MazeWall8;
	private Node2D MazeWall9;
	private Node2D MazeWall10;
	private Node2D MazeWall11;
	private Node2D MazeWall12;
	private Node2D MazeWall13;
	private Node2D MazeWall14;
	private Node2D MazeWall15;
	private Node2D MazeWall16;
	private Node2D MazeWall17;
	private Node2D MazeWall18;
	private Node2D MazeWall19;
	private Node2D MazeWall20;
	// player
	private Node2D Dinobox;
	// end of maze
	private Node2D Box;
	public override void _Ready()
	{
		AudioPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		// Walls for the maze :3
		MazeWall1 = GetNode<Node2D>("MazeWall");
		MazeWall2 = GetNode<Node2D>("MazeWall2");
		MazeWall3 = GetNode<Node2D>("MazeWall3");
		MazeWall4 = GetNode<Node2D>("MazeWall4");
		MazeWall5 = GetNode<Node2D>("MazeWall5");
		MazeWall6 = GetNode<Node2D>("MazeWall6");
		MazeWall7 = GetNode<Node2D>("MazeWall7");
		MazeWall8 = GetNode<Node2D>("MazeWall8");
		MazeWall9 = GetNode<Node2D>("MazeWall9");
		MazeWall10 = GetNode<Node2D>("MazeWall10");
		MazeWall11 = GetNode<Node2D>("MazeWall11");
		MazeWall12 = GetNode<Node2D>("MazeWall12");
		MazeWall13 = GetNode<Node2D>("MazeWall13");
		MazeWall14 = GetNode<Node2D>("MazeWall14");
		MazeWall15 = GetNode<Node2D>("MazeWall15");
		MazeWall16 = GetNode<Node2D>("MazeWall16");
		MazeWall17 = GetNode<Node2D>("MazeWall17");
		MazeWall18 = GetNode<Node2D>("MazeWall18");
		MazeWall19 = GetNode<Node2D>("MazeWall19");
		MazeWall20 = GetNode<Node2D>("MazeWall20");
		//other stuff
		Dinobox = GetNode<Node2D>("Image480");
		Box = GetNode<Node2D>("img5515720");
	}
	public void OnFinished()
	{
		AudioPlayer.Play();
	}
	public override void _Process(double _delta)
	{
		
	}
}
