using Godot;
using System;

public partial class GameEvents : Node
{
	[Signal]
	public delegate void ExperienceVialCollectedEventHandler(float experience);

	public void EmitExperienceVialCollected(float experience)
	{		
		EmitSignal(SignalName.ExperienceVialCollected, experience);
	}
}
