using Godot;
using System;
using System.Diagnostics.Tracing;

public partial class plant : AnimatedSprite2D
{
	private GameManager gameManager;
	private bool isPlayerOnTriggerArea = false;
	private Node2D bulletRespawn;
	[Export]
	public PackedScene bullet;
	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");
		bulletRespawn = GetChild<Node2D>(4);
	}
	public override void _Process(double delta)
	{
		if (isPlayerOnTriggerArea && Animation != "Hit")
		{
			Play("Attack");
		}
	}
	public void OnLeftTriggerAreaBodyEntered(Node2D body)
	{
		isPlayerOnTriggerArea = true;
	}
	public void OnRightTriggerAreaBodyEntered(Node2D body)
	{
		Scale = new Vector2(-Scale.X, Scale.Y);
	}
	public void OnLeftTriggerAreaBodyExited(Node2D body)
	{
		isPlayerOnTriggerArea = false;
	}

	public void OnHitAreaBodyEntered(CharacterBody2D body)
	{
		if (body.Velocity.Y > 0)
		{
			Animation = "Hit";
			body.Velocity = new Vector2(body.Velocity.X, -900);
			gameManager.AddCherriesPoints(3);
		}
	}
	public void OnDamageAreaBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D" && Animation != "Hit")
		{
			gameManager.DoDamage();
		}
	}
	public void OnAnimationFinished()
	{
		if (Animation == "Hit")
		{
			QueueFree();
		}
		if (Animation == "Attack")
		{
			respawnBullet();
			Play("Iddle");
		}
	}
	private void respawnBullet()
	{
		Bullet newBullet = bullet.Instantiate<Bullet>();
		newBullet.gameManager = gameManager;
		if (Scale.X > 0)
		{
			newBullet.isLeft = true;
		}
		else
		{
			newBullet.isLeft = false;
		}
		bulletRespawn.AddChild(newBullet);
	}
}
