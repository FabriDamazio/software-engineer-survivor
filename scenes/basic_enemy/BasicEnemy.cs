using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	private const float MaxSpeed = 75;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Velocity = GetDirectionToPlayer() * MaxSpeed;
		MoveAndSlide();
	}

	private Vector2 GetDirectionToPlayer()
	{
		var playerNode = GetTree().GetFirstNodeInGroup("player") as Player;

		if(playerNode != null)
		{
			return (playerNode.GlobalPosition - GlobalPosition).Normalized();
		}

		return Vector2.Zero;
	}
}
