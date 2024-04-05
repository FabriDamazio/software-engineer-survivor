using Godot;
using Godot.Collections;


public partial class GameEvents : Node
{
	[Signal]
	public delegate void ExperienceVialCollectedEventHandler(float experience);

	[Signal]
	public delegate void AbilityUpgradeAddedEventHandler(AbilityUpgrade upgrade, Dictionary<string, Dictionary<AbilityUpgrade, int>> currentUpgrades);

	public void EmitExperienceVialCollected(float experience)
	{		
		EmitSignal(SignalName.ExperienceVialCollected, experience);
	}

	public void EmitAbilityUpgradeAdded(AbilityUpgrade upgrade, Dictionary<string, Dictionary<AbilityUpgrade, int>> currentUpgrades)
	{
		EmitSignal(SignalName.AbilityUpgradeAdded, upgrade, currentUpgrades);
	}
}
