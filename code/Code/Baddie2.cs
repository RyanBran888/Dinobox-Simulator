using Godot;
using System;

public partial class Baddie2 : Sprite2D
{
	private Godot.Timer timer;
	private Script blabberScript;
	private int numPerRound = -1;
	private int counta = 0;
	public override void _Ready()
	{
		AddToGroup("Baddies");
		blabberScript = (Script)ResourceLoader.Load("res://Blabber.cs");
		timer = GetNode<Godot.Timer>("../Timer4");
		timer.Start(1f);
	}
	public override void _Process(double delta)
	{
		if(GameManager.TDround == 1)
		{
		//	GD.Print("HELLPP");
			numPerRound = -1;
		}else if(GameManager.TDround == 2)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 3)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 4)
		{
			numPerRound = 3;
		}else if(GameManager.TDround == 5)
		{
			numPerRound = 8;
		}else if(GameManager.TDround == 6)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 7)
		{
			numPerRound = 12;
		}else if(GameManager.TDround == 8)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 9)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 10)
		{
			numPerRound = 20;
		}else if(GameManager.TDround == 11)
		{
			numPerRound = 20;
		}else if(GameManager.TDround == 12)
		{
			numPerRound = 25;
		}else if(GameManager.TDround == 13)
		{
			numPerRound = 30;
		}else if(GameManager.TDround == 14)
		{
			numPerRound = 35;
		}else if(GameManager.TDround == 15)
		{
			numPerRound = 40;
		}else if(GameManager.TDround == 16)
		{
			numPerRound = 50;
		}else if(GameManager.TDround == 17)
		{
			numPerRound = 60;
		}else if(GameManager.TDround == 18)
		{
			numPerRound = 70;
		}else if(GameManager.TDround == 19)
		{
			numPerRound = 100;
		}else if(GameManager.TDround == 20)
		{
			numPerRound = 170;
		}else if(GameManager.TDround == 25)
		{
			numPerRound = 180;
		}else if(GameManager.TDround == 30)
		{
			numPerRound = 200;
		}else if(GameManager.TDround == 40)
		{
			numPerRound = 250;
		}else if(GameManager.TDround == 48)
		{
			numPerRound = 300;
		}else if(GameManager.TDround == 49)
		{
			numPerRound = 350;
		}else if(GameManager.TDround == 50)
		{
			numPerRound = 400;
		}
		if(counta >= numPerRound)
		{
				//GameManager.TDround++;
				counta = 0;
				timer.Start(2f);
		}
	}
	private void TimeOut()
	{
		Sprite2D clone = (Sprite2D)Duplicate();
		GetParent().AddChild(clone);
		clone.SetScript(blabberScript);
		if(counta <= numPerRound)
		{
			GD.Print(counta);
			counta++;
			timer.Start(0.5f);
		}else
		{
			timer.Stop();
		}
		
		
		
	}
	
}
