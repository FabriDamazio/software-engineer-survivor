using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private const float MAX_SPEED = 200;
	
	public override void _Process(double delta)
	{
		Vector2 direction = GetMovementVector().Normalized();
		Velocity = direction * MAX_SPEED;
		MoveAndSlide();
	}

	public static Vector2 GetMovementVector()
	{		
		float xMovement = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
		float yMovement = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");

		return new Vector2(xMovement, yMovement);
	}
}
