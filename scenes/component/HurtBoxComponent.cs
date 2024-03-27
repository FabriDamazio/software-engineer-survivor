using Godot;
using System;

public partial class HurtBoxComponent : Area2D
{
	[Export]
	public HealthComponent HealthComponent;

	public override void _Ready()
	{
		AreaEntered += OnAreaEntered;
	}

	public void OnAreaEntered(Area2D otherArea)
	{
		if(otherArea is not HitBoxComponent) return;

		if(HealthComponent == null) return;

		var hitBoxComponent = otherArea as HitBoxComponent;
		HealthComponent.Damage(hitBoxComponent.Damage);
	}
}
