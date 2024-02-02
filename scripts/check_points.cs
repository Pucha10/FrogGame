using Godot;
using System;

public partial class check_points : Area2D
{
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;
	private Node2D startingPosition;

	public override void _Ready()
	{
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
		collisionShape2D = GetChild<CollisionShape2D>(1);
		startingPosition = GetNode<Node2D>("%StartingPosition");
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			animatedSprite2D.Animation = "FlagIn";
		}
	}
	private void OnAnimationFinished()
	{
		animatedSprite2D.Play("FlagIddle");
		collisionShape2D.Disabled = true;
		startingPosition.Position = Position;
	}


}
