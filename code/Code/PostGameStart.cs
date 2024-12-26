using Godot;
using System;
public partial class PostGameStart : Node2D
{
	//POINTS YIPPEEEEEEEEE
	private AudioStreamPlayer soundPlayer;
	private AudioStreamPlayer soundPlayer2;
	private bool running = false;
	private double elapsedTime = 0;
	public int points = 0;
	private int targetTime = 1000;
	private float time1 = 0f;
	private float time2 = 0f;
	private float timeUndelay = 0f;
	private RichTextLabel pointLabel;
	// Timer boolean
	private bool timing = false;
	private Godot.Timer timer;
	private Godot.Timer timer2;
	private Godot.Timer timer3;
	private Godot.Timer timer4;
	// Name the box sprites
	private Node2D boxOne;
	private Node2D boxTwo;
	private Node2D boxThree;
	private Node2D boxFour;
	private Node2D boxFive;
	private Node2D boxSix;
	private Node2D boxSeven;
	private Node2D boxEight;
	private Node2D boxNine;
	// other stuff
	private Node2D SKey;
	private Node2D WKey;
	private Node2D AKey;
	private Node2D DKey;
	private Button button;
	// create counter thingies
	public float round = 0;
	public int y = 0;
	public int x = 0;
	public int e = 0;
	public int z = 0;
	
	public override void _Ready()
	{
		//Get the timer thgingy
		timer = GetNode<Godot.Timer>("Timer");
		timer2 = GetNode<Godot.Timer>("Timer2");
		timer3 = GetNode<Godot.Timer>("Timer3");
		timer4 = GetNode<Godot.Timer>("Timer4");
		// other stuffers
		button = GetNode<Button>("Button");
		SKey = GetNode<Node2D>("S");
		AKey = GetNode<Node2D>("S(3)");
		WKey = GetNode<Node2D>("S(1)");
		DKey = GetNode<Node2D>("S(2)");
		pointLabel = GetNode<RichTextLabel>("RichTextLabel2");
		soundPlayer = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		soundPlayer2 = GetNode<AudioStreamPlayer>("AudioStreamPlayer2");
		// Get the box sprites
		boxOne = GetNode<Node2D>("cow");
		boxTwo = GetNode<Node2D>("Img5516720");
		boxThree = GetNode<Node2D>("Img5517720");
		boxFour = GetNode<Node2D>("Img5518720");
		boxFive = GetNode<Node2D>("Img5519720");
		boxSix = GetNode<Node2D>("Img5520720");
		boxSeven = GetNode<Node2D>("Img5521720");
		boxEight = GetNode<Node2D>("Img5522720");
		boxNine = GetNode<Node2D>("Img5523");
		if(y == 0)
		{
			Timer();
			y += 1;
		}
	}
	public void OnFinished()
	{
		soundPlayer2.Play();
	}
	public override void _Process(double delta)
	{
		if(running)
		{
			elapsedTime += delta * 1000;
		}
	}
	//add and remove the sprites on the inputs
	public override void _Input(InputEvent @event)
	{
		if(round <= 5)
{
		if(@event is InputEventKey keyEvent && keyEvent.Pressed)
		{
			if(keyEvent.Keycode == Key.W && x == 0)
			{
				if(timing == true)
				{
				if(x == 0){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxOne.Visible = false;
					boxTwo.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxOne.Visible = false;
					boxTwo.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
			}else if(keyEvent.Keycode == Key.S && x == 1)
			{
				if(timing == true)
				{
				if(x == 1){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxTwo.Visible = false;
					boxThree.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxTwo.Visible = false;
					boxThree.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
			}else if(keyEvent.Keycode == Key.A && x == 2)
			{
				if(timing == true)
				{
				if(x == 2){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxThree.Visible = false;
					boxFour.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxThree.Visible = false;
					boxFour.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
		}else if(keyEvent.Keycode == Key.D && x == 3)
			{
				if(timing == true)
				{
				if(x == 3){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxFour.Visible = false;
					boxFive.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxFour.Visible = false;
					boxFive.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
		
	}else if(keyEvent.Keycode == Key.W && x == 4)
			{
				if(timing == true)
				{
				if(x == 4){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxFive.Visible = false;
					boxSix.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxFive.Visible = false;
					boxSix.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
}else if(keyEvent.Keycode == Key.S && x == 5)
			{
				if(timing == true)
				{
				if(x == 5){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxSix.Visible = false;
					boxSeven.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxSix.Visible = false;
					boxSeven.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
	}else if(keyEvent.Keycode == Key.A && x == 6)
			{
				if(timing == true)
				{
				if(x == 6){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxSeven.Visible = false;
					boxEight.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxSeven.Visible = false;
					boxEight.Visible = true;
					timing = false;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					x += 1;
					Timer();
				}
	}else if(keyEvent.Keycode == Key.D && x == 7)
			{
				if(timing == true)
				{
				if(x == 7){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					boxEight.Visible = false;
					boxNine.Visible = true;
					timing = false;
					x += 1;
					elapsedTime = 0;
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					boxEight.Visible = false;
					boxNine.Visible = true;
					timing = false;
					elapsedTime = 0;
					x += 1;
					updateScore();
					resetSpot();
					Timer();
				}
	}else if(keyEvent.Keycode == Key.S && x == 8)
			{
				if(timing == true)
				{
				if(x == 8){
					timer3.Stop();
					running = false;
					GD.Print(elapsedTime);
					var timeDifference = 1000 - (round * 100) - elapsedTime;
					if(timeDifference <= 100 && timeDifference >= -100)
					{
						points += 100;
						GD.Print(points);
					}else{
						points += 50;
						GD.Print(points);
					}
					timing = false;
					x = 0;
					elapsedTime = 0;
					if(round == 3 && z == 0){
						e = 2;
						z += 1;
					}else if(round == 4 && z == 0)
					{
						e = 3;
						z += 1;
					}else if(round == 5 && z == 0)
					{
						e = 3;
						z += 1;
					}
					if(e == 0)
					{
					round += 1;
					z = 0;
					}
					if(e != 0){
					e -= 1;
					}
					if(round != 6)
					{
					boxNine.Visible = false;
					boxOne.Visible = true;
					}else{
						boxNine.Visible = true;
						boxEight.Visible = false;
						boxThree.Visible = false;
						boxTwo.Visible = false;
					}
					updateScore();
					resetSpot();
					Timer();
				}
				}else{
					timer.Stop();
					timer2.Stop();
					timer3.Stop();
					running = false;
					timing = false;
					elapsedTime = 0;
					x = 0;
					if(round == 3 && z == 0){
						e = 2;
						z += 1;
					}else if(round == 4 && z == 0)
					{
						e = 3;
						z += 1;
					}else if(round == 5 && z == 0)
					{
						e = 3;
						z += 1;
					}
					if(e == 0)
					{
					round += 1;
					z = 0;
					}
					if(e != 0){
					e -= 1;
					}
					if(round != 6)
					{
					boxNine.Visible = false;
					boxOne.Visible = true;
					}
					updateScore();
					Timer();
					resetSpot();
				}
	}
}
} else
{
	button.Visible = true;
}
}
	public void OnButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://EndRythm.tscn");
	}	
	public void Timer()
	{
		//GD.Print("wat");
		timer3.Start();
		running = true;
		time1 = 0.80f - (round * 0.15f);
		timer.Start(time1);
		if(x == 0)
		{
		MoveThingsW();
		}else if(x == 1)
		{
			MoveThingsS();
		}else if(x == 2)
		{
			MoveThingsA();
		}else if(x == 3)
		{
			MoveThingsD();
		}else if(x == 4)
		{
		MoveThingsW();
		}else if(x == 5)
		{
			MoveThingsS();
		}else if(x == 6)
		{
			MoveThingsA();
		}else if(x == 7)
		{
			MoveThingsD();
		}else if(x==8)
		{
			MoveThingsS();
		}
		
	}
	private void OnTimerTimeout()
	{
		if(timing == false)
		{
		timing = true;
		timer2.Start(0.40f);
		}
	}
	private void OnTimer2Timeout()
	{
		timing = false;
	}
	private void MoveThingsW()
	{
		//var tween = GetTree().CreateTween(); 
		var tween = CreateTween();
		  Vector2 targetPosition = new Vector2(78, 461);
		time2 = 1f - (round * 0.15f);
				timeUndelay = time2 - 0.1f;
				timer4.Start(timeUndelay);
		// Use the tween to animate the position of WKey
		tween.TweenProperty(WKey, "position", targetPosition, time2);
		tween.Play();
	}
		private void MoveThingsD()
	{
		//var tween = GetTree().CreateTween(); 
		var tween = CreateTween();
		  Vector2 targetPosition = new Vector2(378, 461);
		time2 = 1f - (round * 0.15f);
				timeUndelay = time2 - 0.1f;
				timer4.Start(timeUndelay);
		// Use the tween to animate the position of WKey
		tween.TweenProperty(DKey, "position", targetPosition, time2);
		tween.Play();
	}
		private void MoveThingsS()
	{
		//var tween = GetTree().CreateTween(); 
		var tween = CreateTween();
		  Vector2 targetPosition = new Vector2(278, 461);
		time2 = 1f - (round * 0.15f);
		timeUndelay = time2 - 0.1f;
		timer4.Start(timeUndelay);
		// Use the tween to animate the position of WKey
		tween.TweenProperty(SKey, "position", targetPosition, time2);
		tween.Play();
	}
		private void MoveThingsA()
	{
		time2 = 1f - (round * 0.15f);
		//var tween = GetTree().CreateTween(); 
				timeUndelay = time2 - 0.1f;
		timer4.Start(timeUndelay);
		var tween = CreateTween();
		  Vector2 targetPosition = new Vector2(178, 461);

		// Use the tween to animate the position of WKey
		tween.TweenProperty(AKey, "position", targetPosition, time2);
		tween.Play();
	}
	private void OnTimer4Timeout()
	{
		soundPlayer.Play();
	}
	private void updateScore()
	{
		pointLabel.Text = "Points: " + points + "\n Speed Level: " + round;
	}
	private void resetSpot()
	{
		WKey.Position = new Vector2(78, 100);
		SKey.Position = new Vector2(278, 100);
		AKey.Position = new Vector2(178, 100);
		DKey.Position = new Vector2(378, 100);
	}
}			
