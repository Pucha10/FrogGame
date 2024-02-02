using Godot;
using System;

public partial class saw : Area2D
{
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;
	private GameManager gameManager;
	private Timer timer;

	public override void _Ready()
	{
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
		collisionShape2D = GetChild<CollisionShape2D>(1);
		timer = GetChild<Timer>(2);
		gameManager = GetNode<GameManager>("%GameManager");
		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D" && animatedSprite2D.Animation == "On")
		{
			gameManager.DoDamage();
		}
	}
	public void OnTimerTimeout()
	{
		animatedSprite2D.Animation = "On";
	}
}
