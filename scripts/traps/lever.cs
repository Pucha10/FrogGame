using Godot;
using System;

public partial class lever : Area2D
{
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;
	private GameManager gameManager;
	private Timer timer;
	private saw saw;
	[Export]
	public int timeToDeactive = 6;

	public bool isOpen = false;
	public override void _Ready()
	{
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
		collisionShape2D = GetChild<CollisionShape2D>(1);
		timer = GetChild<Timer>(2);
		saw = GetParent<saw>();
		timer.WaitTime = timeToDeactive;
		GD.Print(saw.isStopped);
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body.Name == "CharacterBody2D" && !isOpen)
		{
			animatedSprite2D.Animation = "On";
			timer.Start();
			isOpen = true;
			saw.SetOffAnimation();
		}
	}
	public void OnTimeout()
	{
		timer.Stop();
		if (!saw.isStopped)
		{
			animatedSprite2D.Animation = "Off";
			isOpen = false;
			saw.SetOnAnimation();
		}
	}
}
