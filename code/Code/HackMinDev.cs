using Godot;
using System;

public partial class HackMinDev : Area2D
{
	private bool shooting = false;
	private Sprite2D clockk;
	private float speed;
	private bool runningPress = false;
	private bool pressed = false;
	private bool released = false;
	private bool collide = true;
	private bool placed = false;
	private bool hover = false;
	private bool hover2 = false;
	public static bool PICKINGUP = false;
	private CollisionShape2D are;
	private PopupMenu basic;
	private Timer timer;
	private Area2D badder;
	private int sell = 100;
	private int speedLevel = 1;
	private int speedUpPrice = 50;
	private int dir = 0;
	private Sprite2D Clock;
	private int x = 0;
	private int check = 0;
	public override void _Ready()
	{
		check = 0;
		x = 0;
		Clock = GetNode<Sprite2D>("../Clock");
		speed = 0.25f;
		dir = 0;
		basic = new PopupMenu();
		AddChild(basic);
		timer = new Timer();
		AddChild(timer);
		basic.Connect("id_pressed", new Callable(this, nameof(IdClicked)));
		basic.Connect("mouse_exited", new Callable(this, nameof(Popout)));
		basic.Connect("mouse_entered", new Callable(this, nameof(popin)));
		clockk = null;
	}
	private void edge(Area2D area)
	{
		clockk.QueueFree();
		clockk = null;
		shooting = false;
		clone();
	}
	private void TargetHit(Area2D area)
	{
		area.GetParent().QueueFree();
		clockk.QueueFree();
		clockk = null;
		GameManager.TDstamps += 1;
		GameManager.TDpoints++;
		shooting = false;
		clone();
	}
	public override void _Process(double delta)
	{
		if(x == 0 && placed)
		{
			GD.Print("EEERRRMM");
			clone();
			x++;
		}
		if(clockk != null)
		{
			if(dir == 1)
			{
				clockk.Position = new Vector2(clockk.Position.X - speed, clockk.Position.Y);
				if(clockk.Rotation == 360)
				{
					clockk.Rotation = 0;
				}else
				{
					clockk.Rotation++;
				}
			}else if(dir == 2)
			{
				clockk.Position = new Vector2(clockk.Position.X + speed, clockk.Position.Y);
				if(clockk.Rotation == 360)
				{
					clockk.Rotation = 0;
				}else
				{
					clockk.Rotation++;
				}
			}else if(dir == 3)
			{
				clockk.Position = new Vector2(clockk.Position.X, clockk.Position.Y - speed);
				if(clockk.Rotation == 360)
				{
					clockk.Rotation = 0;
				}else
				{
					clockk.Rotation++;
				}
			}else if(dir == 4)
			{
				clockk.Position = new Vector2(clockk.Position.X, clockk.Position.Y + speed);
				if(clockk.Rotation == 360)
				{
					clockk.Rotation = 0;
				}else
				{
					clockk.Rotation++;
				}
			}
		}
		if(speedLevel > 1)
		{
			sell = speedUpPrice/2 + 50;
		}else if(speedLevel > 1)
		{
			sell = speedUpPrice/2 + 50;
		}
		if(speedLevel == 2)
		{
			speed = 0.5f;
			speedUpPrice = 100;
		}else if(speedLevel == 3)
		{
			speed = 0.75f;
			speedUpPrice = 200;
		}else if(speedLevel == 4)
		{
			speed = 1f;
			speedUpPrice = 350;
		}
		if(released == true)
		{
			pressed = false;
			released = false;
		}
		if(hover && placed && Input.IsMouseButtonPressed(MouseButton.Left))
		{
			popup();
		}
		if(Input.IsMouseButtonPressed(MouseButton.Left) && GameManager.TDstamps >= 200)
		{
		if(hover == true && !placed && (!PICKINGUP || check == 1))
		{
			check = 1;
			Vector2 mousePos = GetGlobalMousePosition();
			Position = mousePos;
			pressed = true;
			PICKINGUP = true;
		}
		}else if(pressed)
		{
			check = 0;
			if(collide == false)
			{
				Area2D clone = (Area2D)Duplicate();
				GetParent().AddChild(clone);
				clone.Position = new Vector2(1102, 43);
				GameManager.TDstamps -= 200;
				placed = true;
			}else
			{
				Position = new Vector2(1102, 43);
				collide = true;
			}
			released = true;
			PICKINGUP = false;
			}
	}
	private void popup()
	{
			basic.Clear();
			basic.AddItem("Sell: $" + sell, 1);
			if(speedLevel <= 4)
			{
				basic.AddItem("Upgrade Speed Currently Level: " + speedLevel + " for: " + speedUpPrice, 2);
			}else
			{
				basic.AddItem("Speed Maxed", 2);
			}
				basic.AddItem("Shoot Left", 3);
				basic.AddItem("Shoot Right", 4);
				basic.AddItem("Shoot Up", 5);
				basic.AddItem("Shoot Down", 6);
			basic.Popup(new Rect2I(new Vector2I((int)Position.X + 50, (int)Position.Y), new Vector2I(1, 1)));
	}
	private void IdClicked(int id)
	{
		switch (id)
		{
			case 1:
				GameManager.TDstamps += sell;
				clockk.QueueFree();
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
				dir = 1;
				break;
			case 4:
				dir = 2;
				break;
			case 5:
				dir = 3;
				break;
			case 6:
				dir = 4;
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
	}
	public void popoutout()
	{
			basic.Hide();
	}
	public void clone()
	{
		if(!shooting)
		{
		Sprite2D cloneClock = (Sprite2D)Clock.Duplicate();
		GetParent().AddChild(cloneClock);
		cloneClock.Position = Position;
		shooting = true;
		clockk = (Sprite2D)cloneClock;
		clockk.GetChild(0).Connect("area_entered", new Callable(this, nameof(TargetHit)));
		}
	}
			
}
