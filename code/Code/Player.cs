using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private AudioStreamPlayer audio;
	public bool MakingOrder1 = false;
	public bool MakingOrder2 = false;
	public bool MakingOrder3 = false;
	public bool Check1 = false;
	public bool Check2 = false;
	public bool Check3 = false;
	private Vector2 velocity = new Vector2();
	private const int Speed = 400;
	private float vel;
	private float velx;
	private bool win1 = false;
	private bool win2 = false;
	private bool win3 = false;
	private int lives = 3;
	private Node2D heart;
	private Node2D heart2;
	private Node2D heart3;
	//order number gens
	private RandomNumberGenerator complexity;
	private RandomNumberGenerator type;
	private RandomNumberGenerator color;
	private RandomNumberGenerator sealNum;
	private Godot.Timer timer4;
	private Godot.Timer timer5;
	private Godot.Timer timer6;
	// variables for stuff
	public bool needRedSeal = false;
	public bool needRedSeal2 = false;
	public bool needRedSeal3 = false;
	public bool needBlueSeal = false;
	public bool needBlueSeal2 = false;
	public bool needBlueSeal3 = false;
	public bool needPinkSeal = false;
	public bool needPinkSeal2 = false;
	public bool needPinkSeal3 = false;
	public bool needBlackSeal = false;
	public bool needBlackSeal2 = false;
	public bool needBlackSeal3 = false;
	public bool finished = false;
	public bool handsFull = false;
	public bool letter = false;
	public bool pinkLetter = false;
	public bool blueLetter = false;
	public bool redLetter = false;
	public bool boxHeld = false;
	public bool seal = false;
	public bool postcard = false;
	public bool needLetter = false;
	public bool needLetter2 = false;
	public bool needLetter3 = false;
	public bool needPinkLetter = false;
	public bool needPinkLetter2 = false;
	public bool needPinkLetter3 = false;
	public bool needBlueLetter = false;
	public bool needBlueLetter2 = false;
	public bool needBlueLetter3 = false;
	public bool needRedLetter = false;
	public bool needRedLetter2 = false;
	public bool needRedLetter3 = false;
	public bool needPostcard = false;
	public bool needPostcard2 = false;
	public bool needPostcard3 = false;
	public bool needSeal = false;
	public bool needSeal2 = false;
	public bool needSeal3 = false;
	public bool needBox = false;
	public bool needBox2 = false;
	public bool needBox3 = false;
	public int comOne = 0;
	private int comOne2 = 0;
	private int comTwo2 = 0;
	private int com2 = 0;
	private int com3 = 0;
	private int comOne3 = 0;
	private int comTwo3 = 0;
	public bool finished2 = false;
	public int comTwo = 0;
	public int typeInt1 = 4;
	public int typeInt2 = 4;
	// give the items a thingy
	private Node2D postcardItem;
	private Node2D sealItem;
	private Node2D letterItem;
	private Node2D pinkLetterItem;
	private Node2D blueLetterItem;
	private Node2D redLetterItem;
	private Node2D boxItem;
	private Node2D Orpheus1;
	private Node2D Orpheus2;
	private Node2D Orpheus3;
	private Godot.Timer timer;
	private Godot.Timer timer2;
	private Godot.Timer timer3;
	private Node2D OrOneCard;
	private Node2D OrOnePink;
	private Node2D OrOneBlue;
	private Node2D OrOneRed;
	private Node2D OrOnePinkSeal;
	private Node2D OrOneRedSeal;
	private Node2D OrOneBlueSeal;
	private Node2D OrOneLetter;
	private Node2D OrOneLetterSeal;
	private Node2D OrOneBox;
	private bool finished3;
	//orpheus 2
	private Node2D OrTwoCard;
	private Node2D OrTwoPink;
	private Node2D OrTwoBlue;
	private Node2D OrTwoRed;
	private Node2D OrTwoPinkSeal;
	private Node2D OrTwoRedSeal;
	private Node2D OrTwoBlueSeal;
	private Node2D OrTwoLetter;
	private Node2D OrTwoLetterSeal;
	private Node2D OrTwoBox;
	//orpheus 3
	private Node2D OrThreeCard;
	private Node2D OrThreePink;
	private Node2D OrThreeBlue;
	private Node2D OrThreeRed;
	private Node2D OrThreePinkSeal;
	private Node2D OrThreeRedSeal;
	private Node2D OrThreeBlueSeal;
	private Node2D OrThreeLetter;
	private Node2D OrThreeLetterSeal;
	private Node2D OrThreeBox;
	public bool InCheck1 = false;
	public bool InCheck2 = false;
	public bool InCheck3 = false;
	private int com = 0;
	public float dropSpeed = 30f;
	
	public override void _Ready()
	{
		audio = GetNode<AudioStreamPlayer>("../AudioStreamPlayer");
		heart = GetNode<Node2D>("../Heart1");
		heart2 = GetNode<Node2D>("../Heart2");
		heart3 = GetNode<Node2D>("../Heart3");
		timer = GetNode<Godot.Timer>("../Timer");
		timer3 = GetNode<Godot.Timer>("../Timer3");
		timer2 = GetNode<Godot.Timer>("../Timer2");
		//items
		postcardItem = GetNode<Node2D>("../Player/Image480/UntitledDesign111-removebg-preview");
		sealItem = GetNode<Node2D>("../Player/Image480/UntitledDesign9-removebg-preview");
		letterItem = GetNode<Node2D>("../Player/Image480/UntitledDesign(2)(1)");
		pinkLetterItem = GetNode<Node2D>("../Player/Image480/UntitledDesign31-removebg-preview");
		blueLetterItem = GetNode<Node2D>("../Player/Image480/UntitledDesign41-removebg-preview");
		redLetterItem = GetNode<Node2D>("../Player/Image480/UntitledDesign51-removebg-preview");
		boxItem = GetNode<Node2D>("../Player/Image480/Img5523");
		//orpheuses
		Orpheus1 = GetNode<Node2D>("../Orepheus1");
		Orpheus2 = GetNode<Node2D>("../Orpheus2");
		Orpheus3 = GetNode<Node2D>("../Orpheus3");
		//Request items
		// orpheus 1
		OrOneCard = GetNode<Node2D>("../OrOneCard");
		OrOnePink = GetNode<Node2D>("../OrOnePink");
		OrOneBlue = GetNode<Node2D>("../OrOneBlue");
		OrOneRed = GetNode<Node2D>("../OrOneRed");
		OrOnePinkSeal = GetNode<Node2D>("../OrOnePinkSeal");
		OrOneRedSeal = GetNode<Node2D>("../OrOneRedSeal");
		OrOneBlueSeal = GetNode<Node2D>("../OrOneBlueSeal");
		OrOneLetter = GetNode<Node2D>("../OrOneLetter");
		OrOneLetterSeal = GetNode<Node2D>("../OrOneLetterSeal");
		OrOneBox = GetNode<Node2D>("../OrOneBox");
		//orpheus 2
		OrTwoCard = GetNode<Node2D>("../OrTwoCard");
		OrTwoPink = GetNode<Node2D>("../OrTwoPink");
		OrTwoBlue = GetNode<Node2D>("../OrTwoBlue");
		OrTwoRed = GetNode<Node2D>("../OrTwoRed");
		OrTwoPinkSeal = GetNode<Node2D>("../OrTwoPinkSeal");
		OrTwoRedSeal = GetNode<Node2D>("../OrTwoRedSeal");
		OrTwoBlueSeal = GetNode<Node2D>("../OrTwoBlueSeal");
		OrTwoLetter = GetNode<Node2D>("../OrTwoLetter");
		OrTwoLetterSeal = GetNode<Node2D>("../OrTwoLetterSeal");
		OrTwoBox = GetNode<Node2D>("../OrTwoBox");
		//orpheus 3
		OrThreeCard = GetNode<Node2D>("../OrThreeCard");
		OrThreePink = GetNode<Node2D>("../OrThreePink");
		OrThreeBlue = GetNode<Node2D>("../OrThreeBlue");
		OrThreeRed = GetNode<Node2D>("../OrThreeRed");
		OrThreePinkSeal = GetNode<Node2D>("../OrThreePinkSeal");
		OrThreeRedSeal = GetNode<Node2D>("../OrThreeRedSeal");
		OrThreeBlueSeal = GetNode<Node2D>("../OrThreeBlueSeal");
		OrThreeLetter = GetNode<Node2D>("../OrThreeLetter");
		OrThreeLetterSeal = GetNode<Node2D>("../OrThreeLetterSeal");
		OrThreeBox = GetNode<Node2D>("../OrThreeBox");
		timer4 = GetNode<Godot.Timer>("../Timer4");
		timer5 = GetNode<Godot.Timer>("../Timer5");
		timer6 = GetNode<Godot.Timer>("../Timer6");
		//rng
		complexity = new RandomNumberGenerator();
		type = new RandomNumberGenerator();
		sealNum = new RandomNumberGenerator();
		color = new RandomNumberGenerator();
		timer.Start(1f);
		timer2.Start(3f);
		timer3.Start(5f);
	}
	public override void _PhysicsProcess(double delta)
	{
		velocity = Vector2.Zero;
		if(Input.IsKeyPressed(Key.W))
		{
			velocity.Y -= Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.S))
		{
			velocity.Y += Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.A))
		{
			velocity.X -= Speed * (float)delta;
		}
		if(Input.IsKeyPressed(Key.D))
		{
			velocity.X += Speed * (float)delta;
		}
		velocity = velocity.Normalized() * Speed;
		Velocity = velocity;
		MoveAndSlide();
	}
	public void LetterEntered(Node body)
	{
		if(handsFull == false)
		{
			letter = true;
			handsFull = true;
		}
	}
	private void fe()
	{
		audio.Play();
	}
	public void PinkEntered(Node body)
	{
		if(letter == true)
		{
			pinkLetter = true;
			letter = false;
		}
	}
	public void RedEntered(Node body)
	{
		if(letter == true)
		{
			redLetter = true;
			letter = false;
		}
	}
	public void BlueEntered(Node body)
	{
		if(letter == true)
		{
			blueLetter = true;
			letter = false;
		}
	}
	public void SealEntered(Node body)
	{
		if(letter == true || pinkLetter == true || blueLetter == true || redLetter == true)
		{
			seal = true;
		}
	}
	public void PostcardEntered(Node body)
	{
		if(handsFull == false)
		{
			postcard = true;
			handsFull = true;
		}
	}
	public void BoxEntered(Node body)
	{
		if(handsFull == false)
		{
			boxHeld = true;
			handsFull = true;
		}
	}
	public void TrashEntered(Node body)
	{
		letter = false;
		seal = false;
		pinkLetter = false;
		blueLetter = false;
		redLetter = false;
		boxHeld = false;
		postcard = false;
		handsFull = false;
	}
	public override void _Process(double delta)
	{
		if(lives == 0)
		{
			GetTree().ChangeSceneToFile("res://EndMailServer.tscn");
		}else if(lives == 1)
		{
			heart2.Visible = false;
			heart3.Visible = false;
		}else if(lives == 2)
		{
			heart3.Visible = false;
		}else if(lives == 3)
		{
			heart3.Visible = true;
			heart.Visible = true;
			heart2.Visible = true;
		}
		if(Check1 == true)
		{
		if(finished == true && needPinkSeal == false && needBlackSeal == false && needRedSeal == false && needBlueSeal == false && needPinkLetter == false && needBlueLetter == false && needRedLetter == false && needLetter == false && needBox == false && needPostcard == false)
		{
			if(InCheck1 == false)
			{
				Orpheus1.Visible = false;
			win1 = true;
			GD.Print("ALERT ALERT ALERT");
			InCheck1 = true;
			}
		}else
		{
			win1 = false;
		}
		}
		if(Check2 == true)
		{
		if(finished2 == true && needPinkSeal2 == false && needBlackSeal2 == false && needBlueSeal2 == false && needRedSeal2 == false && needPinkLetter2 == false && needBlueLetter2 == false && needRedLetter2 == false && needLetter2 == false && needBox2 == false && needPostcard2 == false)
		{
			if(InCheck2 == false)
			{
				Orpheus2.Visible = false;
			win2 = true;
			InCheck2 = true;
			}
		}else
		{
			win2 = false;
		}
		}
		if(Check3 == true)
		{
		if(finished3 == true && needBlackSeal3 == false && needRedSeal3 == false && needBlueSeal3 == false && needPinkSeal3 == false && needPinkLetter3 == false && needBlueLetter3 == false && needRedLetter3 == false && needLetter3 == false && needBox3 == false && needPostcard3 == false)
		{
			if(InCheck3 == false)
			{
				Orpheus3.Visible = false;
			win3 = true;
			InCheck3 = true;
			}
		}else
		{
			win3 = false;
		}
		}
	
		
		if(boxHeld == true)
		{
			boxItem.Visible = true;
		}else
		{
			boxItem.Visible = false;
		}
		if(letter == true)
		{
			letterItem.Visible = true;
		}else
		{
			letterItem.Visible = false;
		}
		if(pinkLetter == true)
		{
			pinkLetterItem.Visible = true;
		}else
		{
			pinkLetterItem.Visible = false;
		}
		if(blueLetter == true)
		{
			blueLetterItem.Visible = true;
		}else
		{
			blueLetterItem.Visible = false;
		}
		if(redLetter == true)
		{
			redLetterItem.Visible = true;
		}else
		{
			redLetterItem.Visible = false;
		}
		if(postcard == true)
		{
			postcardItem.Visible = true;
		}else
		{
			postcardItem.Visible = false;
		}
		if(seal == true)
		{
			sealItem.Visible = true;
		}else
		{
			sealItem.Visible = false;
		}
		if(needLetter == true)
		{
			OrOneLetter.Visible = true;
		}else
		{
			OrOneLetter.Visible = false;
		}
		if(needPinkLetter == true)
		{
			OrOnePink.Visible = true;
			OrOneLetter.Visible = false;
		}else
		{
			OrOnePink.Visible = false;
		}
		if(needBlueLetter == true)
		{
			OrOneBlue.Visible = true;
			OrOneLetter.Visible = false;
		}else
		{
			OrOneBlue.Visible = false;
		}
		if(needRedLetter == true)
		{
			OrOneRed.Visible = true;
			OrOneLetter.Visible = false;
		}else
		{
			OrOneRed.Visible = false;
		}
		if(needBox == true)
		{
			OrOneBox.Visible = true;
		}else
		{
			OrOneBox.Visible = false;
		}
		if(needPostcard == true)
		{
			OrOneCard.Visible = true;
		}else
		{
			OrOneCard.Visible = false;
		}
			if(needPinkSeal == true)
			{
				OrOnePinkSeal.Visible = true;
			}else
			{
				OrOnePinkSeal.Visible = false;
			}
			if(needBlueSeal == true)
			{
				OrOneBlueSeal.Visible = true;
			}else
			{
				OrOneBlueSeal.Visible = false;
			}
			if(needRedSeal == true)
			{
				OrOneRedSeal.Visible = true;
			}else
			{
				OrOneRedSeal.Visible = false;
			}
			if(needBlackSeal == true)
			{
				OrOneLetterSeal.Visible = true;
			}else 
			{
				OrOneLetterSeal.Visible = false;
			}
			
			if(needLetter2 == true)
		{
			OrTwoLetter.Visible = true;
		}else
		{
			OrTwoLetter.Visible = false;
		}
		if(needPinkLetter2 == true)
		{
			OrTwoPink.Visible = true;
			OrTwoLetter.Visible = false;
		}else
		{
			OrTwoPink.Visible = false;
		}
		if(needBlueLetter2 == true)
		{
			OrTwoBlue.Visible = true;
			OrTwoLetter.Visible = false;
		}else
		{
			OrTwoBlue.Visible = false;
		}
		if(needRedLetter2 == true)
		{
			OrTwoRed.Visible = true;
			OrTwoLetter.Visible = false;
		}else
		{
			OrTwoRed.Visible = false;
		}
		if(needBox2 == true)
		{
			OrTwoBox.Visible = true;
		}else
		{
			OrTwoBox.Visible = false;
		}
		if(needPostcard2 == true)
		{
			OrTwoCard.Visible = true;
		}else
		{
			OrTwoCard.Visible = false;
		}
			if(needPinkSeal2 == true)
			{
				OrTwoPinkSeal.Visible = true;
			
			}else
			{
				OrTwoPinkSeal.Visible = false;
			}
			if(needBlueSeal2 == true)
			{
				OrTwoBlueSeal.Visible = true;
		
			}else
			{
				OrTwoBlueSeal.Visible = false;
			}
			if(needRedSeal2 == true)
			{
				OrTwoRedSeal.Visible = true;
			
			}else
			{
				OrTwoRedSeal.Visible = false;
			}
			if(needBlackSeal2 == true)
			{
				OrTwoLetterSeal.Visible = true;
			
			}
			if(needLetter3 == true)
		{
			OrThreeLetter.Visible = true;
		}else
		{
			OrThreeLetter.Visible = false;
		}
		if(needPinkLetter3 == true)
		{
			OrThreePink.Visible = true;
			OrThreeLetter.Visible = false;
		}else
		{
			OrThreePink.Visible = false;
		}
		if(needBlueLetter3 == true)
		{
			OrThreeBlue.Visible = true;
			OrThreeLetter.Visible = false;
		}else
		{
			OrThreeBlue.Visible = false;
		}
		if(needRedLetter3 == true)
		{
			OrThreeRed.Visible = true;
			OrThreeLetter.Visible = false;
		}else
		{
			OrThreeRed.Visible = false;
		}
		if(needBox3 == true)
		{
			OrThreeBox.Visible = true;
		}else
		{
			OrThreeBox.Visible = false;
		}
		if(needPostcard3 == true)
		{
			OrThreeCard.Visible = true;
		}else
		{
			OrThreeCard.Visible = false;
		}
			if(needPinkSeal3 == true)
			{
				OrThreePinkSeal.Visible = true;
				
			}else
			{
				OrThreePinkSeal.Visible = false;
			}
			if(needBlueSeal3 == true)
			{
				OrThreeBlueSeal.Visible = true;
	
			}else
			{
				OrThreeBlueSeal.Visible = false;
			}
			if(needRedSeal3 == true)
			{
				OrThreeRedSeal.Visible = true;

			}else
			{
				OrThreeRedSeal.Visible = false;
			}
			if(needBlackSeal3 == true)
			{
				OrThreeLetterSeal.Visible = true;
			}
		}
	public void MakeOrder1()
	{
		if(MakingOrder1) return;
	MakingOrder1 = true;
	complexity.Randomize();
	type.Randomize();
	int complex = complexity.RandiRange(0, 2); // Randomize complexity
	int typeInt = type.RandiRange(0, 2); // Randomize type
	GD.Print("complex!! " + complex); // Debug: See which complexity is chosen

	// Reset comOne and comTwo when switching complexity
	if (complex == 0)
	{
		comOne = 0;
		comTwo = 0;
		com = 0;
	}

	// Handle complex == 0 case
	if (complex == 0)
	{
		if (com == 0)
		{
			if (typeInt == 0)
			{
				needLetter = true;
				com++; // Increment com to prevent reuse
			}
			else if (typeInt == 1)
			{
				needPostcard = true;
				com++;
			}
			else if (typeInt == 2)
			{
				needBox = true;
				com++;
			}
		}
	}
	// Handle complex == 1 case
	else if (complex == 1 && comOne <= 2)
	{ 
		if (comOne <= 1)
		{
			while(comOne <= 1)
			{
			if (typeInt == 0 || typeInt1 == 0)
			{
				// Randomize color for letter type
				color.Randomize();
				int colorChosen = color.RandiRange(0, 2);
				if (colorChosen == 0)
				{
					needPinkLetter = true;
				}
				else if (colorChosen == 1)
				{
					needRedLetter = true;
				}
				else
				{
					needBlueLetter = true;
				}
				comOne++;
		//		GD.Print(comOne); // Debug: Track progress of comOne
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			else if (typeInt == 1 || typeInt1 == 1)
			{
				needPostcard = true;
				comOne++;
	//			GD.Print(comOne);
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			else if (typeInt == 2 || typeInt1 == 2)
			{
				needBox = true;
				comOne++;
	//			GD.Print(comOne);
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			}
		}else
		{
			comOne = 0; // Reset after full cycle
		}
		
	}

	// Handle complex == 2 case (Similar logic)
	else if (complex == 2 && comTwo <= 3)
	{
		if (comTwo <= 2)
		{
			while(comTwo <= 2)
		{
			
			sealNum.Randomize();
			int sealChosen = sealNum.RandiRange(0, 3);
			color.Randomize();
			int colorChosen = color.RandiRange(0, 2);
			if (colorChosen == 0)
			{
				needPinkLetter = true;
			}
			else if (colorChosen == 1)
			{
				needRedLetter = true;
			}
			else
			{
				needBlueLetter = true;
			}
			if (sealChosen == 0)
			{
				if(needBlueLetter == true)
				{
					needBlueSeal = true;
					needBlueLetter = false;
				}
				if(needRedLetter == true)
				{
					needRedSeal = true;
					needRedLetter = false;
				}
				if(needLetter == true)
				{
					needBlackSeal = true;
					needLetter = false;
				}
				if(needPinkLetter == true)
				{
					needPinkSeal = true;
					needPinkLetter = false;
				}
			}
			comTwo++;
	//		GD.Print("com2 " + comTwo); // Debug: Track progress of comTwo
			type.Randomize();
			typeInt2 = type.RandiRange(0, 2);
		}
		}
		// Repeat similar logic for typeInt == 1, 2...
		else
		{
			comTwo = 0; // Reset after full cycle
		}
	}
	Check1 = true;
	InCheck1 = false;
	MakingOrder1 = false;
	}
	public void MakeOrder2()
	{
		if(MakingOrder2) return;
	MakingOrder2 = true;
	complexity.Randomize();
	type.Randomize();
	int complex = complexity.RandiRange(0, 2); // Randomize complexity
	int typeInt = type.RandiRange(0, 2); // Randomize type
	//GD.Print(complex); // Debug: See which complexity is chosen

	// Reset comOne and comTwo when switching complexity
	if (complex == 0)
	{
		comOne2 = 0;
		comTwo2 = 0;
		com2 = 0;
	}

	// Handle complex == 0 case
	if (complex == 0)
	{
		if (com2 == 0)
		{
			if (typeInt == 0)
			{
				needLetter2 = true;
				com++; // Increment com to prevent reuse
			}
			else if (typeInt == 1)
			{
				needPostcard2 = true;
				com++;
			}
			else if (typeInt == 2)
			{
				needBox2 = true;
				com++;
			}
		}
	}
	// Handle complex == 1 case
	else if (complex == 1 && comOne2 <= 2)
	{ 
		if (comOne2 <= 1)
		{
			while(comOne2 <= 1)
			{
			if (typeInt == 0 || typeInt1 == 0)
			{
				// Randomize color for letter type
				color.Randomize();
				int colorChosen = color.RandiRange(0, 2);
				if (colorChosen == 0)
				{
					needPinkLetter2 = true;
				}
				else if (colorChosen == 1)
				{
					needRedLetter2 = true;
				}
				else
				{
					needBlueLetter2 = true;
				}
				comOne2++;
			//	GD.Print(comOne2); // Debug: Track progress of comOne
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			else if (typeInt == 1 || typeInt1 == 1)
			{
				needPostcard2 = true;
				comOne2++;
		//		GD.Print(comOne2);
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			else if (typeInt == 2 || typeInt1 == 2)
			{
				needBox2 = true;
				comOne2++;
			//	GD.Print(comOne2);
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			}
		}else
		{
			comOne2 = 0; // Reset after full cycle
		}
		
	}

	// Handle complex == 2 case (Similar logic)
	else if (complex == 2 && comTwo2 <= 3)
	{
		if (comTwo2 <= 2)
		{
			while(comTwo2 <= 2)
		{
			
			sealNum.Randomize();
			int sealChosen = sealNum.RandiRange(0, 3);
			color.Randomize();
			int colorChosen = color.RandiRange(0, 2);
			if (colorChosen == 0)
			{
				needPinkLetter2 = true;
			}
			else if (colorChosen == 1)
			{
				needRedLetter2 = true;
			}
			else
			{
				needBlueLetter2 = true;
			}
			if (sealChosen == 0)
			{
				if(needBlueLetter2 == true)
				{
					needBlueSeal2 = true;
					needBlueLetter2 = false;
				}
				if(needRedLetter2 == true)
				{
					needRedSeal2 = true;
					needRedLetter2 = false;
				}
				if(needLetter2 == true)
				{
					needBlackSeal2 = true;
					needLetter2 = false;
				}
				if(needPinkLetter2 == true)
				{
					needPinkSeal2 = true;
					needPinkLetter2 = false;
				}
			}else
			{
				//needSeal2 = false;
			}
			comTwo2++;
		//	GD.Print("com2 " + comTwo2); // Debug: Track progress of comTwo
			type.Randomize();
			typeInt2 = type.RandiRange(0, 2);
		}
		}
		// Repeat similar logic for typeInt == 1, 2...
		else
		{
			comTwo2 = 0; // Reset after full cycle
		}
	}	
	Check2 = true;
	InCheck2 = false;
	MakingOrder2 = false;
	}
	public void MakeOrder3()
	{
		if(MakingOrder3) return;
	MakingOrder3 = true;
	complexity.Randomize();
	type.Randomize();
	int complex = complexity.RandiRange(0, 2); // Randomize complexity
	int typeInt = type.RandiRange(0, 2); // Randomize type
	//GD.Print(complex); // Debug: See which complexity is chosen

	// Reset comOne and comTwo when switching complexity
	if (complex == 0)
	{
		comOne3 = 0;
		comTwo3 = 0;
		com3 = 0;
	}

	// Handle complex == 0 case
	if (complex == 0)
	{
		if (com3 == 0)
		{
			if (typeInt == 0)
			{
				needLetter3 = true;
				com3++; // Increment com to prevent reuse
			}
			else if (typeInt == 1)
			{
				needPostcard3 = true;
				com3++;
			}
			else if (typeInt == 2)
			{
				needBox3 = true;
				com3++;
			}
		}
	}
	// Handle complex == 1 case
	else if (complex == 1 && comOne3 <= 2)
	{ 
		if (comOne3 <= 1)
		{
			while(comOne3 <= 1)
			{
			if (typeInt == 0 || typeInt1 == 0)
			{
				// Randomize color for letter type
				color.Randomize();
				int colorChosen = color.RandiRange(0, 2);
				if (colorChosen == 0)
				{
					needPinkLetter3 = true;
				}
				else if (colorChosen == 1)
				{
					needRedLetter3 = true;
				}
				else
				{
					needBlueLetter3 = true;
				}
				comOne3++;
			//	GD.Print(comOne2); // Debug: Track progress of comOne
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			else if (typeInt == 1 || typeInt1 == 1)
			{
				needPostcard3 = true;
				comOne3++;
			//	GD.Print(comOne2);
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			else if (typeInt == 2 || typeInt1 == 2)
			{
				needBox3 = true;
				comOne3++;
		//		GD.Print(comOne2);
				type.Randomize();
				typeInt1 = type.RandiRange(0, 2);
			}
			}
		}else
		{
			comOne3 = 0; // Reset after full cycle
		}
		
	}

	// Handle complex == 2 case (Similar logic)
	else if (complex == 2 && comTwo3 <= 3)
	{
		if (comTwo3 <= 2)
		{
			while(comTwo3 <= 2)
		{
			
			sealNum.Randomize();
			int sealChosen = sealNum.RandiRange(0, 3);
			color.Randomize();
			int colorChosen = color.RandiRange(0, 2);
			if (colorChosen == 0)
			{
				needPinkLetter3 = true;
			}
			else if (colorChosen == 1)
			{
				needRedLetter3 = true;
			}
			else
			{
				needBlueLetter3 = true;
			}
			if (sealChosen == 0)
			{
				if(needBlueLetter3 == true)
				{
					needBlueSeal3 = true;
					needBlueLetter3 = false;
				}
				if(needRedLetter3 == true)
				{
					needRedSeal3 = true;
					needRedLetter3 = false;
				}
				if(needLetter3 == true)
				{
					needBlackSeal3 = true;
					needLetter3 = false;
				}
				if(needPinkLetter3 == true)
				{
					needPinkSeal3 = true;
					needPinkLetter3 = false;
				}
			}else
			{
				//needSeal3 = false;
			}
			comTwo3++;
	//		GD.Print("com2 " + comTwo2); // Debug: Track progress of comTwo
			type.Randomize();
			typeInt2 = type.RandiRange(0, 2);
		}
		}
		// Repeat similar logic for typeInt == 1, 2...
		else
		{
			comTwo3 = 0; // Reset after full cycle
		}
	}
	Check3 = true;
	InCheck3 = false;
	MakingOrder3 = false;
}
	public void OnTimeout()
	{
		if(finished == false)
		{
		Orpheus1.Visible = true;
		MakeOrder1();
		finished = true;
		timer4.Start(dropSpeed); 
		}
	}
	public void OnTimeout2()
	{
		if(finished2 == false)
		{
		Orpheus2.Visible = true;
		MakeOrder2();
		finished2 = true;
		timer5.Start(dropSpeed);
	}
	}
	public void OnOrOneEntered(Node body)
	{
		
		if(pinkLetter == true && (needPinkLetter == true || needPinkSeal == true))
		{
			if(seal == false && needPinkLetter == true)
			{
				handsFull = false;
				pinkLetter = false;
				needPinkLetter = false;
			}else if(seal == true && needPinkSeal == true)
			{
				handsFull = false;
				pinkLetter = false;
				needPinkLetter = false;
				needPinkSeal = false;
				seal = false;
			}
		}
		if(blueLetter == true && (needBlueLetter == true || needBlueSeal == true))
		{
			if(seal == false && needBlueLetter == true)
			{
				handsFull = false;
				blueLetter = false;
				needBlueLetter = false;
			}else if(seal == true && needBlueSeal == true)
			{
				handsFull = false;
				blueLetter = false;
				needBlueLetter = false;
				needBlueSeal = false;
				seal = false;
			}
		}
		if(redLetter == true && (needRedLetter == true || needRedSeal == true))
		{
			if(seal == false && needRedLetter == true)
			{
				handsFull = false;
				redLetter = false;
				needRedLetter = false;
			}else if(seal == true && needRedSeal == true)
			{
				handsFull = false;
				redLetter = false;
				needRedLetter = false;
				needRedSeal = false;
				seal = false;
			}
		}
		if(letter == true && (needBlackSeal == true || needLetter == true))
		{
			if(needLetter == true && seal == false)
			{
				handsFull = false;
				letter = false;
				needLetter = false;
			}else if(needBlackSeal == true && seal == true)
			{
				handsFull = false;
				letter = false;
				needLetter = false;
				needBlackSeal = false;
				seal = false;
			}
		}
		if(boxHeld == true && needBox == true)
		{
			boxHeld = false;
			needBox = false;
			handsFull = false;
		}
		if(postcard == true && needPostcard == true)
		{
			postcard = false;
			needPostcard = false;
			handsFull = false;
		}
		Check1 = true;
	}
	public void OrTwoEntered(Node body)
	{
		
		if(pinkLetter == true && (needPinkSeal2 == true || needPinkLetter2 == true))
		{
			if(seal == false && needPinkLetter2 == true)
			{
				handsFull = false;
				pinkLetter = false;
				needPinkLetter2 = false;
			}else if(seal == true && needPinkSeal2 == true)
			{
				handsFull = false;
				pinkLetter = false;
				needPinkLetter2 = false;
				needPinkSeal2 = false;
				seal = false;
			}
		}
		if(blueLetter == true && (needBlueSeal2 == true || needBlueLetter2 == true))
		{
			if(seal == false && needBlueLetter2 == true)
			{
				handsFull = false;
				blueLetter = false;
				needBlueLetter2 = false;
			}else if(seal == true && needBlueSeal2 == true)
			{
				handsFull = false;
				blueLetter = false;
				needBlueLetter2 = false;
				needBlueSeal2 = false;
				seal = false;
			}
		}
		if(redLetter == true && (needRedSeal2 == true || needRedLetter2 == true))
		{
			if(seal == false && needRedLetter2 == true)
			{
				handsFull = false;
				redLetter = false;
				needRedLetter2 = false;
			}else if(seal == true && needRedSeal2 == true)
			{
				handsFull = false;
				redLetter = false;
				needRedLetter2 = false;
				needRedSeal2 = false;
				seal = false;
			}
		}
		if(letter == true && (needBlackSeal2 == true || needLetter2 == true))
		{
			if(needLetter2 == true && seal == false)
			{
				handsFull = false;
				letter = false;
				needLetter2 = false;
			}else if(needBlackSeal2 == true && seal == true)
			{
				handsFull = false;
				letter = false;
				needLetter2 = false;
				needBlackSeal2 = false;
				seal = false;
			}
		}
		if(boxHeld == true && needBox2 == true)
		{
			boxHeld = false;
			needBox2 = false;
			handsFull = false;
		}
		if(postcard == true && needPostcard2 == true)
		{
			postcard = false;
			needPostcard2 = false;
			handsFull = false;
		}
		Check2 = true;
		InCheck2 = false;
	}
	public void OnTimeout3()
	{
		if(finished3 == false)
		{
			MakeOrder3();
			Orpheus3.Visible = true;
			finished3 = true;
			timer6.Start(dropSpeed);
		}
	}
	public void OrThreeEntered(Node body)
	{
		
		if(pinkLetter == true && (needPinkSeal3 == true || needPinkLetter3 == true))
		{
			if(seal == false && needPinkLetter3 == true)
			{
				handsFull = false;
				pinkLetter = false;
				needPinkLetter3 = false;
			}else if(seal == true && needPinkSeal3 == true)
			{
				handsFull = false;
				pinkLetter = false;
				needPinkLetter3 = false;
				needPinkSeal3 = false;
				seal = false;
			}
		}
		if(blueLetter == true && (needBlueSeal3 == true || needBlueLetter3 == true))
		{
			if(seal == false && needBlueLetter3 == true)
			{
				handsFull = false;
				blueLetter = false;
				needBlueLetter3 = false;
			}else if(seal == true && needBlueSeal3 == true)
			{
				handsFull = false;
				blueLetter = false;
				needBlueLetter3 = false;
				needBlueSeal3 = false;
				seal = false;
			}
		}
		if(redLetter == true && (needRedSeal3 == true || needRedLetter3 == true))
		{
			if(seal == false && needRedLetter3 == true)
			{
				handsFull = false;
				redLetter = false;
				needRedLetter3 = false;
			}else if(seal == true && needRedSeal3 == true)
			{
				handsFull = false;
				redLetter = false;
				needRedLetter3 = false;
				needRedSeal3 = false;
				seal = false;
			}
		}
		if(letter == true && (needBlackSeal3 == true || needLetter3 == true))
		{
			if(needLetter3 == true && seal == false)
			{
				handsFull = false;
				letter = false;
				needLetter3 = false;
			}else if(needBlackSeal3 == true && seal == true)
			{
				handsFull = false;
				letter = false;
				needLetter3 = false;
				needBlackSeal3 = false;
				seal = false;
			}
		}
		if(boxHeld == true && needBox3 == true)
		{
			boxHeld = false;
			needBox3 = false;
			handsFull = false;
		}
		if(postcard == true && needPostcard3 == true)
		{
			postcard = false;
			needPostcard3 = false;
			handsFull = false;
		}
		Check3 = true;
		InCheck3 = false;
	}
	private void OnTimeout4()
	{
		Orpheus1.Visible = false;
		finished = false;
		if(win1 == true)
		{
			finished = false;
			if(dropSpeed >= 0.2f)
			{
				timer.Start(1f);
			}else
			{
				timer.Start(1f);
			}
			win1 = false;
		}else
		{
			finished = false;
			if(dropSpeed >= 0.2f)
			{
				timer.Start(1f);
			}else
			{
				timer.Start(1f);
			}
			lives--;
		}
		needLetter = false;
		needPinkLetter = false;
		needBlueLetter = false;
		needRedLetter = false;
		needPostcard = false;
		needBox = false;
		needBlueSeal = false;
		needPinkSeal = false;
		needBlackSeal = false;
		needRedSeal = false;
		needSeal = false;
		Check1 = false;
	}
	private void OnTimeout5()
	{
		Orpheus2.Visible = false;
		finished2 = false;
		if(win2 == true)
		{
			finished2 = false;
			if(dropSpeed >= 0.2f)
			{
				timer2.Start(1f);
			}else
			{
				timer2.Start(1f);
			}
			win2 = false;
		}else
		{
			finished2 = false;
			if(dropSpeed >= 0.2f)
			{
				timer2.Start(1f);
			}else
			{
				timer2.Start(1f);
			}
			lives--;
		}
		needLetter2 = false;
		needPinkLetter2 = false;
		needBlueLetter2 = false;
		needRedLetter2 = false;
		needPostcard2 = false;
		needBlackSeal2 = false;
		needPinkSeal2 = false;
		needBlueSeal2 = false;
		needRedSeal2 = false;
		needBox2 = false;
		needSeal2 = false;
		Check2 = false;
	}
	private void OnTimeout6()
	{
		
		Orpheus3.Visible = false;
		finished3 = false;
		if(win3 == true)
		{
			finished3 = false;
			if(dropSpeed >= 5.2f)
			{
				timer3.Start(1f);
			}else
			{
				timer3.Start(1f);
			}
			win3 = false;
		}else
		{
			finished3 = false;
			if(dropSpeed >= 5.2f)
			{
				timer3.Start(1f);
			}else
			{
				timer3.Start(1f);
			}
			lives--;
		}
		needLetter3 = false;
		needPinkLetter3 = false;
		needBlueLetter3 = false;
		needRedLetter3 = false;
		needPostcard3 = false;
		needBox3 = false;
		needSeal3 = false;
		needPinkSeal3 = false;
		needBlueSeal3 = false;
		needRedSeal3 = false;
		needBlackSeal3 = false;
		Check3 = false;
		dropSpeed -= 0.5f;
	}
}
