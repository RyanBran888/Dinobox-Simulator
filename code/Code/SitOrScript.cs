using Godot;
using System;

public partial class SitOrScript : Area2D
{
	private bool shooting = false;
	private Sprite2D seall;
	private float speed;
	private bool runningPress = false;
	private bool pressed = false;
	private bool released = false;
	private bool collide = true;
	private bool placed = false;
	private bool hover = false;
	private bool hover2 = false;
	private CollisionShape2D are;
	private PopupMenu basic;
	private Timer timer;
	private Area2D badder;
	private int sell = 300;
	private int speedLevel = 1;
	private int speedUpPrice = 50;
	private Sprite2D seal;
	private int check = 0;
	private int x = 0;
	public override void _Ready()
	{
		check = 0;
		x = 0;
		seal = GetNode<Sprite2D>("../Seal");
		speed = 0.25f;
		basic = new PopupMenu();
		AddChild(basic);
		timer = new Timer();
		AddChild(timer);
		seall = null;
		basic.Connect("id_pressed", new Callable(this, nameof(IdClicked)));
		basic.Connect("mouse_exited", new Callable(this, nameof(Popout)));
		basic.Connect("mouse_entered", new Callable(this, nameof(popin)));
	}
	private void TargetHit(Area2D area)
	{
		area.GetParent().QueueFree();
		GameManager.TDstamps += 1;
		GameManager.TDpoints++;
	}
	public override void _Process(double delta)
	{
		if(placed && x == 0)
		{
		x++;
		Sprite2D cloneSeal = (Sprite2D)seal.Duplicate();
		GetParent().AddChild(cloneSeal);
		cloneSeal.Position = new Vector2(Position.X + 50, Position.Y + 50);
		seall = (Sprite2D)cloneSeal;
		seall.GetChild(0).Connect("area_entered", new Callable(this, nameof(TargetHit)));
		}
		if(placed && seall != null)
		{
			if(seall.Position.X > Position.X && seall.Position.Y > Position.Y)
			{
				seall.Position = new Vector2(seall.Position.X - speed, seall.Position.Y + speed);
			}
			if(seall.Position.X <= Position.X && seall.Position.Y >= Position.Y)
			{
				seall.Position = new Vector2(seall.Position.X - speed, seall.Position.Y - speed);
			}
			if(seall.Position.X < Position.X && seall.Position.Y < Position.Y)
			{
				seall.Position = new Vector2(seall.Position.X + speed, seall.Position.Y - speed);
			}
			if(seall.Position.X >= Position.X && seall.Position.Y <= Position.Y)
			{
				seall.Position = new Vector2(seall.Position.X + speed, seall.Position.Y + speed);
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
		if(Input.IsMouseButtonPressed(MouseButton.Left) && GameManager.TDstamps >= 600)
		{
		if(hover == true && !placed && (!HackMinDev.PICKINGUP || check == 1))
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
			if(collide == false)
			{
				Area2D clone = (Area2D)Duplicate();
				GetParent().AddChild(clone);
				clone.Position = new Vector2(1006, 166);
				GameManager.TDstamps -= 600;
				placed = true;
			}else
			{
				Position = new Vector2(1006, 166);
				collide = true;
			}
			released = true;
			HackMinDev.PICKINGUP = false;
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
			basic.Popup(new Rect2I(new Vector2I((int)Position.X + 50, (int)Position.Y), new Vector2I(1, 1)));
	}
	private void IdClicked(int id)
	{
		switch (id)
		{
			case 1:
				GameManager.TDstamps += sell;
				seall.QueueFree();
				QueueFree();
				break;
			case 2:
				if(GameManager.TDstamps >= speedUpPrice && speedLevel <= 4)
				{
					GameManager.TDstamps -= speedUpPrice;
					speedLevel++;
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

}
