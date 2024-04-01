using System;
using Godot;

public partial class ExperienceManager : Node
{
	private const float TargetExperienceGrowth = 5f;
	private float _currentExperience;
	private float _targetExperience;
	private int _currentLevel;

	[Signal]
	public delegate void ExperienceUpdatedEventHandler(float currentExperience, float targetExperience);

	public override void _Ready()
	{
		_targetExperience = TargetExperienceGrowth;
		var gameEvents = GetNode<GameEvents>("/root/GameEvents");
		gameEvents.ExperienceVialCollected += IncrementExperience;	
	}

	public void OnExperienceVialCollected(float experience)
	{
		IncrementExperience(experience);
	}

	private void IncrementExperience(float number)
	{
		_currentExperience = Math.Min(_currentExperience + number, _targetExperience);
		EmitSignal(SignalName.ExperienceUpdated, _currentExperience, _targetExperience);

		if(_currentExperience == _targetExperience)
		{			
			_currentLevel++;
			_targetExperience += TargetExperienceGrowth;
			_currentExperience = 0;
			EmitSignal(SignalName.ExperienceUpdated, _currentExperience, _targetExperience);
		}
	}

	
}
