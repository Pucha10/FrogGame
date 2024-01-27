using Godot;
using System;

public partial class endLevel : Area2D
{
	[Export]
	public PackedScene targetLevel;
	[Export]
	public GameManager gameManager;

	public void onBodyEntered(Node2D body)
	{
		GD.Print(gameManager.bananaCounter);
		if (body.Name == "CharacterBody2D" && gameManager.bananaCounter == 0)
		{
			CallDeferred("changeScene");
		}
	}

	private void changeScene()
	{
		GetTree().ChangeSceneToPacked(targetLevel);
	}
}

