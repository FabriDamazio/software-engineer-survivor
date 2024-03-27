using Godot;
using System;

public partial class ExperienceVial : Node2D
{
	public override void _Ready()
	{
		GetNode<Area2D>("Area2D").AreaEntered += OnAreaEntered;
	}

	private void OnAreaEntered(Area2D area)
	{		
		QueueFree();
	}

}
