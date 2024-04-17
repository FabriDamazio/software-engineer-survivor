using Godot;
using System;

public partial class EnemyManager : Node
{

	[Export] 
	public PackedScene BasicEnemyScene;

	[Export] 
	public ArenaTimeManager ArenaTimeManager;
	
	private const float SpawnRadius = 375;
	private Timer _timer;
	private double _baseSpawnTime;

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
		_timer.Timeout += OnTimerTimeout;
		_baseSpawnTime = _timer.WaitTime;
		ArenaTimeManager.ArenaDifficultIncreased += OnArenaDifficultIncreased;
	}

	private void OnTimerTimeout()
	{
		_timer.Start();

		Player player = GetTree().GetFirstNodeInGroup("player") as Player;

		if(player is null) return;

		Vector2 randomDirection = Vector2.Right.Rotated((float)GD.RandRange(0, Math.Tau));
		Vector2 spawnPosition = player.GlobalPosition + (randomDirection * SpawnRadius);

		var enemy = BasicEnemyScene.Instantiate() as Node2D;
		Node entitiesLayer = GetTree().GetFirstNodeInGroup("entities_layer");
		entitiesLayer.AddChild(enemy);
		enemy.GlobalPosition = spawnPosition;
	}

	private void OnArenaDifficultIncreased(int arenaDifficult)
	{
		double timeOff = (0.1/12) * arenaDifficult;
		timeOff = Math.Min(timeOff, 0.7);
		GD.Print(timeOff);
		_timer.WaitTime = _baseSpawnTime - timeOff;
	}

}
