using Godot;
using System;

public partial class UntitledDesign31RemovebgPreview2 : Sprite2D
{
		private Godot.Timer timer;
	private Script blabberScript;
	private int numPerRound = -1;
	private int counta = 0;
	public override void _Ready()
	{
		AddToGroup("Baddies");
		blabberScript = (Script)ResourceLoader.Load("res://blibber.cs");
		timer = GetNode<Godot.Timer>("../Timer5");
		timer.Start(1f);
	}
	public override void _Process(double delta)
	{
		if(GameManager.TDround == 1)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 2)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 3)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 4)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 5)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 6)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 7)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 8)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 9)
		{
			numPerRound = -1;
		}else if(GameManager.TDround == 10)
		{
			numPerRound = 3;
		}else if(GameManager.TDround == 11)
		{
			numPerRound = 5;
		}else if(GameManager.TDround == 12)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 13)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 14)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 15)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 16)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 17)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 18)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 19)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 20)
		{
			numPerRound = 23;
		}else if(GameManager.TDround == 25)
		{
			numPerRound = 30;
		}else if(GameManager.TDround == 30)
		{
			numPerRound = 40;
		}else if(GameManager.TDround == 40)
		{
			numPerRound = 50;
		}else if(GameManager.TDround == 48)
		{
			numPerRound = 90;
		}else if(GameManager.TDround == 49)
		{
			numPerRound = 92;
		}else if(GameManager.TDround == 50)
		{
			numPerRound = 100;
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
		if(clone != null)
		{
			GD.Print("erm");
		}
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
