using Godot;
using System;

public partial class EndScreen : CanvasLayer
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

	public void SetDefeat()
	{
		GetNode<Label>("%TitleLabel").Text = "Defeat";
		GetNode<Label>("%DescriptionLabel").Text = "You lost!";
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
