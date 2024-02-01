using Godot;
using System;

public partial class spike_ball : RigidBody2D
{
	private GameManager gameManager;
	[Export]
	public float xVelocity;
	[Export]
	public float yVelocity;
	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");
		LinearVelocity = new Vector2(xVelocity, yVelocity);

	}
	public void OnBodyEntered(Node2D body)
	{
		if ((LinearVelocity.X < 0 && xVelocity > 0) || (LinearVelocity.X > 0 && xVelocity < 0))
		{
			xVelocity = -xVelocity;
		}

		if ((LinearVelocity.Y < 0 && yVelocity > 0) || (LinearVelocity.Y > 0 && yVelocity < 0))
		{
			yVelocity = -yVelocity;
		}
		// xVelocity = -xVelocity;
		// yVelocity = -yVelocity;
		LinearVelocity = new Vector2(xVelocity, yVelocity);
		if (body.Name == "CharacterBody2D")
		{
			gameManager.DoDamage();
		}
	}

}
