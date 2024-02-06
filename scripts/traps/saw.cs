using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public partial class saw : Area2D
{
	[Export]
	public int timeOn;
	[Export]
	public int timeOff;
	private AnimatedSprite2D animatedSprite2D;
	private CollisionShape2D collisionShape2D;
	private GameManager gameManager;
	private Timer timer;
	private List<lever> levers = new List<lever>();
	public bool isStopped = false;

	public override void _Ready()
	{
		animatedSprite2D = GetChild<AnimatedSprite2D>(0);
		collisionShape2D = GetChild<CollisionShape2D>(1);
		timer = GetChild<Timer>(2);
		gameManager = GetNode<GameManager>("%GameManager");
		if (timeOn > 0)
		{
			timer.WaitTime = timeOn;
			timer.Start();
		}
		foreach (Node child in GetChildren())
		{
			if (child is lever)
			{
				levers.Add((lever)child);
			}
		}
	}
	public void SetOffAnimation()
	{
		int couter = 0;
		foreach (lever lever in levers)
		{
			if (lever.isOpen)
			{
				couter++;
			}
		}
		if (couter == levers.Count)
		{
			animatedSprite2D.Animation = "Off";
			isStopped = true;
		}
	}
	public void SetOnAnimation()
	{
		int couter = 0;
		foreach (lever lever in levers)
		{
			if (lever.isOpen)
			{
				couter++;
			}
		}
		if (couter != levers.Count)
		{
			animatedSprite2D.Animation = "On";
		}
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
		if (animatedSprite2D.Animation == "On")
		{
			animatedSprite2D.Animation = "Off";
			timer.WaitTime = timeOff;
		}
		else
		{
			animatedSprite2D.Animation = "On";
			timer.WaitTime = timeOn;
		}
	}
}
