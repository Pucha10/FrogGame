using Godot;
using System;

public partial class falling_platform : RigidBody2D
{

	private AnimationPlayer animationPlayer;
	private CollisionShape2D collisionShape2D;
	private Timer timer;
	[Export]
	public int time = 5;

	public override void _Ready()
	{
		collisionShape2D = GetChild<CollisionShape2D>(1);
		animationPlayer = GetChild<AnimationPlayer>(3);
		timer = GetChild<Timer>(4);
	}
	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			animationPlayer.Play("shake");
		}
	}
	public void OnBodyExited(Node2D body)
	{
		if (body.Name == "CharacterBody2D")
		{
			timer.WaitTime = time;
			timer.Start();
		}
	}
	public void OnTimerTimeout()
	{
		GD.Print("Ready");
		LinearVelocity = new Vector2(0, 0);
		Position = new Vector2(0, 0);
		collisionShape2D.Disabled = false;
	}
	public void Fall()
	{
		LinearVelocity = new Vector2(0, 1000);
		collisionShape2D.Disabled = true;
	}
}
