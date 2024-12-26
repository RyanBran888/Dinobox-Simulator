using Godot;
using System;

public partial class Zen : Area2D
{
	private bool shooting = false;
	public static int numbe = 0;
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
	private int sell = 1000;
	private int speedLevel = 1;
	private int speedUpPrice = 50;
	private Sprite2D seal;
	private int check = 0;
	private int x = 0;
	public override void _Ready()
	{
		check = 0;
		x = 0;
		seal = GetNode<Sprite2D>("../Seal2");
		speed = 0.25f;
		basic = new PopupMenu();
		AddChild(basic);
		timer = new Timer();
		AddChild(timer);
		seall = null;
	}
	public override void _Process(double delta)
	{
		if(released == true)
		{
			pressed = false;
			released = false;
		}
		if(hover && placed && Input.IsMouseButtonPressed(MouseButton.Left))
		{
			popup();
		}
		if(Input.IsMouseButtonPressed(MouseButton.Left) && GameManager.TDstamps >= 2000)
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
				numbe++;
				Area2D clone = (Area2D)Duplicate();
				GetParent().AddChild(clone);
				clone.Position = new Vector2(1053, 425);
				GameManager.TDstamps -= 2000;
				placed = true;
			}else
			{
				Position = new Vector2(1053, 425);
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
		}
	}
	public void OnHover()
	{
		hover = true;
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

}
