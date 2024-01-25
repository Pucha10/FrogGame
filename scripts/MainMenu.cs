using Godot;
using System;

public partial class MainMenu : Node
{
	public override void _Ready()
	{
		Global.lives = 3;
		Global.points = 0;
	}
	public void onButtonPressed1()
	{
		GetTree().ChangeSceneToFile("res://scenes/level1.tscn");
	}
	public void onButtonPressed2()
	{
		GetTree().Quit();
	}
}
