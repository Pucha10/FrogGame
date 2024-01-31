using Godot;
using System;

public partial class falling_platform : RigidBody2D
{
	private AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		animationPlayer = GetChild<AnimationPlayer>(3);
	}

	public void OnBodyEntered(Node2D body)
	{
		GD.Print("Ready");
		if (body.Name == "CharacterBody2D")
		{
			animationPlayer.Play("shake");
		}
	}
}
