using Godot;
using System;

public partial class armor : Area2D
{
	private GameManager gameManager;
	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			QueueFree();
			gameManager.AddArmor();
		}
	}

}

