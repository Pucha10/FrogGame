using Godot;
using System;

public partial class lever : Area2D
{
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;
	private GameManager gameManager;
	private saw saw;
	public bool isOpen = false;
	public override void _Ready()
	{
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
		collisionShape2D = GetChild<CollisionShape2D>(1);
		saw = GetParent<saw>();
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D" && !isOpen)
		{
			animatedSprite2D.Animation = "On";
			isOpen = true;
			saw.SetOffAnimation();
		}
	}
}
