using Godot;
using System;

public partial class ExperienceBar : CanvasLayer
{
	private ProgressBar _progressBar;

	[Export]
	public ExperienceManager ExperienceManager;

	public override void _Ready()
	{		
		_progressBar = GetNode<ProgressBar>("%ProgressBar");
		ExperienceManager.ExperienceUpdated += OnExperienceUpdated;
	}

	public void OnExperienceUpdated(float currentExperience, float targetExperience)
	{
		float percent = currentExperience / targetExperience;
		_progressBar.Value = percent;
	}
}
