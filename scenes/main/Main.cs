using Godot;
using System;

public partial class Main : Node
{
	[Export]
	public PackedScene EndScreenScene {get; set;}

	public override void _Ready()
	{
		GetNode<Player>("%Player").HealthComponent.Died += OnPlayerDied;
	}

	public override void _Process(double delta)
	{
	}

	private void OnPlayerDied()
	{
		EndScreen endScreenInstance = EndScreenScene.Instantiate<EndScreen>();
		AddChild(endScreenInstance);
		endScreenInstance.SetDefeat();
	}
}
