using Godot;

public partial class ExperienceManager : Node
{
	private float _currentExperience;

	public override void _Ready()
	{
		var gameEvents = GetNode<GameEvents>("/root/GameEvents");
		gameEvents.ExperienceVialCollected += IncrementExperience;	
	}

	public void OnExperienceVialCollected(float experience)
	{
		IncrementExperience(experience);
	}

	private void IncrementExperience(float experience)
	{
		_currentExperience += experience;
		GD.Print($"Experience: {_currentExperience}");
	}

	
}
