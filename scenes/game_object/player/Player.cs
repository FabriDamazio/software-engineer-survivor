using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float MaxSpeed = 125;
	private const float AcelerationSmoothing = 25;
	private int _numberCollidingBodies = 0;
	private Timer _damageIntervalTimer;

	public override void _Ready()
	{
		_damageIntervalTimer = GetNode<Timer>("DamageIntervalTimer");
		_damageIntervalTimer.Timeout += OnDamageIntervalTimerTimeout;
		GetNode<Area2D>("CollisionArea2D").BodyEntered += OnBodyEntered;
		GetNode<Area2D>("CollisionArea2D").BodyExited += OnBodyExited;
	}

    public override void _Process(double delta)
	{
		Vector2 direction = GetMovementVector().Normalized();
		Vector2 targetVelocity = direction * MaxSpeed;
		Velocity = Velocity.Lerp(targetVelocity,  1 - (float)Math.Exp(-delta * AcelerationSmoothing));

		MoveAndSlide();
	}

	public static Vector2 GetMovementVector()
	{		
		float xMovement = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		float yMovement = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");

		return new Vector2(xMovement, yMovement);
	}

	private void CheckDealDamage()
	{
		if (_numberCollidingBodies == 0 || !_damageIntervalTimer.IsStopped()) return;
				
		GetNode<HealthComponent>("HealthComponent").Damage(1);
		_damageIntervalTimer.Start();
	}

	
    private void OnBodyEntered(Node2D otherBody)
    {
		_numberCollidingBodies++;
		CheckDealDamage();
    }

	
    private void OnBodyExited(Node2D body)
    {
        _numberCollidingBodies--;
    }

	
    private void OnDamageIntervalTimerTimeout()
    {
        CheckDealDamage();
    }

}
