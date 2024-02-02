using Godot;
using System;
using System.ComponentModel.DataAnnotations;

public partial class main_character : CharacterBody2D
{
	public uint lives = Global.lives;
	public uint points = Global.lives;
	public Transform2D position;
	public float Speed = 300.0f;
	private float additionalSpeed;
	public float JumpVelocity = -900.0f;
	public float slize = 12f;
	private float additionalSlize;

	public bool canTakeDamage = true;
	private AnimatedSprite2D animatedSprite2D;
	private Node2D startingPosition;
	public Timer timer;


	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public override void _Ready()
	{
		animatedSprite2D = GetNode<AnimatedSprite2D>("%Sprite2D");
		startingPosition = GetParent().GetNode<Node2D>("%StartingPosition");
		timer = GetChild<Timer>(3);
		position = startingPosition.Transform;

	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		if (velocity.X != 0 && canTakeDamage)
		{
			animatedSprite2D.Animation = "running";
		}
		else if (canTakeDamage)
		{
			animatedSprite2D.Animation = "iddle";
		}

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			if (canTakeDamage)
			{
				animatedSprite2D.Animation = "jumping";

			}
		}
		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("left", "right");
		if (direction != 0)
		{
			velocity.X = direction * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, slize);
		}

		Velocity = velocity;
		MoveAndSlide();
		bool isLeft = velocity.X < 0;
		animatedSprite2D.FlipH = isLeft;

	}
	public void onTileSetDetectorBodyEntered(Node2D body)
	{
		if (body is TileMap)
		{
			TileMap tileMap = (TileMap)body;
			Vector2 playerPosition = GlobalPosition;
			Vector2I vector = tileMap.LocalToMap(body.ToLocal(playerPosition));
			vector.Y += 1;
			TileData tileData = tileMap.GetCellTileData(0, vector);
			if (!(tileData is null))
			{
				additionalSpeed = (float)tileData.GetCustomData("addSpeed");
				additionalSlize = (float)tileData.GetCustomData("addSlize");
				Speed += additionalSpeed;
				slize -= additionalSlize;
				return;
			}
			additionalSpeed = 0;
			additionalSlize = 0;
		}

	}
	public void onTileSetDetectorBodyExit(Node2D body)
	{
		Speed -= additionalSpeed;
		slize += additionalSlize;
		additionalSlize = 0;
		additionalSpeed = 0;
	}
	public void StartDamageCooldown()
	{
		timer.Start();
		canTakeDamage = false;
		animatedSprite2D.Play("hit");
	}
	public void OnTimeout()
	{
		canTakeDamage = true;
		GD.Print(JumpVelocity);
	}
}
