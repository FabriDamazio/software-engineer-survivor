using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export]
	public float MaxHealth = 10;

	[Signal]
	public delegate void DiedEventHandler();

	public float CurrentHealth { get; set; }

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;
	}

	public void Damage(float damage)
	{
		CurrentHealth = Math.Max(CurrentHealth - damage, 0);
		Callable callable = new Callable(this, nameof(CheckDeath));
		callable.CallDeferred();
	}

	private void CheckDeath()
	{
		if (CurrentHealth <= 0)
		{
			EmitSignal(SignalName.Died);
			Owner.QueueFree();
		}
	}
}
