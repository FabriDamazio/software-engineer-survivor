using Godot;
using System;

public partial class EnemyManager : Node
{
	private const float SpawnRadius = 375;

	[Export] 
	public PackedScene BasicEnemyScene;

	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
	}

	private void OnTimerTimeout()
	{
		Player player = GetTree().GetFirstNodeInGroup("player") as Player;

		if(player is null) return;

		Vector2 randomDirection = Vector2.Right.Rotated((float)GD.RandRange(0, Math.Tau));
		Vector2 spawnPosition = player.GlobalPosition + (randomDirection * SpawnRadius);

		var enemy = BasicEnemyScene.Instantiate() as Node2D;
		GetParent().AddChild(enemy);
		enemy.GlobalPosition = spawnPosition;
	}

}
