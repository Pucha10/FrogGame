using Godot;
using System;

public partial class GameManager : Node
{
	private Label pointsLabel;
	private Label livesLabel;
	private Node2D startingPosition;
	private CanvasLayer ui;
	[Export]
	public main_character hero;

	public override void _Ready()
	{
		GD.Print(Global.lives);
		ui = GetNode<CanvasLayer>("%UI");
		startingPosition = GetNode<Node2D>("%StartingPosition");
		pointsLabel = ui.GetChild(0).GetChild(0) as Label;
		livesLabel = ui.GetChild(0).GetChild(1) as Label;
		pointsLabel.Text = Global.points.ToString();
		livesLabel.Text = Global.lives.ToString();
	}
	public void AddPoints()
	{
		Global.points += 1;
		pointsLabel.Text = Global.points.ToString();
	}
	public void DoDamage()
	{
		hero.Transform = startingPosition.Transform;
		Global.lives--;
		livesLabel.Text = Global.lives.ToString();
		if (Global.lives < 0)
		{
			GetTree().ChangeSceneToFile("res://scenes/LoseScene.tscn");
		}

	}
}
