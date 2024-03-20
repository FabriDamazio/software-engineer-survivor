using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	private const float MaxSpeed = 75;
	public override void _Ready()
	{
		GetNode<Area2D>("Area2D").AreaEntered += OnAreaEntered;
	}

	public override void _Process(double delta)
	{
		Velocity = GetDirectionToPlayer() * MaxSpeed;
		MoveAndSlide();
	}

	private void OnAreaEntered(Area2D area)
	{
		QueueFree();
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
