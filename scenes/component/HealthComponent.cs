using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export]
	public float MaxHealth = 10;

	[Signal]
	public delegate void DiedEventHandler();

	[Signal]
	public delegate void HealthChangedEventHandler();

	public float CurrentHealth { get; set; }

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;
	}

	public void Damage(float damage)
	{
		CurrentHealth = Math.Max(CurrentHealth - damage, 0);
		Callable callable = new Callable(this, nameof(CheckDeath));
		EmitSignal(SignalName.HealthChanged);
		callable.CallDeferred();
	}

	public float GetHealthPercent()
	{
		if(MaxHealth <= 0) return 0;

		return Math.Min(CurrentHealth / MaxHealth, 1);
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
