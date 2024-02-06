using Godot;
using System;

public partial class blue_bird : RigidBody2D
{
	private GameManager gameManager;
	private AnimatedSprite2D animatedSprite2D;
	private float speed = 300;
	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");
		LinearVelocity = new Vector2(-speed, 0);
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);

	}
	private void OnTransformArea(Node2D body)
	{
		animatedSprite2D.Scale = new Vector2(-animatedSprite2D.Scale.X, animatedSprite2D.Scale.Y);
		if (speed > 0)
		{
			LinearVelocity = new Vector2(speed, 0);
			speed = -speed;
		}
		else
		{
			LinearVelocity = new Vector2(speed, 0);
			speed = -speed;
		}
	}
	private void OnHitAreaBodyEntered(CharacterBody2D body)
	{
		if (body.Velocity.Y > 0)
		{
			animatedSprite2D.Animation = "Hit";
			body.Velocity = new Vector2(body.Velocity.X, -900);
			LinearVelocity = new Vector2(LinearVelocity.X, 300);
			gameManager.AddCherriesPoints(3);
		}
	}
	public void OnDamageAreaBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D" && animatedSprite2D.Animation != "Hit")
		{
			LinearVelocity = new Vector2(speed, 0);
			animatedSprite2D.Scale = new Vector2(-animatedSprite2D.Scale.X, animatedSprite2D.Scale.Y);
			speed = -speed;
			gameManager.DoDamage();
		}
	}
	private void OnAnimationFinished()
	{
		QueueFree();
	}
}
