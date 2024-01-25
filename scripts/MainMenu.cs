using Godot;
using System;

public partial class MainMenu : Node
{
	public void onButtonPressed1()
	{
		GetTree().ChangeSceneToFile("res://scenes/level1.tscn");
	}
	public void onButtonPressed2()
	{
		GetTree().ChangeSceneToFile("res://scenes/level2.tscn");

	}
}
