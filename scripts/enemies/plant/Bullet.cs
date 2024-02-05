using Godot;
using System;
using System.Collections;

public partial class Bullet : RigidBody2D
{
	public GameManager gameManager;
	public bool isLeft;

	public override void _Ready()
	{
		if (isLeft)
		{
			LinearVelocity = new Vector2(-600, 0);
		}
		else
		{
			LinearVelocity = new Vector2(600, 0);
		}
	}

	public void OnDamageAreaBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			gameManager.DoDamage();
		}
		QueueFree();

	}
}
