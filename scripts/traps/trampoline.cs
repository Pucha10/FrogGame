using Godot;
using System;

public partial class trampoline : Area2D
{
	private GameManager gameManager;
	private AnimatedSprite2D animatedSprite2D;
	[Export]
	public float additionalJump = -1350f;

	public override void _Ready()
	{
		gameManager = GetNode<GameManager>("%GameManager");
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
	}
	public void OnBodyEntered(CharacterBody2D body)
	{
		Vector2 velocity = body.Velocity;
		animatedSprite2D.Animation = "jump";
		animatedSprite2D.Play();
		velocity.Y = additionalJump;
		body.Velocity = velocity;
	}
	private void OnAnimationFinished()
	{
		animatedSprite2D.Animation = "default";
	}
}
