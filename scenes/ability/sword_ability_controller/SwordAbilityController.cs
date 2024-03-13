using Godot;
using System;

public partial class SwordAbilityController : Node
{
	[Export]
	public PackedScene SwordAbility;

	public override void _Ready()
	{
		GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
	}

	private void OnTimerTimeout()
	{
		var player = GetTree().GetFirstNodeInGroup("player") as Node2D;
		if(player == null) return;
		
		var sword_instance = SwordAbility.Instantiate() as Node2D;
		player.GetParent().AddChild(sword_instance);
		sword_instance.GlobalPosition = player.GlobalPosition;
	}
}
