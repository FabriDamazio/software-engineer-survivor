using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class SwordAbilityController : Node
{
	[Export]
	private float MaxRange = 150;

	[Export]
	public PackedScene SwordAbility;

	private float _damage = 5;
	private double _baseWaitTime = 1.5;

	public override void _Ready()
	{
		var timer = GetNode<Timer>("Timer");
		timer.Timeout += OnTimerTimeout;
		_baseWaitTime = timer.WaitTime;

		var gameEvents = GetNode<GameEvents>("/root/GameEvents");
		gameEvents.AbilityUpgradeAdded += OnAbilityUpgradeAdded;
	}

	private void OnTimerTimeout()
	{
		var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if(player is null) return;

		var enemies = GetTree().GetNodesInGroup("enemy").OfType<Node2D>();
		var closeEnemies = enemies.Where(x => 
			x.GlobalPosition.DistanceSquaredTo(player.GlobalPosition) < Math.Pow(MaxRange, 2)
		).ToList();

		if(closeEnemies.Count == 0) return;

		closeEnemies.Sort((a,b) =>
			a.GlobalPosition.DistanceSquaredTo(player.GlobalPosition).CompareTo(
				b.GlobalPosition.DistanceSquaredTo(player.GlobalPosition)
			)
		);
		
		var swordInstance = SwordAbility.Instantiate() as SwordAbility;
		player.GetParent().AddChild(swordInstance);
		swordInstance.HitBoxComponent.Damage = _damage;
		swordInstance.GlobalPosition = closeEnemies.FirstOrDefault().GlobalPosition;
		swordInstance.GlobalPosition += Vector2.Right.Rotated(new Random().Next(0, 6)) * 4;

		var enemyDirection = closeEnemies.FirstOrDefault().GlobalPosition = swordInstance.GlobalPosition;
		swordInstance.Rotation = enemyDirection.Angle();
	}

	private void OnAbilityUpgradeAdded(AbilityUpgrade upgrade, Dictionary<string, Dictionary<AbilityUpgrade, int>> currentUpgrades)
	{
		if(upgrade.Id != "sword_rate") return;

		double percentReduction = currentUpgrades["sword_rate"].Values.Sum() * 0.1d;
		var timer = GetNode<Timer>("Timer");
		timer.WaitTime = _baseWaitTime * (1 - percentReduction);
		timer.Start();		
	}
}
