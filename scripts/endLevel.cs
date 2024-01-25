using Godot;
using System;

public partial class endLevel : Area2D
{
	[Export]
	public PackedScene targetLevel;

	public void onBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			CallDeferred("changeScene");
		}
	}

	private void changeScene()
	{
		GetTree().ChangeSceneToPacked(targetLevel);
	}
}

