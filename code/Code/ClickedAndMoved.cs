using Godot;
using System;

public partial class ClickedAndMoved : Area2D
{
	//public static Area2D badder2;
//	public static Area2D badder3;
	private Vector2 prePos = Vector2.Zero;
	private int stillTick = 0;
	private int maxStillTick = 10;
	private float speed;
	private bool runningPress = false;
	private bool pressed = false;
	private bool released = false;
	private bool collide = true;
	private bool placed = false;
	private bool hover = false;
	private bool hover2 = false;
	private bool shooting = false;
	private bool notHit = false;
	private Vector2 targetPos;
	//private Node2D ThisOne;
	private Sprite2D dart;
	private CollisionShape2D are;
	private PopupMenu basic;
	private Timer timer;
	private Timer timer3;
	private Sprite2D range;
	private Area2D badder;
	private Sprite2D stuff;
	private Script dartt;
	public static bool ermmm = false;
	private int sell = 50;
	private int speedLevel = 1;
	private int rangeLevel = 1;
	//private int numLevel = 1;
	private int speedUpPrice = 50;
	private int rangeUpPrice= 50;
//	private int numUpPrice = 50;
	private int rangeScale = 5;
	private Sprite2D ran;
	public static int copy = -1;
	private Sprite2D target;
	private Vector2 closestDistance;
	private int check = 0;
	//private Vector2 targetPos;
	//public static bool shooting2 = false;
	//public static bool shooting3 = false;
	//public static bool notHit2 = false;
	//public static bool notHit3 = false;
	//private Texture2D textur;

	public override void _Ready()
	{
		check = 0;
		stillTick = 0;
		prePos = Vector2.Zero;
		speed = 0.5f;
		copy++;
		GD.Print(copy);
		ran = GetNode<Sprite2D>("../Sprite2D");
		dartt = (Script)ResourceLoader.Load("res://Dart.cs");
		dart = GetNode<Sprite2D>("../Pixil-frame-0(1)");
		are = GetNode<CollisionShape2D>("../StaticBody2D/Area2D/CollisionShape2D");
		range = GetNode<Sprite2D>("../Sprite2D");
		closestDistance = new Vector2(1000, 1000);
		target = null;
	//	badder = null;
		//stuff = null;
	//	are.Disabled = true;
	//	textur = (Texture2D)ResourceLoader.Load("res://pixil-frame-0.png");
	//	if(range != null)
	//	{
	//		GD.Print("NALLL");
	//		range = null;
		//	range.QueueFree();
		//}
		//if(range == null)
		//{
		//GD.Print("NULLLL");
		//range = new Sprite2D();
		//AddChild(range);
		
		//range.Texture = textur;
	//	range.Scale = new Vector2(5, 5);
	//	range.Visible = false;
	//	}
		//if(range != null)
		//{
			//GD.Print("ererre");
		//	clone.range.QueueFree();
		//	range = null;
		//	GetParent().RemoveChild(range);
	//	}
		basic = new PopupMenu();
		AddChild(basic);
		timer = new Timer();
		AddChild(timer);
//		timer3 = new Timer();
//		AddChild(timer3);
		basic.Connect("id_pressed", new Callable(this, nameof(IdClicked)));
		basic.Connect("mouse_exited", new Callable(this, nameof(Popout)));
		basic.Connect("mouse_entered", new Callable(this, nameof(popin)));
//		timer.Connect("timeout", new Callable(this, nameof(Timeout3)));
		//ThisOne = GetNode<Node2D>("res://TowerDef.tscn");
		//basic.Connect("id_pressed", this, nameof(IdClicked));
	}
	//private void updateDirection()
	//{
	//	if(badder != null && stuff != null)
	//	{
	//	targetPos = badder.GlobalPosition - stuff.GlobalPosition;
	//	targetPos = targetPos.Normalized();
	//	stuff.Position += targetPos * speed;
	//	}
	//}
//	private void onareain(Area2D area)
//	{
		//if(ClickedAndMoved.shooting == true)
		//{
		//	ClickedAndMoved.notHit = false;
		//	ClickedAndMoved.shooting = false;
		//}
		
//		area.GetParent().QueueFree();
		//Area2D.GetParent().QueueFree();
//		target = null;
//		badder = null;
//		stuff.QueueFree();
//		stuff = null;
//		GameManager.TDpoints++;
//		GameManager.TDstamps += 2;
//	}
//	private void OnAreaIn(Area2D area)
	//{
		//if(ClickedAndMoved.shooting == true)
		//{
		//	ClickedAndMoved.notHit = false;
		//	ClickedAndMoved.shooting = false;
		//}
		
	//	area.GetParent().QueueFree();
		//Area2D.GetParent().QueueFree();
	//	badder = null;
	//	stuff.QueueFree();
	//	stuff = null;
	//	GameManager.TDpoints++;
	//	GameManager.TDstamps += 2;
//	}
	private void AHH()
	{
			stuff.QueueFree();
			stuff = null;
	}
	private void updateDirection()
	{
		if(stuff != null && (target == null || !target.IsInsideTree())) 
		{
		foreach(Sprite2D node in GetTree().GetNodesInGroup("Baddies"))
		{
			Vector2 distance = node.GlobalPosition - stuff.GlobalPosition;
			if(distance.Length() < closestDistance.Length())
			{
				closestDistance = distance;
				target = node;
				
			}
		}
		}
	//	if(stuff != null && )
	//	{
	//		target = null;
	//	}
		
		if(target != null)
		{
		targetPos = target.GlobalPosition - stuff.GlobalPosition;
		targetPos = targetPos.Normalized();
		stuff.GlobalPosition += targetPos * speed;
		}else
		{
			shooting = false;
			notHit = false;
			stuff.QueueFree();
			target = null;
			stuff = null;
			closestDistance = new Vector2(1000, 1000);
		}
	}
	private void TargetHit(Area2D area)
	{
		area.GetParent().QueueFree();
		
		GameManager.TDstamps += 1;
		GameManager.TDpoints++;
		shooting = false;
		notHit = false;
		stuff.QueueFree();
		target = null;
		stuff = null;
		closestDistance = new Vector2(1000, 1000);
		//timer3.Stop();
		GD.Print("BADDDDIEEEE");
	}
	public override void _Process(double delta)
	{
		if(stuff != null && shooting)
		{
			if(stuff.GlobalPosition == prePos)
			{
				stillTick++;
			}else
			{
				stillTick = 0;
			}
			
			prePos = stuff.GlobalPosition;
			
			if(stillTick >= maxStillTick)
			{
				GD.Print("YOOOO");
				shooting = false;
				notHit = false;
				stuff.QueueFree();
				target = null;
				stuff = null;
				closestDistance = new Vector2(1000, 1000);
			}
		}else
		{
			stillTick = 0;
		}
		if(target != null)
		{
		if(target.Position.X > 964)
		{
			shooting = false;
			notHit = false;
			stuff.QueueFree();
			target = null;
			stuff = null;
			closestDistance = new Vector2(1000, 1000);
		}
		}else if(closestDistance != new Vector2(1000, 1000) && stuff != null)
		{
			shooting = false;
			notHit = false;
			stuff.QueueFree();
			target = null;
			stuff = null;
		}
		//if(target == null && stuff != null && shooting)
		//{
	//		shooting = false;
//			notHit = false;//
//			stuff.QueueFree();
//			target = null;
//			stuff = null;
//		}
		if(speedLevel > 1 && rangeLevel > 1)
		{
			sell = speedUpPrice/2 + rangeUpPrice/2 + 50;
		}else if(speedLevel > 1)
		{
			sell = speedUpPrice/2 + 50;
		}else if(rangeLevel > 1)
		{
			sell = rangeUpPrice/2 + 50;
		}
		
		if(shooting)
		{
			updateDirection();
		}
		//if(shooting && notHit && badder == null)
		//{
		//	shooting = false;
		//	notHit = false;
		//	stuff.QueueFree();
		//	stuff = null;
		//}else if(stuff == null && badder != null)
	//	{
//			shooting = false;
//			notHit = false;
//			badder = null;
//		//	stuff.QueueFree();
//		}
		are.Scale = new Vector2(rangeScale, rangeScale);
		ran.Scale = are.Scale;
		if(speedLevel == 2)
		{
			speed = 0.75f;
			speedUpPrice = 100;
		}else if(speedLevel == 3)
		{
			speed = 1f;
			speedUpPrice = 200;
		}else if(speedLevel == 4)
		{
			speed = 1.25f;
			speedUpPrice = 350;
		}
		if(rangeLevel == 2)
		{
			rangeScale = 6;
			rangeUpPrice = 100;	
		}else if(rangeLevel == 3)
		{
			rangeScale = 7;
			rangeUpPrice = 200;
		}else if(rangeLevel == 4)
		{
			rangeScale = 8;
		}
	//	if(numLevel == 2)
	//	{
	//		numUpPrice = 200;
	//		numUpPrice = 350;
		//}
		if(badder != null && stuff != null && placed)
		{
			
		//	stuff.Set("script", dartt);
		//	stuff.AddChild(dartt);
			
		//	if(notHit)
		//	{
		//		targetPos = Vector2.Zero;
		//		targetPos = badder.Position - stuff.Position;
		//		targetPos = targetPos.Normalized();
		//		updateDirection();
		//		stuff.Position += targetPos * speed;
		//		if(badder.GlobalPosition == null)
		//		{
		//			badder = null;
		//			shooting = false;
		//			
		//			stuff = null;
				}
		//	}else
		//	{
		//		badder = null;
		//		shooting = false;
		//		//stuff.QueueFree();
		//		stuff = null;
		//	}
			
		//}else if(notHit)
		//{
			
	//	}
		if(placed)
		{
			
			//are.Position = Position;
		}
	//	if(range == null && placed)
			//{
			//	createThing();
			//}
		if(hover)
		{
			range.Scale = new Vector2(rangeScale, rangeScale);
			range.Position = Position;
			range.Visible = true;
			
			//if(range != null)
			//{
			//range.Visible = false;
			//}
		}else
		{
		//	range.Scale = new Vector2(0, 0);
		//	range.Visible = false;
		//	if(range != null)
		//	{
		//	range.Visible = true;
		//	}
		}
		//GD.Print("aaaa");
		if(released == true)
		{
			pressed = false;
			released = false;
		}
		if(hover && placed && Input.IsMouseButtonPressed(MouseButton.Left))
		{
			popup();
			range.Scale = new Vector2(rangeScale, rangeScale);
			range.Position = Position;
			range.Visible = true;
		}
		if(Input.IsMouseButtonPressed(MouseButton.Left) && GameManager.TDstamps >= 100)
		{
	
		if(hover == true && !placed && (HackMinDev.PICKINGUP == false || check == 1))
		{
			check = 1;
			Vector2 mousePos = GetGlobalMousePosition();
			Position = mousePos;
			pressed = true;
			HackMinDev.PICKINGUP = true;
		}
		
		}else if(pressed)
		{
			check = 0;
			range.Visible = false;
			runningPress = true;
		//	if(range != null)
		//	{
				//range.QueueFree();
				//range = null;
		//	}
			if(collide == false)
			{
				
				
				//if(range != null)
			//	{
				//range.QueueFree();
				//range = null;
				//range.GetParent().RemoveChild(range);
			//	}
				Area2D clone = (Area2D)Duplicate();
				GetParent().AddChild(clone);
				clone.Position = new Vector2(1002, 43);
				
				//clone.GetParent().RemoveChild(range);
			//	if(range != null)
		//		{
		//		range.QueueFree();	
			//	}
		//		if(range == null)
			//	{
					
	//			}
				
				//Sprite2D newRange = new Sprite2D();
				//newRange.Texture = textur;
				//newRange.Scale = new Vector2(5,5);
				//newRange.Visible = true;
				//clone.AddChild(newRange);
				GameManager.TDstamps -= 100;
				placed = true;
			//	are.Disabled = false;
			}else
			{
				Position = new Vector2(1002, 43);
				collide = true;
			}
			released = true;
			runningPress = false;
			HackMinDev.PICKINGUP = false;
			}
		
		
	}
//	private void Timeout3()
//	{
//		if(shooting && stuff != null)
//		{
//		shooting = false;
//		notHit = false;
//		stuff.QueueFree();
//		target = null;
//		stuff = null;
//		}
//	}
	private void popup()
	{
			//basic.Position = new Vector2I((int)Position.X, (int)Position.Y);
		//	basic.Visible = true;
		//if(!basic.Visible)
		//{
			range.Scale = new Vector2(5, 5);
			range.Position = Position;
			range.Visible = true;
			basic.Clear();
			basic.AddItem("Sell: $" + sell, 1);
			if(speedLevel <= 4)
			{
				basic.AddItem("Upgrade Speed Currently Level: " + speedLevel + " for: " + speedUpPrice, 2);
			}else
			{
				basic.AddItem("Speed Maxed", 2);
			}
			//if(numLevel <= 3)
		//	{
			//	basic.AddItem("Upgrade Stamps Currently Level: " + numLevel + " for: " + numUpPrice, 3);
		//	}else
		//	{
	//			basic.AddItem("Stamps Maxed" + numUpPrice, 3);
		//	}
			if(rangeLevel <= 4)
			{
				basic.AddItem("Upgrade Range Currently Level: " + rangeLevel + " for: " + rangeUpPrice, 3);
			}else
			{
				basic.AddItem("Range Maxed" + rangeUpPrice, 3);
			}
			
			
			basic.Popup(new Rect2I(new Vector2I((int)Position.X + 50, (int)Position.Y), new Vector2I(1, 1)));
		//}else
		//{
		//	basic.Hide();
		//}
	}
	private void IdClicked(int id)
	{
		switch (id)
		{
			case 1:
				GameManager.TDstamps += sell;
				QueueFree();
				break;
			case 2:
				if(GameManager.TDstamps >= speedUpPrice && speedLevel <= 4)
				{
					GameManager.TDstamps -= speedUpPrice;
					speedLevel++;
				}
				break;
			case 3:
				 if(GameManager.TDstamps >= rangeUpPrice && rangeLevel <= 4)
				{
					GameManager.TDstamps -= rangeUpPrice;
					rangeLevel++;
				}
				break;
		}

		
	}
//	private void IntexClicked(int id)
	//{
//		GD.Print("erere");
//		GameManager.TDstamps += 50;
	//	QueueFree();
	//}
	public void OnHover()
	{
		//CloneObject();
		hover = true;
		if(placed)
		{
			//make the range visible
		}
		if(runningPress == false)
		{
			
		}
	}
	private void OnOut()
	{
		if(!hover && !hover2)
		{
		popoutout();
		}
	}
	public void HoverExit()
	{
		hover = false;
		range.Visible = false;
		timer.Start(0.01f);
	//	if(range != null)
	//	{
		//	range.QueueFree();
	//		range = null;
	//	}
	}
	public void OnEntered(Node body)
	{
		collide = true;
	}
	public void OnExited(Node body)
	{
		collide = false;
	}
	public void OnExit2(Node body)
	{
		collide = false;
	}
	public void OnEntered2(Node body)
	{
		collide = true;
	}
	//private void CloneObject()
	//{
	//	Node2D clone = (Node2D)ThisOne.Instantiate();
	//	GetParent().AddChild(clone);
	//}
	public void popin()
	{
		hover2 = true;
	}
	public void Popout()
	{
		hover2 = false;
		timer.Start(0.01f);
		//popoutout();
		if(!hover)
		{
		//	basic.Hide();
		}
	}
	public void popoutout()
	{
		//if(!hover && !hover2)
		//{
			basic.Hide();
		//}
	}
	public void createThing()
	{
	//	if(range == null)
		//{
	//		range = new Sprite2D();
	//	AddChild(range);
	//	
	//	range.Texture = textur;
	//	range.Scale = new Vector2(5, 5);
	//	range.Visible = false;
	//	}
	}
	private void BaddieEnter(Area2D area)
	{
		if(placed && !shooting)
		{
			notHit = true;
			shooting = true;
			CallDeferred(nameof(makeClone), area);
			//makeClone(area);
		//	timer3.Start(300f);
		}
	}
	private void makeClone(Area2D area)
	{	
		if(notHit && stuff == null)
		{
			target = null;
			Sprite2D cloneDart = (Sprite2D)dart.Duplicate();
			GetParent().AddChild(cloneDart);
			cloneDart.Position = Position;
		if (area != null)
		{
			stuff = (Sprite2D)cloneDart;
			stuff.GetChild(0).Connect("area_entered", new Callable(this, nameof(TargetHit)));
		}else
		{
			GD.Print("arerr null");
		}
		}
			
	}
			
}
//	private void AreaEnter2(Area2D area, Sprite2D clonedart)
	//{
	//	if(area == badder)
	//	{
	//	clonedart.QueueFree();
	//	notHit = false;
	//	shooting = false;
	//	}
	//}
/*
GD.Print("ererer");
		if(placed == false)
		{
		if(Input.IsMouseButtonPressed(MouseButton.Left))
		{
			GD.Print("erm");
			pressed = true;
			while(Input.IsMouseButtonPressed(MouseButton.Left))
			{
				Vector2 mousePos = GetGlobalMousePosition();
				Position = mousePos;
			}
			released = true;
			if(pressed == false)
			{
				if(collide == false)
				{
					placed = true;
				}else
				{
					Position = new Vector2(1002, 43);
					collide = false;
				}
			}
		}
		}
		if(area.Position.X >= cloneDart.Position.X)
				{
					if(area.Position.Y >= cloneDart.Position.Y)
					{
						cloneDart.Position = new Vector2(cloneDart.Position.X + speed, cloneDart.Position.Y + speed);
					}else
					{
						cloneDart.Position = new Vector2(cloneDart.Position.X + speed, cloneDart.Position.Y - speed);
					}
				}else
				{
					if(area.Position.Y >= cloneDart.Position.Y)
					{
						cloneDart.Position = new Vector2(cloneDart.Position.X - speed, cloneDart.Position.Y + speed);
					}else
					{
						cloneDart.Position = new Vector2(cloneDart.Position.X - speed, cloneDart.Position.Y - speed);
					}
					if(badder.Position.X >= stuff.Position.X)
				{
					if(badder.Position.Y >= stuff.Position.Y)
					{
						stuff.Position = new Vector2(stuff.Position.X + speed, stuff.Position.Y + speed);
					}else
					{
						stuff.Position = new Vector2(stuff.Position.X + speed, stuff.Position.Y - speed);
					}
				}else
				{
					if(badder.Position.Y >= stuff.Position.Y)
					{
						stuff.Position = new Vector2(stuff.Position.X - speed, stuff.Position.Y + speed);
					}else
					{
						stuff.Position = new Vector2(stuff.Position.X - speed, stuff.Position.Y - speed);
					}
				}
*/
