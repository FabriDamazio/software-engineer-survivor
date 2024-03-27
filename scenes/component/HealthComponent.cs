using Godot;
using System;

public partial class HealthComponent : Node
{
	[Export]
	public float MaxHealth = 10;

	[Signal]
	public delegate void DiedEventHandler();

	private float _currentHealth;

	public override void _Ready()
	{
		_currentHealth = MaxHealth;
	}

	public void Damage(float damage)
	{
		_currentHealth = Math.Max(_currentHealth - damage, 0);
		Callable callable = new Callable(this, nameof(CheckDeath));
		callable.CallDeferred();
	}

	private void CheckDeath()
	{
		if (_currentHealth <= 0)
		{
			EmitSignal(SignalName.Died);
			Owner.QueueFree();
		}
	}
}
