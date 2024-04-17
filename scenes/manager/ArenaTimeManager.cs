using Godot;
using System;

public partial class ArenaTimeManager : Node
{
	[Export]
	public PackedScene EndScreeScene {get; set;}

	private Timer _timer;
	
	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
		_timer.Timeout += OnTimerTimeout;
	}
	public double GetTimeElapsed()
	{
		return _timer.WaitTime - _timer.TimeLeft;
	}

	private void OnTimerTimeout()
	{ 
		var endScreenInstance = EndScreeScene.Instantiate();
		AddChild(endScreenInstance);
	}
}
