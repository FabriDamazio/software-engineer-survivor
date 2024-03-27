using Godot;
using System;

public partial class SwordAbility : Node2D
{
	public HitBoxComponent HitBoxComponent { get; set; }
	public override void _Ready()
	{
		HitBoxComponent = GetNode<HitBoxComponent>("HitBoxComponent");
	}
}
