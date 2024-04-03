using Godot;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{
	[Export]
	public Godot.Collections.Array<AbilityUpgrade> UpgradePool { get; set; }

	[Export]
	public ExperienceManager ExperienceManager { get; set; }

	[Export]
	public PackedScene UpgradeScreenScene { get; set; }

	// This dictionary will store the current upgrades the player has
	// The key is the upgrade id, and the value is a dictionary that stores the upgrade and the amount of times it has been picked
	private Dictionary<string, Dictionary<AbilityUpgrade, int>> _currentUpgrades = new Dictionary<string, Dictionary<AbilityUpgrade, int>>();
	
	public override void _Ready()
	{
		ExperienceManager.LevelUp += OnLevelUp;
	}

	
	public void OnLevelUp(int currentLevel)
	{
		AbilityUpgrade chosen_upgrade = UpgradePool.PickRandom();
		if (chosen_upgrade is null) return;

		var upgradeScreenScene = UpgradeScreenScene.Instantiate() as UpgradeScreen;
		AddChild(upgradeScreenScene);
		upgradeScreenScene.SetAbilityUpgrade(chosen_upgrade);
	}

	private void ApplyUpdate(AbilityUpgrade upgrade)
	{
		if(!_currentUpgrades.ContainsKey(upgrade.Id))
		{
			_currentUpgrades.Add(upgrade.Id, new Dictionary<AbilityUpgrade, int> {
				{upgrade, 1}
			});
		}
		else
		{
			_currentUpgrades[upgrade.Id][upgrade]++;
		}
	}
}
