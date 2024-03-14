using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public partial class SwordAbilityController : Node
{
	[Export]
	private float MaxRange = 150;

	[Export]
	public PackedScene SwordAbility;

	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
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
		
		var sword_instance = SwordAbility.Instantiate() as Node2D;
		player.GetParent().AddChild(sword_instance);
		sword_instance.GlobalPosition = closeEnemies.FirstOrDefault().GlobalPosition;
	}
}
