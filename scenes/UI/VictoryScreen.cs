using Godot;
using System;

public partial class VictoryScreen : CanvasLayer
{
	public override void _Ready()
	{
		GetTree().Paused = true;
		GetNode<Button>("%RestartButton").Pressed += OnRestartButtonPressed;
		GetNode<Button>("%QuitButton").Pressed += OnQuitButtonPressed;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnRestartButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://scenes/main/main.tscn");
	}
	
	private void OnQuitButtonPressed()
	{
		GetTree().Quit();
	}
}
