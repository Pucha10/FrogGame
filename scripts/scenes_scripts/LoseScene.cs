using Godot;
using System;

public partial class LoseScene : Node
{
	public void onButtonPressed1()
	{
		GetTree().ChangeSceneToFile("res://scenes/Option Scenes/MainMenu.tscn");
	}
	public void onButtonPressed2()
	{
		GetTree().Quit();
	}
}
