using Godot;
using System;

public partial class flames : Node
{
	[Export]
	public int frame = 0;
	[Export]
	public float speedScale = 1;
	private GameManager gameManager;
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;

	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
		collisionShape2D = GetChild<CollisionShape2D>(1);
		animatedSprite2D.Frame = frame;
		animatedSprite2D.SpeedScale = speedScale;
	}
	public override void _Process(double delta)
	{
		if (animatedSprite2D.Frame == 0)
		{
			collisionShape2D.Disabled = true;
		}
		else
		{
			collisionShape2D.Disabled = false;

		}
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			gameManager.DoDamage();
		}
	}
}
