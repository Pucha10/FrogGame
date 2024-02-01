using Godot;
using System;

public partial class SpikeBallsParrent : Node
{

	public void ResetChildren()
	{
		GD.Print("Reset dzieci");
		foreach (RigidBody2D child in GetChildren())
		{
			GD.Print("Tutaj jestem");
			GD.Print(child.LinearVelocity);
			child.Position = new Vector2(0, 0);
		}
	}
}

