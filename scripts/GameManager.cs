using Godot;
using System;

public partial class GameManager : Node
{
	private Label pointsLabel;
	private Label livesLabel;
	private Label bananaLabel;
	private Label armorLabel;
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
		armorLabel = ui.GetChild(0).GetChild(3) as Label;
		bananaCounter = GetNode<Node>("%BananaParent").GetChildCount();
		hero.Transform = startingPosition.Transform;
		armorLabel.Text = Global.armor.ToString();
		pointsLabel.Text = Global.points.ToString();
		livesLabel.Text = Global.lives.ToString();
		bananaLabel.Text = bananaCounter.ToString();
	}
	public void AddCherriesPoints(uint i)
	{
		Global.points += i;
		if (Global.points == 10)
		{
			Global.lives += 1;
			Global.points = 0;
			livesLabel.Text = Global.lives.ToString();
		}
		pointsLabel.Text = Global.points.ToString();
	}
	public void DecreaseBananaCount()
	{
		bananaCounter--;
		bananaLabel.Text = bananaCounter.ToString();
	}
	public void AddArmor()
	{
		Global.armor++;
		armorLabel.Text = Global.armor.ToString();
	}
	public void DoDamage()
	{
		if (hero.canTakeDamage)
		{
			if (Global.armor > 0)
			{
				hero.StartDamageCooldown();
				Global.armor--;
				armorLabel.Text = Global.armor.ToString();
			}
			else
			{
				DoLiveDamage();
			}
		}
	}
	public void DoLiveDamage()
	{
		hero.StartDamageCooldown();
		hero.Transform = startingPosition.Transform;
		if (Global.lives == 0)
		{
			CallDeferred("EndGame");
			return;
		}
		hero.Velocity = new Vector2(0, 0);
		Global.lives--;
		livesLabel.Text = Global.lives.ToString();
	}
	private void EndGame()
	{
		GetTree().ChangeSceneToFile("res://scenes/Option Scenes/LoseScene.tscn");
	}
}
