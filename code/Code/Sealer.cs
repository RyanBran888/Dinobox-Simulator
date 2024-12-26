using Godot;
using System;

public partial class Sealer : Area2D
{
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
	private int sell = 500;
	private int speedLevel = 1;
	private int rangeLevel = 1;
	private int speedUpPrice = 50;
	private int rangeUpPrice= 50;
	private int rangeScale = 5;
	private Sprite2D ran;
	private Sprite2D target;
	private Vector2 closestDistance;
	private int check = 0;
	private int copy = 0;
	public override void _Ready()
	{
		check = 0;
		stillTick = 0;
		prePos = Vector2.Zero;
		speed = 2f;
		copy++;
		GD.Print(copy);
		ran = GetNode<Sprite2D>("../Sprite2D");
		dartt = (Script)ResourceLoader.Load("res://Dart.cs");
		dart = GetNode<Sprite2D>("../Pixil-frame-0(1)2");
		are = GetNode<CollisionShape2D>("../Area2D3/Area2D/CollisionShape2D2");
		range = GetNode<Sprite2D>("../Sprite2D");
		closestDistance = new Vector2(1000, 1000);
		target = null;
		basic = new PopupMenu();
		AddChild(basic);
		timer = new Timer();
		AddChild(timer);
		basic.Connect("id_pressed", new Callable(this, nameof(IdClicked)));
		basic.Connect("mouse_exited", new Callable(this, nameof(Popout)));
		basic.Connect("mouse_entered", new Callable(this, nameof(popin)));
		}
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
		are.Scale = new Vector2(rangeScale, rangeScale);
		if(are == null)
		{
			GD.Print("AREEEEE");
		}
		if(ran == null)
		{
			GD.Print("RAAAAAN");
		}
		ran.Scale = are.Scale;
		if(speedLevel == 2)
		{
			speed = 2.5f;
			speedUpPrice = 300;
		}else if(speedLevel == 3)
		{
			speed = 2.75f;
			speedUpPrice = 500;
		}else if(speedLevel == 4)
		{
			speed = 3f;
			speedUpPrice = 1000;
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
		if(hover)
		{
			range.Scale = new Vector2(rangeScale, rangeScale);
			range.Position = Position;
			range.Visible = true;
		}
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
		if(Input.IsMouseButtonPressed(MouseButton.Left) && GameManager.TDstamps >= 1000)
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
			if(collide == false)
			{
				Area2D clone = (Area2D)Duplicate();
				GetParent().AddChild(clone);
				clone.Position = new Vector2(1053, 317);
				GameManager.TDstamps -= 1000;
				placed = true;
			}else
			{
				Position = new Vector2(1053, 317);
				collide = true;
			}
			released = true;
			runningPress = false;
			HackMinDev.PICKINGUP = false;
			}
		
		
	}
	private void popup()
	{
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
			if(rangeLevel <= 4)
			{
				basic.AddItem("Upgrade Range Currently Level: " + rangeLevel + " for: " + rangeUpPrice, 3);
			}else
			{
				basic.AddItem("Range Maxed" + rangeUpPrice, 3);
			}
			
			
			basic.Popup(new Rect2I(new Vector2I((int)Position.X + 50, (int)Position.Y), new Vector2I(1, 1)));

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
	public void OnHover()
	{
		hover = true;

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
	public void popin()
	{
		hover2 = true;
	}
	public void Popout()
	{
		hover2 = false;
		timer.Start(0.01f);
		if(!hover)
		{
	
		}
	}
	public void popoutout()
	{
		basic.Hide();
	}
	public void createThing()
	{
	
	}
	private void BaddieEnter(Area2D area)
	{
		if(placed && !shooting)
		{
			notHit = true;
			shooting = true;
			CallDeferred(nameof(makeClone), area);
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
