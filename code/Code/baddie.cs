using Godot;
using System;

public partial class baddie : Sprite2D
{
	private Godot.Timer timer;
	private Script blibberScript;
	private int numPerRound = 23;
	private int counta = 0;
	public override void _Ready()
	{
		AddToGroup("Baddies");
		blibberScript = (Script)ResourceLoader.Load("res://blibber.cs");
		timer = GetNode<Godot.Timer>("../Timer2");
		timer.Start(1f);
	}
	public override void _Process(double delta)
	{
		
		if(GameManager.TDround == 1)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 2)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 3)
		{
			numPerRound = 10;
		}else if(GameManager.TDround == 4)
		{
			numPerRound = 15;
		}else if(GameManager.TDround == 5)
		{
			numPerRound = 20;
		}else if(GameManager.TDround == 6)
		{
			numPerRound = 25;
		}else if(GameManager.TDround == 7)
		{
			numPerRound = 25;
		}else if(GameManager.TDround == 8)
		{
			numPerRound = 25;
		}else if(GameManager.TDround == 9)
		{
			numPerRound = 25;
		}else if(GameManager.TDround == 10)
		{
			numPerRound = 30;
		}else if(GameManager.TDround == 11)
		{
			numPerRound = 40;
		}else if(GameManager.TDround == 12)
		{
			numPerRound = 50;
		}else if(GameManager.TDround == 13)
		{
			numPerRound = 50;
		}else if(GameManager.TDround == 14)
		{
			numPerRound = 50;
		}else if(GameManager.TDround == 15)
		{
			numPerRound = 50;
		}else if(GameManager.TDround == 16)
		{
			numPerRound = 75;
		}else if(GameManager.TDround == 17)
		{
			numPerRound = 105;
		}else if(GameManager.TDround == 18)
		{
			numPerRound = 105;
		}else if(GameManager.TDround == 19)
		{
			numPerRound = 150;
		}else if(GameManager.TDround == 20)
		{
			numPerRound = 203;
		}else if(GameManager.TDround == 25)
		{
			numPerRound = 300;
		}else if(GameManager.TDround == 30)
		{
			numPerRound = 400;
		}else if(GameManager.TDround == 40)
		{
			numPerRound = 500;
		}else if(GameManager.TDround == 48)
		{
			numPerRound = 900;
		}else if(GameManager.TDround == 49)
		{
			numPerRound = 920;
		}else if(GameManager.TDround == 50)
		{
			numPerRound = 1000;
		}
		if(counta >= numPerRound)
		{
				GameManager.TDround++;
				GameManager.TDlives += Zen.numbe;
				counta = 0;
				timer.Start(2f);
		}
	}
	private void TimeOut()
	{
		Sprite2D clone = (Sprite2D)Duplicate();
		GetParent().AddChild(clone);
		clone.SetScript(blibberScript);
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
