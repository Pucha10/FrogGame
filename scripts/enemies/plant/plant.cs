using Godot;
using System;
using System.Diagnostics.Tracing;

public partial class plant : AnimatedSprite2D
{
	private GameManager gameManager;
	private bool isPlayerOnTriggerArea = false;

	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");

	}
	public override void _Process(double delta)
	{
		if (isPlayerOnTriggerArea && Animation != "Hit")
		{
			Play("Attack");
		}
		GD.Print(isPlayerOnTriggerArea);
	}
	public void OnLeftTriggerAreaBodyEntered(Node2D body)
	{
		isPlayerOnTriggerArea = true;
	}
	public void OnRightTriggerAreaBodyEntered(Node2D body)
	{
		isPlayerOnTriggerArea = true;
		if (Transform.Scale.X > 0)
		{
			Scale = new Vector2(-Scale.X, Scale.Y);
		}
	}
	public void OnLeftTriggerAreaBodyExited(Node2D body)
	{
		isPlayerOnTriggerArea = false;

	}
	public void OnRightTriggerAreaBodyExited(Node2D body)
	{
		isPlayerOnTriggerArea = false;
	}
	public void OnHitAreaBodyEntered(CharacterBody2D body)
	{
		if (body.Velocity.Y > 0)
		{
			Animation = "Hit";
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
			Play("Iddle");
		}
	}


}
