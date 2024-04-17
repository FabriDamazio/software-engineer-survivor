using Godot;
using System;

public partial class ArenaTimeManager : Node
{
	[Export]
	public PackedScene EndScreeScene {get; set;}

	[Signal]
	public delegate void ArenaDifficultIncreasedEventHandler(int arenaDifficult);


	private const int DifficultInterval = 5;
	private int _arenaDifficult = 0;	

	private Timer _timer;
	
	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");		
		_timer.Timeout += OnTimerTimeout;
	}

    public override void _Process(double delta)
    {
        double nextTimeTarget = _timer.WaitTime - ((_arenaDifficult + 1) * DifficultInterval);
		if(_timer.TimeLeft <= nextTimeTarget)
		{
			_arenaDifficult += 1;
			EmitSignal(SignalName.ArenaDifficultIncreased, _arenaDifficult);			
		}
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
