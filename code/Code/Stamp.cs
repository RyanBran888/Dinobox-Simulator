using Godot;
using System;

public partial class Stamp : Sprite2D
{
	private static int stamps = 0;
	private RichTextLabel stampCollected;
	public override void _Ready()
	{
		stampCollected = GetNode<RichTextLabel>("../Dino/Camera2D/RichTextLabel");

	}
	public void OnStamp(Node body)
	{
		if(Visible == true)
		{
			stamps++;
			stampCollected.Text = ("\nStamps Collected: " + stamps);
			Visible = false;

		}
	}
}
