using Godot;
using System;

public partial class endLevel : Area2D
{
	[Export]
	public PackedScene targetLevel;
	public void onBodyEntered(Node2D body)
	{
		GD.Print("Hello");
		if (body.Name == "CharacterBody2D")
		{
			QueueFree();
			GetTree().ChangeSceneToPacked(targetLevel);
		}
	}
}

