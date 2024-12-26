using Godot;
using System;
/*
public partial class CLone : Area2D
{
	//private Script click;
	private PackedScene ThisOne;
	public override void _Ready()
	{
		ThisOne = (PackedScene)ResourceLoader.Load("res://TowerDef.tscn");
	}
	public void OnHoverr()
	{
		CloneObject();
	}
	private void CloneObject()
	{
		Node2D clone = (Node2D)ThisOne.Instantiate();
		GetParent().AddChild(clone);
	//	clone.DetatchScript("res://CLone.cs");
	//	clone.RemoveChild(res://CLone.cs");
		//clone.SetScript("res:ClickedAndMoved.cs");
		//Visible = false;
		//clone.Visible = false;
		//if(clone != null)
		//{
		//	GD.Print("ededjedjde");
		//}
		ClickedAndMoved clickAndMoveScript = new ClickedAndMoved();
		clone.AddChild(clickAndMoveScript);
		clone.SetScript(clickAndMoveScript);
	//	clone.SetScript(ClickedAndMoved);
		clone.Connect("mouse_entered", this, nameof(OnHover));

		// Connect the mouse_exited signal to the HoverExit method of the clone
		clone.Connect("mouse_exited", this, nameof(HoverExit));

		// Connect the area_entered signal to the OnEntered method of the clone
		clone.Connect("area_entered", this, nameof(OnEntered));
		// Connect the area_exited signal to the OnExited method of the clone
		clone.Connect("area_exited", this, nameof(OnExited));
	}
}		
//why is this so hard i hate this so much im going to explode AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH this sucks AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH if your reading this your very cool and pretty AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH ok you can stop reading now AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH ok fr tho AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
*/
