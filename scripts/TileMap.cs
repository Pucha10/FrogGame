using Godot;
using System;

public partial class TileMap : Godot.TileMap
{
	private TileMap tileMap;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tileMap = GetNode<TileMap>("%TileMap");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
