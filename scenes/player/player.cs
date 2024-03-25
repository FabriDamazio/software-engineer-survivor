using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float MaxSpeed = 125;
	private const float AcelerationSmoothing = 25;
	
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
}
