using Godot;
using System;

public partial class GameManager : Node
{
	private Label pointsLabel;
	private Label livesLabel;
	private Label bananaLabel;
	private Node2D startingPosition;
	public int bananaCounter;
	private CanvasLayer ui;
	[Export]
	public main_character hero;
	private float damageCooldown = 1.0f;


	public override void _Ready()
	{
		ui = GetNode<CanvasLayer>("%UI");
		startingPosition = GetNode<Node2D>("%StartingPosition");
		pointsLabel = ui.GetChild(0).GetChild(0) as Label;
		livesLabel = ui.GetChild(0).GetChild(1) as Label;
		bananaLabel = ui.GetChild(0).GetChild(2) as Label;
		bananaCounter = GetNode<Node>("%BananaParent").GetChildCount();
		hero.Transform = startingPosition.Transform;
		pointsLabel.Text = Global.points.ToString();
		livesLabel.Text = Global.lives.ToString();
		bananaLabel.Text = bananaCounter.ToString();
	}
	public void AddCherriesPoints()
	{
		Global.points += 1;
		if (Global.points == 10)
		{
			Global.lives += 1;
			Global.points = 0;
			livesLabel.Text = Global.lives.ToString();
		}
		pointsLabel.Text = Global.points.ToString();
	}
	public void decreaseBananaCount()
	{
		bananaCounter--;
		bananaLabel.Text = bananaCounter.ToString();
	}
	public void DoDamage()
	{
		hero.Transform = startingPosition.Transform;
		if (hero.canTakeDamage)
		{
			hero.canTakeDamage = false;
			if (Global.lives == 0)
			{
				CallDeferred("endGame");
				return;
			}
			hero.Velocity = new Vector2(0, 0);
			Global.lives--;
			livesLabel.Text = Global.lives.ToString();
			startDamageCooldown();
		}

	}
	private void endGame()
	{
		GetTree().ChangeSceneToFile("res://scenes/Option Scenes/LoseScene.tscn");
	}
	private async void startDamageCooldown()
	{
		await
		ToSignal(GetTree().CreateTimer(damageCooldown), "timeout");
		hero.canTakeDamage = true;
	}
}
