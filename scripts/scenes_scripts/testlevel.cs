using Godot;
using System;

public partial class testlevel : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Global.lives = 999;
		Global.armor = 0;
	}


}
