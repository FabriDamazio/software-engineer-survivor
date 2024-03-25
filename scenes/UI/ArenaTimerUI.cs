using System;
using Godot;

public partial class ArenaTimerUI : CanvasLayer
{
	[Export]
	public ArenaTimeManager ArenaTimeManager;

	private Label _timerLabel;

    public override void _Ready()
    {
		_timerLabel = GetNode<Label>("%Label");
    }

    public override void _Process(double delta)
    {
        if(ArenaTimeManager is null) return;

		_timerLabel.Text = FormatTime(ArenaTimeManager.GetTimeElapsed());
    }

	private string FormatTime(double time)
	{
		double minutes = Math.Floor(time / 60);
		double seconds = Math.Floor(time % 60);
		return $"{minutes:00}:{seconds:00}";
	}
}
